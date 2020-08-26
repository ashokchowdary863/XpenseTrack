using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using XpenseTrack.Users.Models;
using XpenseTrack.Users.Services;
using XpenseTrack.Web.Attributes;

namespace XpenseTrack.Web.Controllers {
  [Route( "api/[controller]" )]
  [ApiController]
  public class CategoriesController: ControllerBase {
    private IUserService _userService;
    public CategoriesController( IUserService userService ) {
      _userService = userService;
    }
    [Authorize]
    [HttpGet]
    [Route( "/categories" )]
    public IEnumerable<Category> GetCategories() {
      try {
        return _userService.GetCategories();
      }
      catch ( Exception e ) {
        Console.WriteLine( e );
        return new List<Category>();
      }
    }
  }
}