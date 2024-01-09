using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace IDAL
{
    public interface Itech_meeting_type
    {
        int Operation(Object obj, string type);
        tech_meeting_type GetModelByTypeId(string type_id);
        DataTable GetTech_meeting_type(Object obj, string type);
        string GetMtype_id();
    }
}
