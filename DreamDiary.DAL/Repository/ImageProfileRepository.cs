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
    public class ImageProfileRepository : IImageProfileRepository
    {

        DreamContext db;
        DbSet<ImageProfile> _dbSet;

        public ImageProfileRepository(DreamContext context)
        {
            db = context;
            _dbSet = db.Set<ImageProfile>();
        }

        public async Task<ImageProfile> AddAsync(ImageProfile image)
        {
            await _dbSet.AddAsync(image);
            UserProfile profile = await db.Profiles.SingleOrDefaultAsync(p => p.Guid == image.ProfileGuid);
            profile.ImageProfile = image;
            db.Entry(profile).CurrentValues.SetValues(profile);
            await db.SaveChangesAsync();
            return image;
        }

        public async Task<bool> DeleteAsync(Guid guid)
        {
            ImageProfile current = await _dbSet.SingleOrDefaultAsync(im => im.Guid == guid);
            if(current == null)
                return false;
            _dbSet.Remove(current);
            UserProfile profile = await db.Profiles.SingleOrDefaultAsync(p => p.ImageProfileGuid == guid);
            profile.ImageProfile = null;
            db.Entry(profile).CurrentValues.SetValues(profile);
            db.Entry(current).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<ImageProfile> Get(Guid guid)
        {
            return await _dbSet.SingleOrDefaultAsync(im=>im.Guid==guid);
        }

        public async Task<ImageProfile> UpdateAsync(ImageProfile image)
        {
            ImageProfile current = await _dbSet.FindAsync(image.Guid);
            if (image == null)
                return null;
            current.Image = image.Image;
            db.Entry(current).CurrentValues.SetValues(current);
            await db.SaveChangesAsync();
            return current;
        }
    }
}
