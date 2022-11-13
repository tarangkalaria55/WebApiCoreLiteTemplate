using Api.Jwt;
using DTO;
using IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly ILogger<AuthenticateController> _logger;
        private readonly IJwtAuthManager _jwtAuthManager;
        private readonly IServiceManager _ServiceManager;

        public AuthenticateController(ILogger<AuthenticateController> logger, IJwtAuthManager jwtAuthManager, IServiceManager ServiceManager)
        {
            _logger = logger;
            _jwtAuthManager = jwtAuthManager;
            _ServiceManager = ServiceManager;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login([FromBody] Userdto userdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (_ServiceManager.UserAccountService.IsAuthenticated(userdto) == false)
            {
                return Unauthorized();
            }
            Claim[] claims;
            claims = new[]
{
                    new Claim(ClaimTypes.Name,userdto.UserName)
                    ,new Claim(ClaimTypes.Role,"User")
                };

            var jwtResult = _jwtAuthManager.GenerateTokens(userdto.UserName, claims, DateTime.Now);
            _logger.LogInformation($"User [{userdto.UserName}] logged in the system.");
            return Ok(jwtResult);
        }

    }
}
