using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailService {
  public class MailService {
    public bool SendVerificationMail( string username, string verificationLink, string toAddress ) {
      var emailBodyString = TemplateHelper.GetVerificationTemplate( username, verificationLink );
      MailMessage message = new MailMessage( ServerEmailCredentials.EmailAddress, toAddress ) {
        Subject = "XpenseTrack Verification Email",
        Body = emailBodyString,
        BodyEncoding = Encoding.UTF8,
        IsBodyHtml = true
      };
      SmtpClient client = new SmtpClient( "smtp.gmail.com", 587 );
      System.Net.NetworkCredential basicCredential = new System.Net.NetworkCredential( ServerEmailCredentials.EmailAddress, ServerEmailCredentials.Password );
      client.EnableSsl = true;
      client.Credentials = basicCredential;
      try {
        client.Send( message );
        return true;
      }
      catch ( Exception ) {
        return false;
      }
    }
  }
}
