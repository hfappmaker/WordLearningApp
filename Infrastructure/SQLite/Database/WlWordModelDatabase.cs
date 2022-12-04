using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordLearning.Infrastructure.Models;

namespace WordLearning.Infrastructure.SQLite.Database
{
    internal class WlWordModelDatabase : DatabaseBase<WlWordModel>
    {
        public Task<List<WlWordModel>> GetModelsAsync(IEnumerable<int> wordlistIDs)
        {
            //Get all notes.
            var wordlistIDSet = wordlistIDs.ToHashSet();
            return Database.Table<WlWordModel>().Where(x => wordlistIDSet.Contains(x.ParentWlWordlistID)).ToListAsync();
        }

        private WlWordModelDatabase() { }

        private static readonly Lazy<WlWordModelDatabase> _instance = new(() => new WlWordModelDatabase());

        public static WlWordModelDatabase Instance => _instance.Value;
    }
}