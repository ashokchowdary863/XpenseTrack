using System;
using System.Collections.Generic;
using System.Text;

namespace XpenseTrack.Users.Models {
  public class UserCategory {
    public int Id { set; get; }
    public int UserId { set; get; }
    public string Name { set; get; }
    public string Image { set; get; }
  }
}