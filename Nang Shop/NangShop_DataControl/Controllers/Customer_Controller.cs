using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NangShopObj;

namespace NangShop_DataControl
{
    public class Customer_Controller
    {
        public List<Customer_Info> Customer_GetAll()
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[0];

                DataSet ds = SqlHelper.ExecuteDataset(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_customer_GetAll", spParameter);
                return CBO<Customer_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new List<Customer_Info>();
            }
        }

        public bool Customer_Insert(Customer_Info p_Customer_Info, ref decimal _id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[4];

                spParameter[0] = new SqlParameter("@Customer_Name", SqlDbType.NVarChar);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Customer_Info.Customer_Name;

                spParameter[1] = new SqlParameter("@Phone", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = p_Customer_Info.Phone;

                spParameter[2] = new SqlParameter("@Address", SqlDbType.NVarChar);
                spParameter[2].Direction = ParameterDirection.Input;
                spParameter[2].Value = p_Customer_Info.Address;

                spParameter[3] = new SqlParameter("@Customer_Id", SqlDbType.Int);
                spParameter[3].Direction = ParameterDirection.Output;
                spParameter[3].Value = _id;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "Customer_Insert", spParameter);

                _id = Convert.ToDecimal(spParameter[3].Value);
                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        public bool Customer_Update(int p_Customer_Id,Customer_Info p_Customer_Info)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[4];

                spParameter[0] = new SqlParameter("@Customer_Name", SqlDbType.NVarChar);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Customer_Info.Customer_Name;

                spParameter[1] = new SqlParameter("@Phone", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = p_Customer_Info.Phone;

                spParameter[2] = new SqlParameter("@Address", SqlDbType.NVarChar);
                spParameter[2].Direction = ParameterDirection.Input;
                spParameter[2].Value = p_Customer_Info.Address;

                spParameter[3] = new SqlParameter("@Customer_Id", SqlDbType.Int);
                spParameter[3].Direction = ParameterDirection.Input;
                spParameter[3].Value = p_Customer_Id;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Customer_Update", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        public List<Customer_Info> Search_Customer(string p_name, string p_phone)
        {
            try
            {

                SqlParameter[] spParameter = new SqlParameter[2];

                spParameter[0] = new SqlParameter("@Customer_Name", SqlDbType.NVarChar);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_name;

                spParameter[1] = new SqlParameter("@Phone", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = p_phone;

                DataSet ds = SqlHelper.ExecuteDataset(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Customer_Search", spParameter);
                return CBO<Customer_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new List<Customer_Info>();
            }
        }

        public bool Customer_Delete(int p_Customer_Id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];

                spParameter[0] = new SqlParameter("@Customer_Id", SqlDbType.Int);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Customer_Id;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "Customer_Insert", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        public List<Customer_Buy_Product_Info>Get_Customer_Buy_Product(int p_Customer_Id)
        {
            try
            {

                SqlParameter[] spParameter = new SqlParameter[1];

                spParameter[0] = new SqlParameter("@Customer_Id", SqlDbType.Int);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Customer_Id;

                DataSet ds = SqlHelper.ExecuteDataset(CommonData.ConnectionString, CommandType.StoredProcedure, "Customer_Buy_Product", spParameter);
                return CBO<Customer_Buy_Product_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new List<Customer_Buy_Product_Info>();
            }
        }
    }
}
