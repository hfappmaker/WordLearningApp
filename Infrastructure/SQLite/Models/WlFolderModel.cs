using SQLite;
using WordLearning.Domain.Entry;
using WordLearning.Infrastructure.SQLite.Models;

namespace WordLearning.Infrastructure.Models
{
    internal class WlFolderModel : IModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int? ParentWlFolderID { get; set; }

        public string Name { get; set; }

        public WlFolder Create()
        {
            if (ParentWlFolderID is null)
            {
                return new WlRootFolder(Name);
            }

            return new WlFolder(Name);
        }
    }
}