using Microsoft.EntityFrameworkCore;

namespace BlazorServerWithAuthAndDatabase.Services;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }

    public DbSet<UserEntity> Users => Set<UserEntity>();
}