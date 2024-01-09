using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace IDAL
{
    public interface Itech_published_form
    {
        int Operation(Object obj, string type);
        DataTable GetTech_published_form(Object obj, string type);
        DataTable GetTechPublishedForm(tech_published_form model);
        tech_published_form GetModelById(int id);
    }
}
