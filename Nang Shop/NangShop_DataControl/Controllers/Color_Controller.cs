using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NangShopObj;
using System.Data.SqlClient;
using System.Data;

namespace NangShop_DataControl
{
    public class Color_Controller
    {
        public bool Color_Insert(Color_Info p_Supplier_Info, ref decimal _id)
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[3];

                spParameter[0] = new SqlParameter("@ColorCode", SqlDbType.NVarChar);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Supplier_Info.ColorCode;

                spParameter[1] = new SqlParameter("@ColorName", SqlDbType.NVarChar);
                spParameter[1].Direction = ParameterDirection.Input;
                spParameter[1].Value = p_Supplier_Info.ColorName;

                spParameter[2] = new SqlParameter("@Color_Id", SqlDbType.Int);
                spParameter[2].Direction = ParameterDirection.Output;
                spParameter[2].Value = _id;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Color_Insert", spParameter);

                _id = Convert.ToDecimal(spParameter[2].Value);
                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        public bool Color_Delete(decimal p_Supplier_id)
        {
            try
            {

                SqlParameter[] spParameter = new SqlParameter[1];

                spParameter[0] = new SqlParameter("@Color_Id", SqlDbType.Int);
                spParameter[0].Direction = ParameterDirection.Input;
                spParameter[0].Value = p_Supplier_id;

                SqlHelper.ExecuteNonQuery(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Color_Delete", spParameter);

                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        public List<Color_Info> Get_All()
        {
            try
            {
                SqlParameter[] spParameter = new SqlParameter[0];

                DataSet ds = SqlHelper.ExecuteDataset(CommonData.ConnectionString, CommandType.StoredProcedure, "proc_Color_GetAll", spParameter);
                return CBO<Color_Info>.FillCollectionFromDataSet(ds);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new List<Color_Info>();
            }
        }

        //public bool ThemVaoTempProductInstance(List<Titan_ProductInstance_Info> lst)
        //{
        //    try
        //    {
        //        var bulkCopy = new SqlBulkCopy(CommonData.ConnectionString_OneKN);
        //        DataTable dt = new DataTable();
        //        dt = ConvertData.ConvertToDataTable(lst);
        //        bulkCopy.DestinationTableName = "Temp_ProductInstance";
        //        bulkCopy.ColumnMappings.Add("ProductInstanceId", "ProductInstanceId");
        //        bulkCopy.ColumnMappings.Add("ProductId", "ProductId");
        //        bulkCopy.ColumnMappings.Add("ColorId", "ColorId");
        //        bulkCopy.ColumnMappings.Add("BarCodeId", "BarCodeId");
        //        bulkCopy.ColumnMappings.Add("ReceiveInstanceId", "ReceiveInstanceId");
        //        bulkCopy.ColumnMappings.Add("WarehouseId", "WarehouseId");
        //        bulkCopy.ColumnMappings.Add("LocationCode", "LocationCode");
        //        bulkCopy.ColumnMappings.Add("PrimaryInstanceCode", "PrimaryInstanceCode");
        //        bulkCopy.ColumnMappings.Add("SecondaryInstanceCode", "SecondaryInstanceCode");
        //        bulkCopy.ColumnMappings.Add("LackProductDocument", "LackProductDocument");
        //        bulkCopy.ColumnMappings.Add("LackWarrantyDocument", "LackWarrantyDocument");
        //        bulkCopy.ColumnMappings.Add("InstockDate", "InstockDate");
        //        bulkCopy.ColumnMappings.Add("OutstockDate", "OutstockDate");
        //        bulkCopy.ColumnMappings.Add("ProductType", "ProductType");
        //        bulkCopy.ColumnMappings.Add("OriginType", "OriginType");
        //        bulkCopy.ColumnMappings.Add("Status", "Status");
        //        bulkCopy.ColumnMappings.Add("Comment", "Comment");
        //        bulkCopy.ColumnMappings.Add("OriginWarehouseId", "OriginWarehouseId");
        //        bulkCopy.ColumnMappings.Add("Ngay_Chot", "Ngay_Chot");
        //        bulkCopy.WriteToServer(dt);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        CommonData.log.Error(ex.ToString());
        //        return false;
        //    }
        //}
    }
}
