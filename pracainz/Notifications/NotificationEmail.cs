using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using pracainz.Models;
using System.Xml.Linq;
using pracainz.Email;

namespace pracainz.Notifications
{
    class NotificationEmail : NotificationBase
    {
        public string NameForTitle { get; set; } = string.Empty;
        public override string NotificationType { get { return "EMAIL"; } }

        public static EmailClient emailClient = new EmailClient();
        public List<string> EmailList { get; set; } = new List<string>();

        protected override void SendNotificationsSpecified()
        {
            var emailArray = EmailList.ToArray();
            var emailString = string.Join(",", emailArray);

            NameForTitle = "Test";

            if (emailString != null)
            {
                emailClient.SendStandardEmail(emailString, "Wezwanie: " + NameForTitle, NotificationBody);
            }
            else
            {
                Status = new Status
                {
                    success = false,
                    queued = 111,
                    error = new Error()
                    {
                        code = 1,
                        message = "No Recipients"
                    }
                };
            }
        }

        internal override void GetAndFillTemplate(ERP_DB _chartsCtx, Dictionary<string, string> holders, int notificationId)
        {
            var spisWezwania = _chartsCtx.SpisWezwania.Find(notificationId);

            if (holders != null)
            {
                NotificationBody = spisWezwania.TemplateMail;
                foreach (var h in holders)
                    NotificationBody = NotificationBody.Replace("{" + h.Key + "}", h.Value);
            }
            else
            {
                NotificationBody = "Puste wezwanie";
            }
        }
    }
}
