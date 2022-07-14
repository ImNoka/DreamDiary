using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.DAL.Interfaces
{
    public interface IRepository <T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        Task<T> AddAsync(T item);
        Task<T> UpdateAsync(T item);
    }
}
