using Microsoft.EntityFrameworkCore;
using Users.Domain;

namespace Users.Persistence.DataBase
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}