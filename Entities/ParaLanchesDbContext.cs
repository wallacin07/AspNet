using Microsoft.EntityFrameworkCore;

namespace Server.Entities;

public class ParaLanchesDbContext(DbContextOptions<ParaLanchesDbContext> options): DbContext(options)
{
    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<ApplicationOrder> Orders { get; set; }
    public DbSet<ApplicationMeal> Meals { get; set; }
    public DbSet<ApplicationDrink> Drinks { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
       builder.Entity<ApplicationUser>()
       .HasMany(e => e.InvitedUsers)
       .WithOne(e => e.InvitedBy)
       .HasForeignKey(e => e.InvitedById)
       .OnDelete(DeleteBehavior.SetNull);

        builder.Entity<ApplicationUser>()
       .HasOne(e => e.InvitedBy)
       .WithMany(e => e.InvitedUsers)
       .HasForeignKey(e => e.InvitedById)
       .OnDelete(DeleteBehavior.NoAction);

       builder.Entity<ApplicationUser>()
       .HasMany(e => e.Orders)
       .WithOne(e => e.Customer)
       .HasForeignKey(e => e.CustomerId)
       .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ApplicationOrder>()
        .HasMany(e => e.Drinks)
        .WithMany(e => e.Orders)
        .UsingEntity(j => j.ToTable("OrderDrinks"));

        builder.Entity<ApplicationOrder>()
        .HasMany(e => e.Meals)
        .WithMany(e => e.Orders)
        .UsingEntity(j => j.ToTable("OrderMeals"));

    }
}