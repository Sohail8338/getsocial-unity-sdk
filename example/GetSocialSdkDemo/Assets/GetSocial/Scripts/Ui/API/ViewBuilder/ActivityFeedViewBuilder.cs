﻿#if USE_GETSOCIAL_UI
using System;
using System.Runtime.InteropServices;
using GetSocialSdk.Core;
using UnityEngine;

namespace GetSocialSdk.Ui
{
    /// <summary>
    /// Use this class to construct activity feed view.
    /// Call <see cref="Show()"/> to present the UI.
    /// </summary>
    public sealed class ActivityFeedViewBuilder : ViewBuilder<ActivityFeedViewBuilder>
    {
        readonly string _feed;

        Action<string, ActivityPost> _onButtonClicked;

        internal ActivityFeedViewBuilder()
        {
            _feed = ActivitiesQuery.GlobalFeed;
        }

        internal ActivityFeedViewBuilder(string feed)
        {
            _feed = feed;
        }

        /// <summary>
        /// Register callback to listen when activity action button was clicked.
        /// </summary>
        /// <param name="onButtonClicked">Called when activity action button was clicked.</param>
        /// <returns><see cref="ActivityFeedViewBuilder" instance./></returns>
        public ActivityFeedViewBuilder WithButtonActionListener(Action<string, ActivityPost> onButtonClicked)
        {
            _onButtonClicked = onButtonClicked;

            return this;
        }

        public override bool Show()
        {
#if UNITY_ANDROID
            return ShowBuilder(ToAJO());
#elif UNITY_IOS
            return _showActivityFeedView(_feed, ActivityFeedActionButtonCallback.OnActionButtonClick, _onButtonClicked.GetPointer());
#else
            return false;
#endif
        }

#if UNITY_ANDROID

        AndroidJavaObject ToAJO()
        {
            var activityFeedBuilderAJO =
                new AndroidJavaObject("im.getsocial.sdk.ui.activities.ActivityFeedViewBuilder", _feed);

            SetTitleAJO(activityFeedBuilderAJO);

            if (_onButtonClicked != null)
            {
                activityFeedBuilderAJO.CallAJO("withButtonActionListener",
                    new ActionButtonListenerProxy(_onButtonClicked));
            }

            return activityFeedBuilderAJO;
        }

#elif UNITY_IOS

        [DllImport("__Internal")]
        static extern bool _showActivityFeedView(
            string feed,
            ActivityActionButtonClickedDelegate callback, IntPtr onButtonClickPtr);

#endif
    }
}

#endif