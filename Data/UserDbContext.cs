using db_test.Entities;
using Microsoft.EntityFrameworkCore;

namespace db_test.Data;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options): base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(user => user.Addresses)
            .WithOne(address => address.User)
            .HasForeignKey(user => user.UserId);
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
}