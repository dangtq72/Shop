
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
//using Oracle.DataAccess.Client;
using ZetaCompressionLibrary;
using NangShopObj;

namespace NangShop_DataControl
{


    public class FunctionsController
    {
        /// <summary>
        /// Lấy function theo nhóm ng dùng
        /// </summary>
        /// <param name="p_type"></param>
        /// <returns></returns>
        public ArrayList Function_GetByType(decimal p_type, string p_lang)
        {
            try
            {
                //byte[] byteGetbyType = Common.CommonData.c_serviceWCF.Function_GetByType(p_type);
                //DataSet dsGetbyType = CompressionHelper.DecompressDataSet(byteGetbyType);
                //ArrayList arr = CBO.FillCollectionFromDataSet(dsGetbyType, typeof(FunctionsInfo));

                //return GetChildofFunction(arr, p_lang);

                return new ArrayList();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new ArrayList();
            }
        }
        public decimal Function_Insert(FunctionsInfo _FunctionsInfo)
        {
            try
            {
                //decimal id = Common.CommonData.c_serviceWCF.Function_Insert(_FunctionsInfo.name, _FunctionsInfo.id, _FunctionsInfo.prid, _FunctionsInfo.lev,
                //    _FunctionsInfo.last, _FunctionsInfo.status, _FunctionsInfo.objname, _FunctionsInfo.shortcut,
                //    _FunctionsInfo.notes, _FunctionsInfo.deleted, _FunctionsInfo.created_by, _FunctionsInfo.created_date, _FunctionsInfo.System_Type);

                //_FunctionsInfo.id = id.ToString();

                //TraceControler _TraceControler = new TraceControler();
                //_TraceControler.Trace_Insert("TS_FUNCTIONS", "Function_Insert", Common.CommonData.c_CurrentUserInfo.username, _FunctionsInfo);

                //return id;
                return 0;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return -1;
            }
        }

        public void Function_Update(FunctionsInfo _FunctionsInfo, FunctionsInfo old)
        {
            try
            {
                //Common.CommonData.c_serviceWCF.Function_Update(_FunctionsInfo.id, _FunctionsInfo.name, _FunctionsInfo.prid,
                //    _FunctionsInfo.lev, _FunctionsInfo.last, _FunctionsInfo.status, _FunctionsInfo.objname,
                //    _FunctionsInfo.shortcut, _FunctionsInfo.notes, _FunctionsInfo.deleted, _FunctionsInfo.modified_by, _FunctionsInfo.modified_date);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        public void Function_Delete(string p_id, string p_name)
        {
            try
            {
                //Common.CommonData.c_serviceWCF.Function_Delete(p_id);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        public ArrayList Function_GetAll(string p_lang)
        {
            try
            {
                //byte[] byteRecive = Common.CommonData.c_serviceWCF.Function_GetAll();
                //DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                //ArrayList arr = CBO.FillCollectionFromDataSet(ds, typeof(FunctionsInfo));

                //return GetChildofFunction(arr, p_lang);

                return new ArrayList();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new ArrayList();
            }
        }

        public ArrayList Function_Get_By_System(string p_system, string p_lang)
        {
            try
            {
                //byte[] byteRecive = Common.CommonData.c_serviceWCF.Function_GetBy_SystemType(p_system);
                //DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                //ArrayList arr = CBO.FillCollectionFromDataSet(ds, typeof(FunctionsInfo));

                //return GetChildofFunction(arr, p_lang);

                return new ArrayList();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new ArrayList();
            }
        }

        public ArrayList GetChildofFunction(ArrayList arrAllFunction, string p_lang)
        {
            ArrayList new_arr = new ArrayList();
            string _cach = "          ";

            foreach (FunctionsInfo _info in arrAllFunction)
            {
                if (_info.prid == "0")
                {
                    new_arr.Add(_info);
                    BuidlTreeFuction(_info, _info.id, arrAllFunction, ref new_arr, _cach, p_lang);
                }
            }
            return new_arr;
        }

        public void BuidlTreeFuction(FunctionsInfo p_parentItem, string p_parentID, ArrayList arrAllFunction, ref ArrayList new_arr, string cach, string p_lang)
        {
            foreach (FunctionsInfo _info in arrAllFunction)
            {
                if (_info.prid == p_parentID)
                {
                    _info.name = cach + _info.name;

                    new_arr.Add(_info);
                    BuidlTreeFuction(_info, _info.id, arrAllFunction, ref new_arr, cach + "          ", p_lang);
                }
            }
        }

        public ArrayList GetParentOfFunction(ArrayList arr, ArrayList arrAllFunction)
        {
            try
            {
                ArrayList new_arr = new ArrayList();

                foreach (FunctionsInfo _info in arr)
                {
                    new_arr.Add(_info);
                    BuidlTreeFuction(_info, arrAllFunction, ref new_arr);
                }
                return new_arr;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new ArrayList();
            }
        }

        public void BuidlTreeFuction(FunctionsInfo p_ChildItem, ArrayList arrAllFunction, ref ArrayList new_arr)
        {
            try
            {
                foreach (FunctionsInfo _info in arrAllFunction)
                {
                    if (p_ChildItem.prid == _info.id)
                    {
                        new_arr.Add(_info);
                    }
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        public ArrayList Function_Check_Not_Same(string p_id)
        {
            try
            {
                //byte[] byteRecive = Common.CommonData.c_serviceWCF.Function_Check_Not_Same(p_id);
                //DataSet ds = CompressionHelper.DecompressDataSet(byteRecive);
                //ArrayList arr = CBO.FillCollectionFromDataSet(ds, typeof(FunctionsInfo));

                //return arr;

                return new ArrayList();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new ArrayList();
            }
        }
    }
}
