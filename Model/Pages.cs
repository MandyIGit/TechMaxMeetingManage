using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Pages
    {
        // Fields
        private string column;
        private int index;
        private int num;
        private string orderby;
        private string table;
        private string where;
        private string prikey;

        // Properties
        public string Column
        {
            get
            {
                return this.column;
            }
            set
            {
                this.column = value;
            }
        }
        public int Index
        {
            get
            {
                return this.index;
            }
            set
            {
                this.index = value;
            }
        }
        public int Num
        {
            get
            {
                return this.num;
            }
            set
            {
                this.num = value;
            }
        }
        public string Orderby
        {
            get
            {
                return this.orderby;
            }
            set
            {
                this.orderby = value;
            }
        }
        public string Table
        {
            get
            {
                return this.table;
            }
            set
            {
                this.table = value;
            }
        }
        public string Where
        {
            get
            {
                return this.where;
            }
            set
            {
                this.where = value;
            }
        }

        public string Prikey
        {
            get { return prikey; }
            set { prikey = value; }
        }
    }
}
