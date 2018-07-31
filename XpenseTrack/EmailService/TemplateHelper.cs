using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService {
  public static class TemplateHelper {
    public static string GetVerificationTemplate( string username, string verificationLink ) {
      return "<html>" +
                         "<body>" +
                         "<head>" +
                         "<style>" +
                         ".btn-style{" +
                         "    color: #fff;" +
                         "    background-color: #5cb85c;" +
                         "    border-color: #4cae4c;" +
                         "    display: inline-block;" +
                         "    padding: 6px 12px;" +
                         "    margin-bottom: 0;" +
                         "    font-size: 14px;" +
                         "    font-weight: 400;" +
                         "    line-height: 1.42857143;" +
                         "    text-align: center;" +
                         "    white-space: nowrap;" +
                         "    vertical-align: middle;" +
                         "    -ms-touch-action: manipulation;" +
                         "    touch-action: manipulation;" +
                         "    cursor: pointer;" +
                         "    -webkit-user-select: none;" +
                         "    -moz-user-select: none;" +
                         "    -ms-user-select: none;" +
                         "    user-select: none;" +
                         "    background-image: none;" +
                         "    border: 1px solid transparent;" +
                         "    border-radius: 4px; }" +
                         "</style>" +
                         "</head>" +
                         "Hello <span style=\"font-weight:bold\">" + username + "</span>," +
                         "<br/><br/>" +
                         "Congratulations, your login details have been created! ." +
                         "<br/><br/>" +
                         "To get started, please verify your email id by clicking on the link below." +
                         "<br/><br/>" +
                         "<a class=\"btn-style\" href='" + verificationLink + "'>Click this link for activation</a>" +
                         "<br/><br/><br/>" +
                         "Thanks," +
                         "<br/>" +
                         "Team XpenseTrack" +
                         "</body>" +
                         "</html>";
    }
  }
}
