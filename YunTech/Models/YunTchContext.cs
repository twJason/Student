

using Microsoft.EntityFrameworkCore;

namespace YunTech.Models
{
    public class YunTchContext : DbContext
    {
        public YunTchContext() { }
        public YunTchContext(DbContextOptions<YunTchContext> options): base(options) { 
        }

        public DbSet<系所資料> Depts { get; set; }
        public DbSet<課程資料> Subjects { get; set; }
        public DbSet<學生學籍資料> Students { get; set; }
        public DbSet<學生選課資料> StudentCourses { get; set; }
        public DbSet<學期課程資料> Courses { get; set; }
      

    }
}
