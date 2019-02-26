using System.Security.Cryptography;
using System;
using System.Linq;
using System.Net.Mail;
using System.Xml.Linq;
using System.Net;
using pracainz.Notifications;

namespace pracainz.Email
{
    public class EmailClientSmall
    {
        public string From { get; set; }
        public string To { get; set; }
        private static readonly SimpleAES aes = new SimpleAES("aplEmailPass");

        public void SendEMail(MailMessage msg)
        {
            using (SmtpClient newClient = new SmtpClient("host", /*tmpPort*/ 111))
            {
                newClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                newClient.UseDefaultCredentials = false;
                newClient.EnableSsl = false;
                newClient.Credentials = new NetworkCredential("userName", "password");
                newClient.Send(msg);
            }
        }
    }
}
