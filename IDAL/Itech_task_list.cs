using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface Itech_task_list
    {
        int Operation(tech_task_list info, string type);

        int GetTech_task_list_count(tech_task_list info);

        DataTable GetTech_task_list(tech_task_list info, int pageIndex, int pageSize);

        DataTable GetTech_task_list(tech_task_list info);

        DataTable GetTech_task_list(tech_task_list info, string type);

        tech_task_list GetModel(string id);
    }
}
