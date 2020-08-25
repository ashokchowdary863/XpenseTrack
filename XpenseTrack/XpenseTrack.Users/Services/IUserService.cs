using System;
using System.Collections.Generic;
using System.Text;
using XpenseTrack.Users.Models;

namespace XpenseTrack.Users.Services {
  public interface IUserService {
    IList<User> GetAllRecords();
    User GetRecordByUserName( string userName );
    User GetRecordByFirstName( string firstName, string lastName );

  }
}
