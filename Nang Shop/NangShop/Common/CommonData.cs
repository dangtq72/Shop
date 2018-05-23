using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using NangShopObj;

namespace NangShop
{
    public enum ReturnValue
    {
        Susscess = 1,          //Neu thanh cong
        Error = -1             //Neu khong thanh cong
    }

    public class CommonData
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static ArrayList c_arrQuyen = new ArrayList(); //danh sách cách quyền của user
        public static string c_cultureName_lang = "vi-VN"; //en-US
        public static User_Info c_Urser_Info = new User_Info();
        public static string ExcelDesignFilePath = "report//";
        static string _ConnectionString = "";
        public static string ConnectionString
        {
            get
            {
                if (_ConnectionString == "")
                {
                    try
                    {
                        _ConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
                    }
                    catch
                    {
                        _ConnectionString = "";
                    }
                }

                return _ConnectionString;

            }
        }



        //Chuỗi kết nối đến File Excel (Bo di dung trong Controller.)
        public static string connectionStringExcel = "";

        public static string getcon(string fileName, string ex)
        {
            try
            {
                switch (ex)
                {
                    case ".xls": //Excel 97-03
                        connectionStringExcel = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;;Data Source=" + fileName + ";Extended Properties=\"Excel 8.0;HDR=YES\";");
                        break;
                    case ".xlsx": //Excel 07
                        connectionStringExcel = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;\"");
                        break;
                }
                return connectionStringExcel;
            }
            catch
            {
                return "";
            }
        }
    }

    public enum Status_Type
    {
        ConHang = 1,
        DaBan = 0
    }

    public enum Form_Type
    {
        Insert = 0,
        Update = 1,
        View = 2
    }

    public enum Payment_Type
    {
        ChuyenKhoan = 1,
        Cash = 2
    }

    public enum ThuChi_Type
    {
        Nhap_Hang = 0,
        Ban_Le = 1,
        Ban_Buon = 2
    }

    public enum User_Status_Type
    {
        Active = 1,
        UnActive = 0
    }

    public enum Change_Product_Type
    {
        Normal = 0,
        AddNew = 1,
        Return = 2
    }
}
