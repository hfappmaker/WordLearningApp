namespace WordLearning.Domain.BusinessTransaction
{
    internal interface ICommand
    {
        public void Undo();

        public void Redo();
    }
}