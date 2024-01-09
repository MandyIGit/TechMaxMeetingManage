using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace IDAL
{
    public interface Itech_article_type
    {
        int Operation(Object obj, string type);
        DataTable GetTech_article_type(Object obj, string type);
        DataTable GetTechArticleType(tech_article_type model);
        tech_article_type GetModelById(int id);
    }
}
