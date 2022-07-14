using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> DeleteAsync(Guid guid);
    }
}
