﻿#if UNITY_IOS 
using System;
using GetSocialSdk.Core;

namespace GetSocialSdk.Ui
{
    delegate void MentionClickListenerDelegate(IntPtr mentionClickListenerPtr, string userId);
    
    public class MentionClickListenerCallback
    {
        [AOT.MonoPInvokeCallback(typeof(MentionClickListenerDelegate))]
        public static void OnMentionClicked(IntPtr mentionClickListenerPtr, string mention)
        {
            GetSocialDebugLogger.D(string.Format("OnMentionClicked for user {0}", mention));

            if (mentionClickListenerPtr != IntPtr.Zero)
            {
                mentionClickListenerPtr.Cast<Action<string>>().Invoke(mention);
            }
        }
    }
}

#endif