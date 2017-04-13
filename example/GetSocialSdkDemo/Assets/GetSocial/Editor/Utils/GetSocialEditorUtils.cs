﻿/**
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

using System.IO;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

namespace GetSocialSdk.Editor
{
    [InitializeOnLoad]
    public static class GetSocialEditorUtils
    {
        public static Texture2D AndroidIcon;
        public static Texture2D IOSIcon;
        public static Texture2D SettingsIcon;
        public static Texture2D InfoIcon;
        public static Texture2D GetSocialIcon;

        static string _editorPath;
        static string _editorGuiPath;

        static GetSocialEditorUtils()
        {
            Initialize();
            AndroidIcon = (Texture2D)AssetDatabase.LoadAssetAtPath(_editorGuiPath + "/android.png", typeof(Texture2D));
            IOSIcon = (Texture2D)AssetDatabase.LoadAssetAtPath(_editorGuiPath + "/ios.png", typeof(Texture2D));
            SettingsIcon = (Texture2D)AssetDatabase.LoadAssetAtPath(_editorGuiPath + "/settings.png", typeof(Texture2D));
            InfoIcon = (Texture2D)AssetDatabase.LoadAssetAtPath(_editorGuiPath + "/icon_info.png", typeof(Texture2D));
            GetSocialIcon = (Texture2D)AssetDatabase.LoadAssetAtPath(_editorGuiPath + "/getsocial.png", typeof(Texture2D));
        }

        static void Initialize()
        {
            var rootDir = new DirectoryInfo(Application.dataPath);
            var files = rootDir.GetFiles("GetSocialSettingsEditor.cs", SearchOption.AllDirectories);
            _editorPath = Path.GetDirectoryName(files[0].FullName.Replace("\\", "/").Replace(Application.dataPath, "Assets"));
            _editorGuiPath = Path.Combine(_editorPath, "GUI");
        }

        public static void BeginSetSmallIconSize()
        {
            EditorGUIUtility.SetIconSize(new Vector2(14, 14));
        }

        public static void EndSetSmallIconSize()
        {
            EditorGUIUtility.SetIconSize(Vector2.zero);
        }

        public static string[] GetFiles(string path, string searchPattern, SearchOption searchOption)
        {
            var searchPatterns = searchPattern.Split(';');
            var files = new List<string>();
            foreach (string sp in searchPatterns)
            {
                files.AddRange(Directory.GetFiles(path, sp, searchOption));
            }
            files.Sort();
            return files.ToArray();
        }
    }
}
