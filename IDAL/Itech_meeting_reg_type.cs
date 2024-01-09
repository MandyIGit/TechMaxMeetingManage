using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace IDAL
{
    public interface Itech_meeting_reg_type
    {
        int Operation(Object obj, string type);
        DataTable GetTech_meeting_reg_type(Object obj, string type);
        DataTable GetTechMeetingRegType(tech_meeting_reg_type model);
        tech_meeting_reg_type GetModelById(int id);
    }
}
