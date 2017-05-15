using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CourseWork_2.DataBase;

namespace CourseWork_2.Migrations
{
    [DbContext(typeof(PrototypingContext))]
    partial class PrototypingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("CourseWork_2.DataBase.DBModels.EmotionFragment", b =>
                {
                    b.Property<int>("EmotionFragmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("Duration");

                    b.Property<long?>("Interval");

                    b.Property<int>("RecordId");

                    b.Property<long>("Start");

                    b.HasKey("EmotionFragmentId");

                    b.HasIndex("RecordId");

                    b.ToTable("EmotionFragments");
                });

            modelBuilder.Entity("CourseWork_2.DataBase.DBModels.EmotionMeanScores", b =>
                {
                    b.Property<int>("EmotionMeanScoresId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("AngerScore");

                    b.Property<float>("ContemptScore");

                    b.Property<float>("DisgustScore");

                    b.Property<int>("EmotionFragmentId");

                    b.Property<float>("FearScore");

                    b.Property<float>("HappinessScore");

                    b.Property<float>("NeutralScore");

                    b.Property<float>("SadnessScore");

                    b.Property<float>("SurpriseScore");

                    b.HasKey("EmotionMeanScoresId");

                    b.HasIndex("EmotionFragmentId");

                    b.ToTable("EmotionScores");
                });

            modelBuilder.Entity("CourseWork_2.DataBase.DBModels.Prototype", b =>
                {
                    b.Property<int>("PrototypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<DateTime>("LastRecordingDate");

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.HasKey("PrototypeId");

                    b.ToTable("Prototypes");
                });

            modelBuilder.Entity("CourseWork_2.DataBase.DBModels.Record", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<double>("EmotionVideoTimeScale");

                    b.Property<string>("OperationLocation");

                    b.Property<string>("PathToVideo");

                    b.Property<int>("UserId");

                    b.HasKey("RecordId");

                    b.HasIndex("UserId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("CourseWork_2.DataBase.DBModels.RecordScreen", b =>
                {
                    b.Property<int>("RecordScreenId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PathToHeatMapScreen");

                    b.Property<string>("PathToOriginalScreen");

                    b.Property<string>("PointsText");

                    b.Property<int>("RecordId");

                    b.Property<string>("UriPage");

                    b.HasKey("RecordScreenId");

                    b.HasIndex("RecordId");

                    b.ToTable("RecordScreens");
                });

            modelBuilder.Entity("CourseWork_2.DataBase.DBModels.RecordSettings", b =>
                {
                    b.Property<int>("RecordSettingsId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("FrontCamera");

                    b.Property<int>("RecordId");

                    b.Property<bool>("Touches");

                    b.HasKey("RecordSettingsId");

                    b.HasIndex("RecordId")
                        .IsUnique();

                    b.ToTable("RecordSettings");
                });

            modelBuilder.Entity("CourseWork_2.DataBase.DBModels.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Biography");

                    b.Property<DateTime>("LastRecordingDate");

                    b.Property<string>("Name");

                    b.Property<int>("PrototypeId");

                    b.HasKey("UserId");

                    b.HasIndex("PrototypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CourseWork_2.DataBase.DBModels.EmotionFragment", b =>
                {
                    b.HasOne("CourseWork_2.DataBase.DBModels.Record", "Record")
                        .WithMany("ResultEmotion")
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CourseWork_2.DataBase.DBModels.EmotionMeanScores", b =>
                {
                    b.HasOne("CourseWork_2.DataBase.DBModels.EmotionFragment", "EmotionFragment")
                        .WithMany("Scores")
                        .HasForeignKey("EmotionFragmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CourseWork_2.DataBase.DBModels.Record", b =>
                {
                    b.HasOne("CourseWork_2.DataBase.DBModels.User", "User")
                        .WithMany("Records")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CourseWork_2.DataBase.DBModels.RecordScreen", b =>
                {
                    b.HasOne("CourseWork_2.DataBase.DBModels.Record", "Record")
                        .WithMany("Screens")
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CourseWork_2.DataBase.DBModels.RecordSettings", b =>
                {
                    b.HasOne("CourseWork_2.DataBase.DBModels.Record", "Record")
                        .WithOne("Settings")
                        .HasForeignKey("CourseWork_2.DataBase.DBModels.RecordSettings", "RecordId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CourseWork_2.DataBase.DBModels.User", b =>
                {
                    b.HasOne("CourseWork_2.DataBase.DBModels.Prototype", "Prototype")
                        .WithMany("Users")
                        .HasForeignKey("PrototypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
