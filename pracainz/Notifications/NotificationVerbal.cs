using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pracainz.Models;

namespace pracainz.Notifications
{
    class NotificationVerbal : NotificationBase
    {
        public override string NotificationType { get { return "VERBAL"; } }

        protected override void SendNotificationsSpecified()
        {
            GenerateStatus();
        }

        private void GenerateStatus()
        {
            Status = new Status
            {
                success = true,
                queued = 111, //tmp
                error = Error.GetEmptyError()
            };
        }
    }

}
