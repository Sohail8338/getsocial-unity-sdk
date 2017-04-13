using System.Reflection;
using System.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace GetSocialSdk.Core
{
    [DebuggerStepThrough]
    public static class DebugUtils
    {
        public static void LogMethodCall(MethodBase method, params object[] values)
        {
            ParameterInfo[] parameters = method.GetParameters();

            StringBuilder message = new StringBuilder().AppendFormat("Method call: {0}(", method.Name);
            for(int i = 0; i < parameters.Length; i++)
            {
                message.AppendFormat("{0}: {1}", parameters[i].Name, values[i] ?? "null");
                if(i < parameters.Length - 1)
                {
                    message.Append(", ");
                }
            }
            message.Append(")");

            Debug.Log(message);
        }

        public static void TraceMethodCall()
        {
            try
            {
                throw new Exception("THIS EXCEPTION IS HARMLESS. TRACING METHOD CALL.");
            }
            catch(Exception e)
            {
                Debug.LogException(e);
            }
        }

        public static string ToDebugString<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
            {
                return "null";
            }

            if (dictionary.Count == 0)
            {
                return "[]";
            }

            StringBuilder sb = new StringBuilder();
            foreach(TKey key in dictionary.Keys)
            {
                sb.Append("{");
                sb.Append(key);
                sb.Append("=");
                sb.Append(dictionary[key]);
                sb.Append("}\n");
            }
            return sb.ToString();
        }
    }
}