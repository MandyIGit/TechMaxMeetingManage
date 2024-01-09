using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace IDAL
{
    public interface Itech_admin
    {
        int Operation(Object obj, string type);
        tech_admin Login(string login_name, string login_pwd);
        tech_admin GetModel(int Admin_Code);
        DataTable GetTech_admin(Object obj, string type);
    }
}
