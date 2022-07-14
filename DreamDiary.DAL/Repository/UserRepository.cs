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
    public class UserRepository : IUserRepository
    {
        DreamContext db;
        public UserRepository(DreamContext context)
        {
            //db = new DreamContext();
            db = context;
        }

        public async Task<User> AddAsync(User item)
        {
            await db.Users.AddAsync(item);
            db.Entry(item).State = EntityState.Added;
            await db.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var current = await db.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (current != null)
            {
                db.Users.Remove(current);
                await db.SaveChangesAsync();
                return true;
            }
            else
                return false;
            //throw new Exception("Not found");
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public async Task<User> UpdateAsync(User item)
        {
            User current = await db.Users.FirstOrDefaultAsync(u => u.Id == item.Id);
            if (current != null)
            {
                current.Email = item.Email;
                current.UserName = item.UserName;
                db.Entry(current).CurrentValues.SetValues(current);
                await db.SaveChangesAsync();
            }
            return item;
        }
    }
}
