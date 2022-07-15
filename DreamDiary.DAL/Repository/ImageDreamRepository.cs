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
    public class ImageDreamRepository : IImageDreamRepository
    {
        DreamContext db;
        DbSet<ImageDream> _dbSet;

        public ImageDreamRepository(DreamContext context)
        {
            db= context;
            _dbSet = db.Set<ImageDream>();
        }

        public async Task<ImageDream> AddAsync(ImageDream image)
        {
            await _dbSet.AddAsync(image);
            Dream dream = await db.Dreams.SingleOrDefaultAsync(d=> d.Guid==image.DreamGuid);
            dream.ImageDream = image;
            db.Entry(dream).CurrentValues.SetValues(dream);
            await db.SaveChangesAsync();
            return image;
        }

        public Task<bool> DeleteAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<ImageDream> Get(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<ImageDream> UpdateAsync(ImageDream image)
        {
            throw new NotImplementedException();
        }
    }
}
