using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace IDAL
{
    public interface Itech_temp_batch_account
    {
        int Operation(object obj, string type);
        List<tech_temp_batch_account> GetTechTempBatchAccount();
        tech_temp_batch_account GetModelByOrderId(string order_id);
    }
}
