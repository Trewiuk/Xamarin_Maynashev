using SqliteTaratorki.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SqliteTaratorki.Services
{
    public interface IClientRepository
    {
        Task<bool> AddClientAsync(ClientInfo clientInfo);
        Task<bool> UpdateClientAsync(ClientInfo clientInfo);
        Task<bool> DeleteClientAsync(int id);
        Task<ClientInfo> GetClientAsync(int id);
        Task<IEnumerable<ClientInfo>> GetClientsAsync();


    }
}
