using System;
using System.Linq;
using System.Text;
using NangShopObj;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace NangShop_DataControl
{
    public class Sale_Header_Controller
    {
        public bool Sale_Header_Insert(Sale_Header_Info p_Sale_Header_Info, ref decimal _id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[16];

                int i = 0;
                spParameter[i] = new SqlParameter("@Customer_Id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Sale_Header_Info.Customer_Id;

                i++;
                spParameter[i] = new SqlParameter("@BranchId", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Sale_Header_Info.BranchId;

                i++;
                spParameter[i] = new SqlParameter("@Sale_Date", SqlDbType.DateTime);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Sale_Header_Info.Sale_Date;

                i++;
                spParameter[i] = new SqlParameter("@SalesType", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Sale_Header_Info.SalesType;

                i++;
                spParameter[i] = new SqlParameter("@Total_Amount", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Sale_Header_Info.Total_Amount;

                i++;
                spParameter[i] = new SqlParameter("@Debt_Amount", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Sale_Header_Info.Debt_Amount;

                i++;
                spParameter[i] = new SqlParameter("@UserName", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Sale_Header_Info.UserName;

                i++;
                spParameter[i] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Sale_Header_Info.CreatedDate;

                i++;
                spParameter[i] = new SqlParameter("@Comment", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Sale_Header_Info.Comment;

                i++;
                spParameter[i] = new SqlParameter("@SoHoaDon", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Sale_Header_Info.SoHoaDon;

                i++;
                spParameter[i] = new SqlParameter("@Ship_Price", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Sale_Header_Info.Ship_Price;

                i++;
                spParameter[i] = new SqlParameter("@Per_Discont", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Sale_Header_Info.Per_Discont;

                i++;
                spParameter[i] = new SqlParameter("@Discount", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Sale_Header_Info.Discount;

                i++;
                spParameter[i] = new SqlParameter("@Pay_Type", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Sale_Header_Info.Pay_Type;

                i++;
                spParameter[i] = new SqlParameter("@Per_Discount_Price", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Sale_Header_Info.Per_Discount_Price;

                i++;
                spParameter[i] = new SqlParameter("@Sale_Header_Id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Output;
                spParameter[i].Value = _id;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Sale_Header_Insert", spParameter);
                _id = Convert.ToDecimal(spParameter[i].Value);

                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        public bool Sale_Detail_Insert(Sale_Detail_Info p_Sale_Detail_Info, decimal p_Sale_Header_Id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[5];

                int i = 0;
                spParameter[i] = new SqlParameter("@Sale_Header_Id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Sale_Header_Id;

                i++;
                spParameter[i] = new SqlParameter("@Product_Id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Sale_Detail_Info.Product_Id;

                i++;
                spParameter[i] = new SqlParameter("@Status", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Sale_Detail_Info.Status;

                i++;
                spParameter[i] = new SqlParameter("@Count", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Sale_Detail_Info.Count;

                i++;
                spParameter[i] = new SqlParameter("@Color_Id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Sale_Detail_Info.Color_Id;


                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Sale_Detail_Insert", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        public decimal Sale_Header_Get_Max_Id()
        {
            try
            {

                SqlParameter[] spParameter = new SqlParameter[1];

                spParameter[0] = new SqlParameter("@Sale_Header_Id", SqlDbType.Int);
                spParameter[0].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_SaleHeader_Get_Max_Id", spParameter);

                return Convert.ToDecimal(spParameter[0].Value);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return 0;
            }
        }

        public bool Sale_Header_Delete(decimal Sale_Header_Id)
        {
            try
            {

                SqlParameter[] spParameter = new SqlParameter[1];

                spParameter[0] = new SqlParameter("@Sale_Header_Id", SqlDbType.Int);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = Sale_Header_Id;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Sale_Header_Delete", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        public List<Sale_Header_Info> Sale_Header_Search(string p_sohd, string p_date,string p_date_to, string p_customer,int p_type)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[5];

                int i = 0;
                spParameter[i] = new SqlParameter("@SoHoaDon", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_sohd;

                i++;
                spParameter[i] = new SqlParameter("@Sale_Date", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_date;

                i++;
                spParameter[i] = new SqlParameter("@Sale_Date_To", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_date_to;

                i++;
                spParameter[i] = new SqlParameter("@Customer_Name", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_customer;

                i++;
                spParameter[i] = new SqlParameter("@SalesType", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_type.ToString();

                DataSet ds = SqlHelper.ExecuteDataset(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Sale_Header_Search", spParameter);
                return CBO<Sale_Header_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new List<Sale_Header_Info>();
            }
        }

        public List<Product_Info> Get_Product_By_Sale_Header(string p_sohd)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];

                int i = 0;
                spParameter[i] = new SqlParameter("@SoHoaDon", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_sohd;

                DataSet ds = SqlHelper.ExecuteDataset(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_get_Product_By_SHD", spParameter);
                return CBO<Product_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new List<Product_Info>();
            }
        }

        public bool Change_Product_ByHeader_New(Sale_Header_Info p_Sale_Header_Info, int p_new_product_id,
             decimal p_new_count, decimal p_per_discount, decimal p_new_total_amount, DateTime p_modifi_date)
        {
            try
            {

                SqlParameter[] spParameter = new SqlParameter[7];

                int i = 0; // 1
                spParameter[i] = new SqlParameter("@SoHoaDon", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Sale_Header_Info.SoHoaDon;

                i++;//2
                spParameter[i] = new SqlParameter("@Sale_Header_Id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Sale_Header_Info.Sale_Header_Id;

                i++; //3
                spParameter[i] = new SqlParameter("@New_Product_Id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_new_product_id;

                i++; //4
                spParameter[i] = new SqlParameter("@New_Count", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_new_count;

                i++; //5
                spParameter[i] = new SqlParameter("@Per_Discount", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_per_discount;

                i++; //6
                spParameter[i] = new SqlParameter("@New_Total_Price", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_new_total_amount;

                i++; //7
                spParameter[i] = new SqlParameter("@Modifi_Date", SqlDbType.Date);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_modifi_date;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Change_Product_By_Header", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        public bool Change_Product_ByHeader_Old(Sale_Header_Info p_Sale_Header_Info, decimal p_old_product_id, decimal p_old_count, 
            decimal p_new_total_amount, DateTime p_modifi_date)
        {
            try
            {

                SqlParameter[] spParameter = new SqlParameter[6];

                int i = 0; // 1
                spParameter[i] = new SqlParameter("@SoHoaDon", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Sale_Header_Info.SoHoaDon;

                i++;//2
                spParameter[i] = new SqlParameter("@Sale_Header_Id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Sale_Header_Info.Sale_Header_Id;

                i++; //3
                spParameter[i] = new SqlParameter("@Old_Product_Id", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_old_product_id;

                i++; //4
                spParameter[i] = new SqlParameter("@New_Count", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_old_count;

                i++; //5
                spParameter[i] = new SqlParameter("@New_Total_Price", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_new_total_amount;

                i++; //6
                spParameter[i] = new SqlParameter("@Modifi_Date", SqlDbType.Date);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_modifi_date;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Change_Product_By_Header_Old", spParameter);

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
