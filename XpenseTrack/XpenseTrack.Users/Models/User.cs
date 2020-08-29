﻿using MongoDB.Bson;

namespace XpenseTrack.Users.Models {
  public class User {

    public ObjectId Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
  }
}
