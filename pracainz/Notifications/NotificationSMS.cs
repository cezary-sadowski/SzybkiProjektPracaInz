using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pracainz.Models;

namespace pracainz.Notifications
{
    class NotificationSMS : NotificationBase
    {
        readonly SmsServer smsServer = new SmsServer("cez94k", "qqwerty123");
        public override string NotificationType { get { return "SMS"; } }
        public List<string> PhoneNumbers { get; set; } = new List<string>();
        protected override void SendNotificationsSpecified()
        {
            var phoneArray = PhoneNumbers.ToArray();
            var phoneString = string.Join(",", phoneArray);

            if (phoneString != null) 
            {
                string response = smsServer.SmsRequest(phoneString, NotificationBody);
                DeserializeStatus(response);
            }
        }

        internal override void GetAndFillTemplate(ERP_DB ctx, Dictionary<string, string> holders, int notificationId)
        {
            var spisWezwania = ctx.SpisWezwania.Find(notificationId);

            if (holders != null)
            {
                NotificationBody = spisWezwania.TemplateSMS;
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
