using DreamDiary.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.BLL.Interfaces
{
    public interface IUserProfileService
    {
        UserProfileDTO Add(int userId);
        Task<bool> Delete(Guid guid);
        UserProfileDTO Update(UserProfileDTO profileDTO);
        UserProfileDTO Get(int userId);
    }
}
