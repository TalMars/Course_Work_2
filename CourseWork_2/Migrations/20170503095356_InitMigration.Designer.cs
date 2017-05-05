using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CourseWork_2.DataBase;

namespace CourseWork_2.Migrations
{
    [DbContext(typeof(PrototypingContext))]
    [Migration("20170503095356_InitMigration")]
    partial class InitMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

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

                    b.Property<string>("PathToVideo");

                    b.Property<int>("UserId");

                    b.HasKey("RecordId");

                    b.HasIndex("UserId");

                    b.ToTable("RecordsPrototype");
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

                    b.ToTable("RecordsScreens");
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
