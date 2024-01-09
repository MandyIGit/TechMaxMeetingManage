using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface Itech_mobile_menu
    {
        IList<tech_mobile_menu> GetMenuList(string mid);

        int ModifyMenu(tech_mobile_menu menu);

        int Delete(int menuid);

        int SetBanStatu(int menuid);

        tech_mobile_menu GetModel(int menuid);

        tech_mobile_menu GetUpModel(int sort, string mid);

        tech_mobile_menu GetDownModel(int sort, string mid);
    }
}
