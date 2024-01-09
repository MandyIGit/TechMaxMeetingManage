using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface Itech_meeting_order
    {
        DataTable GetTech_meeting_order(string user_code);
    }
}
