using IDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class tv_menuManager
    {
        private Itv_menu dal = null;
        /// <summary>
        /// 取得实例
        /// </summary>
        public tv_menuManager()
        {
            dal = BLLComm.GetClassInstance("tv_menu") as Itv_menu;
        }

        public DataTable Get_tv_menu(int menu_id)
        {
            return dal.Get_tv_menu(menu_id);
        }

        public DataTable Get_tv_menu(int menu_id, int sys_code)
        {
            return dal.Get_tv_menu(menu_id, sys_code);
        }

        public DataTable GetTv_menu(int sys_code)
        {
            return dal.GetTv_menu(sys_code);
        }
    }
}
