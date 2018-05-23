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
//using Oracle.DataAccess.Client;
using ZetaCompressionLibrary;
using NangShopObj;

namespace NangShop_DataControl
{
    public class UserCoreController
    {
        public ArrayList Send_Users_Get_By_HNX_System(string p_HnxSystem)
        {
            try
            {
                //UsersController _UsersController = new UsersController();
                //DataSet ds = _UsersController.Send_Users_Get_By_HNX_System(p_HnxSystem);
                //return CBO.FillCollectionFromDataSet(ds, typeof(UserCoreInfo));

                return new ArrayList();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new ArrayList();
            }
        }

        public ArrayList Send_Users_Get_MenuItem(string code)
        {
            try
            {
                //UsersController _UsersController = new UsersController();
                //DataSet ds = _UsersController.Send_Users_Get_MenuItem(code);
                //return CBO.FillCollectionFromDataSet(ds, typeof(User_FunctionsInfo));

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
