using Microsoft.EntityFrameworkCore;

namespace BlazorServerWithAuthAndDatabase.Services;

public class UserContext(DbContextOptions<UserContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users => Set<UserEntity>();
}