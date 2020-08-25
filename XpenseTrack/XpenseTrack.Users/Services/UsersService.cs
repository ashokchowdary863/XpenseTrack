using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using XpenseTrack.Database;
using XpenseTrack.Users.Models;

namespace XpenseTrack.Users.Services {
  public class UserService: IUserService {
    private readonly IMongoCollection<User> _collection;
    private readonly string TableName = "users";
    private IMongoDatabase _db;
    public UserService() {
      _db = ConnectionManager.GetConnection( "mongodb+srv://Teja:2C7blwxcNcqOciLB@cluster0.8lr10.azure.mongodb.net/Application?retryWrites=true&w=majority", "Application" );
      _collection = _db.GetCollection<User>( TableName );
    }

    public IList<User> GetAllRecords() {
      return _collection.Find( new BsonDocument() ).ToList();
    }

    public LoginStatus CheckCredentials( User user ) {
      var status = new LoginStatus { Success = false };
      if ( string.IsNullOrEmpty( user.UserName ) && string.IsNullOrEmpty( user.Email ) ) {
        return status;
      }
      if ( !string.IsNullOrEmpty( user.UserName ) ) {
        var dbUser = GetRecordByUserName( user.UserName );
        status.User = dbUser;
        status.Success = dbUser.Password.Equals( user.Password );
      }
      if ( !string.IsNullOrEmpty( user.Email ) ) {
        var dbUser = GetRecordByEmail( user.UserName );
        status.User = dbUser;
        status.Success = dbUser.Password.Equals( user.Password );
      }
      return status;
    }

    public User GetRecordByUserName( string userName ) {
      var filter = Builders<User>.Filter.Eq( "UserName", userName );
      return _collection.Find( filter ).FirstOrDefault();
    }
    public User GetRecordByEmail( string email ) {
      var filter = Builders<User>.Filter.Eq( "Email", email );
      return _collection.Find( filter ).FirstOrDefault();
    }

    public User GetRecordByFirstName( string firstName, string lastName ) {
      var filter = Builders<User>.Filter.Where( x => x.FirstName.Equals( firstName ) && x.LastName.Equals( lastName ) );
      return _collection.Find( filter ).FirstOrDefault();
    }
  }
}
