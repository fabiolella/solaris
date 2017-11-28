using Microsoft.EntityFrameworkCore;

namespace examApi.Models
{
    public class ExamContext : DbContext
    {
        public ExamContext(DbContextOptions<ExamContext> options)
            : base(options)
        {
        }

        //definisco i datasets relativi alle entita'
        public DbSet<Exam> ExamItems { get; set; }
        public DbSet<Student> StudentItems { get; set; }

    }
}