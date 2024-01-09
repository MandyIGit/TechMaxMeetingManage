using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace IDAL
{
    public interface Itech_mobile_template
    {
        int Operation(Object obj, string type);
        tech_mobile_template GetModelByMTemplateId(string mtemplate_id);
        DataTable GetTech_mobile_template(Object obj, string type);
    }
}
