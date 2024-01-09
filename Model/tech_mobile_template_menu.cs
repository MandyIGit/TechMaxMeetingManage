using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tech_mobile_template_menu
    {
        private int _menu_id;
        private int _mt_id;
        private string _menu_name;
        private string _menu_icon;
        private string _menu_url;
        private int _sort;

        public int menu_id
        {
            get { return _menu_id; }
            set { _menu_id = value; }
        }

        public int mt_id
        {
            get { return _mt_id; }
            set { _mt_id = value; }
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
