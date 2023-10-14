using Android.App;
using Android.OS;
using Android.Views;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using AndroidX.Transitions;
using WordLearning.Domain.States;
using WordLearning.Domain.Utility;
using WordLearning.Domain.Colors;

namespace WordLearning.Application.Activities.ActivityCore
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
            get => _toolbarState;

            private set
            {
                _toolbarState = value;
                NotifyToolbarStateChanged();
            }
        }

        protected virtual void NotifyToolbarStateChanged()
        {
            ViewGroup rootscene = FindViewById<ViewGroup>(ToolbarId);
            Scene scene = Scene.GetSceneForLayout(rootscene, ToolbarState.ToolbarLayout, this);
            Fade transition = new();
            transition.SetDuration(150L);
            TransitionManager.Go(scene, transition);
            Toolbar toolbar = FindViewById<Toolbar>(ToolbarState.ToolbarId);
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
