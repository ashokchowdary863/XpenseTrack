using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using XpenseTrack.Users.Services;

namespace XpenseTrack.Web {
  public class JwtMiddleware {
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;
    public JwtMiddleware( RequestDelegate next, IConfiguration configuration ) {
      _configuration = configuration;
      _next = next;
    }

    public async Task Invoke( HttpContext context, IUserService userService ) {
      var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split( " " ).Last();

      if ( token != null )
        Authenticate( context, userService, token );

      await _next( context );
    }

    private void Authenticate( HttpContext context, IUserService userService, string token ) {
      try {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes( _configuration["Jwt:Key"] );
        tokenHandler.ValidateToken( token, new TokenValidationParameters {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey( key ),
          ValidateIssuer = false,
          ValidateAudience = false,
          // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
          ClockSkew = TimeSpan.Zero
        }, out SecurityToken validatedToken );

        var jwtToken = (JwtSecurityToken) validatedToken;
        var userName = jwtToken.Claims.First( x => x.Type == JwtRegisteredClaimNames.Sub ).Value;

        // attach user to context on successful jwt validation
        context.Items["User"] = userService.GetRecordByUserName( userName );
      }
      catch {
        // do nothing if jwt validation fails
        // user is not attached to context so request won't have access to secure routes
      }
    }
  }
}
