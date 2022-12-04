using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordLearning.DependencyResolver;

namespace WordLearning.Application.MainApp
{
    [Application]
    public class MainApp : Android.App.Application
    {
        public MainApp(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            Resolver.Resolve();
        }
    }
}