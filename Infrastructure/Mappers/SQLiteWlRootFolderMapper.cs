using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordLearning.Domain.Entry;
using WordLearning.Domain.Entry.EntryCore;
using WordLearning.Infrastructure.SQLite.Database;

namespace WordLearning.Infrastructure.Mappers
{
    internal class SQLiteWlRootFolderMapper : IAggregateRootMapper<WlRootFolder>
    {
        public async Task<WlRootFolder> GetById(int id)
        {
            var wlFolderModels = await WlFolderModelDatabase.Instance.GetRootModelsAsync(id);
            var wlWordlistModels = await WlWordlistModelDatabase.Instance.GetModelsAsync(wlFolderModels.Select(x => x.ID));
            var wlWordModels = await WlWordModelDatabase.Instance.GetModelsAsync(wlWordlistModels.Select(x => x.ID));
            Dictionary<int, WlDirectory> wlFolderDict = new();
            Dictionary<int, WlDirectory> wlWordlistDict = new();
            Dictionary<int, WlEntry> wlWordDict = new();
            foreach (var wlFolderModel in wlFolderModels)
            {
                wlFolderDict[wlFolderModel.ID] = wlFolderModel.Create();
            }

            foreach (var wlWordlistModel in wlWordlistModels)
            {
                wlWordlistDict[wlWordlistModel.ID] = wlWordlistModel.Create();
            }

            foreach (var wlWordModel in wlWordModels)
            {
                wlWordDict[wlWordModel.ID] = wlWordModel.Create();
            }

            foreach (var wlWordModel in wlWordModels)
            {
                wlWordDict[wlWordModel.ID].AddTo(wlWordlistDict[wlWordModel.ParentWlWordlistID]);
            }

            foreach (var wlFolderModel in wlFolderModels)
            {
                if (wlFolderModel.ParentWlFolderID is not null)
                {
                    wlFolderDict[wlFolderModel.ID].AddTo(wlFolderDict[wlFolderModel.ParentWlFolderID.Value]);
                }
            }

            foreach (var wlWordlistModel in wlWordlistModels)
            {
                wlWordlistDict[wlWordlistModel.ID].AddTo(wlFolderDict[wlWordlistModel.ParentWlFolderID]);
            }

            return (WlRootFolder)wlFolderDict[id];
        }
    }
}