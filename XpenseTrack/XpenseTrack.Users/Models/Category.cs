using MongoDB.Bson;

namespace XpenseTrack.Users.Models {
  public class Category {
    public ObjectId Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
  }
}
