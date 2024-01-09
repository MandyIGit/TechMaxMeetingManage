using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace IDAL
{
    public interface Itech_mobile_type
    {
        int Operation(Object obj, string type);
        tech_mobile_type GetModelByTypeId(string type_id);
        DataTable GetTech_mobile_type(Object obj, string type);
    }
}
