using Android.OS;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using System;

namespace WordLearning.CoreLibrary.Extension
{
    public static class FragmentManagerExtension
    {
        public static void SetFragmentResultListenerXamarin(this FragmentManager @this, string requestKey, ILifecycleOwner lifecycleOwner, Action<string, Bundle> action)
        {
            var fragmentResultListener = new FragmentResultListener(action);
            @this.SetFragmentResultListener(requestKey, lifecycleOwner, fragmentResultListener);
        }



        private class FragmentResultListener : Java.Lang.Object, IFragmentResultListener
        {
            private Action<string, Bundle> _fragmentResultAction;


            public void OnFragmentResult(string p0, Bundle p1) => _fragmentResultAction?.Invoke(p0, p1);


            public FragmentResultListener(Action<string, Bundle> fragmentResultAction)
            {
                _fragmentResultAction = fragmentResultAction;
            }


            protected override void Dispose(bool disposing)
            {
                _fragmentResultAction = null;
                base.Dispose(disposing);
            }
        }
    }
}
