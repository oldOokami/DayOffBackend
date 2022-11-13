namespace DayOff.Api.Models
{
    public record CreateUserRequest(string UserName, string Password, string Email);
    public record UserData(string UserName, string Email);
}
