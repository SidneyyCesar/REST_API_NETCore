using domain.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace infra.Data
{
    public class SqlContext: DbContext
    {
        public SqlContext() { }

        public SqlContext(DbContextOptions<SqlContext> options): base(options) { }
     
        public DbSet<Users> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userModel = modelBuilder.Entity<Users>();
           
            userModel.Property(p => p.id).HasColumnName("Id");
            userModel.Property(p => p.email).HasMaxLength(200).HasColumnName("Email");
            userModel.Property(p => p.name).HasMaxLength(100).HasColumnName("Name");
            userModel.Property(p => p.password).HasMaxLength(50).HasColumnName("Password");
            

            userModel.ToTable("Usuarios");

            base.OnModelCreating(modelBuilder);
        }
    }
}