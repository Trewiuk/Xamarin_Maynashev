using SQLite;
using SqliteTaratorki.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SqliteTaratorki.Services
{
    public class CabinetService : ICabinetRepository
    {
        public SQLiteAsyncConnection _database; 
        
        public CabinetService(string dbPath) 
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<CabinetInfo>().Wait();
        }
        public async Task<bool> AddCabinetAsync(CabinetInfo cabinetInfo)
        {
            if (cabinetInfo.CabinetId > 0)
            {
                await _database.UpdateAsync(cabinetInfo);
            }
            else 
            {
                await _database.InsertAsync(cabinetInfo);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteCabinetAsync(int id)
        {
            await _database.DeleteAsync<CabinetInfo>(id);
            return await Task.FromResult(true);
        }

        public async Task<CabinetInfo> GetCabinetAsync(int id)
        {
            return await _database.Table<CabinetInfo>().Where(p => p.CabinetId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CabinetInfo>> GetCabinetsAsync()
        {
            return await Task.FromResult(await _database.Table<CabinetInfo>().ToListAsync());
        }

        public Task<bool> UpdateCabinetAsync(CabinetInfo cabinetInfo)
        {
            throw new NotImplementedException();
        }
    }
}
