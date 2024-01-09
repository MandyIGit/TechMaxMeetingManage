using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tech_cart
    {
        private string order_id;
        private string user_id;
        private string children_ids;
        private decimal total_fee;
        private int pay_type;
        private int status;
        private DateTime inputtime;
        private DateTime paytime;
        private string third_id;
        private string mid;
        private string mtype_id;

        public string Mid
        {
            get { return mid; }
            set { mid = value; }
        }

        public string Mtype_id
        {
            get { return mtype_id; }
            set { mtype_id = value; }
        }

        /// <summary>
        /// 订单ID
        /// </summary>
        public string Order_id
        {
            get { return order_id; }
            set { order_id = value; }
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public string User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        /// <summary>
        /// 订单的子id集合
        /// </summary>
        public string Children_ids
        {
            get { return children_ids; }
            set { children_ids = value; }
        }

        /// <summary>
        /// 总费用
        /// </summary>
        public decimal Total_fee
        {
            get { return total_fee; }
            set { total_fee = value; }
        }

        /// <summary>
        /// 支付类型
        /// </summary>
        public int Pay_type
        {
            get { return pay_type; }
            set { pay_type = value; }
        }

        /// <summary>
        /// 支付状态：1已支付；2未支付
        /// </summary>
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime Inputtime
        {
            get { return inputtime; }
            set { inputtime = value; }
        }

        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime Paytime
        {
            get { return paytime; }
            set { paytime = value; }
        }

        /// <summary>
        /// 第三方订单ID
        /// </summary>
        public string Third_id
        {
            get { return third_id; }
            set { third_id = value; }
        }

    }
}
