using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NangShopObj
{
    public class Function_GroupInfo
    {
        private decimal _user_type;
        public decimal user_type
        {
            get { return _user_type; }
            set { _user_type = value; }
        }

        private string _functionid;
        public string functionid
        {
            get { return _functionid; }
            set { _functionid = value; }
        }
    }

}
