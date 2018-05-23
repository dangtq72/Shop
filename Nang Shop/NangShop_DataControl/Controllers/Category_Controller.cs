using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NangShopObj;
using System.Data.SqlClient;
using System.Data;

namespace NangShop_DataControl
{
    public class Category_Controller
    {
        public bool Category_Insert(Category_Info p_Category_Info, ref decimal _id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[3];

                spParameter[0] = new SqlParameter("@Category_Name", SqlDbType.NVarChar);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Category_Info.Category_Name;

                spParameter[1] = new SqlParameter("@Note", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = p_Category_Info.Note;

                spParameter[2] = new SqlParameter("@Category_Id", SqlDbType.Int);
                spParameter[2].Direction = ParameterDirection.Output;
                spParameter[2].Value = _id;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Category_Insert", spParameter);

                _id = Convert.ToDecimal(spParameter[2].Value);
                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        public List<Category_Info> Get_All()
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[0];

                DataSet ds = SqlHelper.ExecuteDataset(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Category_GetAll", spParameter);
                return CBO<Category_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new List<Category_Info>();
            }
        }

        public bool Category_Update(decimal p_Category_Info_Id, Category_Info p_Category_Info)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[3];

                spParameter[0] = new SqlParameter("@Category_Id", SqlDbType.Int);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Category_Info_Id;

                spParameter[1] = new SqlParameter("@Category_Name", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = p_Category_Info.Category_Name;

                spParameter[2] = new SqlParameter("@Note", SqlDbType.NVarChar);
                spParameter[2].Direction = ParameterDirection.Input;
                spParameter[2].Value = p_Category_Info.Note;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Category_Update", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        public bool Categor_Delete(decimal p_Category_Info_Id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];

                spParameter[0] = new SqlParameter("@Category_Id", SqlDbType.Int);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Category_Info_Id;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Category_Delete", spParameter);

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
