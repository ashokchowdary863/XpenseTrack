using System.Collections.Generic;
using System.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;


namespace Users {
  public class UserService: IUserService {
    private readonly IMongoDatabase _db;
    private readonly IMongoCollection<User> _collection;
    private readonly string _tableName;
    public UserService( string tableName = "users" ) {
      var dbConnectionString = ConfigurationManager.AppSettings["MongoDBConnectionString"];
      var dbName = ConfigurationManager.AppSettings["MongoDBDatabaseName"];
      var client = new MongoClient(dbConnectionString);
      _db = client.GetDatabase( dbName );
      _collection = _db.GetCollection<User>( tableName );
      _tableName = tableName;
    }

    public IList<User> GetAllRecords() {
      return _collection.Find( new BsonDocument() ).ToList();
    }

    public User GetRecordByUserName( string userName ) {
      var filter = Builders<User>.Filter.Eq( "UserName", userName );
      return _collection.Find( filter ).FirstOrDefault();
    }

    public User GetRecordByFirstName( string firstName, string lastName ) {
      var filter = Builders<User>.Filter.Where( x => x.FirstName.Equals( firstName ) && x.LastName.Equals( lastName ) );
      return _collection.Find( filter ).FirstOrDefault();
    }
  }
}
