using Microsoft.EntityFrameworkCore;
using MVCJqueryLearning.Models;

namespace MVCJqueryLearning.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
