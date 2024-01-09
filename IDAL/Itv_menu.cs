using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IDAL
{
    public interface Itv_menu
    {
        DataTable Get_tv_menu(int menu_id);
        DataTable Get_tv_menu(int menu_id, int sys_code);
        DataTable GetTv_menu(int sys_code);
    }
}
