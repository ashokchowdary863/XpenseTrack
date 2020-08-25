using System;
using System.Collections.Generic;
using System.Text;

namespace XpenseTrack.Users.Models {
  public class LoginStatus {
    public User User { get; set; }
    public bool Success { get; set; }
  }
}
