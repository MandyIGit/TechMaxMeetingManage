using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace IDAL
{
    public interface Itech_mobile_menu_content
    {
        int ModifyModel(tech_mobile_menu_content model);
        tech_mobile_menu_content GetModelByMcId(string mc_id);
        DataTable GetTech_mobile_menu_content(Object obj, string type);
    }
}
