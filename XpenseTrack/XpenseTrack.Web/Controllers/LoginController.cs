using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using XpenseTrack.Users.Models;
using XpenseTrack.Users.Services;

namespace XpenseTrack.Web.Controllers {
  [Route( "api/[controller]" )]
  [ApiController]
  public class LoginController: ControllerBase {
    private IConfiguration _config;
    private IUserService _userService;
    public LoginController( IConfiguration config, IUserService userService ) {
      _config = config;
      _userService = userService;
    }
    [AllowAnonymous]
    [HttpPost]
    public IActionResult Login( [FromBody]User user ) {
      IActionResult response = Unauthorized();
      var status = _userService.CheckCredentials( user );
      if ( status.Success ) {
        var tokenString = GenerateJSONWebToken( status.User );
        response = Ok( new { token = tokenString } );
      }

      return response;
    }

    private string GenerateJSONWebToken( User userInfo ) {
      var securityKey = new SymmetricSecurityKey( Encoding.UTF8.GetBytes( _config["Jwt:Key"] ) );
      var credentials = new SigningCredentials( securityKey, SecurityAlgorithms.HmacSha256 );

      var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

      var token = new JwtSecurityToken( _config["Jwt:Issuer"],
          _config["Jwt:Issuer"],
          claims,
          expires: DateTime.Now.AddMinutes( 120 ),
          signingCredentials: credentials );

      return new JwtSecurityTokenHandler().WriteToken( token );
    }
  }
}