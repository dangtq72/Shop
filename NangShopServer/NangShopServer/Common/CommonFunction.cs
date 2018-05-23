using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace NangShopServer
{
    public class CommonFunction
    {
        /// <summary>
        /// Tạo nội dung định dạng json để gửi đi
        /// </summary>
        /// <typeparam name="T">Kiểu object</typeparam>
        /// <param name="p_mes_type">mes type</param>
        /// <param name="p_list">danh sách object cần gửi đi</param>
        /// <param name="p_result">trả ra chuỗi json</param>
        public static string Create_List_Json_Send<T>(string p_mes_type, List<T> p_list)
        {
            try
            {
                Send_Mes_Info<T> _Send_Mes_Info = new Send_Mes_Info<T>();
                _Send_Mes_Info.MES_TYPE = p_mes_type;
                _Send_Mes_Info.CONTENT = p_list;
                return JsonConvert.SerializeObject(_Send_Mes_Info, Formatting.Indented);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return null;
            }
        }

        public static string Create_Json_Send<T>(string p_mes_type, T p_object)
        {
            try
            {
                Mes_Common_Info<T> _Mes_Req_Info = new Mes_Common_Info<T>();
                _Mes_Req_Info.MES_TYPE = p_mes_type;
                _Mes_Req_Info.CONTENT = p_object;

                //thực hiện gửi message thông tin thay đổi về cho client
                return JsonConvert.SerializeObject(_Mes_Req_Info, Formatting.Indented);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return null;
            }
        }

        public static string Create_Json_Send_String(string p_mes_type, string p_mes)
        {
            try
            {
                Send_Mes_Info _Send_Mes_Info = new Send_Mes_Info();
                _Send_Mes_Info.MES_TYPE = p_mes_type;
                _Send_Mes_Info.CONTENT = p_mes;
                return JsonConvert.SerializeObject(_Send_Mes_Info, Formatting.Indented);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Get mes type
        /// </summary>
        /// <returns>mes type</returns>
        public static string Get_Mes_Type(string p_mes)
        {
            try
            {
                JObject _JObject = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(p_mes);
                string _s = _JObject["MES_TYPE"].ToString();
                return _s.Remove(_s.Length - 1, 1).Substring(1);
            }
            catch (Exception ex)
            {
                ErrorLog.log.Error(ex.ToString());
                return "";
            }
        }

        public static Hashtable GetPropertyInfo(Type objType)
        {
            Hashtable hashProperties = new Hashtable();
            foreach (PropertyInfo objProperty in objType.GetProperties())
            {
                hashProperties[objProperty.Name.ToUpper()] = objProperty;
            }
            return hashProperties;
        }

        public static string MakeMD5(string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sbHash = new StringBuilder();
            foreach (byte b in bHash)
            {
                sbHash.Append(String.Format("{0:x2}", b));
            }
            return sbHash.ToString();
        }
    }
}
