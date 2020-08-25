using System.Collections.Generic;


namespace Users {
  public interface IUserService {
    IList<User> GetAllRecords();
    User GetRecordByUserName( string userName );
    User GetRecordByFirstName( string firstName, string lastName );

  }
}
