using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface Itech_mobile_template_menu
    {
        IList<tech_mobile_template_menu> GetMenuList(string mt_id);

        int ModifyMenu(tech_mobile_template_menu menu);

        int Delete(int menuid);

        tech_mobile_template_menu GetModel(int menuid);
    }
}
