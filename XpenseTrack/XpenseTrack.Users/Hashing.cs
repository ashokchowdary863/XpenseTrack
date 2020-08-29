namespace XpenseTrack.Users {
  public class Hashing {

    private static string GetRandomSalt() {
      return BCrypt.Net.BCrypt.GenerateSalt( 12 );
    }

    public static string GenerateHash( string password ) {
      return BCrypt.Net.BCrypt.HashPassword( password, GetRandomSalt() );
    }

    public static bool ValidatePassword( string password, string hash ) {
      return BCrypt.Net.BCrypt.Verify( password, hash );
    }
  }
}
