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
        public DbSet<User> Users { get; set; }
        public DbSet<RecordSettings> RecordSettings { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<RecordScreen> RecordScreens { get; set; }
        public DbSet<EmotionFragment> EmotionFragments { get; set; }
        public DbSet<EmotionMeanScores> EmotionScores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=HBCDataBase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Ignore
            modelBuilder.Entity<RecordScreen>()
                .Ignore(r => r.Points);

            //Generate Add primary keys
            modelBuilder.Entity<Prototype>()
                .Property(p => p.PrototypeId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
                .Property(u => u.UserId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Record>()
                .Property(r => r.RecordId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<RecordSettings>()
                .Property(r => r.RecordSettingsId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<RecordScreen>()
                .Property(r => r.RecordScreenId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<EmotionFragment>()
                .Property(r => r.EmotionFragmentId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<EmotionMeanScores>()
                .Property(r => r.EmotionMeanScoresId)
                .ValueGeneratedOnAdd();

            //Relationships
            modelBuilder.Entity<RecordSettings>()
                .HasOne(rs => rs.Record)
                .WithOne(p => p.Settings)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Prototype)
                .WithMany(p => p.Users)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);

            modelBuilder.Entity<Record>()
                .HasOne(rp => rp.User)
                .WithMany(u => u.Records)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);

            modelBuilder.Entity<RecordScreen>()
                .HasOne(rs => rs.Record)
                .WithMany(rp => rp.Screens)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);

            modelBuilder.Entity<EmotionFragment>()
                .HasOne(rs => rs.Record)
                .WithMany(rp => rp.ResultEmotion)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);

            modelBuilder.Entity<EmotionMeanScores>()
                .HasOne(rs => rs.EmotionFragment)
                .WithMany(rp => rp.Scores)
                .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Cascade);
        }

    }
}
