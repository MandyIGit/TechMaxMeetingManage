using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace IDAL
{
    public interface Itech_mobile_site_template
    {
        int Operation(Object obj, string type);
        tech_mobile_site_template GetModelByTemplateId(string id);
        DataTable GetTech_mobile_site_template(Object obj, string type);
    }
}
