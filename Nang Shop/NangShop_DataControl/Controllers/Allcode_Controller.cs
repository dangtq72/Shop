using NangShopObj;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NangShop_DataControl
{
    public class Allcode_Controller
    {
        public List<AllCode_Info> Get_AllCode_ByCdNameCdType(string p_cdname, string p_cdtype)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[2];

                spParameter[0] = new SqlParameter("@CdName", SqlDbType.NVarChar);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_cdname;

                spParameter[1] = new SqlParameter("@CdType", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = p_cdtype;

                DataSet ds = SqlHelper.ExecuteDataset(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_GetBy_Name_Type", spParameter);
                return CBO<AllCode_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new List<AllCode_Info>();
            }
        }

        public List<AllCode_Info> AllCode_Get_All(string p_cdname, string p_cdtype)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[0];

                DataSet ds = SqlHelper.ExecuteDataset(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_GetBy_All", spParameter);
                return CBO<AllCode_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new List<AllCode_Info>();
            }
        }

        public bool Check_Connect()
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[0];

                DataSet ds = SqlHelper.ExecuteDataset(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_GetBy_All", spParameter);
                List<AllCode_Info> _lst = CBO<AllCode_Info>.FillCollectionFromDataSet(ds);

                if (_lst.Count > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

    }
}
