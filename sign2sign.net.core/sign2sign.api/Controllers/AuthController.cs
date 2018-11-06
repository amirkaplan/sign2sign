﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using sign2sign.api.BusinessModels;

namespace sign2sign.api.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _user_manager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<IdentityUser> user_manager, IConfiguration configuration)
        {
            _user_manager = user_manager;
            _configuration = configuration;
        }

        [Route("register")]
        [HttpPost]
        public async Task<ActionResult> Register([FromBody] login login)
        {
            var user = new IdentityUser
            {
                Email = login.Email,
                UserName = login.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _user_manager.CreateAsync(user, login.Password);
            if (result.Succeeded)
            {
                await _user_manager.AddToRoleAsync(user, "Business");
            }
            return Ok(new { username = user.UserName });
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] login login)
        {
            var user = await _user_manager.FindByNameAsync(login.Email);
            if (user != null && await _user_manager.CheckPasswordAsync(user, login.Password))
            {
                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName)
                };

                var signinKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["Jwt:SigninKey"]));

                int expiryInMinuts = Convert.ToInt32(_configuration["Jwt:ExpiryInMinuts"]);

                var token = new JwtSecurityToken(
                        issuer: _configuration["Jwt:Site"],
                        audience: _configuration["Jwt:Site"],
                        expires: DateTime.UtcNow.AddMinutes(expiryInMinuts),
                        signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
            }
            return Unauthorized();
        }
    }
}