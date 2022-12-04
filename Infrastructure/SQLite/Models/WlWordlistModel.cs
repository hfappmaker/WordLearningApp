using SQLite;
using WordLearning.Domain.Entry;
using WordLearning.Infrastructure.SQLite.Models;

namespace WordLearning.Infrastructure.Models
{
    internal class WlWordlistModel : IModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int ParentWlFolderID { get; set; }

        public string Name { get; set; }

        public int SleepCount { get; set; }

        public WlWordList Create()
        {
            return new WlWordList(Name);
        }
    }
}