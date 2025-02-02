/**
 *     Copyright 2015-2016 GetSocial B.V.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using UnityEngine;
using System.IO;
using UnityEditor.iOS.Xcode.GetSocial;
using GetSocialSdk.Core;
using System.Linq;
using UnityEditor;

namespace GetSocialSdk.Editor
{
    public static class GetSocialPostprocessIOS
    {
        private const int MinimumIosVersionRequirnment = 8;

        public static void UpdateXcodeProject(string projectPath)
        {
            CheckIosVersion();
            
#if !UNITY_CLOUD_BUILD
            Debug.Log(string.Format("GetSocial: Xcode postprocessing started for project '{0}'", projectPath));
#endif
            PBXProjectUtils.ModifyPbxProject(projectPath, (project, target) =>
            {
                AddOtherLinkerFlags(project, target);
                SetupDeepLinking(project, projectPath, target);
#if !UNITY_2018_3_OR_NEWER 
                EmbedFrameworks(project, target);
#endif
                AddStripFrameworksScriptBuildPhase(project, projectPath, target);
                if (GetSocialSettings.IsRichPushNotificationsEnabled && GetSocialSettings.IsIosPushEnabled)
                {
                    AddNotificationExtension(project, projectPath);
                }
                project.CheckRuntimeSearchPath();
            });

            PBXProjectUtils.ModifyPlist(projectPath, (plistDocument) =>
            {
                WhitelistApps(plistDocument);
                SetUiBackgroundModes(plistDocument);
                DisableViewControllerBasedStatusBar(plistDocument);
            });
        }

        static void AddNotificationExtension(PBXProject project, string projectPath)
        {
#if UNITY_2018_1_OR_NEWER            
            const string extensionName = "/GetSocialNotificationExtension";
            if (!Directory.Exists(projectPath + extensionName))
            {
                Directory.CreateDirectory(projectPath + extensionName);
            }

            var pluginDir = GetSocialSettings.GetPluginPath();
            PlistDocument notificationServicePlist = new PlistDocument();
            notificationServicePlist.ReadFromFile (pluginDir + "/Editor/iOS/Helpers/NotificationService/Info.plist");
            notificationServicePlist.root.SetString ("CFBundleShortVersionString", PlayerSettings.bundleVersion);
            notificationServicePlist.root.SetString ("CFBundleVersion", PlayerSettings.iOS.buildNumber);
            notificationServicePlist.WriteToFile(projectPath + "/GetSocialNotificationExtension/Info.plist");
            
            var extensionServiceSourceHeaderFile = pluginDir + "/Editor/iOS/Helpers/NotificationService/GetSocialNotificationService.h";
            var extensionServiceSourceImpFile = pluginDir + "/Editor/iOS/Helpers/NotificationService/GetSocialNotificationService.m";
            var extensionServiceTargetHeaderFile = "GetSocialNotificationExtension/GetSocialNotificationService.h";
            var extensionServiceTargetImpFile = "GetSocialNotificationExtension/GetSocialNotificationService.m";
            
            File.Copy(extensionServiceSourceHeaderFile, projectPath + "/" + extensionServiceTargetHeaderFile, true);
            File.Copy(extensionServiceSourceImpFile, projectPath + "/" + extensionServiceTargetImpFile, true);

            var mainTarget = project.TargetGuidByName(PBXProject.GetUnityTargetName());

            var appExtensionTarget = project.AddAppExtension(mainTarget, "GetSocialNotificationExtension", projectPath + "/GetSocialNotificationExtension/Info.plist");
                        
            project.AddFileToBuild(appExtensionTarget, project.AddFile(extensionServiceTargetHeaderFile, extensionServiceTargetHeaderFile));
            project.AddFileToBuild(appExtensionTarget, project.AddFile(extensionServiceTargetImpFile, extensionServiceTargetImpFile));

            var frameworksPath =
                GetSocialSettings.GetPluginPath().Substring(GetSocialSettings.GetPluginPath().IndexOf("/") + 1);  
            
            var relativeExtensionFrameworkPath = "Frameworks/" + frameworksPath + "/Plugins/iOS/GetSocialNotificationExtension.framework";

            project.AddFileToBuild(appExtensionTarget, project.FindFileGuidByProjectPath(relativeExtensionFrameworkPath));
            
            var deviceFamily = "";
            switch (PlayerSettings.iOS.targetDevice)
            {
                case iOSTargetDevice.iPhoneOnly:
                    deviceFamily = "1";
                    break;
                case iOSTargetDevice.iPadOnly:
                    deviceFamily = "2";
                    break;
                case iOSTargetDevice.iPhoneAndiPad:
                    deviceFamily = "1,2";
                    break;
            }
            

            project.SetBuildProperty(appExtensionTarget, "TARGETED_DEVICE_FAMILY", deviceFamily);
            if (double.Parse(PlayerSettings.iOS.targetOSVersionString) > 10) 
            {
                project.SetBuildProperty(appExtensionTarget, "IPHONEOS_DEPLOYMENT_TARGET", PlayerSettings.iOS.targetOSVersionString.ToString());
            } else
            {
                project.SetBuildProperty(appExtensionTarget, "IPHONEOS_DEPLOYMENT_TARGET", "10.0");
            }
            
            project.SetBuildProperty(appExtensionTarget, "DEVELOPMENT_TEAM", PlayerSettings.iOS.appleDeveloperTeamID);
            project.SetBuildProperty(appExtensionTarget, "PRODUCT_BUNDLE_IDENTIFIER", GetSocialSettings.ExtensionBundleId);
            project.SetBuildProperty(appExtensionTarget, "CODE_SIGN_STYLE", PlayerSettings.iOS.appleEnableAutomaticSigning ?  "Automatic" : "Manual");
            if (!PlayerSettings.iOS.appleEnableAutomaticSigning)
            {
                if (GetSocialSettings.ExtensionProvisioningProfile.Length == 0)
                {
                    Debug.LogError("Notification Extension Provisioning Profile must be specified.");
                }
                else
                {
                    project.SetBuildProperty(appExtensionTarget, "PROVISIONING_PROFILE", GetSocialSettings.ExtensionProvisioningProfile);
                    project.SetBuildProperty(appExtensionTarget, "PROVISIONING_PROFILE_SPECIFIER", GetSocialSettings.ExtensionProvisioningProfile);
                }
            }
            project.AddFrameworkToProject(mainTarget, "UserNotifications.framework", false);
            AddExtensionEntitlements(projectPath, project, appExtensionTarget);
#endif            
        }
        static void AddExtensionEntitlements(string projectPath, PBXProject project, string target)
        {
            var entitlementsSetting = "extension.entitlements";
            project.AddFileToBuild(target,
                    project.AddFile("extension.entitlements", entitlementsSetting, PBXSourceTree.Source));
            project.AddBuildProperty(target, "CODE_SIGN_ENTITLEMENTS", entitlementsSetting);
            
            var entitlementsFilePath = Path.Combine(projectPath, entitlementsSetting); 
            var entitlements = new PlistDocument();
            if (File.Exists(entitlementsFilePath))
            {
                entitlements.ReadFromFile(entitlementsFilePath);
            }
            ConfigureAppGroups(entitlements);
            entitlements.WriteToFile(entitlementsFilePath);
        }

        static void AddOtherLinkerFlags(PBXProject project, string target)
        {
            project.UpdateBuildProperty(target, "OTHER_LDFLAGS", new[]
            {
                "-ObjC",
                "-licucore"
            }, new string[] { });
            project.SetBuildProperty(target, "ALWAYS_EMBED_SWIFT_STANDARD_LIBRARIES", "YES");
        }

        static void AddStripFrameworksScriptBuildPhase(PBXProject project, string projectPath, string target)
        {
            // remove previous script versions
            project.RemoveShellScript(target, "GetSocial.framework/strip_frameworks.sh");
        }

        static void EmbedFrameworks(PBXProject project, string target)
        {
            const string coreFrameworkName = "GetSocialSDK.framework";
            const string uiFrameworkName = "GetSocialUI.framework";
            const string extensionFrameworkName = "GetSocialNotificationExtension.framework";

            var frameworksPath =
                GetSocialSettings.GetPluginPath().Substring(GetSocialSettings.GetPluginPath().IndexOf("/") + 1);  
            
            var defaultLocationInProj = "Frameworks/" + frameworksPath + "/Plugins/iOS/";
            var relativeCoreFrameworkPath = defaultLocationInProj + coreFrameworkName;
            var relativeExtensionFrameworkPath = defaultLocationInProj + extensionFrameworkName;
            var relativeUiFrameworkPath = defaultLocationInProj + uiFrameworkName;
            
            project.AddDynamicFrameworkToProject(target, relativeCoreFrameworkPath);
            project.AddDynamicFrameworkToProject(target, relativeExtensionFrameworkPath);
            project.AddDynamicFrameworkToProject(target, relativeUiFrameworkPath);
            
#if !UNITY_CLOUD_BUILD
            Debug.Log("GetSocial: GetSocial Dynamic Frameworks added to Embedded binaries.");
#endif            
        }

        #region deep_linking

        static void SetupDeepLinking(PBXProject project, string projectPath, string target)
        {
#if !UNITY_CLOUD_BUILD
            Debug.Log(
                "[GetSocial] Setting up deep linking...\n\tFor universal links setup please refer to https://docs.getsocial.im/guides/smart-links/receive-smart-links/unity/");
#endif
            // URL Schemes (iOS <= 8)
            AddGetSocialUrlScheme(projectPath);

            // App links (iOS >=9 )
            AddAppEntitlements(projectPath, project, target);
        }

        static void AddGetSocialUrlScheme(string projectPath)
        {
#if !UNITY_CLOUD_BUILD
            Debug.Log(string.Format("[GetSocial] Setting up GetSocial deep linking for iOS <= 8 for '{0}'", projectPath));
#endif            
            PBXProjectUtils.ModifyPlist(projectPath, AddGetSocialUrlSchemeToPlist,
                "Failed to set up GetSocial deep linking for iOS <= 8.");
        }

        static void AddGetSocialUrlSchemeToPlist(PlistDocument plistInfoFile)
        {
            const string CFBundleURLTypes = "CFBundleURLTypes";
            const string CFBundleURLSchemes = "CFBundleURLSchemes";

            if (!plistInfoFile.ContainsKey(CFBundleURLTypes))
            {
                plistInfoFile.root.CreateArray(CFBundleURLTypes);
            }

            var cFBundleURLTypesElem = plistInfoFile.root.values[CFBundleURLTypes] as PlistElementArray;

            var getSocialUrlSchemesArray = new PlistElementArray();
            getSocialUrlSchemesArray.AddString(string.Format("getsocial-{0}", GetSocialSettings.AppId));

            if (cFBundleURLTypesElem != null)
            {
                var getSocialSchemeElem = cFBundleURLTypesElem.AddDict();
                getSocialSchemeElem.values[CFBundleURLSchemes] = getSocialUrlSchemesArray;
            }
        }

        static void AddAppEntitlements(string projectPath, PBXProject project, string target)
        {
            var toCreate = false;
            var existingEntitlementsFiles = project.GetBuildPropertyValues(target, "CODE_SIGN_ENTITLEMENTS");
            if (existingEntitlementsFiles.Count == 0)
            {
                project.AddFileToBuild(target,
                    project.AddFile("app.entitlements", "app.entitlements", PBXSourceTree.Source));
                project.AddBuildProperty(target, "CODE_SIGN_ENTITLEMENTS", "app.entitlements");
                existingEntitlementsFiles.Add("app.entitlements");
                toCreate = true;
            }
            foreach (var entitlementsSetting in existingEntitlementsFiles)
            {
                var entitlementsParts = entitlementsSetting.Split(' ');
                foreach (var entitlementsPart in entitlementsParts) 
                {
                    var entitlementsFilePath = Path.Combine(projectPath, entitlementsSetting); 
                    if (!File.Exists(entitlementsFilePath) && !toCreate) 
                    {
                        if (File.Exists(entitlementsSetting)) 
                        {
                            entitlementsFilePath = entitlementsSetting;
                        } else {
                            continue;
                        }
                    }
                    var entitlements = new PlistDocument();
                    if (File.Exists(entitlementsFilePath))
                    {
                        entitlements.ReadFromFile(entitlementsFilePath);
                    }

                    if (GetSocialSettings.IsRichPushNotificationsEnabled && GetSocialSettings.IsIosPushEnabled)
                    {
                        ConfigureAppGroups(entitlements);
                    }
                    ConfigureAssociatedDomains(entitlements);
                    ConfigurePushNotifications(entitlements);
                
                    entitlements.WriteToFile(entitlementsFilePath);
                }
            }
        }

        private static void ConfigureAppGroups(PlistDocument entitlements)
        {
            var appGroupsNode = entitlements.root["com.apple.security.application-groups"] != null 
                ? entitlements.root["com.apple.security.application-groups"].AsArray() 
                : entitlements.root.CreateArray("com.apple.security.application-groups");

            appGroupsNode.AddString(string.Format("group.{0}.getsocial_extension", Application.identifier));
        }

        public static void ConfigureAssociatedDomains(PlistDocument entitlements)
        {
            // Universal Links
            var associatedDomainsNode = entitlements.root["com.apple.developer.associated-domains"] != null 
                ? entitlements.root["com.apple.developer.associated-domains"].AsArray() 
                : entitlements.root.CreateArray("com.apple.developer.associated-domains");
            GetSocialSettings.DeeplinkingDomains.ForEach(domain =>
            {
                var valueToAdd = string.Format("applinks:{0}", domain);

                var addValue = associatedDomainsNode.values.All(existingValue => !existingValue.AsString().Equals(valueToAdd));
                if (addValue)
                {
                    associatedDomainsNode.AddString(valueToAdd);
                }
            });
        }


        public static void ConfigurePushNotifications(PlistDocument entitlements)
        {
            // Push Environment
            if (!GetSocialSettings.IsIosPushEnabled) return;

            // read current value
            var currentPushSettings = entitlements.ContainsKey("aps-environment")
                ? entitlements.root["aps-environment"].AsString()
                : null;
            if (currentPushSettings != null && !GetSocialSettings.IosPushEnvironment.Equals(currentPushSettings))
            {
                // show warning
                Debug.LogWarning("[GetSocial] Push notification settings are different, check the settings in the GetSocial Dashboard at http://dashboard.getsocial.im .");
            }
            if (currentPushSettings == null)
            {
                entitlements.root.SetString("aps-environment", GetSocialSettings.IosPushEnvironment);
            }
        }

        #endregion

        private static void DisableViewControllerBasedStatusBar(PlistDocument plistDocument)
        {
            plistDocument.root.SetString("UIViewControllerBasedStatusBarAppearance", "NO");
        }
        
        static void WhitelistApps(PlistDocument plistInfoFile)
        {
            const string LSApplicationQueriesSchemes = "LSApplicationQueriesSchemes";
            string[] fbApps =
            {
                "fbapi",
                "fbapi20130214",
                "fbapi20130410",
                "fbapi20130702",
                "fbapi20131010",
                "fbapi20131219",
                "fbapi20140410",
                "fbapi20140116",
                "fbapi20150313",
                "fbapi20150629",
                "fbauth",
                "fbauth2",
                "fb-messenger-api20140430",
                "fb-messenger-api",
                "fb-messenger-share-api",
                "fbshareextension"
            };

            string[] otherApps =
            {
                "kik-share",
                "kakaolink",
                "line",
                "whatsapp",
                "viber",
                "tg",
                "instagram-stories",
                "facebook-stories"
            };

            PlistElementArray existingSchemes = plistInfoFile.root[LSApplicationQueriesSchemes] as PlistElementArray;
            if (existingSchemes == null)
            {
                existingSchemes = plistInfoFile.root.CreateArray(LSApplicationQueriesSchemes);
            }
            MergePlistArrays(existingSchemes, fbApps);
            MergePlistArrays(existingSchemes, otherApps);
        }

        private static void MergePlistArrays(PlistElementArray originalArray, string[] newArray)
        {
            newArray.ToList().ForEach((entry) => {
                var contains = false;
                originalArray.values.ForEach((plistElement) => {
                    if (plistElement.AsString().Equals(entry))
                    {
                        contains = true;
                    }
                });
                if (!contains)
                {
                    originalArray.AddString(entry);
                }
            });

        }

        private static void SetUiBackgroundModes(PlistDocument plistDocument)
        {
            var backgroundModesArray = plistDocument.root.CreateArray("UIBackgroundModes");
            backgroundModesArray.AddString("remote-notification");
        }

        private static void CheckIosVersion()
        {
            var targetIosVersion = PlayerSettings.iOS.targetOSVersionString;

            try
            {
                var iosMajorVersionString = targetIosVersion.Split('.')[0];
                if (int.Parse(iosMajorVersionString) < MinimumIosVersionRequirnment)
                {
                    Debug.LogWarning(string.Format(
                        "GetSocial: Target iOS version {0} is not supported. GetSocial SDK requires iOS {1}+",
                        targetIosVersion, MinimumIosVersionRequirnment));
                }
            }
            catch (Exception)
            {
                Debug.LogWarning(string.Format(
                    "GetSocial: failed to parse target iOS version.. GetSocial SDK requires iOS {0}+", MinimumIosVersionRequirnment));
            }
        }
    }
}