using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLAPI
{
    class TimeStamp
    {
        private string endTime;

        public string EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        //private string timestamp;

        //public string Timestamp
        //{
        //    get { return timestamp; }
        //    set { timestamp = value; }
        //}






        //public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        //{
        //    System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        //    DateTime dt = new DateTime();
        //    dt = dtDateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
        //    return dt;
        //}


    }
}
