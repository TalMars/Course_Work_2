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
        public DbSet<RecordsScreen> RecordsScreens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=HBCDataBase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Ignore
            modelBuilder.Entity<RecordsScreen>()
                .Ignore(r => r.Points);

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

            modelBuilder.Entity<RecordingSettings>()
                .Property(r => r.RecordingSettingsId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<RecordsScreen>()
                .Property(r => r.RecordsScreenId)
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

            modelBuilder.Entity<RecordsScreen>()
                .HasOne(rs => rs.RecordPrototype)
                .WithMany(rp => rp.Screens)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);
        }

    }
}
