using System;
using System.Collections.Generic;
using System.Linq;
using pracainz.Models;

namespace pracainz.Notifications
{
    internal class Notification
    {
        public List<PosredniaWezwaniaPracownicy> RawOperators { get; set; }
        public List<int> AcceptedTypes { get; set; }
        public int ActualOtType { get; set; }
        public string Nazwa { get; set; }
        public string TemplateMail { get; set; }
        public string TemplateSMS { get; set; }
        public string TemplateVoice { get; set; }
        public int NotificationId { get; internal set; }
        public bool NeedConfirmation { get; set; }

        public List<NotificationBase> ListToSend = new List<NotificationBase>();
        NotificationsGenerator ParentGenerator;

        internal Notification(NotificationsGenerator notificationsGenerator)
        {
            ParentGenerator = notificationsGenerator;
        }

        public void ExecuteNotification(ERP_DB _chartsCtx, Dictionary<string, string> holders, int notificationId)
        {

            NotificationEmail Email = null;
            NotificationSMS SMS = null;
            NotificationVoice Voice = null;
            NotificationVerbal Verbal = null;

            foreach (var tmp in RawOperators)
            {
                if (tmp.SendMail)
                    AddRecipient(tmp.SpisPracownikowID, /*test*/ "cez94k@gmail.com", ref Email);
                if (tmp.SendSMS)
                    AddRecipient(tmp.SpisPracownikowID, /*test*/ "691884748", ref SMS);
                if (tmp.SendVoice)
                    AddRecipient(tmp.SpisPracownikowID, /*test*/ "691884748", ref Voice);
                if (!tmp.SendMail && !tmp.SendSMS && !tmp.SendSMS)
                    AddRecipient(tmp.SpisPracownikowID, "", ref Verbal);
            }

            if (Email != null)
            {
                Email.NameForTitle = Nazwa;
                Email.Template = TemplateMail;
            }
            if (SMS != null)
                SMS.Template = TemplateSMS;
            if (Voice != null)
                Voice.Template = TemplateVoice;

            ListToSend.ForEach(x => x.SendNotifications(_chartsCtx, holders, notificationId));
        }

        private void AddRecipient<T>(int ID, string recipient, ref T Notification)
        {
            AddNotificationClassIfNotExist(ref Notification);
        }

        private void AddNotificationClassIfNotExist<T>(ref T Notification)
        {
            if (Notification == null)
            {
                CreateInstance(ref Notification);
                (Notification as NotificationBase).Parent = this;
                ListToSend.Add(Notification as NotificationBase);
            }
        }

        private void CreateInstance<T>(ref T Notification)
        {
            Notification = (T)Activator.CreateInstance(typeof(T));
        }

        public bool CheckIfSucces()
        {
            return ListToSend.Where(x => x.Status != null).Select(x => x.Status.success).Contains(true);
        }

        public int GetStatus()
        {
            int output = 0;
            if (ListToSend.Any(nb => nb.Status?.success ?? false) || true)
                if (NeedConfirmation)
                    output = 3;
                else
                    output = 2;
            else
                output = 1;

            return output;
        }
    }
}
