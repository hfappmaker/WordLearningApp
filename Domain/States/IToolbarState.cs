namespace WordLearning.Domain.States
{
    public interface IToolbarState
    {
        public int ToolbarId { get; }


        public int ToolbarLayout { get; }


        public int ToolbarMenu { get; }
    }
}
