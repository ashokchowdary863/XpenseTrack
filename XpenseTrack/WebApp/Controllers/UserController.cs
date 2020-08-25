using System;
using System.Collections.Generic;
using System.Web.Http;
using Users;

namespace WebApp.Controllers {
  public class UserController: ApiController {
    private readonly IUserService _userService;

    public UserController() {
      _userService = new UserService();
    }

    [HttpGet]
    [Route( "api/users" )]
    public IEnumerable<User> GetAllUsers() {
      try {
        return _userService.GetAllRecords();
      }
      catch ( Exception e ) {
        Console.WriteLine( e );
        return new List<User>();
      }
    }

    [HttpGet]
    [Route( "api/users/userName" )]
    public User GetUser( string userName ) {
      try {
        return _userService.GetRecordByUserName( userName );
      }
      catch ( Exception e ) {
        Console.WriteLine( e );
        return new User();
      }
    }

    [HttpGet]
    [Route( "api/users/FirstName" )]
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
