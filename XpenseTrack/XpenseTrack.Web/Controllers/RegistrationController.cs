using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XpenseTrack.Users.Models;
using XpenseTrack.Users.Services;

namespace XpenseTrack.Web.Controllers {
  [Route( "api/[controller]" )]
  [ApiController]
  public class RegistrationController: ControllerBase {
    private IUserService _userService;
    public RegistrationController( IUserService userService ) {
      _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Register( [FromBody] User user ) {
      try {
        _userService.Register( user );
        return Ok( new { msg = "Success" } );
      }
      catch ( Exception e ) {
        return BadRequest( new { message = e.Message } );
      }
    }

  }
}