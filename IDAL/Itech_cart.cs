using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface Itech_cart
    {
        tech_cart GetTech_cart(Object obj, string type);
    }
}
