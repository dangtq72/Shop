using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NangShopServer
{
    public class CommonData
    {
        public static string c_DirSaveFile = "";
        public static int c_TimeSleepSaveFile = 5;
    }

    public class ErrorLog
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }

    public class Mes_Common_Info<T>
    {
        public string MES_TYPE { get; set; }
        public T CONTENT { get; set; }
    }

    public class Send_Mes_Info<T>
    {
        public string MES_TYPE { get; set; }

        public List<T> CONTENT { get; set; }
    }

    public class Send_Mes_Info
    {
        public string MES_TYPE { get; set; }

        public string CONTENT { get; set; }
    }
}
