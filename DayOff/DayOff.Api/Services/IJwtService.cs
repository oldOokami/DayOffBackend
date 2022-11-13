using DayOff.Api.Models;
using Microsoft.AspNetCore.Identity;

namespace DayOff.Api.Services
{
    public interface IJwtService
    {
        AuthenticationResponse CreateToken(IdentityUser user);
    }
}