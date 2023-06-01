using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

public class IdentityContext : DbContext
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Add any additional configuration here
    }

    // Add your entity sets here
    public DbSet<User> Users { get; set; }
    public DbSet<ShoppingCartEntity> ShoppingCarts { get; set; }
    public DbSet<ShoppingCartItemEntity> ShoppingCartsItemEntity { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
}





