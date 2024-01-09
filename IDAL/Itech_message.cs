using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface Itech_message
    {
        int Operation(Object obj, string type);
        DataTable GetTech_message(Object obj, string type);
        DataTable GetTechMessage(tech_message model);
        tech_message GetModelById(string id);
    }
}
