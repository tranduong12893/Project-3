using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CourseManagement.Models.CourseModels
{
    public partial class CoureseContext : DbContext
    {
        public CoureseContext()
            : base("name=CoureseContext")
        {
        }

        public virtual DbSet<branch> branchs { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<cours> courses { get; set; }
        public virtual DbSet<courses_student> courses_student { get; set; }
        public virtual DbSet<courses_type> courses_type { get; set; }
        public virtual DbSet<question> questions { get; set; }
        public virtual DbSet<setting> settings { get; set; }
        public virtual DbSet<student> students { get; set; }
        public virtual DbSet<students_register> students_register { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<category>()
                .HasMany(e => e.courses)
                .WithOptional(e => e.category)
                .HasForeignKey(e => e.category_id);

            modelBuilder.Entity<cours>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<cours>()
                .HasMany(e => e.courses_student)
                .WithOptional(e => e.cours)
                .HasForeignKey(e => e.course_id);

            modelBuilder.Entity<cours>()
                .HasMany(e => e.students_register)
                .WithOptional(e => e.cours)
                .HasForeignKey(e => e.course_id);

            modelBuilder.Entity<courses_type>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<courses_type>()
                .HasMany(e => e.courses_student)
                .WithOptional(e => e.courses_type)
                .HasForeignKey(e => e.course_type_id);

            modelBuilder.Entity<courses_type>()
                .HasMany(e => e.students_register)
                .WithOptional(e => e.courses_type)
                .HasForeignKey(e => e.course_type_id);

            modelBuilder.Entity<question>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<setting>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<setting>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .HasMany(e => e.courses_student)
                .WithOptional(e => e.student)
                .HasForeignKey(e => e.student_id);

            modelBuilder.Entity<user>()
                .Property(e => e.user_name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
