using System;
using System.Configuration;
using MongoDB.Driver;

namespace XpenseTrack.Database {
  public class ConnectionManager {
    public static IMongoDatabase GetConnection( string connectionString, string dbName ) {
      var client = new MongoClient( connectionString );
      IMongoDatabase db = client.GetDatabase( dbName );
      return db;
    }
  }
}
