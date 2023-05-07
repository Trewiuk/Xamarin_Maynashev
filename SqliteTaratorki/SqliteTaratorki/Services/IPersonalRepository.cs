using System;
using System.Collections.Generic;
using System.Text;
using SqliteTaratorki.Models;
using System.Threading.Tasks;

namespace SqliteTaratorki.Services
{
    public interface IPersonalRepository
    {
        Task<bool> AddPersonalAsync(PersonalInfo personalInfo);
        Task<bool> UpdatePersonalAsync(PersonalInfo personalInfo);
        Task<bool> DeletePersonalAsync(int id);
        Task<PersonalInfo> GetPersonalAsync(int id);
        Task<IEnumerable<PersonalInfo>> GetPersonalsAsync();
    }
}
