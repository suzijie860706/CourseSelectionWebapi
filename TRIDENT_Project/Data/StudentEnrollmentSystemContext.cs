using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TRIDENT_Project.Models;

namespace TRIDENT_Project.Data
{
    public partial class StudentEnrollmentSystemContext : DbContext
    {
        public StudentEnrollmentSystemContext()
        {
        }

        public StudentEnrollmentSystemContext(DbContextOptions<StudentEnrollmentSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<ClassSchedule> ClassSchedules { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Professor> Professors { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentCourse> StudentCourses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.HasIndex(e => new { e.CourseId, e.ProfessorId }, "IX_Class");

                entity.Property(e => e.ClassId)
                    .HasColumnName("classId")
                    .HasComment("課表Id");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(50)
                    .HasColumnName("className")
                    .HasComment("班級名稱");

                entity.Property(e => e.CourseId)
                    .HasColumnName("courseID")
                    .HasComment("課程Id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("endDate")
                    .HasComment("結束日期");

                entity.Property(e => e.ProfessorId)
                    .HasColumnName("professorId")
                    .HasComment("教授Id");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("startDate")
                    .HasComment("開始日期");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Class__courseID__5535A963");

                entity.HasOne(d => d.Professor)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.ProfessorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Class__professor__5629CD9C");
            });

            modelBuilder.Entity<ClassSchedule>(entity =>
            {
                entity.HasKey(e => e.ScheduleId)
                    .HasName("PK__CourseSc__3213E83FCAD3F462");

                entity.ToTable("ClassSchedule");

                entity.HasIndex(e => new { e.CourseId, e.DayOfWeek }, "UQ_CourseSchedule")
                    .IsUnique();

                entity.Property(e => e.ScheduleId)
                    .HasColumnName("scheduleId")
                    .HasComment("課表排程Id");

                entity.Property(e => e.CourseId)
                    .HasColumnName("courseId")
                    .HasComment("課程Id");

                entity.Property(e => e.DayOfWeek)
                    .HasColumnName("dayOfWeek")
                    .HasComment("星期");

                entity.Property(e => e.EndTime)
                    .HasColumnName("endTime")
                    .HasComment("下課時間");

                entity.Property(e => e.Location)
                    .HasMaxLength(20)
                    .HasColumnName("location");

                entity.Property(e => e.StartTime)
                    .HasColumnName("startTime")
                    .HasComment("上課時間");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.ClassSchedules)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CourseSch__cours__3F466844");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.HasIndex(e => e.CourseName, "IX_Course")
                    .IsUnique();

                entity.Property(e => e.CourseId)
                    .HasColumnName("courseId")
                    .HasComment("唯一識別碼");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(10)
                    .HasColumnName("courseName")
                    .HasComment("課程名稱");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate")
                    .HasComment("課程建立時間");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description")
                    .HasComment("說明");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedDate")
                    .HasComment("課程更新時間");
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.ToTable("Professor");

                entity.Property(e => e.ProfessorId)
                    .HasColumnName("professorId")
                    .HasComment("唯一識別碼");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate")
                    .HasComment("帳號建立時間");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email")
                    .HasComment("電子郵件地址");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .HasColumnName("name")
                    .HasComment("教授姓名");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedDate")
                    .HasComment("帳號更新時間");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId)
                    .HasColumnName("studentId")
                    .HasComment("唯一識別碼");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate")
                    .HasComment("帳號建立時間");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email")
                    .HasComment("電子郵件地址");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .HasColumnName("name")
                    .HasComment("學生姓名");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedDate")
                    .HasComment("帳號更新時間");
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.ToTable("StudentCourse");

                entity.HasIndex(e => new { e.StudentId, e.ClassId, e.ProfessorId }, "IX_StudentCourse")
                    .IsUnique();

                entity.Property(e => e.StudentCourseId)
                    .ValueGeneratedNever()
                    .HasColumnName("studentCourseId")
                    .HasComment("唯一識別碼");

                entity.Property(e => e.ClassId)
                    .HasColumnName("classId")
                    .HasComment("課程Id");

                entity.Property(e => e.EnrollDate)
                    .HasColumnType("date")
                    .HasColumnName("enrollDate")
                    .HasComment("選課日期");

                entity.Property(e => e.ProfessorId)
                    .HasColumnName("professorId")
                    .HasComment("教授Id");

                entity.Property(e => e.StudentId)
                    .HasColumnName("studentId")
                    .HasComment("學生Id");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentCourse_Course");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentCourse_Student");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
