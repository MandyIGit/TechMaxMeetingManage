using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class tech_mobile_menuManager
    {
        private Itech_mobile_menu dal = null;
        public tech_mobile_menuManager()
        {
            dal = BLLComm.GetClassInstance("tech_mobile_menu") as Itech_mobile_menu;
        }

        static readonly private tech_mobile_menuManager _instance = new tech_mobile_menuManager();
        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_mobile_menuManager Instance
        {
            get { return _instance; }
        }

        public IList<tech_mobile_menu> GetMenuList(string mid)
        {
            return dal.GetMenuList(mid);
        }

        public int ModifyMenu(tech_mobile_menu menu)
        {
            return dal.ModifyMenu(menu);
        }

        public int Delete(int menuid)
        {
            return dal.Delete(menuid);
        }

        public int SetBanStatu(int menuid)
        {
            return dal.SetBanStatu(menuid);
        }

        public tech_mobile_menu GetModel(int menuid)
        {
            return dal.GetModel(menuid);
        }

        public tech_mobile_menu GetUpModel(int sort, string mid)
        {
            return dal.GetUpModel(sort, mid);
        }

        public tech_mobile_menu GetDownModel(int sort, string mid)
        {
            return dal.GetDownModel(sort, mid);
        }

    }
}
