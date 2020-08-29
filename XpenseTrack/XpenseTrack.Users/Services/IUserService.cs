using System.Collections.Generic;
using XpenseTrack.Users.Models;

namespace XpenseTrack.Users.Services {
  public interface IUserService {
    IList<User> GetAllRecords();
    User GetRecordByUserName( string userName );
    User GetRecordByFirstName( string firstName, string lastName );
    LoginStatus CheckCredentials( User user );
    IList<Category> GetCategories();
    void Register( User user );

  }
}
