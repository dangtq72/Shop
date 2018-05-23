using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NangShopObj
{

    /// <summary>
    /// Chi tiết áo
    /// </summary>
    public class Detail_Items_Info
    {
        public decimal Detail_Id { get; set; }  // lô áo
        public decimal Product_Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; } // Mô tả

        public decimal Sale_Price_Expect { get; set; } // Giá bán dự kiến
        public decimal Sale_Price { get; set; } // Giá bán thực
        public decimal Per_Discount { get; set; } // triết khấu trên từng sản phẩm

        public decimal Status { get; set; } // trạng thái bán
        public string Size { get; set; }
        public decimal Color_Id { get; set; }

        public bool IsCheck { get; set; }
    }
}
