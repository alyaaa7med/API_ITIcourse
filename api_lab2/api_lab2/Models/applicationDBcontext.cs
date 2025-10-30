using Microsoft.EntityFrameworkCore;

namespace api_lab2.Models
{
    public class applicationDBcontext :DbContext
    {

      
        public applicationDBcontext(DbContextOptions<applicationDBcontext> options)
            : base(options)
        {
        }
        public DbSet<Student> student { get; set; }
        public DbSet<Department> department { get; set; }
        public DbSet<Instructor> instructor { get; set; }
    }
}
