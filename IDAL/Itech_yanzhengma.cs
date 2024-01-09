using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace IDAL
{
    public interface Itech_yanzhengma
    {
        int Operation(tech_yanzhengma info, string type);

        DataTable GetTech_yanzhengma(tech_yanzhengma info);

        tech_yanzhengma getModel(string mobile, int yanzhengma);
    }
}
