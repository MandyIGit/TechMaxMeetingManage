using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface Itech_operating_record
    {
        int Operating(tech_operating_record info, string type);

        DataTable GetTech_operation_record(Object obj, string type);
    }
}
