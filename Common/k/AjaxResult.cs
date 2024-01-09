using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public class AjaxResult
    {
        private int _result;
        public int result
        {
            get { return this._result; }
            set { this._result = value; }
        }
        private string _msg;
        public string msg
        {
            get { return this._msg; }
            set { this._msg = value; }
        }
        private string _url;
        public string url
        {
            get { return this._url; }
            set { this._url = value; }
        }

        private Dictionary<string, object> _data = new Dictionary<string, object>();
        public Dictionary<string, object> data
        {
            get { return this._data; }
            set { this._data = value; }
        }

        private object _list;
        public object list
        {
            get { return this._list; }
            set { this._list = value; }
        }
        public AjaxResult()
        {
            result = 1;
            msg = "成功";
        }
        public AjaxResult(int result, string msg = "")
        {
            this.result = result;
            this.msg = msg;
        }
    }
}
