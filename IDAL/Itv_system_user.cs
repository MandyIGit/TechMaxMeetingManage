using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface Itv_system_user
    {
        DataTable GetTv_system_user(tv_system_user info);

        DataTable GetTv_system_user(tv_system_user info, int pageIndex, int pageSize);

        int GetTv_system_user_count(tv_system_user info);

        int Add_Update(tv_system_user info, string type);

        int Delete_system_user(string id_array, string mid);
    }
}
