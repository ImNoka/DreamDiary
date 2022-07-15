using DreamDiary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.DAL.Interfaces
{
    public interface IUserProfileRepository : IRepository<UserProfile>, IBaseRepository<UserProfile>
    {
        UserProfile Get(int id);
    }
}
