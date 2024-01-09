using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace IDAL
{
    public interface Iemail_template
    {
        int Operation(Object obj, string type);
        DataTable GetEmail_template(Object obj, string type);
        DataTable GetEmailTemplate(email_template model);
        email_template GetModelById(int id);
    }
}
