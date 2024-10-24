﻿using BLOG.Domain.AccountVm;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BLOG.Presistence;

namespace BLOG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;
        public AccountController(UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto register)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            ApplicationUser user = new();
            user.UserName = register.Name;
            user.Email = register.Email;
            var result = await _userManager.CreateAsync(user, register.Password);
            if (result.Succeeded)
                return Ok("Created Account");
            foreach (var item in result.Errors)
                ModelState.AddModelError("Password", item.Description);
            return BadRequest(ModelState);

        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = await _userManager.FindByNameAsync(login.Name);
            if (user is not null)
            {
                var check = await _userManager.CheckPasswordAsync(user, login.Password);
                if (check)
                {
                    var userClaims = new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(ClaimTypes.NameIdentifier, user.Id),
                        new Claim(ClaimTypes.Name, user.UserName)
                    };


                    var smKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
                    var signCred = new SigningCredentials(smKey, SecurityAlgorithms.HmacSha256);

                    var myToken = new JwtSecurityToken
                    (
                        issuer: _config["JWT:Issuer"],
                        audience: _config["JWT:Audience"],
                        expires: DateTime.Now.AddHours(1),
                        claims: userClaims,
                        signingCredentials: signCred
                    );
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(myToken),
                        expiresIn = DateTime.Now.AddHours(1),
                    });

                }

            }
            ModelState.AddModelError("UserName", "UserName or Passord Not Valid");
            return BadRequest(ModelState);
        }
    }
}
