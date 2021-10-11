using System;
using System.Net;
using System.Configuration;
using System.Collections.Specialized;
using System.Net.Mail;
using System.Timers;

namespace StockQuoteAlert
{
    public class EmailClient
    {
        private static NameValueCollection GetMailSettings()
        {
            return ConfigurationManager.GetSection("ApplicationSettings") as NameValueCollection;
        }

        public static void SendEmail(string sellOrBuy, Timer timer)
        {
            timer.Enabled = false;

            var mailSettings = GetMailSettings();

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = Int32.Parse(mailSettings["Port"]),
                Credentials = new NetworkCredential(mailSettings["Email"], mailSettings["Password"]),
                EnableSsl = Boolean.Parse(mailSettings["Ssl"]),
            };
                
            smtpClient.Send(
                mailSettings["Email"],
                mailSettings["AlertEmail"],
                sellOrBuy,
                sellOrBuy
            );
        }
    }
}