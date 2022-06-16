using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyJWTApi.Models;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PharmacyJWTApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PharmacyAuthController : ControllerBase
    {
        private readonly IJwtAuthenticator _jwtAuthenticator;

        private readonly PharmacyDbContext _context;
        private IConfiguration _config;
        public PharmacyAuthController(PharmacyDbContext context, IConfiguration config, IJwtAuthenticator jwtAuthenticator)
        {
            _config = config;
            _context = context;
            _jwtAuthenticator = jwtAuthenticator;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(LoginDetails loginDetail)
        {
            var tokenString = "";

            if (!_context.UserDetails.Any(c => c.Email == loginDetail.Email && c.Password == loginDetail.Password))
            {
                tokenString = null;
            }
            else
            {
                UserDetail usrDetail = _context.UserDetails.FirstOrDefault(u => u.Email == loginDetail.Email && u.Password == loginDetail.Password);
                tokenString = _jwtAuthenticator.TokenGenerator(usrDetail.Email, usrDetail.UserName, usrDetail.Password);
            }

            if (tokenString == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(new { token = tokenString });
            }

        }
        
    }
}
