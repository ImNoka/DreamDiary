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
        public DbSet<NoteProfile> Notes { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Dream> Dreams { get; set; }
        

        public DreamContext(DbContextOptions options):base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-GP81B11\SQLNOKAINC;Database=DreamDiaryDatabase;Trusted_Connection=true;MultipleActiveResultSets=true;Encrypt=false");
        }
    }
}
