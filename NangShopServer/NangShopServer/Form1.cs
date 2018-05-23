using NangShop_DataControl;
using NangShopObj;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace NangShopServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
        }

        List<Product_Info> c_lst = new List<Product_Info>();
        Product_Controller c_Product_Controller = new Product_Controller();

        List<Color_Info> c_lst_color = new List<Color_Info>();
        Color_Controller c_Color_Controller = new Color_Controller();

        private void Form1_Load(object sender, EventArgs e)
        {
            CommonData.c_DirSaveFile = System.Configuration.ConfigurationManager.AppSettings["DirSaveFile"];
            CommonData.c_TimeSleepSaveFile = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["TimeSleepSaveFile"]);

            ShowText(DateTime.Now.ToString("HH:mm:ss") + " - Start Service at " );
            Thread _thr = new Thread(RunThread);
            _thr.IsBackground = true;
            _thr.Start();
        }

        void RunThread()
        {
            while (true)
            {
                try
                {
                    string filePath = System.IO.Path.Combine(CommonData.c_DirSaveFile, "product.json");

                    c_lst = c_Product_Controller.Get_All();
                    string _json = CommonFunction.Create_List_Json_Send<Product_Info>("PRODUCT", c_lst);
                    File.WriteAllText(filePath, _json);

                    ShowText(DateTime.Now.ToString("HH:mm:ss") + " - Save file " + filePath);

                    filePath = System.IO.Path.Combine(CommonData.c_DirSaveFile, "color.json");
                    c_lst_color = c_Color_Controller.Get_All();
                    _json = CommonFunction.Create_List_Json_Send<Color_Info>("COLOR", c_lst_color);
                    File.WriteAllText(filePath, _json);
                    ShowText(DateTime.Now.ToString("HH:mm:ss") + " - Save file " + filePath);

                    Thread.Sleep(CommonData.c_TimeSleepSaveFile * 1000 * 60);
                }
                catch (Exception ex)
                {
                    ErrorLog.log.Error(ex.ToString());
                    txtJsonString.Text = ex.ToString();
                    Thread.Sleep(60000);
                }
            }
        }

        delegate void delegateShowText(string p_text);
        void ShowText(string p_text)
        {
            if (txtJsonString.InvokeRequired)
            {
                this.Invoke(new delegateShowText(ShowText), p_text);
            }

            else
            {
                txtJsonString.Text += p_text + "\r\n";
            }
        }
    }
}
