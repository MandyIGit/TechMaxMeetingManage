using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace IDAL
{
    public interface Itech_html_template
    {
        int Operation(Object obj, string type);
        DataTable GetTech_html_template(Object obj, string type);
        DataTable GetTechHtmlTemplate(tech_html_template model);
        tech_html_template GetModelByTId(int t_id);
        string Get_tm_id();
    }
}
