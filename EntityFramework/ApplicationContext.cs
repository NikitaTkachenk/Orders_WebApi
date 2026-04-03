using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders_WabApi.Entity;

namespace EntityFramework;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<User> User { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItem { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
        modelBuilder.Entity<User>();
    }
}

public class UserConfiguration() : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
    }
}

public class OrderConfiguration() : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        builder.HasOne(o => o.User).WithMany(o => o.Orders).HasForeignKey(o => o.UserId);
    }
}

public class OrderItemConfiguration() : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(o => o.Id);
        builder.HasOne(oi => oi.Order).WithOne(o => o.OrderItem).HasForeignKey<OrderItem>(o => o.OrderId);
    }
}