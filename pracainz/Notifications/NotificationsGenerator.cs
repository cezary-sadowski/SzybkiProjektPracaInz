using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pracainz.Models;

namespace pracainz.Notifications
{
    internal class NotificationsGenerator
    {
        List<Notification> NotificationsList = new List<Notification>();

        public void DoNotificationRequest(ERP_DB ctx, Dictionary<string, string> holders, int notificationID)
        {
            try
            {
                GenerateNotificationsFromDB(ctx, notificationID);
                ExecuteNotifications(ctx, holders, notificationID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("NotificationsGenerator exception: " + ex.ToString());
            }
        }

        private void GenerateNotificationsFromDB(ERP_DB ctx, int notificationID)
        {
            List<SpisWezwania> NotificationsDB;

            NotificationsDB = ctx.SpisWezwania.Where(n => n.ID == notificationID).ToList();


            foreach (SpisWezwania wezwanie in NotificationsDB)
            {
                var AcceptedTypes = new List<int>() { 1, 2 }; //tmp
                var ActiveWithoutOT = wezwanie.SchouldBeAvailableIfNoOtVisualization;

                if (ActiveWithoutOT)
                    AcceptedTypes.Add(-1);

                Notification notification = new Notification(this)
                {
                    AcceptedTypes = AcceptedTypes,
                    TemplateMail = wezwanie.TemplateMail,
                    TemplateSMS = wezwanie.TemplateSMS,
                    TemplateVoice = wezwanie.TemplateVoice,
                    NotificationId = wezwanie.ID,
                    NeedConfirmation = wezwanie.NeedConfirmation,
                    Nazwa = wezwanie.Nazwa

                };
                NotificationsList.Add(notification);
            }
        }

        private void ExecuteNotifications(ERP_DB ctx, Dictionary<string, string> holders, int notificationId)
        {
            NotificationsList.ForEach(x => x.ExecuteNotification(ctx, holders, notificationId));
        }
    }
}
