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
    public class UserProfileRepository : IUserProfileRepository
    {
        DreamContext db;
        public UserProfileRepository(DreamContext context)
        {
            //db = new DreamContext();
            db = context;
        }

        public async Task<UserProfile> AddAsync(UserProfile item)
        {
            await db.Profiles.AddAsync(item);
            await db.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteAsync(Guid guid)
        {
            var current = await db.Profiles.FirstOrDefaultAsync(u => u.Guid == guid);
            if (current != null)
            {
                db.Profiles.Remove(current);
                await db.SaveChangesAsync();
                return true;
            }
            else
                return false;
            //throw new Exception("Not found");
        }

        public UserProfile Get(int id)
        {
            UserProfile userProfile = db.Profiles.FirstOrDefault(p => p.UserId == id);
            if (userProfile != null)
                return userProfile;
            throw new Exception("Not found");
        }

        public IEnumerable<UserProfile> GetAll()
        {
            return db.Profiles;
        }

        public async Task<UserProfile> UpdateAsync(UserProfile item)
        {
            UserProfile current = await db.Profiles.FirstOrDefaultAsync(p => p.Guid == item.Guid);
            if (current != null)
            {
                current.FirstName = item.FirstName;
                current.LastName = item.LastName;
                current.About = item.About;
                current.Age = item.Age;
                current.ImageProfile = item.ImageProfile;
                db.Entry(current).CurrentValues.SetValues(current);
                db.Entry(current.ImageProfile).CurrentValues.SetValues(current.ImageProfile);
            }
            await db.SaveChangesAsync();
            return current;
        }
    }
}
