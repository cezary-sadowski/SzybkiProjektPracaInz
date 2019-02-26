using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using serwersms;
using pracainz.Models;

namespace pracainz.Notifications

{
    public class SmsServer
    {
        string user;
        string password;
        SerwerSMS Serwer;

        public SmsServer(string User, string Password)
        {
            try
            {
                user = User;
                password = Password;
                Serwer = new SerwerSMS(user, password);
            }
            catch(Exception ex)
            {
                Console.WriteLine("SmsServer exception: " + ex.ToString());
            }
        }

        internal void DoRequest(ERP_DB ctx, ref Dictionary<string, string> holders, int notificationID, string plant)
        {
            var userFromPlaceHolders = holders.SingleOrDefault(holder => holder.Key != null && holder.Key.Equals("user")).Value;
            var phoneNumber = ctx.SpisPracownikow.FirstOrDefault(user => user.ImieNaziwsko != null && user.ImieNaziwsko.Equals(userFromPlaceHolders)).Telefon;

            var typWezwania = ctx.SpisWezwania.SingleOrDefault(sw => sw.ID == notificationID).TypyWezwanID;
            var voiceType = 2; //tmp
            if (typWezwania == voiceType)
            {
                var notifVoice = new NotificationVoice();
                notifVoice.GetAndFillTemplate(ctx, holders, notificationID);
                VoiceRequest(phoneNumber, notifVoice.NotificationBody);
            }
            else
            {
                var notifSms = new NotificationSMS();
                notifSms.GetAndFillTemplate(ctx, holders, notificationID);
                SmsRequest(phoneNumber, notifSms.NotificationBody);
            }
        }

        public string VoiceRequest(string phoneNumber, string body)
        {
            var data = new Dictionary<string, string>
            {
                { "text", body },
                { "Adam", "Adam" }
            };
            var response = Serwer.messages.sendVoice(phoneNumber, data).ToString();
            return response;
        }

        public string SmsRequest(string phoneNumber, string body)
        {
            var sender = "TEST";
            var response = Serwer.messages.sendSms(phoneNumber, body, sender).ToString();
            return response;
        }
    }
}
