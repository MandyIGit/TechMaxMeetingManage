using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class tech_mobile_menu_content
    {
        private int _mc_id;
        private string _mc_title;
        private string _mc_msg;
        private int _menu_id;
        private int _isdel;
        private DateTime _inputtime;

        public int mc_id
        {
            get { return _mc_id; }
            set { _mc_id = value; }
        }

        public string mc_title
        {
            get { return _mc_title; }
            set { _mc_title = value; }
        }

        public string mc_msg
        {
            get { return _mc_msg; }
            set { _mc_msg = value; }
        }

        public int menu_id
        {
            get { return _menu_id; }
            set { _menu_id = value; }
        }

        public int isdel
        {
            get { return _isdel; }
            set { _isdel = value; }
        }

        public DateTime inputtime
        {
            get { return _inputtime; }
            set { _inputtime = value; }
        }
    }
}
