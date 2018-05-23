using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NangShopObj;
using System.Data.SqlClient;
using System.Data;

namespace NangShop_DataControl
{
    public class User_Controller
    {
        public bool User_Insert(User_Info p_User_Info, ref decimal _id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[8];

                int i = 0;
                spParameter[i] = new SqlParameter("@User_Name", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_User_Info.User_Name;

                i++;
                spParameter[i] = new SqlParameter("@Pass", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_User_Info.Pass;

                i++;
                spParameter[i] = new SqlParameter("@User_Type", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_User_Info.User_Type;

                i++;
                spParameter[i] = new SqlParameter("@FullName", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_User_Info.FullName;

                i++;
                spParameter[i] = new SqlParameter("@Status", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_User_Info.Status;

                i++;
                spParameter[i] = new SqlParameter("@Phone", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_User_Info.Phone;

                i++;
                spParameter[i] = new SqlParameter("@Group_Id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_User_Info.Group_Id;

                i++;
                spParameter[i] = new SqlParameter("@User_Id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Output;
                spParameter[i].Value = _id;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_User_Insert", spParameter);

                _id = Convert.ToDecimal(spParameter[i].Value);
                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        public List<User_Info>User_Get_All()
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[0];

                DataSet ds = SqlHelper.ExecuteDataset(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_User_Get_All", spParameter);
                return CBO<User_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new List<User_Info>();
            }
        }

        public bool User_Update(decimal p_User_Id, User_Info p_User_Info)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[8];

                int i = 0;
                spParameter[i] = new SqlParameter("@User_Name", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_User_Info.User_Name;

                i++;
                spParameter[i] = new SqlParameter("@Pass", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_User_Info.Pass;

                i++;
                spParameter[i] = new SqlParameter("@User_Type", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_User_Info.User_Type;

                i++;
                spParameter[i] = new SqlParameter("@FullName", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_User_Info.FullName;

                i++;
                spParameter[i] = new SqlParameter("@Status", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_User_Info.Status;

                i++;
                spParameter[i] = new SqlParameter("@Phone", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_User_Info.Phone;

                i++;
                spParameter[i] = new SqlParameter("@Group_Id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_User_Info.Group_Id;

                i++;
                spParameter[i] = new SqlParameter("@User_Id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_User_Id;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_User_Update", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        public bool User_Delete(decimal p_User_Id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];

                spParameter[0] = new SqlParameter("@User_Id", SqlDbType.Int);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_User_Id;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_User_Delete", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        public User_Info User_Login(string p_user_name,string p_pass)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[2];
                int i = 0;
                spParameter[i] = new SqlParameter("@User_Name", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_user_name;

                i++;
                spParameter[i] = new SqlParameter("@Pass", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_pass;

                DataSet ds = SqlHelper.ExecuteDataset(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_User_Login", spParameter);
                List<User_Info> _lst = CBO<User_Info>.FillCollectionFromDataSet(ds);

                if (_lst.Count > 0) return _lst[0];
                else return null;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return null;
            }
        }

        public bool User_Update_Last_Login(decimal p_User_Id, DateTime p_last)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[2];

                int i = 0;
                spParameter[i] = new SqlParameter("@Last_Login", SqlDbType.Date);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_last;

                i++;
                spParameter[i] = new SqlParameter("@User_Id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_User_Id;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_User_Update_Last", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        public bool User_Update_Pass(decimal p_User_Id, string p_pass)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[2];
                int i = 0;
                spParameter[i] = new SqlParameter("@User_Id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_User_Id;

                i++;
                spParameter[i] = new SqlParameter("@Pass", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_pass;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_User_Update_Pass", spParameter);
                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        /// <summary>
        ///  tăng trường đếm số lần ~ quyền cho user lên + 1 để báo log out khi ~ quyền
        /// </summary>
        public void User_Change_SetRight(decimal id)
        {
            try
            {
                //Common.CommonData.c_serviceWCF.User_Change_SetRight(id);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }
    }
}
