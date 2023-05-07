using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SqliteTaratorki.Models;

namespace SqliteTaratorki.Services
{
    public interface INoteRepository
    {
        Task<bool> AddNoteAsync(NoteInfo noteInfo);
        Task<bool> UpdateNoteAsync(NoteInfo noteInfo);
        Task<bool> DeleteNoteAsync(int id);
        Task<NoteInfo> GetNoteAsync(int id);

        Task<IEnumerable<NoteInfo>> GetNotesAsync();
    }
}
