using System;
using System.Collections.Generic;
using System.Linq;
using WordLearning.Domain.Entry;
using WordLearning.Domain.Entry.EntryCore;
using WordLearning.Infrastructure.Models;
using WordLearning.Infrastructure.SQLite.Database;
using WordLearning.Infrastructure.SQLite.Models;

namespace WordLearning.Infrastructure.Stores
{
    internal class SQLiteWlRootFolderStore : IAggregateRootStore<WlRootFolder>
    {
        public int Insert(WlRootFolder root)
        {
            // TODO: switch文の削除検討

            Queue<(WlEntry, int?)> queue = new ();
            queue.Enqueue((root, null));
            while (queue.Count > 0)
            {
                (WlEntry entry, int? parentID) = queue.Dequeue();
                IModel model = null;
                switch (entry)
                {
                    case WlFolder folder:
                        model = new WlFolderModel() { Name = folder.Name, ParentWlFolderID = parentID, };
                        WlFolderModelDatabase.Instance.SaveModelAsync((WlFolderModel)model);
                        break;
                    case WlWordList wordlist:
                        model = new WlWordlistModel() { Name = wordlist.Name, ParentWlFolderID = parentID.Value, };
                        WlWordlistModelDatabase.Instance.SaveModelAsync((WlWordlistModel)model);
                        break;
                    case WlWord word:
                        model = new WlWordModel() { Word = word.Word, WordMeaning = word.WordMeaning, Memo = word.Memo, };
                        WlWordModelDatabase.Instance.SaveModelAsync((WlWordModel)model);
                        break;
                }

                if (entry is WlDirectory directory)
                {
                    foreach (WlEntry child in directory)
                    {
                        queue.Enqueue((child, model.ID));
                    }
                }
            }

            throw new NotImplementedException();
        }

        public void Update(int id, WlRootFolder root)
        {
            // TODO: 実装
        }

        public void Delete(int id)
        {
            // TODO: 高速化
            var wlFolderModels = WlFolderModelDatabase.Instance.GetRootModelsAsync(id).Result;
            var wlWordlistModels = WlWordlistModelDatabase.Instance.GetModelsAsync(wlFolderModels.Select(x => x.ID)).Result;
            var wlWordModels = WlWordModelDatabase.Instance.GetModelsAsync(wlWordlistModels.Select(x => x.ID)).Result;
            foreach (var wlFolderModel in wlFolderModels)
            {
                WlFolderModelDatabase.Instance.DeleteModelAsync(wlFolderModel);
            }

            foreach (var wlWordlistModel in wlWordlistModels)
            {
                WlWordlistModelDatabase.Instance.DeleteModelAsync(wlWordlistModel);
            }

            foreach (var wlWordModel in wlWordModels)
            {
                WlWordModelDatabase.Instance.DeleteModelAsync(wlWordModel);
            }
        }
    }
}