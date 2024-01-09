using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface Itech_meeting_user_ppt
    {
        DataTable SelectUser(string family_name, string given_name, string mtype_id);

        int AddscheduleUser(string family_name, string given_name, string mtype_id, string mid);

        int Operation(object obj, string type);

        IList<tech_meeting_user_ppt> GetList(tech_meeting_user_ppt obj, string type);

        tech_meeting_user_ppt GetMeetingUser_ppt(int id);

        DataTable GetMeetingUserByLikeName(tech_meeting_user_ppt info);

        tech_meeting_user_ppt GetMeetingUserByName(string mtype_id, string full_name);

    }
}
