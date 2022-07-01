using domain.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace infra.Data
{
    public class SqlContext: DbContext
    {
        public SqlContext() { }

        public SqlContext(DbContextOptions<SqlContext> options): base(options) { }
     
        public DbSet<Users> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userModel = modelBuilder.Entity<Users>();
           
            userModel.Property(p => p.email).HasMaxLength(200);
            userModel.Property(p => p.name).HasMaxLength(100);
            userModel.Property(p => p.password).HasMaxLength(50);
            userModel.Property(p => p.status).HasMaxLength(1);

            base.OnModelCreating(modelBuilder);
        }
    }
}