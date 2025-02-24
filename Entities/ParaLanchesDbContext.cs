using Microsoft.EntityFrameworkCore;

namespace Server.Entities;

public class ParaLanchesDbContext(DbContextOptions<ParaLanchesDbContext> options): DbContext(options)
{
    public DbSet<ApplicationUser> Users { get; set; }
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
    }
}