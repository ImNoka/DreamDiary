using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.DAL.Interfaces
{
    public interface IImageRepository<T> where T : class
    {
        Task<T> Get(Guid guid);
        Task<T> AddAsync(T image);
        Task<bool> DeleteAsync(Guid guid);
        Task<T> UpdateAsync(T image);
    }
}
