using System;
using System.Collections.Generic;
using System.Text;

namespace XpenseTrack.Users.Models {
  public class Expense {
    public int id { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public string TimeStamp { get; set; }
    public double Amount { get; set; }
    public string Currency { get; set; }
    public string File { get; set; }
  }
}
