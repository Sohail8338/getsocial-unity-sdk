using System;
using UnityEngine;

namespace GetSocialSdk.Ui
{

    public delegate void UiActionListener(UiAction action, Action pendingAction);
    /// <summary>
    /// Class to present GetSocial user interface.
    /// </summary>
    public static class GetSocialUi
    {
        static IGetSocialUiNativeBridge _getSocialUiImpl;

        internal static IGetSocialUiNativeBridge GetSocialImpl
        {
            get { return _getSocialUiImpl ?? (_getSocialUiImpl = GetSocialUiFactory.InstantiateGetSocialUi()); }
        }

        /// <summary>
        /// Show GetSocial view
        /// </summary>
        /// <param name="viewBuilder">View to open</param>
        /// <c>true</c>, if view was opened, <c>false</c> otherwise.
        public static bool ShowView<T>(ViewBuilder<T> viewBuilder) where T : ViewBuilder<T>
        {
            return GetSocialImpl.ShowView(viewBuilder);
        }

        /// <summary>
        /// Loads the default GetSocial Ui configuration.
        /// </summary>
        /// <returns><c>true</c>, if default configuration was loaded, <c>false</c> otherwise.</returns>
        public static bool LoadDefaultConfiguration()
        {
            return GetSocialImpl.LoadDefaultConfiguration();
        }

        /// <summary>
        /// Sets the UI configuration file to use.
        /// </summary>
        /// <param name="path">Relative path to the configuration file in <code>/StreamingAssets/</code>folder.</param>
        /// <returns><c>true</c> if configuration was successfully loaded, <c>false</c> otherwise</returns>
        public static bool LoadConfiguration(string path)
        {
            return GetSocialImpl.LoadConfiguration(path);
        }

        /// <summary>
        /// Closes GetSocial view without save state.
        /// </summary>
        /// <returns><c>true</c> if view was closed, <c>false</c> otherwise</returns>
        public static bool CloseView()
        {
            return CloseView(false);
        }

        /// <summary>
        /// Closes GetSocial view.
        /// </summary>
        /// <param name="saveViewState">returns <c>true</c> if the state of GetSocial view needs to be restored later by calling restoreView.</param>
        /// <returns><c>true</c> if view was closed, <c>false</c> otherwise</returns>
        public static bool CloseView(bool saveViewState)
        {
            return GetSocialImpl.CloseView(saveViewState);
        }

        /// <summary>
        /// Restores GetSocial view that was hidden by <see cref="CloseView"/> method.
        /// </summary>
        /// <returns><c>true</c> if view was restored, <c>false</c> otherwise</returns>
        public static bool RestoreView()
        {
            return GetSocialImpl.RestoreView();
        }

#if UNITY_ANDROID
        /// <summary>
        /// Pass back button presses through this method.
        /// </summary>
        /// <returns><c>true</c> if the GetSocial Ui is handling the back press.</returns>
        public static bool OnBackPressed()
        {
            return GetSocialImpl.OnBackPressed();
        }
#endif
    }
}
