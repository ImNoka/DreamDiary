using DreamDiary.DAL.Entities;
using DreamDiary.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.DAL.Repository
{
    public class GoalRepository : IGoalRepository
    {
        public Task<Goal> AddAsync(Goal item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Goal Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Goal> GetAll()
        {
            throw new NotImplementedException();
        }

        public Goal GetByGuid(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<Goal> UpdateAsync(Goal item)
        {
            throw new NotImplementedException();
        }
    }
}
