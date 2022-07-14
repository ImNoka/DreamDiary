using DreamDiary.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAll();
        UserDTO GetById(int id);
        UserDTO Register(UserDTO userDTO);
        UserDTO Update(UserDTO userDTO);
        Task<bool> Delete(int id);
    }
}
