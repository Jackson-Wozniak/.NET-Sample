using db_test.Entities;
using Microsoft.EntityFrameworkCore;

namespace db_test.Data;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options): base(options) {}
    
    public DbSet<User> Users { get; set; }
}