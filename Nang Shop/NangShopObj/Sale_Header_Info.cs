using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NangShopObj
{
    public class Sale_Header_Info
    {
        public int Sale_Header_Id { get; set; }
        public string SoHoaDon { get; set; }
        public int Customer_Id { get; set; }
        public int BranchId { get; set; }

        public decimal Pay_Type { get; set; } // Loại thanh toán
        public int SalesType { get; set; }

        public decimal Total_Amount { get; set; }
        public decimal Debt_Amount { get; set; }
        public decimal Ship_Price { get; set; }
        public decimal Per_Discont { get; set; }
        public decimal Per_Discount_Price { get; set; }
        public decimal Discount { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime Sale_Date { get; set; }

        public string Customer_Name { get; set; } // Tên khách hàng
        public string Address { get; set; } // Tên khách hàng
        public string Comment { get; set; }
        public string UserName { get; set; }

        public List<Product_Info> List_Product_Sale { get; set; } // Sản phẩn mua

        private string _str_SalesType;

        public string Str_SalesType
        {
            get {

                if (SalesType == 1)
                    return "Bán lẻ";
                else if (SalesType == 2)
                    return "Bán buôn";
                else return "Nothing";
            }
            set { _str_SalesType = value; }
        }
    }

    public class Sale_Detail_Info
    {
        public int Sale_Detail_Id { get; set; }
        public int Sale_Header_Id { get; set; }
        public int Product_Id { get; set; }

        public int Status { get; set; }

        public int Count { get; set; }
        public int Color_Id { get; set; }
    }
}
