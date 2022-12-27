namespace DayOff.Api.Models
{
    public record AuthenticationResponse(string Token, DateTime Expiration);
}
