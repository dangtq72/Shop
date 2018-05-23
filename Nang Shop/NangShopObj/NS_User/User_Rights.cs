using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NangShopObj
{
    public class User_RightsInfo
    {
        private decimal _id;
        private decimal _userid;
        private string _funcid;
        private string _authcode;
        private string _notes;
        private decimal _deleted;
        private string _created_by;
        private DateTime _created_date;
        private string _modified_by;
        private DateTime _modified_date;

        public decimal id
        {
            get { return _id; }
            set { _id = value; }
        }

        public decimal userid
        {
            get { return _userid; }
            set { _userid = value; }
        }

        public string funcid
        {
            get { return _funcid; }
            set { _funcid = value; }
        }

        public string authcode
        {
            get { return _authcode; }
            set { _authcode = value; }
        }

        public string notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        public decimal deleted
        {
            get { return _deleted; }
            set { _deleted = value; }
        }

        public string created_by
        {
            get { return _created_by; }
            set { _created_by = value; }
        }

        public DateTime created_date
        {
            get { return _created_date; }
            set { _created_date = value; }
        }

        public string modified_by
        {
            get { return _modified_by; }
            set { _modified_by = value; }
        }

        public DateTime modified_date
        {
            get { return _modified_date; }
            set { _modified_date = value; }
        }
    }

    public class User_FunctionsInfo
    {
        private string _functionId;
        private decimal _groupId;
        private decimal _use_right;
        private decimal _view_right;
        private decimal _insert_right;
        private decimal _update_right;
        private decimal _delete_right;
        private decimal _approveInfo_right;
        private string _right;
        private string _name;
        private string _name_eng;
        private decimal _lev;
        private string _prid;
        private string _last;
        private System.Windows.Visibility _Show;
        private decimal _Full_Right;
        private System.Windows.Media.Brush _br_n;

        public User_FunctionsInfo()
        {

        }
        public User_FunctionsInfo(User_FunctionsInfo p_copy)
        {
            //User_FunctionsInfo _User_FunctionsInfo = new User_FunctionsInfo();
            this._functionId = p_copy.functionId;
            this._groupId = p_copy._groupId;
            this._use_right = p_copy._use_right;
            this._view_right = p_copy._view_right;
            this._insert_right = p_copy._insert_right;
            this._update_right = p_copy._update_right;
            this._delete_right = p_copy._delete_right;

            this._approveInfo_right = p_copy._approveInfo_right;
            this._right = p_copy._right;
            this._name = p_copy._name;
            this._name_eng = p_copy._name_eng;
            this._lev = p_copy._lev;
            this._prid = p_copy._prid;
            this._last = p_copy._last;
            this._Show = p_copy._Show;
            this._Full_Right = p_copy._Full_Right;
            this._br_n = p_copy._br_n;

            //return _User_FunctionsInfo;
        }

        public string functionId
        {
            get { return _functionId; }
            set { _functionId = value; }
        }

        public decimal groupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }

        public decimal use_right
        {
            get
            {
                return _use_right;
            }
            set
            {
                _use_right = value;
                _right = _use_right.ToString() + _view_right.ToString() + _insert_right.ToString() + _update_right.ToString()
                    + _delete_right.ToString() + _approveInfo_right.ToString();
                if (_right == "111111")
                {
                    _Full_Right = 1;
                }
                else if (_right == "000000")
                {
                    _Full_Right = 0;
                }
            }
        }

        public decimal view_right
        {
            get
            {
                return _view_right;
            }
            set
            {
                _view_right = value;
                _right = _use_right.ToString() + _view_right.ToString() + _insert_right.ToString() + _update_right.ToString()
                    + _delete_right.ToString() + _approveInfo_right.ToString();
                if (_right == "111111")
                {
                    _Full_Right = 1;
                }
                else if (_right == "000000")
                {
                    _Full_Right = 0;
                }
            }
        }

        public decimal insert_right
        {
            get
            {
                return _insert_right;
            }
            set
            {
                _insert_right = value;
                _right = _use_right.ToString() + _view_right.ToString() + _insert_right.ToString() + _update_right.ToString()
                    + _delete_right.ToString() + _approveInfo_right.ToString();
                if (_right == "111111")
                {
                    _Full_Right = 1;
                }
                else if (_right == "000000")
                {
                    _Full_Right = 0;
                }
            }
        }

        public decimal update_right
        {
            get
            {
                return _update_right;
            }
            set
            {
                _update_right = value;
                _right = _use_right.ToString() + _view_right.ToString() + _insert_right.ToString() + _update_right.ToString()
                    + _delete_right.ToString() + _approveInfo_right.ToString();
                if (_right == "111111")
                {
                    _Full_Right = 1;
                }
                else if (_right == "000000")
                {
                    _Full_Right = 0;
                }
            }
        }

        public decimal delete_right
        {
            get
            {
                return _delete_right;
            }
            set
            {
                _delete_right = value;
                _right = _use_right.ToString() + _view_right.ToString() + _insert_right.ToString() + _update_right.ToString()
                    + _delete_right.ToString() + _approveInfo_right.ToString();
                if (_right == "111111")
                {
                    _Full_Right = 1;
                }
                else if (_right == "000000")
                {
                    _Full_Right = 0;
                }
            }
        }

        public decimal approveInfo_right
        {
            get
            {
                return _approveInfo_right;
            }
            set
            {
                _approveInfo_right = value;
                _right = _use_right.ToString() + _view_right.ToString() + _insert_right.ToString() + _update_right.ToString()
                    + _delete_right.ToString() + _approveInfo_right.ToString();
                if (_right == "111111")
                {
                    _Full_Right = 1;
                }
                else if (_right == "000000")
                {
                    _Full_Right = 0;
                }
            }
        }

        public decimal lev
        {
            get { return _lev; }
            set { _lev = value; }
        }

        public string prid
        {
            get { return _prid; }
            set { _prid = value; }
        }

        public string right
        {
            get { return _right; }
            set { _right = value; }
        }

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Name_Eng
        {
            get { return _name_eng; }
            set { _name_eng = value; }
        }

        public System.Windows.Visibility Show
        {
            get
            {
                return _Show;
            }
            set { _Show = value; }
        }

        public string last
        {
            get { return _last; }
            set { _last = value; }
        }

        public decimal Full_Right
        {
            get { return _Full_Right; }
            set { _Full_Right = value; }
        }

        public System.Windows.Media.Brush Br_N
        {
            get
            {
                return _br_n;
            }
            set { _br_n = value; }
        }
    }
}
