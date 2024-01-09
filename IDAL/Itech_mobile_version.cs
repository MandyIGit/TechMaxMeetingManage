using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface Itech_mobile_version
    {
        int Operation(object obj, string type);
        DataTable GetTech_mobile_version(Object obj, string type);
        tech_mobile_version GetModelByVersonId(string v_id);
    }
}
