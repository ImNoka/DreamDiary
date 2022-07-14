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
    public class NoteProfileRepository : INoteProfileRepository
    {
        DreamContext db;
        private readonly DbSet<NoteProfile> dbSet;
        public NoteProfileRepository(DreamContext context)
        {
            //db = new DreamContext();
            db = context;
            dbSet = db.Set<NoteProfile>();
        }
        public async Task<NoteProfile> AddAsync(NoteProfile item)
        {
            await dbSet.AddAsync(item);
            //await db.Notes.AddAsync(item);
            //db.Entry(item).State = EntityState.Added;
            await db.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteAsync(Guid guid)
        {
            var current = await dbSet.SingleOrDefaultAsync(n => n.Guid == guid);
            if (current != null)
            {
                dbSet.Remove(current);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public IEnumerable<NoteProfile> GetByProfileGuid(Guid guid)
        {
            IEnumerable<NoteProfile> notes = dbSet.Where(n => n.ProfileGuid == guid);
            //IEnumerable<Note> note = await dbSet.Where
            return notes;
        }

        public NoteProfile Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NoteProfile> GetAll()
        {
            var notes = db.ProfileNotes;
            return notes;
        }

        public async Task<NoteProfile> UpdateAsync(NoteProfile item)
        {
            NoteProfile current = await db.ProfileNotes.SingleOrDefaultAsync(n => n.Guid == item.Guid);
            if (current != null)
            {
                current.Text = item.Text;
                current.Name = item.Name;
                db.Entry(current).CurrentValues.SetValues(current);
                await db.SaveChangesAsync();
            }
            return current;
        }
    }
}
