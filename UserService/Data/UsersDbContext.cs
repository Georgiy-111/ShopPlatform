using Microsoft.EntityFrameworkCore;
using UserService.Domain.Entities;

namespace UserService.Data;

public class UsersDbContext : DbContext
{
    public UsersDbContext(DbContextOptions<UsersDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
}