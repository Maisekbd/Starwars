using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Starwars.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [AllowAnonymous]
        [HttpPost()]
        public async Task<IActionResult> Login([FromBody]AuthenticateModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    // This doesn't count login failures towards account lockout
                    // To enable password failures to trigger account lockout, 
                    // set lockoutOnFailure: true
                    var result = await _signInManager.PasswordSignInAsync(model.Username,
                                       model.Password, false, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var key = Encoding.UTF8.GetBytes("somethingyouwantwhichissecurewillworkk");
                        var user = await _userManager.FindByNameAsync(model.Username);
                        List<Claim> claims = new List<Claim>();
                        (await _userManager.GetRolesAsync(user)).ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
                        claims.Add(new Claim(ClaimTypes.Name, user.Id.ToString()));
                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Issuer = "localhost",
                            Subject = new ClaimsIdentity(claims),
                            Expires = DateTime.UtcNow.AddDays(7),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                        };
                        var token = tokenHandler.CreateToken(tokenDescriptor);
                        var tokenString = tokenHandler.WriteToken(token);

                        // return basic user info and authentication token
                        return Ok(new
                        {
                            //Id = user.Id,
                            Token = tokenString
                        });
                    }

                }
                return BadRequest();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }

    public class AuthenticateModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}