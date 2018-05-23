using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NangShopObj;
using System.Data.SqlClient;
using System.Data;

namespace NangShop_DataControl
{
    public class Product_Controller
    {
        public List<Product_Info> Get_All()
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[0];

                DataSet ds = SqlHelper.ExecuteDataset(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Product_GetAll", spParameter);
                return CBO<Product_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new List<Product_Info>();
            }
        }

        public List<Product_Info> Get_By_Category(decimal p_Category_Id)
        {
            try
            {
                return new List<Product_Info>();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new List<Product_Info>();
            }
        }

        public bool Product_Insert(Product_Info p_Product_Info, ref decimal _id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[21];

                int i = 0;
                spParameter[i] = new SqlParameter("@Name", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Product_Info.Name;

                i++;//2
                spParameter[i] = new SqlParameter("@Note", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Product_Info.Note;

                i++;//3
                spParameter[i] = new SqlParameter("@Category_Id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Product_Info.Category_Id;


                i++;//4
                spParameter[i] = new SqlParameter("@Receive_Date", SqlDbType.Date);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Product_Info.Receive_Date;


                i++;//5
                spParameter[i] = new SqlParameter("@Receive_Price", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Product_Info.Receive_Price;


                i++;//6
                spParameter[i] = new SqlParameter("@Per_BanLe", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Product_Info.Per_BanLe;
                
                i++;//7
                spParameter[i] = new SqlParameter("@BanLe_Price", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Product_Info.BanLe_Price;


                i++;//8
                spParameter[i] = new SqlParameter("@Per_BanBuon", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Product_Info.Per_BanBuon;

                i++;//9
                spParameter[i] = new SqlParameter("@BanBuon_Price", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Product_Info.BanBuon_Price;

                i++;//10
                spParameter[i] = new SqlParameter("@Receive_Count", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Product_Info.Receive_Count;

                i++;//11
                spParameter[i] = new SqlParameter("@Count_by_Ri", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Product_Info.Count_by_Ri;

                i++;//12
                spParameter[i] = new SqlParameter("@Supplier_Id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Product_Info.Supplier_Id;

                i++;//13
                spParameter[i] = new SqlParameter("@Is_XuatDu", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Product_Info.Is_XuatDu;

                i++;//14
                spParameter[i] = new SqlParameter("@Color_Name", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Product_Info.Color_Name;

                i++;//15
                spParameter[i] = new SqlParameter("@Total_Receive", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Product_Info.Total_Receive;

                i++;//16        
                spParameter[i] = new SqlParameter("@Ship_Price", SqlDbType.Decimal);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Product_Info.Ship_Price;

                i++;//17
                spParameter[i] = new SqlParameter("@Product_Code", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Product_Info.Product_Code;

                i++;
                spParameter[i] = new SqlParameter("@Size", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Product_Info.Size;

                i++;//18
                spParameter[i] = new SqlParameter("@Unit", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Product_Info.Unit;

                i++;//19
                spParameter[i] = new SqlParameter("@User_Name", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_Product_Info.User_Name;

                i++;//20
                spParameter[i] = new SqlParameter("@Product_Id", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Output;
                spParameter[i].Value = _id;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Product_Insert", spParameter);

                _id = Convert.ToDecimal(spParameter[i].Value);

                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        public decimal Product_Get_Max_Id()
        {
            try
            {

                SqlParameter[] spParameter = new SqlParameter[1];

                spParameter[0] = new SqlParameter("@Product_Id", SqlDbType.Int);
                spParameter[0].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Product_Get_Max_Id", spParameter);

                return Convert.ToDecimal(spParameter[0].Value);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return 0;
            }
        }

        public bool Product_Delete(decimal p_Product_Info_id)
        {
            try
            {

                SqlParameter[] spParameter = new SqlParameter[1];

                spParameter[0] = new SqlParameter("@Product_Id", SqlDbType.Int);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Product_Info_id;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Product_Delete", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        public bool Product_Detail_Insert(Product_Detail_Info p_Product_Detail_Info)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[6];

                spParameter[0] = new SqlParameter("@Product_Id", SqlDbType.Int);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Product_Detail_Info.Product_Id;

                spParameter[1] = new SqlParameter("@Color_Id", SqlDbType.Int);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = p_Product_Detail_Info.Color_Id;

                spParameter[2] = new SqlParameter("@Ri_Count", SqlDbType.Int);
                spParameter[2].Direction = ParameterDirection.Input;
                spParameter[2].Value = p_Product_Detail_Info.Ri_Count;

                spParameter[3] = new SqlParameter("@Total_Count", SqlDbType.Int);
                spParameter[3].Direction = ParameterDirection.Input;
                spParameter[3].Value = p_Product_Detail_Info.Total_Count;

                spParameter[4] = new SqlParameter("@Name", SqlDbType.NVarChar);
                spParameter[4].Direction = ParameterDirection.Input;
                spParameter[4].Value = p_Product_Detail_Info.Name;

                spParameter[5] = new SqlParameter("@Size", SqlDbType.NVarChar);
                spParameter[5].Direction = ParameterDirection.Input;
                spParameter[5].Value = p_Product_Detail_Info.Size;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Product_Detail_Insert", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        public bool Product_Detail_Delete(decimal p_Product_Info_id)
        {
            try
            {

                SqlParameter[] spParameter = new SqlParameter[1];

                spParameter[0] = new SqlParameter("@Product_Id", SqlDbType.Int);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Product_Info_id;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Product_Detail_Delete_By_Product_Id", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        public List<Product_Detail_Info> Get_Detail_By_Product(decimal p_Product_Info_id)
        {
            try
            {

                SqlParameter[] spParameter = new SqlParameter[1];
                spParameter[0] = new SqlParameter("@Product_Id", SqlDbType.Int);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Product_Info_id;

                DataSet ds = SqlHelper.ExecuteDataset(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Get_Product_Detail_By_Product_Id", spParameter);
                return CBO<Product_Detail_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new List<Product_Detail_Info>();
            }
        }

        public List<Product_Info> Product_Get_By_Code(string Product_Code)
        {
            try
            {

                SqlParameter[] spParameter = new SqlParameter[1];
                spParameter[0] = new SqlParameter("@Product_Code", SqlDbType.NVarChar);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = Product_Code;

                DataSet ds = SqlHelper.ExecuteDataset(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Product_Get_ByCode", spParameter);
                return CBO<Product_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new List<Product_Info>();
            }
        }

        public List<Product_Info> Product_Get_By_Code(string Product_Code,string Product_Name)
        {
            try
            {

                SqlParameter[] spParameter = new SqlParameter[2];
                spParameter[0] = new SqlParameter("@Product_Code", SqlDbType.NVarChar);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = Product_Code.ToUpper();

                spParameter[1] = new SqlParameter("@Product_Name", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = Product_Name.ToUpper();

                DataSet ds = SqlHelper.ExecuteDataset(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Search_Product", spParameter);
                return CBO<Product_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new List<Product_Info>();
            }
        }
    }
}
