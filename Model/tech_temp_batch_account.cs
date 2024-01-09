using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tech_temp_batch_account
    {
        private string _order_id;        
        private decimal _total_fee;
        private int _pay_type;
        private string _children_ids;
        private DateTime _input_time;

        public string order_id
        {
            get { return _order_id; }
            set { _order_id = value; }
        }
        public decimal total_fee
        {
            get { return _total_fee; }
            set { _total_fee = value; }
        }
        public int pay_type
        {
            get { return _pay_type; }
            set { _pay_type = value; }
        }
        public string children_ids
        {
            get { return _children_ids; }
            set { _children_ids = value; }
        }
        public DateTime input_time
        {
            get { return _input_time; }
            set { _input_time = value; }
        }
    }
}
