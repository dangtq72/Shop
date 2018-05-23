using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NangShopObj;

namespace NangShop_DataControl
{
    public class Detail_Item_Controller
    {
        public List<Detail_Items_Info> Get_All()
        {
            try
            {
                return new List<Detail_Items_Info>();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new List<Detail_Items_Info>();
            }
        }

        public List<Detail_Items_Info> Get_By_Product(decimal p_Product_Id)
        {
            try
            {
                return new List<Detail_Items_Info>();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new List<Detail_Items_Info>();
            }
        }
    }
}
