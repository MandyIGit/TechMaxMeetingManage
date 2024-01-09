using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace IDAL
{
    public interface Itech_project_manager
    {
        int Operation(Object obj, string type);
        DataTable GetTech_project_manager(Object obj, string type);
        tech_project_manager GetModelById(string id);
        tech_project_manager Login(string login_name, string login_pwd);        
    }
}
