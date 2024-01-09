using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface Itech_forbidden_word
    {
        int Operation(Object obj, string type);
        DataTable GetWord(tech_forbidden_word model);
        tech_forbidden_word GetWordByID(string id);
    }
}
