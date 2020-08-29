using MongoDB.Bson;

namespace XpenseTrack.Users.Models {
  public class Expense {
    public ObjectId Id { get; set; }
    public ObjectId UserId { get; set; }
    public ObjectId CategoryId { get; set; }
    public string TimeStamp { get; set; }
    public double Amount { get; set; }
    public string Currency { get; set; }
    public string File { get; set; }
  }
}
