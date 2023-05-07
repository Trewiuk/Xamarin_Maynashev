using SQLite;
using SqliteTaratorki.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SqliteTaratorki.Services
{
   
    public class NoteService: INoteRepository
    {
        public SQLiteAsyncConnection _database;
        public NoteService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<NoteInfo>().Wait();
        }
        public async Task<bool> AddNoteAsync(NoteInfo noteInfo)
        {
            if (noteInfo.NoteId > 0)
            {
                await _database.UpdateAsync(noteInfo);
            }
            else
            {
                await _database.InsertAsync(noteInfo);
            }
            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteNoteAsync(int id)
        {
            await _database.DeleteAsync<NoteInfo>(id);
            return await Task.FromResult(true);
        }
        public async Task<NoteInfo> GetNoteAsync(int id)
        {
            return await _database.Table<NoteInfo>().Where(p => p.NoteId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<NoteInfo>> GetNotesAsync()
        {
            return await Task.FromResult(await _database.Table<NoteInfo>().ToListAsync());
        }

        public Task<bool> UpdateNoteAsync(NoteInfo noteInfo)
        {
            throw new NotImplementedException();
        }
    }
}
