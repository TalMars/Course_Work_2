using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CourseWork_2.DataBase;

namespace CourseWork_2.Migrations
{
    [DbContext(typeof(PrototypingContext))]
    [Migration("20170227115753_InitMigration")]
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

            modelBuilder.Entity("CourseWork_2.DataBase.DBModels.RecordingSettings", b =>
                {
                    b.Property<int>("RecordingSettingsId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("DownScale");

                    b.Property<int>("MaxFPS");

                    b.Property<int>("PrototypeId");

                    b.Property<bool>("WithFrontCamera");

                    b.Property<bool>("WithTouches");

                    b.Property<bool>("WithTouchesLogging");

                    b.HasKey("RecordingSettingsId");

                    b.HasIndex("PrototypeId")
                        .IsUnique();

                    b.ToTable("PrototypesSettings");
                });

            modelBuilder.Entity("CourseWork_2.DataBase.DBModels.RecordPrototype", b =>
                {
                    b.Property<int>("RecordPrototypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("PathToVideo");

                    b.Property<int>("UserPrototypeId");

                    b.HasKey("RecordPrototypeId");

                    b.HasIndex("UserPrototypeId");

                    b.ToTable("RecordsPrototype");
                });

            modelBuilder.Entity("CourseWork_2.DataBase.DBModels.RecordsScreen", b =>
                {
                    b.Property<int>("RecordsScreenId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PathToHeatMapScreen");

                    b.Property<string>("PathToOriginalScreen");

                    b.Property<string>("PointsText");

                    b.Property<int>("RecordPrototypeId");

                    b.Property<string>("UriPage");

                    b.HasKey("RecordsScreenId");

                    b.HasIndex("RecordPrototypeId");

                    b.ToTable("RecordsScreens");
                });

            modelBuilder.Entity("CourseWork_2.DataBase.DBModels.UserPrototype", b =>
                {
                    b.Property<int>("UserPrototypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Biography");

                    b.Property<DateTime>("LastRecordingDate");

                    b.Property<string>("Name");

                    b.Property<int>("PrototypeId");

                    b.HasKey("UserPrototypeId");

                    b.HasIndex("PrototypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CourseWork_2.DataBase.DBModels.RecordingSettings", b =>
                {
                    b.HasOne("CourseWork_2.DataBase.DBModels.Prototype", "Prototype")
                        .WithOne("Settings")
                        .HasForeignKey("CourseWork_2.DataBase.DBModels.RecordingSettings", "PrototypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CourseWork_2.DataBase.DBModels.RecordPrototype", b =>
                {
                    b.HasOne("CourseWork_2.DataBase.DBModels.UserPrototype", "UserPrototype")
                        .WithMany("Records")
                        .HasForeignKey("UserPrototypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CourseWork_2.DataBase.DBModels.RecordsScreen", b =>
                {
                    b.HasOne("CourseWork_2.DataBase.DBModels.RecordPrototype", "RecordPrototype")
                        .WithMany("Screens")
                        .HasForeignKey("RecordPrototypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CourseWork_2.DataBase.DBModels.UserPrototype", b =>
                {
                    b.HasOne("CourseWork_2.DataBase.DBModels.Prototype", "Prototype")
                        .WithMany("Users")
                        .HasForeignKey("PrototypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
