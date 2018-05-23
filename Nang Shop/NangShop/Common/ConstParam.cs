using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NangShop.Common
{
    //dùng cho biết const
    public static class ConstParam
    {
        public static string c_str_KN_Debt = "RD"; // nghĩa là tiền Kuong Ngan nợ trong thu chi
        public static string c_str_Receive = "R"; // nghĩa là tiền Kuong Ngan trả nợ trong thu chi

        public static string c_str_Sales_Debt = "SD"; // nghĩa là khách hàng nợ Kuong Ngan
        public static string c_str_Sales = "S"; // nghĩa là tiền khách hàng trả nợ trong bảng thu chi (thiết kế hơi ngược)

        public static string c_str_Customer_BanLe = "R";
        public static string c_str_Customer_BanBuon = "W"; // nghĩa là thu tiền trong bảng thu chi (thiết kế hơi ngược)

        public static string c_str_Status_D = "D";
        public static string c_str_Status_L = "L";
        public static string c_str_Status_O = "O";
        public static string c_str_Status_I = "I";

        public static string c_str_Status_C = "C"; 

        // kí hiệu kiểu thanh toán
    }
}
