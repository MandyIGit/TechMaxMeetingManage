using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class TimeStamp
    {
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }
    }
}
