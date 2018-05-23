using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NangShopObj
{
    public class Customer_Info
    {
        public int Customer_Id {get;set;}
        public string Customer_Name {get;set;}
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Deleted { get; set; }
    }

    public class Customer_Buy_Product_Info
    {
        public int Customer_Id { get; set; }
        public string SoHoaDon { get; set; }
        public DateTime Sale_Date { get; set; }
        public decimal Total_Amount { get; set; }
        public decimal Ship_Price { get; set; }

        public decimal Discount { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
