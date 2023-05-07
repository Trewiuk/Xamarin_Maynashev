using SQLite;
using SqliteTaratorki.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SqliteTaratorki.Services
{
    public class PersonalService: IPersonalRepository
    {
        public SQLiteAsyncConnection _database;
        public PersonalService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<PersonalInfo>().Wait();
        }
        public async Task<bool> AddPersonalAsync(PersonalInfo personalInfo)
        {
            if (personalInfo.PersonalId > 0)
            {
                await _database.UpdateAsync(personalInfo);
            }
            else
            {
                await _database.InsertAsync(personalInfo);
            }
            return await Task.FromResult(true);
        }
        public async Task<bool> DeletePersonalAsync(int id)
        {
            await _database.DeleteAsync<PersonalInfo>(id);
            return await Task.FromResult(true);
        }
        public async Task<PersonalInfo> GetPersonalAsync(int id)
        {
            return await _database.Table<PersonalInfo>().Where(p => p.PersonalId == id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<PersonalInfo>> GetPersonalsAsync()
        {
            return await Task.FromResult(await _database.Table<PersonalInfo>().ToListAsync());
        }
        public Task<bool> UpdatePersonalAsync(PersonalInfo personalInfo)
        {
            throw new NotImplementedException();
        }
    }
}
