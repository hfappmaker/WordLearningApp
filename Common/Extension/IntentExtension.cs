using System;
using Android.Content;
using Common.Utility;
using Java.IO;
using Newtonsoft.Json;

namespace Common.Extension
{
    public static class IntentExtension
    {
        public static void PutExtra<T>(this Intent @intent, string name, T item) where T : class
        {
            intent.PutExtra(name, CommonUtility.SetData(item));
        }


        public static T GetExtra<T>(this Intent @intent, string name) where T : class
        {
            return CommonUtility.GetData<T>(intent.GetIntExtra(name, -1));
        }
    }
}
