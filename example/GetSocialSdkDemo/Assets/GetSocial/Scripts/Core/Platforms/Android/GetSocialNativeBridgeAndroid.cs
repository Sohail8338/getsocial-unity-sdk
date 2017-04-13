#if UNITY_ANDROID
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GetSocialSdk.Core
{
    class GetSocialNativeBridgeAndroid : IGetSocialNativeBridge
    {
        const string GetSocialClassSignature = "im.getsocial.sdk.GetSocial";
        const string GetSocialUserClassSignature = GetSocialClassSignature + "$User";
        const string AndroidAccessHelperClass = "im.getsocial.sdk.GetSocialAccessHelper";
        const string HadesConfigurationTypeClass = "im.getsocial.sdk.core.component.componentprovider.HadesConfigurationProvider$Type";

        static IGetSocialNativeBridge _instance;

        readonly AndroidJavaClass _getSocial;
        readonly AndroidJavaClass _user;

        GetSocialNativeBridgeAndroid()
        {
            MainThreadExecutor.Init();
            _getSocial = new AndroidJavaClass(GetSocialClassSignature);
            _user = new AndroidJavaClass(GetSocialUserClassSignature);
        }

        public static IGetSocialNativeBridge Instance
        {
            get { return _instance ?? (_instance = new GetSocialNativeBridgeAndroid()); }
        }

        #region initialization

        public bool IsInitialized
        {
            get { return _getSocial.CallStaticBool("isInitialized"); }
        }

        public void Init(Action onSuccess, Action<GetSocialError> onFailure)
        {
            _getSocial.CallStatic("init", JniUtils.Activity,
                new CompletionCallback(onSuccess, onFailure));
        }

        public string GetNativeSdkVersion()
        {
            return _getSocial.CallStaticStr("getSdkVersion");
        }

        public string GetLanguage()
        {
            return _getSocial.CallStaticStr("getLanguage");
        }

        public bool SetLanguage(string languageCode)
        {
            return _getSocial.CallStaticBool("setLanguage", languageCode);
        }

        #endregion

        #region smart_invites

        public InviteChannel[] InviteChannels
        {
            get
            {
                var channelsJavaList = _getSocial.CallStaticAJO("getInviteChannels");
                var channelsAJOs = channelsJavaList.FromJavaList<AndroidJavaObject>();
                var channels = channelsAJOs.ConvertAll(ajo => new InviteChannel().ParseFromAJO(ajo));
                channelsAJOs.ForEach(ajo => ajo.Dispose());

                return channels.ToArray();
            }
        }

        public void SendInvite(string channelId, Action onComplete, Action onCancel, Action<GetSocialError> onFailure)
        {
            _getSocial.CallStatic("sendInvite", channelId, new InviteCallbackProxy(onComplete, onCancel, onFailure));
        }

        public void SendInvite(string channelId, InviteContent customInviteContent, Action onComplete, Action onCancel,
            Action<GetSocialError> onFailure)
        {
            _getSocial.CallStatic("sendInvite", channelId, customInviteContent.ToAJO(),
                new InviteCallbackProxy(onComplete, onCancel, onFailure));
        }

        public void SendInvite(string channelId, InviteContent customInviteContent,
            CustomReferralData customReferralData,
            Action onComplete, Action onCancel, Action<GetSocialError> onFailure)
        {
            _getSocial.CallStatic("sendInvite", channelId, customInviteContent.ToAJO(), customReferralData.ToAJO(),
                new InviteCallbackProxy(onComplete, onCancel, onFailure));
        }

        public bool RegisterInviteChannelPlugin(string channelId, InviteChannelPlugin inviteChannelPlugin)
        {
            var proxy = new InviteChannelPluginProxy(inviteChannelPlugin);
            return _getSocial.CallStaticBool("registerInviteChannelPlugin", channelId,
                new AndroidJavaObject("im.getsocial.sdk.unity.InviteChannelPluginAdapter", JniUtils.Activity, proxy));
        }

        public void GetReferralData(Action<ReferralData> onSuccess, Action<GetSocialError> onFailure)
        {
            _getSocial.CallStatic("getReferralData",
                new FetchReferralDataCallbackProxy(onSuccess, onFailure));
        }

        public void RegisterForPushNotifications()
        {
            _getSocial.CallStatic("registerForPushNotifications");
        }

        public void SetNotificationActionListener(Func<NotificationAction, bool> listener)
        {
            _getSocial.CallStatic("setNotificationActionListener", new NotificationActionListenerProxy(listener));
        }

        #endregion

        public bool SetGlobalErrorListener(Action<GetSocialError> onError)
        {
            return _getSocial.CallStaticBool("setGlobalErrorListener", new GlobalErrorListenerProxy(onError));
        }

        public bool RemoveGlobalErrorListener()
        {
            return _getSocial.CallStaticBool("removeGlobalErrorListener");
        }

        #region user_management

        public string UserId
        {
            get { return _user.CallStaticStr("getId"); }
        }

        public bool IsUserAnonymous
        {
            get { return _user.CallStaticBool("isAnonymous"); }
        }

        public Dictionary<string, string> UserAuthIdentities
        {
            get { return _user.CallStaticAJO("getAuthIdentities").FromJavaHashMap(); }
        }

        public string DisplayName
        {
            get { return _user.CallStaticStr("getDisplayName"); }
        }

        public void SetDisplayName(string displayName, Action onComplete, Action<GetSocialError> onFailure)
        {
            _user.CallStatic("setDisplayName", displayName, new CompletionCallback(onComplete, onFailure));
        }

        public string AvatarUrl
        {
            get { return _user.CallStaticStr("getAvatarUrl"); }
        }

        public void SetAvatarUrl(string avatarUrl, Action onComplete, Action<GetSocialError> onFailure)
        {
            _user.CallStatic("setAvatarUrl", avatarUrl, new CompletionCallback(onComplete, onFailure));
        }

        public void AddAuthIdentity(AuthIdentity identity,
            Action onComplete,
            Action<GetSocialError> onFailure,
            Action<ConflictUser> onConflict)
        {
            _user.CallStatic("addAuthIdentity", identity.ToAJO(),
                new AddAuthIdentityCallbackProxy(onComplete, onFailure, onConflict));
        }

        public void SwitchUser(AuthIdentity identity, Action onSuccess,
            Action<GetSocialError> onFailure)
        {
            _user.CallStatic("switchUser", identity.ToAJO(), new CompletionCallback(onSuccess, onFailure));
        }

        public void RemoveAuthIdentity(string providerId, Action onSuccess, Action<GetSocialError> onFailure)
        {
            _user.CallStatic("removeAuthIdentity", providerId, new CompletionCallback(onSuccess, onFailure));
        }

        public bool SetOnUserChangedListener(Action onUserChanged)
        {
            return _user.CallStaticBool("setOnUserChangedListener", new OnUserChangedListenerProxy(onUserChanged));
        }

        public bool RemoveOnUserChangedListener()
        {
            return _user.CallStaticBool("removeOnUserChangedListener");
        }

        #endregion

        #region social_graph

        public void AddFriend (string userId, Action<int> onSuccess, Action<GetSocialError> onFailure)
        {
            _user.CallStatic ("addFriend", userId, new IntCallbackProxy (onSuccess, onFailure));
        }

        public void RemoveFriend (string userId, Action<int> onSuccess, Action<GetSocialError> onFailure)
        {
            _user.CallStatic ("removeFriend", userId, new IntCallbackProxy (onSuccess, onFailure));
        }

        public void IsFriend (string userId, Action<bool> onSuccess, Action<GetSocialError> onFailure)
        {
            _user.CallStatic ("isFriend", userId, new BoolCallbackProxy (onSuccess, onFailure));
        }

        public void GetFriendsCount(Action<int> onSuccess, Action<GetSocialError> onFailure)
        {
            _user.CallStatic("getFriendsCount", new IntCallbackProxy(onSuccess, onFailure));
        }

        public void GetFriends (int offset, int limit, Action<List<PublicUser>> onSuccess, Action<GetSocialError> onFailure)
        {
            _user.CallStatic ("getFriends", offset, limit, new CallbackProxy<List<PublicUser>> (onSuccess, onFailure, PublicUserListFromAJO));
        }

        #endregion

        #region activity_feed

        public void GetAnnouncements(string feed, Action<List<ActivityPost>> onSuccess,
            Action<GetSocialError> onFailure)
        {
            _getSocial.CallStatic("getAnnouncements", feed, new CallbackProxy<List<ActivityPost>>(onSuccess, onFailure, ActivityPostListFromAJO));
        }

        public void GetActivities(ActivitiesQuery query, Action<List<ActivityPost>> onSuccess,
            Action<GetSocialError> onFailure)
        {
            _getSocial.CallStatic("getActivities", query.ToAJO(), new CallbackProxy<List<ActivityPost>>(onSuccess, onFailure, ActivityPostListFromAJO));
        }

        public void GetActivity(string activityId, Action<ActivityPost> onSuccess, Action<GetSocialError> onFailure)
        {
            _getSocial.CallStatic("getActivity", activityId, new CallbackProxy<ActivityPost>(onSuccess, onFailure, new ActivityPost().ParseFromAJO));
        }

        public void PostActivityToFeed(string feed, ActivityPostContent content, Action<ActivityPost> onSuccess, Action<GetSocialError> onFailure)
        {
            _getSocial.CallStatic("postActivityToFeed", feed, content.ToAJO(), new CallbackProxy<ActivityPost>(onSuccess, onFailure, new ActivityPost().ParseFromAJO));
        }

        public void PostCommentToActivity(string activityId, ActivityPostContent comment, Action<ActivityPost> onSuccess,
            Action<GetSocialError> onFailure)
        {
            _getSocial.CallStatic("postCommentToActivity", activityId, comment.ToAJO(), new CallbackProxy<ActivityPost>(onSuccess, onFailure, new ActivityPost().ParseFromAJO));
        }

        public void LikeActivity(string activityId, bool isLiked, Action<ActivityPost> onSuccess,
            Action<GetSocialError> onFailure)
        {
            _getSocial.CallStatic("likeActivity", activityId, isLiked, new CallbackProxy<ActivityPost>(onSuccess, onFailure, new ActivityPost().ParseFromAJO));
        }

        public void GetActivityLikers(string activityId, int offset, int limit, Action<List<PublicUser>> onSuccess,
            Action<GetSocialError> onFailure)
        {
            _getSocial.CallStatic("getActivityLikers", activityId, offset, limit, new CallbackProxy<List<PublicUser>>(onSuccess, onFailure, PublicUserListFromAJO));
        }

        static List<ActivityPost> ActivityPostListFromAJO(AndroidJavaObject ajo)
        {
            var list = ajo.FromJavaList<AndroidJavaObject>();

            return list.ConvertAll(item => new ActivityPost().ParseFromAJO(item));
        }

        static List<PublicUser> PublicUserListFromAJO(AndroidJavaObject ajo)
        {
            var list = ajo.FromJavaList<AndroidJavaObject>();

            return list.ConvertAll(item => new PublicUser().ParseFromAJO(item));
        }

        #endregion

        #region access_helpers

        public void Reset()
        {
            try
            {
                using (var ajc = new AndroidJavaClass(AndroidAccessHelperClass))
                {
                    ajc.CallStatic("reset");
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Resetting user failed");
                Debug.LogException(e);
            }
        }

        public void SetHadesConfiguration(int hadesConfigurationType)
        {
            using (var accessHelperJavaClass = new AndroidJavaClass(AndroidAccessHelperClass))
            using (var hadesConfigurationTypeJavaClass = new AndroidJavaClass(HadesConfigurationTypeClass))
            {
                var hadesConfigurationTypeAjo = hadesConfigurationTypeJavaClass.CallStaticAJO("findByValue", hadesConfigurationType);
                accessHelperJavaClass.CallStatic("setHadesConfiguration", JniUtils.Activity, hadesConfigurationTypeAjo);
            }
        }

        public int GetCurrentHadesConfiguration()
        {
            using (var accessHelperJavaClass = new AndroidJavaClass(AndroidAccessHelperClass))
            {
                var currentHadesConfigurationAjo = accessHelperJavaClass.CallStaticAJO("getCurrentHadesConfiguration", JniUtils.Activity);
                return currentHadesConfigurationAjo.CallInt("getValue");
            }
        }

        #endregion
    }
}

#endif