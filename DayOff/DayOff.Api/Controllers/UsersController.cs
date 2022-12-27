using DayOff.Api.Models;
using DayOff.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DayOff.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IJwtService jwtService;

        public UsersController(UserManager<IdentityUser> userManager, IJwtService jwtService)
        {
            this.userManager = userManager;
            this.jwtService = jwtService;
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserRequest>> PostUser(CreateUserRequest user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await userManager.CreateAsync(
                new IdentityUser() { UserName = user.UserName, Email = user.Email },
                user.Password
            );

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var newUser = user with { Password = string.Empty };
            return Created("", newUser);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<UserData>> GetUser(string username)
        {
            var user = await userManager.FindByNameAsync(username);

            if (user is null)
            {
                return NotFound();
            }

            return CreatedAtAction("GetUser", new { username = user.UserName },  new UserData(user.UserName!, user.Email!));
        }

        [HttpPost("BearerToken")]
        public async Task<ActionResult<AuthenticationResponse>> CreateBearerToken(AuthenticationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad credentials");
            }

            var user = await userManager.FindByNameAsync(request.Username);

            if (user == null)
            {
                return BadRequest("Bad credentials");
            }

            var isPasswordValid = await userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }

            var token = jwtService.CreateToken(user);

            return Ok(token);
        }
    }
}
