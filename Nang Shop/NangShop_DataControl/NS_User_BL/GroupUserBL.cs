
using System;
using System.Linq;
using System.Text;
using System.Collections;
using ZetaCompressionLibrary;
using System.Data;
using NangShopObj;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace NangShop_DataControl
{
    public class GroupUserController
    {
        public List<GroupUserInfo> GroupUser_GetAll()
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[0];

                DataSet ds = SqlHelper.ExecuteDataset(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Group_UserGetAll", spParameter);
                return CBO<GroupUserInfo>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new List<GroupUserInfo>();
            }
        }

        public decimal GroupUser_Insert(GroupUserInfo p_GroupUserInfo)
        {
            try
            {
                decimal _id = -1;
                SqlParameter[] spParameter = new SqlParameter[4];

                int i = 0;
                spParameter[i] = new SqlParameter("@Name", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_GroupUserInfo.Name;

                i++;
                spParameter[i] = new SqlParameter("@Group_Type", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_GroupUserInfo.Group_Type;

                i++;
                spParameter[i] = new SqlParameter("@Note", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_GroupUserInfo.Note;

                i++;
                spParameter[i] = new SqlParameter("@Id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Output;
                spParameter[i].Value = _id;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Group_User_Insert", spParameter);

                return Convert.ToDecimal(spParameter[i].Value);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return -1;
            }
        }

        /// <summary>
        /// update theo id GroupUser
        /// </summary>
        public bool GroupUser_Update(decimal id, GroupUserInfo p_GroupUserInfo)
        {
            try
            {
                //Common.CommonData.c_serviceWCF.GroupUser_Update(id, p_GroupUserInfo.Name, p_GroupUserInfo.Group_Type, p_GroupUserInfo.Note);

                SqlParameter[] spParameter = new SqlParameter[4];

                int i = 0;
                spParameter[i] = new SqlParameter("@Name", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_GroupUserInfo.Name;

                i++;
                spParameter[i] = new SqlParameter("@Group_Type", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_GroupUserInfo.Group_Type;

                i++;
                spParameter[i] = new SqlParameter("@Note", SqlDbType.NVarChar);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = p_GroupUserInfo.Note;

                i++;
                spParameter[i] = new SqlParameter("@Id", SqlDbType.Int);
                spParameter[i].Direction = ParameterDirection.Input;
                spParameter[i].Value = id;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Group_User_Update", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// xoa GroupUser theo id
        /// </summary>
        public bool GroupUser_Delete(decimal id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];

                spParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = id;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Group_User_Delete", spParameter);

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
