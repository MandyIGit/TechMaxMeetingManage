using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace IDAL
{
    public interface Itech_person_print
    {
        int Operation(Object obj, string type);
        DataTable Get_tech_person_print(Object obj, string type);
        DataTable GetTechPersonPrint(tech_person_print model);
        tech_person_print GetModelById(int id);
    }
}
