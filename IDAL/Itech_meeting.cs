using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace IDAL
{
    public interface Itech_meeting
    {
        int Operation(Object obj, string type);
        DataTable GetTech_meeting(Object obj, string type);
        DataTable GetTechMeeting(tech_meeting model);
        tech_meeting MeetingLogin(string mid, string pwd);
        tech_meeting GetModelByMId(string mid);
        string GetMid();
    }
}
