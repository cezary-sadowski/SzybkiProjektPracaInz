using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pracainz.Models;

namespace pracainz.Notifications
{
    internal class NotificationBase
    {
        public int OtType { get; set; }
        public string Template { get; set; }
        public Status Status { get; protected set; }
        public Notification Parent { get; set; }
        public virtual string NotificationType { get { throw new NotImplementedException(); } }
        public string NotificationBody { get; protected set; }

        internal void SendNotifications(ERP_DB ctx, Dictionary<string, string> holders, int notificationId)
        {
            GetAndFillTemplate(ctx, holders, notificationId);

            SendNotificationsSpecified();
        }

        protected virtual void SendNotificationsSpecified()
        {
            throw new NotImplementedException("Function SendNotificationsSpecified in base class is not overrided.");
        }

        protected void DeserializeStatus(string str)
        {
            Status = JsonConvert.DeserializeObject<Status>(str);
        }

        internal virtual void GetAndFillTemplate(ERP_DB ctx, Dictionary<string, string> holders, int notificationId)
        {
            throw new NotImplementedException("Function GetAndFillTemplate in base class is not overrided.");
        }
    }
}
