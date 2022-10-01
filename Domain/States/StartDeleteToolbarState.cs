namespace WordLearning.Domain.States
{
    public class StartDeleteToolbarState : IToolbarState
    {
        public int ToolbarId { get; } = Resource.Id.tbStart_Deletemode;


        public int ToolbarLayout { get; } = Resource.Layout.Toolbar_Start_Deletemode;


        public int ToolbarMenu { get; } = Resource.Menu.menu_Start_Deletemode;
    }
}
