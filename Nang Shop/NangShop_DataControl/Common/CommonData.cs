using System;


namespace NangShop_DataControl
{
    internal class CommonData
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
    }
}
