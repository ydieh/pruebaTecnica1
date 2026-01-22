using Microsoft.EntityFrameworkCore;
using prueba.Models;

namespace prueba.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación Payment → Customer por CustomerCodigo
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Payments)          // 1 Customer → muchos Payments
                .WithOne(p => p.Customer)          // Cada Payment tiene un Customer
                .HasForeignKey(p => p.CustomerCodigo) // FK en Payment
                .HasPrincipalKey(c => c.CustomerCodigo); // Columna en Customer que actúa como "principal key"

            // Relación Payment → ServiceCategory por ServiceProvider → Name
            modelBuilder.Entity<ServiceCategory>()
                .HasMany(s => s.Payments)
                .WithOne(p => p.ServiceCategory)
                .HasForeignKey(p => p.ServiceProvider)
                .HasPrincipalKey(s => s.Name);
        }
    }
}
