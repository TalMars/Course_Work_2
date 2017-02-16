using CourseWork_2.DataBase.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_2.DataBase
{
    public class PrototypingContext : DbContext
    {
        public DbSet<Prototype> Prototypes { get; set; }
        public DbSet<UserPrototype> Users { get; set; }
        public DbSet<RecordingSettings> PrototypesSettings { get; set; }
        public DbSet<RecordPrototype> RecordsPrototype { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=HBCDataBase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Generate Add primary keys
            modelBuilder.Entity<Prototype>()
                .Property(p => p.PrototypeId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<UserPrototype>()
                .Property(u => u.UserPrototypeId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<RecordPrototype>()
                .Property(r => r.RecordPrototypeId)
                .ValueGeneratedOnAdd();

            //Relationships
            modelBuilder.Entity<RecordingSettings>()
                .HasOne(rs => rs.Prototype)
                .WithOne(p => p.Settings)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);

            modelBuilder.Entity<UserPrototype>()
                .HasOne(u => u.Prototype)
                .WithMany(p => p.Users)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);

            modelBuilder.Entity<RecordPrototype>()
                .HasOne(rp => rp.UserPrototype)
                .WithMany(u => u.Records)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);
        }

    }
}
