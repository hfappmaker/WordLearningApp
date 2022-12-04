namespace WordLearning.Domain.States
{
    public class Edit_WordlistInitToolbarState : IToolbarState
    {
        public int ToolbarId { get; } = Resource.Id.tbEdit_Wordlist_Init;

        public int ToolbarLayout { get; } = Resource.Layout.Toolbar_Edit_Wordlist_Init;

        public int ToolbarMenu { get; } = Resource.Menu.menu_Edit_Wordlist_Init;
    }
}
