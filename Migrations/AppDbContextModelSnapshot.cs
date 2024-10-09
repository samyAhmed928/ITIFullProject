﻿// <auto-generated />
using ITIFullProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ITIFullProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ITIFullProject.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("InstructorId")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("ITIFullProject.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Degree")
                        .HasColumnType("decimal(3,2)");

                    b.Property<int>("DeptId")
                        .HasColumnType("int");

                    b.Property<decimal>("MinDegree")
                        .HasColumnType("decimal(3,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DeptId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("ITIFullProject.Models.CourseInstructor", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "InstructorId");

                    b.HasIndex("InstructorId");

                    b.ToTable("CoursesInstructors");
                });

            modelBuilder.Entity("ITIFullProject.Models.CourseResult", b =>
                {
                    b.Property<int>("TraineeId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<decimal>("Degree")
                        .HasColumnType("decimal(3,2)");

                    b.HasKey("TraineeId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("CoursesResults");
                });

            modelBuilder.Entity("ITIFullProject.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MangerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ITIFullProject.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("DeptId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DeptId");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("ITIFullProject.Models.Trainee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("DeptId")
                        .HasColumnType("int");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DeptId");

                    b.ToTable("Trainees");
                });

            modelBuilder.Entity("ITIFullProject.Models.Account", b =>
                {
                    b.HasOne("ITIFullProject.Models.Instructor", "Instructor")
                        .WithOne("Account")
                        .HasForeignKey("ITIFullProject.Models.Account", "InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("ITIFullProject.Models.Course", b =>
                {
                    b.HasOne("ITIFullProject.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DeptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ITIFullProject.Models.CourseInstructor", b =>
                {
                    b.HasOne("ITIFullProject.Models.Course", "Course")
                        .WithMany("CourseInstructors")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ITIFullProject.Models.Instructor", "Instructor")
                        .WithMany("CoursesInstructors")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("ITIFullProject.Models.CourseResult", b =>
                {
                    b.HasOne("ITIFullProject.Models.Course", "Course")
                        .WithMany("CourseResults")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ITIFullProject.Models.Trainee", "Trainee")
                        .WithMany("CourseResults")
                        .HasForeignKey("TraineeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("ITIFullProject.Models.Instructor", b =>
                {
                    b.HasOne("ITIFullProject.Models.Department", "Department")
                        .WithMany("Instructors")
                        .HasForeignKey("DeptId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ITIFullProject.Models.Trainee", b =>
                {
                    b.HasOne("ITIFullProject.Models.Department", "Department")
                        .WithMany("Trainees")
                        .HasForeignKey("DeptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ITIFullProject.Models.Course", b =>
                {
                    b.Navigation("CourseInstructors");

                    b.Navigation("CourseResults");
                });

            modelBuilder.Entity("ITIFullProject.Models.Department", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Instructors");

                    b.Navigation("Trainees");
                });

            modelBuilder.Entity("ITIFullProject.Models.Instructor", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();

                    b.Navigation("CoursesInstructors");
                });

            modelBuilder.Entity("ITIFullProject.Models.Trainee", b =>
                {
                    b.Navigation("CourseResults");
                });
#pragma warning restore 612, 618
        }
    }
}
