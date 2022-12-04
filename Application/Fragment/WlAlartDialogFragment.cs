using Android.OS;
using AndroidX.AppCompat.App;
using WordLearning.Application.Activities.ActivityCore;

namespace WordLearning.Application.Fragment
{
    public class WlAlartDialogFragment : AppCompatDialogFragment
    {
        public WlAlartDialogFragment(Bundle bundle) : base()
        {
            Arguments = bundle;
        }


        public WlAlartDialogFragment() : base() { }


        protected void OnDialogResult(dynamic result)
        {
            (Activity as CustomActivity).OnDialogResult(result, GetType().Name);
        }


        protected void OnDialogResult()
        {
            OnDialogResult(null);
        }
    }
}
