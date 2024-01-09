using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface Itech_send_wx_message
    {
        int Operation(Object obj, string type);
        DataTable GetTech_Send_WX_Message(Object obj, string type);
        DataTable GetTech_Send_WX_Message(tech_send_wx_message model);
        tech_send_wx_message GetModelById(string id);
    }
}
