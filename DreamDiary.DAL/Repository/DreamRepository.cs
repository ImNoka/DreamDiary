using DreamDiary.DAL.Entities;
using DreamDiary.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.DAL.Repository
{
    public class DreamRepository : IDreamRepository
    {
        public Task<Dream> AddAsync(Dream item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Dream Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dream> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Dream> UpdateAsync(Dream item)
        {
            throw new NotImplementedException();
        }
    }
}
