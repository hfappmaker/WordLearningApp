using SQLite;
using WordLearning.Domain.Entry;
using WordLearning.Infrastructure.SQLite.Models;

namespace WordLearning.Infrastructure.Models
{
    internal class WlWordModel : IModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int ParentWlWordlistID { get; set; }

        public string Word { get; set; }

        public string WordMeaning { get; set; }

        public string Memo { get; set; }

        public WlWord Create()
        {
            return new WlWord(Word, WordMeaning, Memo);
        }
    }
}