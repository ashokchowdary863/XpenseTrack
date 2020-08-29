using MongoDB.Bson;

namespace XpenseTrack.Users.Models {
  public class UserCategory {
    public ObjectId Id { set; get; }
    public ObjectId UserId { set; get; }
    public string Name { set; get; }
    public string Image { set; get; }
  }
}