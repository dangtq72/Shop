using NangShop_DataControl;
using NangShopObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NangShop.Control
{
    /// <summary>
    /// Interaction logic for Check_Connection.xaml
    /// </summary>
    public partial class Check_Connection : Window
    {
        public Check_Connection()
        {
            InitializeComponent();
        }
        Allcode_Controller c_AllCodeController = new Allcode_Controller();

        int c_LoadCommonDataStatus = 0;//trạng thái của load dữ liệu: 0: dang load, 1: load khong thanh cong, 2: load thanh cong
        string c_msgNotify; //mesage thogn bao
        public bool c_isLogin = true;

        enum MsgType
        {
            NORMAL = 0,
            ERROR = 1

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = NoteBox.Show(" Bạn có muốn thoát khỏi chương trình không?", "Thông báo", NoteBoxLevel.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
                Application.Current.Shutdown();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (c_isLogin)
            {
                stkLoading.Visibility = Visibility.Visible;
                gr_main.Visibility = Visibility.Collapsed;

                Thread _thr = new Thread(ThreadSystemCheck);
                _thr.IsBackground = true;
                _thr.Start();

                txtUsername.Text = "admin";
                txtPassword.Text = "123";
            }
            else
            {
                stkLoading.Visibility = Visibility.Collapsed;
                gr_main.Visibility = Visibility.Visible;

                txtUsername.Text =  CommonData.c_Urser_Info.User_Name;
                txtUsername.IsHitTestVisible = true;
                txtUsername.Focusable = false;
                txtPassword.Text = "";
                txtPassword.Focus();
            }
            tblError.Visibility = Visibility.Collapsed;
        }

        private void passwordBox1_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void txtUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            txtUsername.Focus();
            txtUsername.SelectAll();
        }

        private void passwordBox1_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPassword.Focus();
            //txtPassword.SelectAll();
        }

        private void btnLogon_Click(object sender, RoutedEventArgs e)
        {
            if (c_isLogin)
            {
                UserLogin();
            }
            else
            {
                UserLock();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = NoteBox.Show("Bạn chắc chắn muốn thoát khỏi chương trình?", "Thông báo", NoteBoxLevel.Question);
                if (result == MessageBoxResult.Yes)
                {
                    this.Close();
                    Application.Current.Shutdown();
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void ThreadSystemCheck()
        {
            try
            {
                #region 1. Kiem tra ket noi database

                c_msgNotify = "Kiểm tra thông số hệ thống";
                ShowLabel(MsgType.NORMAL, c_msgNotify, 30);

                Thread.Sleep(2000);
                c_msgNotify = "Kiểm tra kết nối đến Database";
                ShowLabel(MsgType.NORMAL, c_msgNotify, 50);
                bool _Result = c_AllCodeController.Check_Connect();
                if (_Result == false)
                {
                    c_LoadCommonDataStatus = 1; //kiẻm tra bị lôi
                    c_msgNotify = "Error: Lỗi kết nối đến Database";
                    ShowLabel(MsgType.ERROR, c_msgNotify, 50);
                    return;
                }

               
                #endregion

                //2.load common data
                try
                {
                    c_msgNotify = "Load dữ liệu tham số hệ thống ...";
                    ShowLabel(MsgType.NORMAL, c_msgNotify, 70);
                    //Common.Begin_End_Day.Get_hashTradingSchedules();
                    Common.DBMemory.LoadParamSystem();
                }
                catch (Exception ex)
                {
                    c_LoadCommonDataStatus = 1;  
                    c_msgNotify = "Error: tham số hệ thống";
                    ShowLabel(MsgType.ERROR, c_msgNotify, 70);
                    CommonData.log.Error(ex.ToString());
                    return;
                }

                c_LoadCommonDataStatus = 2;
                Thread.Sleep(2000);
                ShowLabel(MsgType.NORMAL, "Kết nối thành công", 90);

                HidenLoading();

            }
            catch
            {
                c_LoadCommonDataStatus = 1; //kiẻm tra bị lôi
                c_msgNotify = "Error: Lỗi khi load tham số hệ thống";
                ShowLabel(MsgType.ERROR, c_msgNotify, 0);
            }
        }

        #region Delegate

        delegate void DelegateShowLabel(MsgType p_MsgType, string strMsg, int p_pgbValue);
        private void ShowLabel(MsgType p_MsgType, string strMsg, int p_pgbValue)
        {
            if (lblMes.Dispatcher.CheckAccess() == false)
            {
                lblMes.Dispatcher.Invoke(new DelegateShowLabel(ShowLabel), p_MsgType, strMsg, p_pgbValue);
            }
            else
            {
                lblMes.Visibility = Visibility.Visible;
                lblMes.Text = strMsg;
            }
        }

        delegate void DelegateShowControl();
        private void HidenLoading()
        {
            try
            {
                if (lblMes.Dispatcher.CheckAccess() == false)
                {
                    lblMes.Dispatcher.Invoke(new DelegateShowControl(HidenLoading));
                }
                else
                {
                    stkLoading.Visibility = Visibility.Collapsed;
                    gr_main.Visibility = Visibility.Visible;

                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        #endregion

        #region Methods

        private void UserLogin()
        {
            try
            {
                tblError.Visibility = Visibility.Collapsed;
                if (c_LoadCommonDataStatus != 2) return;

                User_Controller _User_Controller = new User_Controller();

                User_Info _User_Info = _User_Controller.User_Login(txtUsername.Text, txtPassword.Text);

                if (_User_Info == null)
                {
                    NoteBox.Show("Sai tên đăng nhập hoặc mật khẩu", "", NoteBoxLevel.Error);
                    txtPassword.Focus();
                    return;
                }

                _User_Controller.User_Update_Last_Login(_User_Info.User_Id, DateTime.Now);

                CommonData.c_Urser_Info = _User_Info;
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                NoteBox.Show("Đăng nhập thất bại", "Thông báo");
            }
        }

        private void UserLock()
        {
            try
            {
                if (CommonData.c_Urser_Info.Pass == txtPassword.Text)
                {
                    this.Close();
                }
                else
                {
                    tblError.Visibility = Visibility.Visible;
                    tblError.Text = "Mật khẩu không đúng.............";
                    //NoteBox.Show("Mật khẩu không đúng", "Thông báo", NoteBoxLevel.Error);
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                tblError.Text = "Đăng nhập thất bại.............";
                //NoteBox.Show("Đăng nhập thất bại", "Thông báo");
                App.Current.Shutdown();
            }
        }
        #endregion

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    if (c_isLogin)
                    {
                        UserLogin();
                    }
                    else
                    {
                        UserLock();
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
