using Microsoft.EntityFrameworkCore;

namespace BlazorServerWithAuthAndDatabase.Services;

public interface IUserService
{
    Task<List<UserEntity>> GetUsers(CancellationToken ct = default);
}

public class UserService(IDbContextFactory<UserContext> dbFactory) : IUserService
{
    public async Task<List<UserEntity>> GetUsers(CancellationToken ct = default)
    {
        await using var db = await dbFactory.CreateDbContextAsync(ct);
        return await db.Users.OrderByDescending(x => x.Id).ToListAsync(cancellationToken: ct);
    }
}