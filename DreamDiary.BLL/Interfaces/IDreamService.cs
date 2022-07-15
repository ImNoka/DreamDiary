using DreamDiary.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.BLL.Interfaces
{
    public interface IDreamService
    {
        DreamDTO GetByGuid(Guid guid);
        DreamDTO Add(DreamDTO dreamDTO, byte[] image);
        DreamDTO Add(string name, string text, Guid profileGuid, byte[] image);
        DreamDTO Update(DreamDTO dreamDTO);
        bool Delete(Guid guid);
        IEnumerable<DreamDTO> GetByProfileGuid(Guid guid);
        IEnumerable<DreamDTO> GetAll();
    }
}
