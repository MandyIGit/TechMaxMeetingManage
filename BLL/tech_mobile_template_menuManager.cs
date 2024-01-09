using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class tech_mobile_template_menuManager
    {
        private Itech_mobile_template_menu dal = null;

        public tech_mobile_template_menuManager()
        {
            dal = BLLComm.GetClassInstance("tech_mobile_template_menu") as Itech_mobile_template_menu;
        }

        static readonly private tech_mobile_template_menuManager _instance = new tech_mobile_template_menuManager();
        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_mobile_template_menuManager Instance
        {
            get { return _instance; }
        }

        public IList<tech_mobile_template_menu> GetMenuList(string mtype_id)
        {
            return dal.GetMenuList(mtype_id);
        }

        public int ModifyMenu(tech_mobile_template_menu menu)
        {
            return dal.ModifyMenu(menu);
        }

        public int Delete(int menuid)
        {
            return dal.Delete(menuid);
        }

        public tech_mobile_template_menu GetModel(int menuid)
        {
            return dal.GetModel(menuid);
        }
    }
}
