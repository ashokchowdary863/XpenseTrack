using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using XpenseTrack.Users.Models;
using XpenseTrack.Users.Services;
using XpenseTrack.Web.Attributes;

namespace XpenseTrack.Web.Controllers {
  [Route( "api/[controller]" )]
  [ApiController]
  public class UsersController: ControllerBase {
    private readonly IUserService _userService;

    public UsersController( IUserService userService ) {
      _userService = userService;
    }

    [Authorize]
    [HttpGet]
    [Route( "/users" )]
    public IEnumerable<User> GetAllUsers() {
      try {
        return _userService.GetAllRecords();
      }
      catch ( Exception e ) {
        Console.WriteLine( e );
        return new List<User>();
      }
    }

    [Authorize]
    [HttpGet]
    [Route( "/users/userName" )]
    public User GetUser( string userName ) {
      try {
        return _userService.GetRecordByUserName( userName );
      }
      catch ( Exception e ) {
        Console.WriteLine( e );
        return new User();
      }
    }

    [Authorize]
    [HttpGet]
    [Route( "/users/firstName/lastName" )]
    public User GetUser( string firstName, string lastName ) {
      try {
        return _userService.GetRecordByFirstName( firstName, lastName );
      }
      catch ( Exception e ) {
        Console.WriteLine( e );
        return new User();
      }
    }
  }
}