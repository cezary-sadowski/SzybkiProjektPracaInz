using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pracainz.Models;

namespace pracainz.Notifications
{
    class NotificationVoice : NotificationBase
    {
        readonly SmsServer smsServer = new SmsServer("cez94k", "qqwerty123");
        public override string NotificationType { get { return "VOICE"; } }
        public List<string> NumbersForVoice { get; set; } = new List<string>();
        protected override void SendNotificationsSpecified()
        {
            var phonesVoiceArray = NumbersForVoice.ToArray();
            var phoneString = string.Join(",", phonesVoiceArray);

            if (phoneString != null)
            {
                string response = smsServer.VoiceRequest(phoneString, NotificationBody);
                DeserializeStatus(response);
            }
        }

        internal override void GetAndFillTemplate(ERP_DB ctx, Dictionary<string, string> holders, int notificationId)
        {
            var spisWezwania = ctx.SpisWezwania.Find(notificationId);

            if (holders != null)
            {
                NotificationBody = spisWezwania.TemplateVoice;
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
