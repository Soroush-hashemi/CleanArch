using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Ef
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().OwnsOne(b => b.Price, option =>
            {
                option.Property(p => p.Value).HasColumnName("Price"); // اسم ولیو ابجکت رو عوض میکنه 
            });

            modelBuilder.Entity<Product>().OwnsOne(b => b.Price);
            modelBuilder.Entity<User>().OwnsOne(b => b.Email);

            base.OnModelCreating(modelBuilder);
        }
    }
}
