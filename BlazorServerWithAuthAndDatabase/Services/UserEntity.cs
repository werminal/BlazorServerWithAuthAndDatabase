namespace BlazorServerWithAuthAndDatabase.Services;

public class UserEntity
{
    public int Id { get; set; }
    public string First { get; set; }
    public string Last { get; set; }
    public string? Email { get; set; }
    public DateTime Registered { get; set; }
}