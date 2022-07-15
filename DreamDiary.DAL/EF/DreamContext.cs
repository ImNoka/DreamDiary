using DreamDiary.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.DAL.EF
{
    public class DreamContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<NoteProfile> ProfileNotes { get; set; }
        public DbSet<NoteGoal> GoalNotes { get; set; }
        public DbSet<NoteTask> TaskNotes { get; set; } 
        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Dream> Dreams { get; set; }
        public DbSet<GoalTask> Tasks { get; set; }
        public DbSet<ImageDream> DreamImages { get; set; }
        public DbSet<ImageProfile> ImageProfiles { get; set; }
        public DbSet<ImageGoal> GoalImages { get; set; }

        public DreamContext(DbContextOptions options):base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-GP81B11\SQLNOKAINC;Database=DreamDiaryDatabase;Trusted_Connection=true;MultipleActiveResultSets=true;Encrypt=false");
        }
    }
}
