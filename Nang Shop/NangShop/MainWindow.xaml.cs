using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

using Microsoft.Windows.Controls.Ribbon;
using AvalonDock;
using NangShop.Control;
using NangShop.Control.Created;
using NangShop.Display;
using System.Windows.Threading;
using NangShop.User;
using NangShopObj;
using NangShop.Control.Alert;

namespace NangShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                // Set TimeValue tự động chốt tồn kho

                log4net.Config.XmlConfigurator.Configure();

                this.Visibility = System.Windows.Visibility.Hidden;
                Check_Connection _Check = new Check_Connection();
                if (_Check.ShowDialog() != true)
                {
                    //neu tra ve khong hop le thi dong ung dung
                    ForceClose = true;
                    this.Close();
                }

                AddHandler(Keyboard.PreviewKeyDownEvent, (KeyEventHandler)HandleKeyDownEvent);

                this.Visibility = System.Windows.Visibility.Visible;

                TimerSP.Interval = new TimeSpan(0, 0, 1);
                TimerSP.IsEnabled = true;
                TimerSP.Tick += new EventHandler(TimerSP_Tick);

                username.Content = CommonData.c_Urser_Info.User_Name;
            }
            catch
            {
            }
        }

        DispatcherTimer TimerSP = new DispatcherTimer();//ham timmer de hien thi dong ho
        private static bool ForceClose = false;
        private Hashtable AllManagerForm = new Hashtable(); //Biến lưu trữ các docking form của chương trình
        private Hashtable AllNameRibbon = new Hashtable(); // biến lưu giữ các tên của ribbon button

        #region Event
        private void frmmain_Loaded(object sender, RoutedEventArgs e)
        {
            InitAllDockForm();
        }

        private void frmmain_Closed(object sender, EventArgs e)
        {

        }

        private void HandleKeyDownEvent(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.L && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                {
                    LockSystem();
                }
                else if (e.Key == Key.System && e.SystemKey == Key.F4)
                {
                    Application.Current.Shutdown();
                }
                else if (e.Key == Key.F2)
                {
                    frmSuggest _frmSuggest = new frmSuggest();
                    _frmSuggest.Owner = Window.GetWindow(this);
                    _frmSuggest.ShowDialog();
                }
                else if (e.Key == Key.S && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                {
                    FrmCreateSale_Header _FrmCreateSale_Header = new FrmCreateSale_Header();
                    _FrmCreateSale_Header.Owner = Window.GetWindow(this);
                    _FrmCreateSale_Header.ShowDialog();
                }
                else if (e.Key == Key.D && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                {
                    FrmCreateSale_Ban_Buon_Header _FrmCreateSale_Header = new FrmCreateSale_Ban_Buon_Header();
                    _FrmCreateSale_Header.Owner = Window.GetWindow(this);
                    _FrmCreateSale_Header.ShowDialog();
                }
                else if (e.Key == Key.F && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                {
                    frmSearchProduct _frmSearchProduct = new frmSearchProduct();
                    _frmSearchProduct.Owner = Window.GetWindow(this);
                    _frmSearchProduct.c_is_QuickSearch = true;
                    _frmSearchProduct.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void DockManager_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnDockingForm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string frmName = ((RibbonButton)sender).Tag.ToString();
                object objForm = AllManagerForm[frmName];

                if (objForm != null)
                {
                    DockableContent _ContentForm = (DockableContent)objForm;
                    ((DockableContent)objForm).NVSQuyen_Core = new SecurityLevel(checkfunction(frmName));
                    _ContentForm.IsFistLoad = true;
                    if (_ContentForm.State == DockableContentState.None)
                    {
                        _ContentForm.ShowAsDocument();
                        _ContentForm.Activate();
                    }
                    else
                    {
                        _ContentForm.Show();
                    }
                }
                else
                {
                    NoteBox.Show("Chức năng chưa được khởi tạo, hãy liên lạc với quản trị hệ thống");
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void btnLock_Click(object sender, RoutedEventArgs e)
        {
            LockSystem();
        }

        private void Resetpass_Click(object sender, RoutedEventArgs e)
        {
            Update_Pass _frmUpdate_pass = new Update_Pass();
            _frmUpdate_pass.Owner = Window.GetWindow(this);
            _frmUpdate_pass.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TimerSP_Tick(object sender, EventArgs e)
        {
            try
            {
                string _time = DateTime.Now.ToLongTimeString() + "  ";
                lbltime.Content = _time;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void rbn_Receive_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Frm_NhapHang _Frm_NhapHang = new Frm_NhapHang();
                _Frm_NhapHang.Owner = Window.GetWindow(this);
                _Frm_NhapHang.ShowDialog();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void rbn_Sale_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FrmCreateSale_Header _FrmCreateSale_Header = new FrmCreateSale_Header();
                _FrmCreateSale_Header.Owner = Window.GetWindow(this);
                _FrmCreateSale_Header.ShowDialog();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void rbn_Sale_Buon_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                FrmCreateSale_Ban_Buon_Header _FrmCreateSale_Header = new FrmCreateSale_Ban_Buon_Header();
                _FrmCreateSale_Header.Owner = Window.GetWindow(this);
                _FrmCreateSale_Header.ShowDialog();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void btnImgUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                frmCreate_User _Users_View = new frmCreate_User();
                _Users_View.Owner = Window.GetWindow(this);

                _Users_View.c_User_Info = CommonData.c_Urser_Info;
                _Users_View.c_type = Convert.ToInt16(Form_Type.View);
                _Users_View.ShowDialog();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void btnGoiY_Click(object sender, RoutedEventArgs e)
        {
            frmSuggest _frmSuggest = new frmSuggest();
            _frmSuggest.Owner = Window.GetWindow(this);
            _frmSuggest.ShowDialog();
        }

        #endregion

        #region Methods

        private void LockSystem()
        {
            try
            {
                this.Visibility = System.Windows.Visibility.Hidden;
                //Check_Connection _lock = new Check_Connection();
                frmLogOn _lock = new frmLogOn();
                //_lock.c_isLogin = false;
                _lock.Owner = Window.GetWindow(this);
                //_lock.Title = "Hệ thống đã bị khóa";
                _lock.ShowDialog();

                this.Visibility = System.Windows.Visibility.Visible;
                this.Focus();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        /// <summary>
        /// Định nghĩa các form mà sử dụng avalondock
        /// </summary>
        private void InitAllDockForm()
        {
            try
            {
                Supplier_Display _Supplier_Display = new Supplier_Display();
                _Supplier_Display.Manager = DockManager;
                AllManagerForm[_Supplier_Display.Name] = _Supplier_Display;
                AllNameRibbon[_Supplier_Display.Name] = rbn_NhaBuon;

                Category_Display _Category_Display = new Category_Display();
                _Category_Display.Manager = DockManager;
                AllManagerForm[_Category_Display.Name] = _Category_Display;
                AllNameRibbon[_Category_Display.Name] = rbn_Category;

                Product_Display _Product_Display = new Product_Display();
                _Product_Display.Manager = DockManager;
                AllManagerForm[_Product_Display.Name] = _Product_Display;
                AllNameRibbon[_Product_Display.Name] = rbn_Product;

                Color_Display _Color_Display = new Color_Display();
                _Color_Display.Manager = DockManager;
                AllManagerForm[_Color_Display.Name] = _Color_Display;
                AllNameRibbon[_Color_Display.Name] = rbn_Color;

                Customer_Display _Customer_Display = new Customer_Display();
                _Customer_Display.Manager = DockManager;
                AllManagerForm[_Customer_Display.Name] = _Customer_Display;
                AllNameRibbon[_Customer_Display.Name] = rbn_Customer;


                UserDisplay _UserDisplay = new UserDisplay();
                _UserDisplay.Manager = DockManager;
                AllManagerForm[_UserDisplay.Name] = _UserDisplay;
                AllNameRibbon[_UserDisplay.Name] = rbn_User;

                

                Group_User_Display _Group_User_Display = new Group_User_Display();
                _Group_User_Display.Manager = DockManager;
                AllManagerForm[_Group_User_Display.Name] = _Group_User_Display;
                AllNameRibbon[_Group_User_Display.Name] = rbn_Group_User;

                HoaDon_Display _HoaDon_Display = new HoaDon_Display();
                _HoaDon_Display.Manager = DockManager;
                AllManagerForm[_HoaDon_Display.Name] = _HoaDon_Display;
                AllNameRibbon[_HoaDon_Display.Name] = rbn_SaleHeader;

                HoaDon_BanBuon_Display _HoaDon_BanBuon_Display = new HoaDon_BanBuon_Display();
                _HoaDon_BanBuon_Display.Manager = DockManager;
                AllManagerForm[_HoaDon_BanBuon_Display.Name] = _HoaDon_BanBuon_Display;
                AllNameRibbon[_HoaDon_BanBuon_Display.Name] = rbn_SaleHeader_BanBuon;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private string checkfunction(string menuitem)
        {
            try
            {
                string result = "";
                foreach (User_FunctionsInfo quyen in CommonData.c_arrQuyen)
                {
                    if (quyen.name == menuitem)
                    {
                        result = quyen.right;
                        break;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return "";
            }
        }
        #endregion

    }
}
