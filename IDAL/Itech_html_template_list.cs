using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace IDAL
{
    public interface Itech_html_template_list
    {
        int Operation(Object obj, string type);
        DataTable GetTech_html_template_list(Object obj, string type);
        DataTable GetTechHtmlTemplateList(tech_html_template_list model);
        tech_html_template_list GetModelByMId(string mid);
        string Get_tm_id();
    }
}
