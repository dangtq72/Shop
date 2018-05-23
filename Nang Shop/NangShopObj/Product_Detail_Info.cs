using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NangShopObj
{
    public class Product_Detail_Info
    {
        public string Name { get; set; } 

        public decimal Product_Id { get; set; }
        public decimal Color_Id { get; set; }
        public decimal Ri_Count { get; set; }
        public decimal Total_Count { get; set; }
        public decimal Total_Sale { get; set; }

        public string Size { get; set; } // Size áo (
        public string Color_Name { get; set; } // Màu áo ( Xanh | Đỏ | Cam )
        public decimal Remain_Count { get; set; }
             
    }
}
