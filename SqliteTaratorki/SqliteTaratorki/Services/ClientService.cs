using SQLite;
using SqliteTaratorki.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SqliteTaratorki.Services
{
    public class ClientService : IClientRepository
    {
        public SQLiteAsyncConnection _database;
        public ClientService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ClientInfo>().Wait();
        }
        public async Task<bool> AddClientAsync(ClientInfo clientInfo)
        {
            if (clientInfo.ClientId > 0)
            {
                await _database.UpdateAsync(clientInfo);
            }
            else
            {
                await _database.InsertAsync(clientInfo);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            await _database.DeleteAsync<ClientInfo>(id);
            return await Task.FromResult(true);
        }

        public async Task<ClientInfo> GetClientAsync(int id)
        {
            return await _database.Table<ClientInfo>().Where(p => p.ClientId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ClientInfo>> GetClientsAsync()
        {
            return await Task.FromResult(await _database.Table<ClientInfo>().ToListAsync());
        }

        public Task<bool> UpdateClientAsync(ClientInfo clientInfo)
        {
            throw new NotImplementedException();
        }
    }
}
