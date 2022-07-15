using DreamDiary.DAL.EF;
using DreamDiary.DAL.Entities;
using DreamDiary.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.DAL.Repository
{
    public class GoalRepository : IGoalRepository
    {

        DreamContext db;
        DbSet<Goal> _dbSetGoals;
        DbSet<GoalTask> _dbSetTasks;

        public GoalRepository(DreamContext context)
        {
            db = context;
            _dbSetTasks = db.Set<GoalTask>();
            _dbSetGoals = db.Set<Goal>();
        }

        public async Task<Goal> AddAsync(Goal item)
        {
            await _dbSetGoals.AddAsync(item);
            await db.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteAsync(Guid guid)
        {
            Goal goal = await _dbSetGoals.FindAsync(guid);
            _dbSetGoals.Remove(goal);
            await db.SaveChangesAsync();
            return true;
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
            IEnumerable<GoalTask> tasks = _dbSetTasks.Where(t => t.GoalGuid == guid);
            Goal goal = _dbSetGoals.Find(guid);
            goal.Tasks = tasks;
            return goal;
        }

        public IEnumerable<Goal> GetByProfileGuid(Guid guid)
        {
            IEnumerable<Goal> goals = _dbSetGoals.Where(g => g.ProfileGuid == guid);
            foreach(Goal goal in goals)
            {
                goal.Tasks = _dbSetTasks.Where(t => t.GoalGuid == goal.Guid);
            }
            return goals;
        }

        public async Task<Goal> UpdateAsync(Goal item)
        {
            Goal current = await _dbSetGoals.FindAsync(item.Guid);
            if(current != null)
            {
                current.Text=item.Text;
                current.Name = item.Name;
                current.IsCompleted = item.IsCompleted;
                db.Entry(current).CurrentValues.SetValues(current);
                await db.SaveChangesAsync();
            }
            return current;
        }
    }
}
