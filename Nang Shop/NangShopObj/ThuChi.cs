using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NangShopObj
{
    public class ThuChi_Info
    {
        public decimal ID { get; set; }
        public string SoHoadon { get; set; }
        public DateTime Create_Date { get; set; }
        public int ThuChi { get; set; } // 0 là chi, 1 là thu
        public decimal Price { get; set; }
        public string DienGiai { get; set; }
        public int Customer_Id { get; set; }
        public int Supplier_Id { get; set; }
    }
}
