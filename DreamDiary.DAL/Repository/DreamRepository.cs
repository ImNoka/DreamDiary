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
    public class DreamRepository : IDreamRepository
    {
        DreamContext db;
        DbSet<Dream> _dbSet; 

        public DreamRepository(DreamContext context)
        {
            db = context;
            _dbSet = db.Set<Dream>();
        }

        public async Task<Dream> AddAsync(Dream item)
        {
            await _dbSet.AddAsync(item);
            /*if(item.ImageDream!=null)
            {
                await db.DreamImages.AddAsync(item.ImageDream);
            }*/
            await db.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteAsync(Guid guid)
        {
            Dream dream = await _dbSet.FindAsync(guid);
            _dbSet.Remove(dream);
            await db.SaveChangesAsync();
            return true;
        }

        public Dream GetByGuid(Guid guid)
        {
            ImageDream imageDream = db.DreamImages.FirstOrDefault(x => x.DreamGuid == guid);
            Dream dream = _dbSet.Find(guid);
            dream.ImageDream = imageDream;
            return dream;
        }

        public IEnumerable<Dream> GetAll()
        {
            return _dbSet.Include(d=>d.ImageDream);
        }

        public async Task<Dream> UpdateAsync(Dream item)
        {
            Dream current = _dbSet.Find(item.Guid);
            if(current!=null)
            {
                current.Text = item.Text;
                current.Name = item.Name;
                current.ImageDream=item.ImageDream;
                current.ImageDreamGuid = item.ImageDreamGuid;
                db.Entry(current).CurrentValues.SetValues(current);
                await db.SaveChangesAsync();
            }
            return current;

        }

        public IEnumerable<Dream> GetByProfileGuid(Guid guid)
        {
            return _dbSet.Where(d => d.ProfileGuid == guid).Include(d=>d.ImageDream);
        }
    }
}
