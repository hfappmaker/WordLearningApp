using Android.App;
using System.Linq;
using Android.Views;
using Android.OS;
using WordLearning.Colors;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using WordLearning.Utility;
using Common.States;
using AndroidX.Transitions;

namespace WordLearning.Activities
{
    [Activity(Label = "Inherit this activity")]
    public abstract class CustomActivity : AppCompatActivity
    {
        public int? basetoolbarResID = null;
        public IMenu menu;
        private IToolbarState _toolbarState;
        protected abstract int ToolbarId { get; }

        protected abstract int LayoutId { get; }

        protected IToolbarState ToolbarState
        {
            get
            {
                return _toolbarState;
            }

            private set
            {
                _toolbarState = value;
                NotifyToolbarStateChanged();
            }
        }

        protected virtual void NotifyToolbarStateChanged()
        {
            var rootscene = FindViewById<ViewGroup>(ToolbarId);
            var scene = Scene.GetSceneForLayout(rootscene, ToolbarState.ToolbarLayout, this);
            var transition = new Fade();
            transition.SetDuration(150L);
            TransitionManager.Go(scene, transition);
            var toolbar = FindViewById<Toolbar>(ToolbarState.ToolbarId);
            toolbar.Title = SupportActionBar?.Title;
            SetSupportActionBar(toolbar);
        }


        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(ToolbarState.ToolbarMenu, menu);
            return true;
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="layoutResID"></param>
        /// <param name="toolbarResID"></param>
        public void SetContentViewAndToolbar<T>() where T : IToolbarState, new()
        {
            SetContentView(LayoutId);
            Window.SetStatusBarColor(ThemeColor.DarkColor);
            Window.SetNavigationBarColor(ThemeColor.Color);
            SetToolbar<T>();
            WlUtility.AddEventToEachView(this);
        }


        protected void SetToolbar<T>() where T : IToolbarState, new()
        {
            ToolbarState = new T();
        }


        public abstract void OnDialogResult(object result, string dialogName);

    }
}
