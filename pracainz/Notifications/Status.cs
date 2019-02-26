using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pracainz.Notifications
{
    class Status
    {
        public bool success;
        public int queued;
        //public int unsent;
        public Error error;
    }

    public class Error
    {
        public int code;
        public string type;
        public string message;

        static public Error GetEmptyError()
        {
            return new Error
            {
                message = "",
                type = ""
            };
        }
    }

}
