using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Choice> Choices { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<SchoolClass> SchoolClassses { get; set; } = null!;
        public DbSet<SchoolClassSubject> SchoolClassSubjects { get; set; } = null!;
        public DbSet<SchoolYear> SchoolYears { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<StudentExam> StudentExams { get; set; } = null!;
        public DbSet<StudentExamAnswer> StudentExamAnswers { get; set; } = null!;
        public DbSet<StudentSubject> StudentSubjects { get; set; } = null!;
        public DbSet<Subject> Subjects { get; set; } = null!;
        public DbSet<Teacher> Teacher { get; set; } = null!;
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Exam> Exams { get; set; } = null!;
        public DbSet<ExamQuestion> ExamQuestions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ====================
            // StudentSubject
            // ====================

            modelBuilder.Entity<StudentSubject>()
                .HasOne(ss => ss.Student)
                .WithMany()
                .HasForeignKey(ss => ss.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentSubject>()
               .HasOne(ss => ss.Student)
               .WithMany()
               .HasForeignKey(ss => ss.StudentId)
               .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<StudentSubject>()
                .Property(ss => ss.Score)
                .HasPrecision(5, 2); 

            modelBuilder.Entity<SchoolClassSubject>()
                .HasOne(scs => scs.SchoolClass)
                .WithMany()
                .HasForeignKey(scs => scs.SchoolClassId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SchoolClassSubject>()
                .HasOne(scs => scs.Subject)
                .WithMany()
                .HasForeignKey(scs => scs.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }


    }
}
