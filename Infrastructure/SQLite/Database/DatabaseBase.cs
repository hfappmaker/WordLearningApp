using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WordLearning.Infrastructure.SQLite.Models;

namespace WordLearning.Infrastructure.SQLite.Database
{
    internal abstract class DatabaseBase<T> where T : IModel, new()
    {
        protected SQLiteAsyncConnection Database { get; }

        public DatabaseBase()
        {
            Database = new SQLiteAsyncConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), $"{typeof(T).Name}s.db3"));
            Database.CreateTableAsync<T>().Wait();
        }

        public Task<List<T>> GetModelsAsync()
        {
            //Get all notes.
            return Database.Table<T>().ToListAsync();
        }

        public Task<T> GetModelAsync(int id)
        {
            // Get a specific note.
            return Database.Table<T>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveModelAsync(T note)
        {
            if (note.ID != 0)
            {
                // Update an existing note.
                return Database.UpdateAsync(note);
            }
            else
            {
                // Save a new note.
                return Database.InsertAsync(note);
            }
        }

        public Task<int> DeleteModelAsync(T note)
        {
            // Delete a note.
            return Database.DeleteAsync(note);
        }
    }
}