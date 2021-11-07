using Common.States;

namespace WordLearning.States
{
    public class StartInitToolbarState : IToolbarState
    {
        public int ToolbarId { get; } = Resource.Id.tbStart_Init;

        public int ToolbarLayout { get; } = Resource.Layout.Toolbar_Start_Init;

        public int ToolbarMenu { get; } = Resource.Menu.menu_Start_Init;
    }
}
