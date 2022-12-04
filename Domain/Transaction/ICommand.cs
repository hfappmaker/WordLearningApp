namespace WordLearning.Domain.Transaction
{
    internal interface ICommand
    {
        public void Undo();

        public void Redo();
    }
}