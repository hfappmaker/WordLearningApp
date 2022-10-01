using Android.OS;
using WordLearning.CoreLibrary.Utility;
using Java.IO;
using System;

namespace WordLearning.CoreLibrary.Extension
{
    public static class BundleExtension
    {
        public static void PutExtra<T>(this Bundle @bundle, string key, T item) where T : class
        {
            bundle.PutString(key, CommonUtility.SetData(item));
        }


        public static T GetExtra<T>(this Bundle @bundle, string key) where T : class
        {
            return CommonUtility.GetData<T>(bundle.GetString(key));
        }


        public static void PutEnum<T>(this Bundle @bundle, string key, T value) where T : struct
        {
            bundle.PutString(key, value.ToString());
        }


        public static T GetEnum<T>(this Bundle @bundle, string key) where T : struct
        {
            if (Enum.TryParse(bundle.GetString(key), out T result))
            {
                return result;
            }
            else
            {
                throw new InvalidObjectException("enum error");
            }
        }
    }
}
