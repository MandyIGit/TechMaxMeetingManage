using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface Itech_mobile_type_menu
    {
        IList<tech_mobile_type_menu> GetMenuList(string mtype_id);

        int ModifyMenu(tech_mobile_type_menu menu);

        int Delete(int menuid);

        tech_mobile_type_menu GetModel(int menuid);

    }
}
