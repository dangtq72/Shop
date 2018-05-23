using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NangShopObj;
using System.Data.SqlClient;
using System.Data;

namespace NangShop_DataControl
{
    public class Supplier_Controller
    {

        public bool Supplier_Insert(Supplier_Info p_Supplier_Info, ref decimal _id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[4];

                spParameter[0] = new SqlParameter("@Supplier_Name", SqlDbType.NVarChar);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Supplier_Info.Supplier_Name;

                spParameter[1] = new SqlParameter("@Phone", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = p_Supplier_Info.Phone;

                spParameter[2] = new SqlParameter("@Address", SqlDbType.NVarChar);
                spParameter[2].Direction = ParameterDirection.Input;
                spParameter[2].Value = p_Supplier_Info.Address;

                spParameter[3] = new SqlParameter("@Supplier_Id", SqlDbType.Int);
                spParameter[3].Direction = ParameterDirection.Output;
                spParameter[3].Value = _id;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Supplier_Insert", spParameter);

                _id = Convert.ToDecimal(spParameter[3].Value);
                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        public bool Supplier_Delete(decimal p_Supplier_id)
        {
            try
            {

                SqlParameter[] spParameter = new SqlParameter[1];

                spParameter[0] = new SqlParameter("@Supplier_Id", SqlDbType.Int);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Supplier_id;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Supplier_Delete", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        public List<Supplier_Info> Get_All()
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[0];

                DataSet ds = SqlHelper.ExecuteDataset(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Supplier_GetAll", spParameter);
                return CBO<Supplier_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new List<Supplier_Info>();
            }
        }

        public bool Supplier_Update(decimal p_Supplier_Id, Supplier_Info p_Supplier_Info)
        {
            try
            {
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
