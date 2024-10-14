﻿using System;
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

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Professor> Professors { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentCourse> StudentCourses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("唯一識別碼");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(10)
                    .HasColumnName("courseName")
                    .IsFixedLength()
                    .HasComment("課程名稱");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate")
                    .HasComment("課程建立時間");

                entity.Property(e => e.Description)
                    .HasMaxLength(10)
                    .HasColumnName("description")
                    .IsFixedLength();

                entity.Property(e => e.EndTime).HasColumnName("endTime");

                entity.Property(e => e.ProfessorId)
                    .HasColumnName("professorId")
                    .HasComment("授課教授Id");

                entity.Property(e => e.StartTime).HasColumnName("startTime");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedDate")
                    .HasComment("課程更新時間");

                entity.HasOne(d => d.Professor)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.ProfessorId)
                    .HasConstraintName("FK_Course_Professor");
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.ToTable("Professor");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
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

                entity.Property(e => e.Id)
                    .HasColumnName("id")
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

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("唯一識別碼");

                entity.Property(e => e.CourseId)
                    .HasColumnName("courseId")
                    .HasComment("課程Id");

                entity.Property(e => e.EnrollDate)
                    .HasColumnType("date")
                    .HasColumnName("enrollDate")
                    .HasComment("選課日期");

                entity.Property(e => e.StudentId)
                    .HasColumnName("studentId")
                    .HasComment("學生Id");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.CourseId)
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
