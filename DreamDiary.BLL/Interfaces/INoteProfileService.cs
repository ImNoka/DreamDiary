using DreamDiary.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.BLL.Interfaces
{
    public interface INoteProfileService
    {
        IEnumerable<NoteProfileDTO> GetAll();

        Task<bool> Add(NoteProfileDTO note);
        Task<bool> Delete(Guid guid);
        Task<bool> Update(NoteProfileDTO note);
        IEnumerable<NoteProfileDTO> GetAllByProfileGuid(Guid guid);
    }
}
