using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Symphone.Models
{
    public partial class Symphony_LimitedContext : DbContext
    {
        public Symphony_LimitedContext()
        {
        }

        public Symphony_LimitedContext(DbContextOptions<Symphony_LimitedContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CenterList> CenterLists { get; set; } = null!;
        public virtual DbSet<CourseList> CourseLists { get; set; } = null!;
        public virtual DbSet<ExamLibrary> ExamLibraries { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=TRANDUONG\\SQLEXPRESS;Database=Symphony_Limited;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CenterList>(entity =>
            {
                entity.ToTable("center_list", "symphony_limited");

                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.CenterName).HasMaxLength(150);

                entity.Property(e => e.Title)
                    .HasMaxLength(300)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<CourseList>(entity =>
            {
                entity.ToTable("course list", "symphony_limited");

                entity.Property(e => e.Content).HasMaxLength(300);

                entity.Property(e => e.NameCourse).HasMaxLength(60);
            });

            modelBuilder.Entity<ExamLibrary>(entity =>
            {
                entity.ToTable("exam library", "symphony_limited");

                entity.Property(e => e.Question).HasMaxLength(300);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("invoice", "symphony_limited");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Code).HasColumnName("CODE");

                entity.Property(e => e.Courseid).HasColumnName("COURSEID");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Status).HasColumnName("STATUS");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("post", "symphony_limited");

                entity.HasIndex(e => e.UserId, "UserId");

                entity.Property(e => e.Content).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(300);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("post$post_ibfk_1");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("question", "symphony_limited");

                entity.HasIndex(e => e.UserId, "UserId");

                entity.Property(e => e.Answer).HasMaxLength(500);

                entity.Property(e => e.Ques).HasMaxLength(300);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("question$question_ibfk_1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user", "symphony_limited");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
