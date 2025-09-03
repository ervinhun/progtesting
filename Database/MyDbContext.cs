namespace Database;
using Microsoft.EntityFrameworkCore;

public partial class MyDbContext : DbContext
{
        public MyDbContext(DbContextOptions<MyDbContext> options)
                : base(options)
        {
        }

        public virtual DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}