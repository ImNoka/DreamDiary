using DreamDiary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.DAL.Interfaces
{
    public interface IUserRepository : IRepository<User>, IMainRepository<User>
    {

    }
}
