using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordLearning.Infrastructure.Models;

namespace WordLearning.Infrastructure.SQLite.Database
{
    internal class WlWordlistModelDatabase : DatabaseBase<WlWordlistModel>
    {
        public Task<List<WlWordlistModel>> GetModelsAsync(IEnumerable<int> folderIDs)
        {
            //Get all notes.
            var folderIDSet = folderIDs.ToHashSet();
            return Database.Table<WlWordlistModel>().Where(x => folderIDSet.Contains(x.ParentWlFolderID)).ToListAsync();
        }

        private WlWordlistModelDatabase() { }

        private static readonly Lazy<WlWordlistModelDatabase> _instance = new(() => new WlWordlistModelDatabase());

        public static WlWordlistModelDatabase Instance => _instance.Value;
    }
}