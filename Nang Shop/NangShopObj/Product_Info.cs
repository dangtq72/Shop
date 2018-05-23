using System;
using System.Collections.Generic;
using System.Text;

namespace NangShopObj
{
    /// <summary>
    /// Lô áo nhập về
    /// </summary>
    public class Product_Info
    {
        public int Product_Id { get; set; }

        public string Product_Code { get; set; }
        public string Name { get; set; } // Tên áo
        public string Note { get; set; } // Mô tả

        public decimal Deleted { get; set; }

        public decimal Category_Id { get; set; } // Loại (áo,váy quần ...)
        public DateTime Receive_Date { get; set; } // Ngày nhập
        public decimal Receive_Price { get; set; } // Giá nhập
        public decimal Sale_Price_Expect { get; set; } // Giá bán dự kiến

        public string Size { get; set; } // Size áo (

        public decimal Color_Id { get; set; } // Màu áo ( 1 | 2 | 3 )
        public string Color_Name { get; set; } // Màu áo ( Xanh | Đỏ | Cam )

        /// <summary>
        /// Số áo trên 1 Ri
        /// </summary>
        public decimal Receive_Count { get; set; } // Số lượng nhập
        public decimal Count_by_Ri { get; set; } // Số áo / dây 

        public string Receive_Adress { get; set; } // Nhập hàng ở đâu
        public decimal Supplier_Id { get; set; }  // Nhà cung cấp

        public decimal Per_BanLe { get; set; } // tỷ lệ bán lẻ
        public decimal BanLe_Price { get; set; } // giá bán lẻ = tỷ lệ bán lẻ * giá nhập

        public decimal Per_BanBuon { get; set; } // tỷ lệ bán buôn
        public decimal BanBuon_Price { get; set; } // giá bán buôn = tỷ lệ bán lẻ * giá nhập

        public decimal Count_Ri_by_Color { get; set; } // Số ri có / màu
        public decimal Is_XuatDu { get; set; }
        public int Unit { get; set; }
        public string Unit_Name { get; set; }
        public decimal Total_Receive { get; set; } // tổng số áo nhập
        public decimal Total_Sale { get; set; } // tổng số áo đã bán
        public decimal Total_Remain { get; set; } // tổng số áo còn lại
        public decimal Ship_Price { get; set; }


        public string Supplier_Name { get; set; }
        public string Phone { get; set; }
        public string Category_Name { get; set; }
        public string User_Name { get; set; }
        public decimal Count_Sale_By_Header { get; set; }  // số lượng mua / hóa đơn
        public decimal Total_Price { get; set; }  // tiền / hóa đơn

        private string _Status_Name;
        public string Status_Name
        {
            get
            {

                if (Total_Remain > 0)
                    return "Còn hàng";
                else return "Hết hàng";
            }
            set { _Status_Name = value; }
        }

        private int _Status_Remain;
        public int Status_Remain
        {
            get
            {

                if (Total_Remain > 0)
                    return 1;
                else return 0;
            }
            set { _Status_Remain = value; }
        }

        public int SalesType { get; set; }

        //private decimal _Total_Price_By_Header;
        //public decimal Total_Price_By_Header
        //{
        //    get
        //    {
        //        if (SalesType == 1) // bán lẻ
        //        {
        //            return Count_Sale_By_Header * BanLe_Price;
        //        }
        //        else if (SalesType == 2) // bán buôn
        //        {
        //            return Count_Sale_By_Header * BanBuon_Price;
        //        }
        //        else
        //            return Receive_Price * BanBuon_Price;
        //    }
        //    set { _Total_Price_By_Header = value; }
        //}

        private decimal _DonGia_By_Type;
        public decimal DonGia_By_Type
        {
            get
            {
                if (SalesType == 1) // bán lẻ
                {
                    return BanLe_Price;
                }
                else if (SalesType == 2) // bán buôn
                {
                    return BanBuon_Price;
                }
                else
                    return _DonGia_By_Type;
            }
            set { _DonGia_By_Type = value; }
        }


        /// <summary>
        /// 0 là bình thường ,1 là thêm hàng mới, 2 là trả hàng
        /// </summary>
        public decimal Change_Type { get; set; }
    }
}
