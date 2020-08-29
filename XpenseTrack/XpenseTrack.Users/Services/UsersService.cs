using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using XpenseTrack.Database;
using XpenseTrack.Users.Models;

namespace XpenseTrack.Users.Services {
  public class UserService: IUserService {
    private readonly IMongoCollection<User> _collection;
    private readonly string TableName = "users";
    private IMongoDatabase _db;
    public UserService( IConfiguration configuration ) {
      _db = ConnectionManager.GetConnection( configuration["Mongo:ConnectionString"], configuration["Mongo:DbName"] );
      _collection = _db.GetCollection<User>( TableName );
    }

    public IList<User> GetAllRecords() {
      return _collection.Find( new BsonDocument() ).ToList();
    }

    public LoginStatus CheckCredentials( User user ) {
      var status = new LoginStatus { Success = false };
      if ( string.IsNullOrEmpty( user.UserName ) || string.IsNullOrEmpty( user.Email ) ) {
        return status;
      }
      if ( !string.IsNullOrEmpty( user.UserName ) ) {
        var dbUser = GetRecordByUserName( user.UserName );
        status.User = dbUser;
        status.Success = ValidatePassword( dbUser.Password, user.Password );
      }
      if ( !string.IsNullOrEmpty( user.Email ) ) {
        var dbUser = GetRecordByEmail( user.Email );
        status.User = dbUser;
        status.Success = ValidatePassword( dbUser.Password, user.Password );
      }
      return status;
    }

    public User GetRecordByUserName( string userName ) {
      var filter = Builders<User>.Filter.Eq( "UserName", userName );
      return _collection.Find( filter ).FirstOrDefault();
    }

    public User GetRecordByUserId( ObjectId userId ) {
      var filter = Builders<User>.Filter.Eq( "_id", userId );
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

    public IList<Category> GetCategories() {
      var collection = _db.GetCollection<Category>( "categories" );
      return collection.Find( new BsonDocument() ).ToList();
    }

    public void Register( User user ) {
      user.Id = new ObjectId();
      user.Password = CreateHash( user.Password );
      var collection = _db.GetCollection<User>( TableName );
      collection.InsertOne( user );
    }

    public void AddExpense( Expense expense ) {
      var now = (DateTimeOffset) DateTime.UtcNow;
      expense.Id = new ObjectId();
      expense.TimeStamp = now.ToUnixTimeSeconds().ToString();
      var collection = _db.GetCollection<Expense>( "expenses" );
      collection.InsertOne( expense );
    }

    public void RemoveExpense( ObjectId expenseId ) {
      var collection = _db.GetCollection<Expense>( "expenses" );
      collection.DeleteOne( Builders<Expense>.Filter.Where( x => x.Id.Equals( expenseId ) ) );
    }

    public void AddCategory( Category category ) {
      category.Id = new ObjectId();
      var collection = _db.GetCollection<Category>( "categories" );
      collection.InsertOne( category );
    }

    public void RemoveCategory( ObjectId categoryId ) {
      var collection = _db.GetCollection<Category>( "categories" );
      collection.DeleteOne( Builders<Category>.Filter.Where( x => x.Id.Equals( categoryId ) ) );
    }

    public void AddUserCategory( UserCategory category ) {
      category.Id = new ObjectId();
      var collection = _db.GetCollection<UserCategory>( "user_categories" );
      collection.InsertOne( category );
    }

    public void RemoveUserCategory( ObjectId categoryId ) {
      var collection = _db.GetCollection<UserCategory>( "user_categories" );
      collection.DeleteOne( Builders<UserCategory>.Filter.Where( x => x.Id.Equals( categoryId ) ) );
    }

    public bool CreateNewPassword( ObjectId userId, string oldPassword, string newPassword ) {
      var user = GetRecordByUserId( userId );
      if ( !ValidatePassword( user.Password, oldPassword ) ) return false;
      var collection = _db.GetCollection<User>( TableName );
      var filter = Builders<User>.Filter.Eq( "_id", userId );
      var update = Builders<User>.Update.Set( "Password", CreateHash( newPassword ) );
      collection.UpdateOne( filter, update );
      return true;

    }

    private bool ValidatePassword( string hash, string password ) {
      return Hashing.GenerateHash( password ).Equals( hash );
    }

    private string CreateHash( string password ) {
      return Hashing.GenerateHash( password );
    }


  }
}
