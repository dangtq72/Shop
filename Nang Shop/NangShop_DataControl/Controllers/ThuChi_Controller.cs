using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using NangShopObj;

namespace NangShop_DataControl
{
    public class ThuChi_Controller
    {
        public bool ThuChi_Insert(ThuChi_Info p_ThuChi_Info)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[7];

                int i = 0;
                spParameter[i] = new SqlParameter("@SoHoadon", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_ThuChi_Info.SoHoadon;

                i++;
                spParameter[i] = new SqlParameter("@Create_Date", SqlDbType.DateTime);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_ThuChi_Info.Create_Date;

                i++;
                spParameter[i] = new SqlParameter("@ThuChi", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_ThuChi_Info.ThuChi;

                i++;
                spParameter[i] = new SqlParameter("@Price", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_ThuChi_Info.Price;

                i++;
                spParameter[i] = new SqlParameter("@DienGiai", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_ThuChi_Info.DienGiai;

                i++;
                spParameter[i] = new SqlParameter("@Customer_Id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_ThuChi_Info.Customer_Id;

                i++;
                spParameter[i] = new SqlParameter("@Supplier_Id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_ThuChi_Info.Supplier_Id;


                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_ThuChi_Insert", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Update số lượng bán vào bảng Product
        /// </summary>
        public bool Update_Product_Sale_Count(int p_product_id, int p_sale_count,int p_color_id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[3];

                int i = 0;
                spParameter[i] = new SqlParameter("@Product_Id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_product_id;

                i++;
                spParameter[i] = new SqlParameter("@Sale_count", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_sale_count;

                i++;
                spParameter[i] = new SqlParameter("@Color_id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_color_id;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_update_sale_Count", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

    }
}
