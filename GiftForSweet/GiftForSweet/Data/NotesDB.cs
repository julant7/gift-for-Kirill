using System.Collections.Generic;
using GiftForSweet.Models;
using System.Threading.Tasks;

using SQLite;

namespace GiftForSweet.Data
{
    public class NotesDB
    {
        readonly SQLiteAsyncConnection db;

        public NotesDB(string connectionString)
        {
            db = new SQLiteAsyncConnection(connectionString);

            db.CreateTableAsync<Note>().Wait();
        }
        public Task<List<Note>> GetNotesAsync()
        {
            return db.Table<Note>().ToListAsync();
        }
        public Task<Note> GetNoteAsync(int id)
        {
            return db.Table<Note>()
               .Where(i => i.ID == id)
               .FirstOrDefaultAsync();
        }
        public Task<int> SaveNotAsync(Note note)
        {
            if (note.ID != 0)
            {
                return db.UpdateAllAsync(note);
            }
            else
            {
                return db.InsertAllAsync(note);
            }
        }

        public Task<int> DeleteNotAsync(Note note)
        {
            return db.DeleteAsync(note);
        }
    }

}
