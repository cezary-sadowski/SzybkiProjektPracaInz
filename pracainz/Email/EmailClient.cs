using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace pracainz.Email
{
    public class EmailClient : EmailClientSmall
    {
        public new void SendEMail(MailMessage msg)
        {
            try
            {
                base.SendEMail(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Email sending fail: " + ex.ToString());
            }
        }

        internal void SendStandardEmail(string to, string subject, string body)
        {
            From = "cez94k@gmail.com";
            MailMessage msg = new MailMessage(From, to, subject, body)
            {
                IsBodyHtml = true
            };
            new Task(() => SendEMail(msg)).Start();
        }
    }
}
