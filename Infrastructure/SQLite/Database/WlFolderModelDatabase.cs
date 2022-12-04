using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordLearning.Infrastructure.Models;

namespace WordLearning.Infrastructure.SQLite.Database
{
    internal class WlFolderModelDatabase : DatabaseBase<WlFolderModel>
    {
        public Task<List<WlFolderModel>> GetRootModelsAsync(int rootID)
        {
            return Database.QueryAsync<WlFolderModel>(
                    @"WITH RECURRSIVE X AS (
                    SELECT *
                    FROM WlFolderModels
                    WHERE ID = ?
                    UNION ALL
                    SELECT WlFolderModels.*
                    FROM    WlFolderModels, X
                    WHERE   ParentWlFolderID = X.ID)
                    SELECT * FROM X;
                    ",
                    rootID
            );
        }

        private WlFolderModelDatabase() { }

        private static readonly Lazy<WlFolderModelDatabase> _instance = new(() => new WlFolderModelDatabase());

        public static WlFolderModelDatabase Instance => _instance.Value;
    }
}