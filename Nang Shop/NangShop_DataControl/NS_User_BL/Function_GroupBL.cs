/* 
* Project: CoreMonitor_DataControl
* Author : Trinh The Vu – Navisoft.
* Summary: cung cap cac ham de doc va ghi du lieu vao bang TS_USERS(2.1.4) trong DB Oracle tang BL
* Modification Logs:
* DATE             AUTHOR      DESCRIPTION
* --------------------------------------------------------
* May 14, 2012  	VuTT     Created
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using ZetaCompressionLibrary;
using NangShopObj;

namespace NangShop_DataControl
{
    public class Function_GroupController
    {
        public bool Function_Group_DelByGroup(decimal id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[1];

                spParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = id;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Function_Group_Delete", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        public void Function_Group_Insert_Batch(ArrayList arr,decimal type)
        {
            try
            {
                List<Function_GroupInfo> _list = new List<Function_GroupInfo>();

                for (int i = 0; i < arr.Count; i++)
                {
                    FunctionsInfo item = (FunctionsInfo)arr[i];
                    Function_GroupInfo _Function_GroupInfo = new Function_GroupInfo();
                    _Function_GroupInfo.user_type = type;
                    _Function_GroupInfo.functionid = item.id;
                    _list.Add(_Function_GroupInfo);
                }

                string strConn = CommonData.ConnectionString;

                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    var bulkCopy = new SqlBulkCopy(conn);
                    bulkCopy.DestinationTableName = "Function_Group";

                    bulkCopy.ColumnMappings.Add("user_type", "user_type");
                    bulkCopy.ColumnMappings.Add("functionid", "functionid");

                    using (var datareader = new ObjectDataReader<Function_GroupInfo>(_list)) 
                    {
                        bulkCopy.WriteToServer(datareader);
                    }
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }
    }
}
