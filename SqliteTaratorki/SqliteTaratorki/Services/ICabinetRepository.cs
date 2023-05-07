using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SqliteTaratorki.Models;

namespace SqliteTaratorki.Models
{
    public interface ICabinetRepository
    {
        Task<bool> AddCabinetAsync(CabinetInfo cabinetInfo);
        Task<bool> UpdateCabinetAsync(CabinetInfo cabinetInfo);
        Task<bool> DeleteCabinetAsync(int id);
        Task<CabinetInfo> GetCabinetAsync(int id);

        Task<IEnumerable<CabinetInfo>> GetCabinetsAsync();


    }
}
