#if UNITY_ANDROID
using System;
using UnityEngine;

namespace GetSocialSdk.Core
{
    public static class JniExtensionMethods
    {
        // STATIC

        public static string CallStaticStr(this AndroidJavaObject ajo, string methodName, params object[] args)
        {
            return CallStaticSafe<string>(ajo, methodName, args);
        }

        public static bool CallStaticBool(this AndroidJavaObject ajo, string methodName, params object[] args)
        {
            return CallStaticSafe<bool>(ajo, methodName, args);
        }

        public static int CallStaticInt(this AndroidJavaObject ajo, string methodName, params object[] args)
        {
            return CallStaticSafe<int>(ajo, methodName, args);
        }

        public static long CallStaticLong(this AndroidJavaObject ajo, string methodName,
            params object[] args)
        {
            return CallStaticSafe<long>(ajo, methodName, args);
        }

        public static float CallStaticFloat(this AndroidJavaObject ajo, string methodName, params object[] args)
        {
            return CallStaticSafe<float>(ajo, methodName, args);
        }

        public static AndroidJavaObject CallStaticAJO(this AndroidJavaObject ajo, string methodName,
            params object[] args)
        {
            return CallStaticSafe<AndroidJavaObject>(ajo, methodName, args);
        }

        public static void CallStaticSafe(this AndroidJavaObject ajo, string methodName,
            params object[] args)
        {
            try
            {
                ajo.CallStatic(methodName, args);
            }
            catch (Exception e)
            {
                GetSocialDebugLogger.Ex(e, string.Format("Failed to call {0} on {1}", methodName, ajo.GetClassName()));
            }
        }

        // NON-STATIC

        public static bool CallBool(this AndroidJavaObject ajo, string methodName, params object[] args)
        {
            return CallSafe<bool>(ajo, methodName, args);
        }

        public static int CallInt(this AndroidJavaObject ajo, string methodName, params object[] args)
        {
            return CallSafe<int>(ajo, methodName, args);
        }

        public static long CallLong(this AndroidJavaObject ajo, string methodName, params object[] args)
        {
            return CallSafe<long>(ajo, methodName, args);
        }

        public static float CallFloat(this AndroidJavaObject ajo, string methodName, params object[] args)
        {
            return CallSafe<float>(ajo, methodName, args);
        }

        public static string CallStr(this AndroidJavaObject ajo, string methodName,
            params object[] args)
        {
            return CallSafe<string>(ajo, methodName, args);
        }

        public static AndroidJavaObject CallAJO(this AndroidJavaObject ajo, string methodName,
            params object[] args)
        {
            return CallSafe<AndroidJavaObject>(ajo, methodName, args);
        }

        public static void CallSafe(this AndroidJavaObject ajo, string methodName,
            params object[] args)
        {
            try
            {
                ajo.Call(methodName, args);
            }
            catch (Exception exception)
            {
                GetSocialDebugLogger.Ex(exception, string.Format("Failed to call {0} because of: {1}", methodName, exception.Message));
            }
        }

        static T CallStaticSafe<T>(this AndroidJavaObject ajo, string methodName,
            params object[] args)
        {
            try
            {
                return ajo.CallStatic<T>(methodName, args);
            }
            catch (Exception exception)
            {
                HandleAndroidJavaObjectCallException<T>(ajo, methodName, exception);
                return default(T);
            }
        }

        static T CallSafe<T>(this AndroidJavaObject ajo, string methodName,
            params object[] args)
        {
            try
            {
                return ajo.Call<T>(methodName, args);
            }
            catch (Exception exception)
            {
                HandleAndroidJavaObjectCallException<T>(ajo, methodName, exception);
                return default(T);
            }
        }

        private static void HandleAndroidJavaObjectCallException<T>(AndroidJavaObject ajo, string methodName,
            Exception exception)
        {
            // If we call method that return null from Java an exception will be thrown. So we have to ignore most part of them.
            // Related Unity issue: https://issuetracker.unity3d.com/issues/androidjavaobject-dot-call-throws-exception-instead-of-returning-null-pointer
            var isExceptionCausedByNullObjectReturnedFromJava =
                typeof(T) == typeof(AndroidJavaObject)
                && exception.Message.Contains("AndroidJavaObject with null ptr");

            if (!isExceptionCausedByNullObjectReturnedFromJava)
            {
                GetSocialDebugLogger.Ex(exception,
                    string.Format("Failed to call {0} on {1}", methodName, ajo.GetClassName()));
            }
        }
    }
}

#endif