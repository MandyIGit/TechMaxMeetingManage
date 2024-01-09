using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class tech_mobile_type_menu
    {
        private int _menu_id;
        private int _mtype_id;
        private string _menu_name;
        private string _menu_icon;
        private string _menu_url;
        private int _sort;

        public int menu_id
        {
            get { return _menu_id; }
            set { _menu_id = value; }
        }

        public int mtype_id
        {
            get { return _mtype_id; }
            set { _mtype_id = value; }
        }

        public string menu_name
        {
            get { return _menu_name; }
            set { _menu_name = value; }
        }

        public string menu_icon
        {
            get { return _menu_icon; }
            set { _menu_icon = value; }
        }

        public string menu_url
        {
            get { return _menu_url; }
            set { _menu_url = value; }
        }

        public int sort
        {
            get { return _sort; }
            set { _sort = value; }
        }
    }
}
