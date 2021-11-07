using Common.States;

namespace WordLearning.States
{
    public class Edit_WordlistDeleteToolbarState : IToolbarState
    {
        public int ToolbarId { get; } = Resource.Id.tbEdit_Wordlist_Deletemode;


        public int ToolbarLayout { get; } = Resource.Layout.Toolbar_Edit_Wordlist_Deletemode;


        public int ToolbarMenu { get; } = Resource.Menu.menu_Edit_Wordlist_Deletemode;
    }
}
