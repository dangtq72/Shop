using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using NangShopObj;
using System.Data;
using NangShop.Common;
using NangShop.Control.Created;
using NangShop_DataControl;
using System.Collections;
using NangShop.Control.Update;

namespace NangShop.Control.View
{
    /// <summary>
    /// Interaction logic for View_HeaderProduct_Detail.xaml
    /// </summary>
    public partial class Change_HeaderProduct_Detail : Window
    {
        public Change_HeaderProduct_Detail()
        {
            InitializeComponent();
        }

        public Sale_Header_Info c_Sale_Header_Info;
        Product_Controller c_Product_Controller = new Product_Controller();
        Product_Info c_Product_Info_Search = new Product_Info(); // sản phẩm vừa tìm kiếm được
        List<Product_Info> c_list_Product_Buy = new List<Product_Info>(); // chứa danh sách sp mua

        Hashtable c_hs_Product = new Hashtable();

        List<Product_Info> c_lst_Product_Add_New = new List<Product_Info>();
        List<Product_Info> c_lst_Product_Delete = new List<Product_Info>();

        decimal _discount_price = 0;
        decimal _per_discount_price = 0;
        decimal _total_price = 0;
        decimal _per = 0;
        decimal _ship_price = 0;
        public bool c_ok = false;

        #region Events

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
            txtProductCode.Focus();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                exitForm();
            else if (e.Key == Key.Enter) Accept();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            exitForm();
        }

        private void dgrProduct_Detail_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void dgrProduct_Detail_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                Delete_Product();
                e.Handled = true;
            }
        }

        private void dgrProduct_Return_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void dgrProduct_Return_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete) e.Handled = true;
        }

        private void txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBox textbox = (TextBox)e.Source;
                switch (textbox.Name)
                {
                    case "txtTotalPrice":
                        CommonFunction.Text_Change_Format_Money(txtTotalPrice);
                        break;

                    case "txtCount":
                        CommonFunction.Text_Change_Format_Money(txtCount);
                        break;
                    case "txtPerDiscount":
                        Call_PerDiscount();
                        break;

                    case "txtShipPrice":
                        Call_Ship_Price();
                        break;

                    case "txtDiscount":
                        Call_Discount();
                        break;

                    case "txtPayPrice":
                        CommonFunction.Text_Change_Format_Money(txtPayPrice);
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void txtProductCode_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Get_Product_ByCode(txtProductCode.Text.ToUpper());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Add_Product();
            Call_Price_Sale_Header();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            Accept();
        }

        private void btnTraHang_Click(object sender, RoutedEventArgs e)
        {
            Delete_Product();
        }

        #endregion

        #region Methods

        void LoadData()
        {
            try
            {
                decimal _total_p = 0;
                Sale_Header_Controller _Product_Controller = new Sale_Header_Controller();
                c_list_Product_Buy = _Product_Controller.Get_Product_By_Sale_Header(c_Sale_Header_Info.SoHoaDon);
                dgrProduct_Detail.ItemsSource = c_list_Product_Buy;
                c_hs_Product = new Hashtable();

                foreach (Product_Info item in c_list_Product_Buy)
                {
                    item.Change_Type = Convert.ToInt16(Change_Product_Type.Normal);
                    item.Total_Price = item.DonGia_By_Type * item.Count_Sale_By_Header;
                    _total_p += item.DonGia_By_Type * item.Count_Sale_By_Header;
                    c_hs_Product[item.Product_Code.ToUpper()] = c_Product_Info_Search;
                }

                txtTotalPrice.Text = _total_p.ToString();

                if (c_Sale_Header_Info.SalesType == Convert.ToInt16(ThuChi_Type.Ban_Buon))
                {
                    this.Title = "Hóa đơn bán buôn " + c_Sale_Header_Info.SoHoaDon;
                }
                else if (c_Sale_Header_Info.SalesType == Convert.ToInt16(ThuChi_Type.Ban_Le))
                {
                    this.Title = "Hóa đơn bán lẻ " + c_Sale_Header_Info.SoHoaDon;
                }

                txtCustomer_Name.Text = c_Sale_Header_Info.Customer_Name;
                txtDiscount.Text = c_Sale_Header_Info.Discount.ToString();
                txtPayPrice.Text = c_Sale_Header_Info.Total_Amount.ToString();
                txtSaleDate.Text = c_Sale_Header_Info.Sale_Date.ToString("dd/MM/yyyy");
                txtShipPrice.Text = c_Sale_Header_Info.Ship_Price.ToString();
                //txtPhone.Text = c_Sale_Header_Info.
                if (c_Sale_Header_Info.Per_Discont != 0)
                    txtPerDiscount.Text = c_Sale_Header_Info.Per_Discont.ToString("###,###,0") + "%";
                else
                    txtPerDiscount.Text = c_Sale_Header_Info.Per_Discount_Price.ToString();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Accept()
        {
            try
            {
                MessageBoxResult result = NoteBox.Show("Bạn có muốn thay đổi hóa đơn này hay không form hay không?", "Thông báo", NoteBoxLevel.Question);
                if (result != MessageBoxResult.Yes) return;
                Sale_Header_Controller _Sale_Header_Controller = new Sale_Header_Controller();

                decimal _per_dc = 0;

                foreach (Product_Info item in c_lst_Product_Delete)
                {
                    if (item.Change_Type == Convert.ToInt16(Change_Product_Type.Normal))
                        _Sale_Header_Controller.Change_Product_ByHeader_Old(c_Sale_Header_Info, item.Product_Id, item.Count_Sale_By_Header,
                            Convert.ToDecimal(txtPayPrice.Text), DateTime.Now);
                }

                foreach (Product_Info item in c_lst_Product_Add_New)
                {
                    if (item.Change_Type == Convert.ToInt16(Change_Product_Type.AddNew))
                        _Sale_Header_Controller.Change_Product_ByHeader_New(c_Sale_Header_Info, item.Product_Id, item.Count_Sale_By_Header, _per_dc,
                            Convert.ToDecimal(txtPayPrice.Text), DateTime.Now);
                }

                NoteBox.Show("Thay đổi hóa đơn thành công");
                c_ok = true;
                this.Close();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Get_Product_ByCode(string p_code)
        {
            try
            {
                if (txtProductCode.Text == "")
                {
                    lblProduct_Name.Content = "";
                    lblSalePrice.Content = "";
                    lblRemain.Content = "";
                    c_Product_Info_Search = null;

                    return;
                }

                List<Product_Info> _lst = c_Product_Controller.Product_Get_By_Code(p_code);

                if (_lst.Count == 1)
                {
                    lblProduct_Name.Content = _lst[0].Name.ToUpper();

                    lblSalePrice.Content = _lst[0].BanLe_Price.ToString("###,###");
                    lblRemain.Content = _lst[0].Total_Remain.ToString("###,###");
                    txtProductCode.Text = _lst[0].Product_Code.ToUpper();
                    txtCount.Text = "";
                    c_Product_Info_Search = _lst[0];
                }
                else if (_lst.Count == 0)
                {
                    lblProduct_Name.Content = "";
                }
                else
                {
                    frmSearchProduct _frmSearchProduct = new frmSearchProduct();
                    _frmSearchProduct.Owner = Window.GetWindow(this);
                    _frmSearchProduct.c_lst_Product_Info = _lst;
                    _frmSearchProduct.ShowDialog();
                    if (_frmSearchProduct.c_ok == 1)
                    {
                        c_Product_Info_Search = _frmSearchProduct.c_Product_Info_Search;
                        lblProduct_Name.Content = c_Product_Info_Search.Name.ToUpper();

                        if (c_Sale_Header_Info.SalesType == Convert.ToInt16(ThuChi_Type.Ban_Le))
                            lblSalePrice.Content = c_Product_Info_Search.BanLe_Price.ToString("###,###");
                        else if (c_Sale_Header_Info.SalesType == Convert.ToInt16(ThuChi_Type.Ban_Buon))
                            lblSalePrice.Content = c_Product_Info_Search.BanBuon_Price.ToString("###,###");

                        lblRemain.Content = c_Product_Info_Search.Total_Remain.ToString("###,###");
                        txtProductCode.Text = c_Product_Info_Search.Product_Code.ToUpper();
                        txtCount.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Add_Product()
        {
            try
            {
                if (txtCount.Text == "")
                {
                    NoteBox.Show("Nhập số lượng sản phẩm ", "", NoteBoxLevel.Error);
                    return;
                }
                if (c_Product_Info_Search == null) return;

                decimal _count = Convert.ToDecimal(txtCount.Text);

                if (_count > c_Product_Info_Search.Total_Remain)
                {
                    NoteBox.Show("Mua nhiều thế !!!!! Số lượng trong hàng không đủ, hiện tại chỉ còn " + c_Product_Info_Search.Total_Remain.ToString(), "", NoteBoxLevel.Error);
                    txtCount.Focus();
                    txtCount.SelectAll();
                    return;
                }

                if (!c_hs_Product.ContainsKey(c_Product_Info_Search.Product_Code.ToUpper()))
                {
                    c_Product_Info_Search.Count_Sale_By_Header = _count;
                    c_Product_Info_Search.Change_Type = Convert.ToInt16(Change_Product_Type.AddNew);
                    if (c_Sale_Header_Info.SalesType == Convert.ToInt16(ThuChi_Type.Ban_Le))
                    {
                        c_Product_Info_Search.SalesType = Convert.ToInt16(ThuChi_Type.Ban_Le);
                        c_Product_Info_Search.Total_Price = _count * c_Product_Info_Search.BanLe_Price;
                        c_Product_Info_Search.DonGia_By_Type = c_Product_Info_Search.BanLe_Price;
                    }
                    else if (c_Sale_Header_Info.SalesType == Convert.ToInt16(ThuChi_Type.Ban_Buon))
                    {
                        c_Product_Info_Search.SalesType = Convert.ToInt16(ThuChi_Type.Ban_Buon);
                        c_Product_Info_Search.Total_Price = _count * c_Product_Info_Search.BanBuon_Price;
                        c_Product_Info_Search.DonGia_By_Type = c_Product_Info_Search.BanBuon_Price;
                    }
                    c_list_Product_Buy.Add(c_Product_Info_Search);

                    c_hs_Product[c_Product_Info_Search.Product_Code.ToUpper()] = c_Product_Info_Search;
                    c_lst_Product_Add_New.Add(c_Product_Info_Search);
                }
                else
                {
                    NoteBox.Show("Chỉ được thêm sản phẩm chưa có trong hóa đơn", "", NoteBoxLevel.Error);
                    txtCount.Focus();
                    txtCount.SelectAll();
                    return;
                }

                txtProductCode.Focus();
                txtProductCode.Text = "";
                lblProduct_Name.Content = "";
                lblRemain.Content = "";
                lblSalePrice.Content = "";

                dgrProduct_Detail.ItemsSource = c_list_Product_Buy;
                dgrProduct_Detail.Items.Refresh();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Delete_Product()
        {
            try
            {
                Product_Info _Product_Info = (Product_Info)dgrProduct_Detail.SelectedItem;
                if (_Product_Info == null) return;

                MessageBoxResult result = NoteBox.Show("Bạn có muốn TRẢ LẠI sản phẩm này hay không?", "Thông báo", NoteBoxLevel.Question);
                if (result == MessageBoxResult.Yes)
                {

                    //c_list_Product_Buy.Remove(_Product_Info);
                    //c_lst_Product_Delete.Add(_Product_Info);
                    //dgrProduct_Detail.Items.Refresh();

                    //dgrProduct_Return.ItemsSource = c_lst_Product_Delete;
                    //dgrProduct_Return.Items.Refresh();

                    //Call_Price_Sale_Header();

                    frmRepayProduct _frmRepayProduct = new frmRepayProduct();
                    _frmRepayProduct.c_Product_Info = _Product_Info;
                    _frmRepayProduct.c_Sale_Header_Info = c_Sale_Header_Info;
                    _frmRepayProduct.Owner = Window.GetWindow(this);
                    _frmRepayProduct.ShowDialog();

                    if (_frmRepayProduct.c_count_repay != 0 && _frmRepayProduct.c_ok == 1)
                    {
                        if (_frmRepayProduct.c_count_repay == _Product_Info.Count_Sale_By_Header)
                        {
                            c_list_Product_Buy.Remove(_Product_Info);
                            c_lst_Product_Delete.Add(_Product_Info);
                            dgrProduct_Detail.Items.Refresh();

                            dgrProduct_Return.ItemsSource = c_lst_Product_Delete;
                            dgrProduct_Return.Items.Refresh();

                            Call_Price_Sale_Header();
                        }
                        else
                        {
                            Product_Info _Product_Info_Del = new Product_Info();
                            // cập nhật lại số lượng mua
                            _Product_Info.Count_Sale_By_Header = _Product_Info.Count_Sale_By_Header - _frmRepayProduct.c_count_repay;

                            _Product_Info_Del.Product_Id = _Product_Info.Product_Id;
                            _Product_Info_Del.Name = _Product_Info.Name;
                            _Product_Info_Del.DonGia_By_Type = _Product_Info.DonGia_By_Type;
                            _Product_Info_Del.Count_Sale_By_Header = _frmRepayProduct.c_count_repay;
                            _Product_Info_Del.Total_Price = _frmRepayProduct.c_count_repay * _Product_Info.DonGia_By_Type;
                            c_lst_Product_Delete.Add(_Product_Info_Del);

                            // gán lại source và refresh lại
                            dgrProduct_Return.ItemsSource = c_lst_Product_Delete;
                            dgrProduct_Detail.Items.Refresh();
                            dgrProduct_Return.Items.Refresh();

                            Call_Price_Sale_Header();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void exitForm()
        {
            MessageBoxResult result = NoteBox.Show("Bạn có muốn thoát khỏi form hay không?", "Thông báo", NoteBoxLevel.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
            else
                this.Focus();
        }

        #region Caculate

        void Call_PerDiscount()
        {
            try
            {
                if (txtPerDiscount.Text == "")
                {
                    _per_discount_price = 0;
                    txtPayPrice.Text = (_total_price - _discount_price - _per_discount_price + _ship_price).ToString("###,##0");
                }
                else if (!txtPerDiscount.Text.Contains("%"))
                {
                    CommonFunction.Text_Change_Format_Money(txtPerDiscount);

                    if (txtTotalPrice.Text == "") return;
                    _total_price = Convert.ToDecimal(txtTotalPrice.Text);

                    _per_discount_price = Convert.ToDecimal(txtPerDiscount.Text);

                    txtPayPrice.Text = (_total_price - _per_discount_price - _discount_price + _ship_price).ToString("###,##0");
                }
                else
                {
                    if (txtTotalPrice.Text == "") return;
                    _total_price = Convert.ToDecimal(txtTotalPrice.Text);

                    _per = Convert.ToDecimal(txtPerDiscount.Text.Remove(txtPerDiscount.Text.Length - 1, 1));

                    _per_discount_price = (_total_price / 100) * _per;

                    txtPayPrice.Text = (_total_price - _per_discount_price - _discount_price + _ship_price).ToString("###,##0");
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Call_Ship_Price()
        {
            try
            {
                CommonFunction.Text_Change_Format_Money(txtShipPrice);

                if (txtShipPrice.Text == "")
                    _ship_price = 0;
                else
                    _ship_price = Convert.ToDecimal(txtShipPrice.Text);

                if (txtTotalPrice.Text == "") return;
                _total_price = Convert.ToDecimal(txtTotalPrice.Text);

                txtPayPrice.Text = (_total_price - _per_discount_price - _discount_price + _ship_price).ToString("###,##0");

            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        /// <summary>
        /// Tổng tiền - số tiền khuyến mại
        /// </summary>
        void Call_Discount()
        {
            try
            {
                CommonFunction.Text_Change_Format_Money(txtDiscount);

                if (txtDiscount.Text == "")
                    _discount_price = 0;
                else
                    _discount_price = Convert.ToDecimal(txtDiscount.Text);

                if (txtTotalPrice.Text == "") return;
                _total_price = Convert.ToDecimal(txtTotalPrice.Text);

                txtPayPrice.Text = (_total_price - _discount_price - _per_discount_price + _ship_price).ToString("###,##0");
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Call_Price_Sale_Header()
        {
            try
            {
                decimal _total_p = 0;
                decimal _total_c = 0;
                foreach (Product_Info item in c_list_Product_Buy)
                {
                    item.Total_Price = item.Count_Sale_By_Header * item.BanLe_Price;
                    _total_p += item.BanLe_Price * item.Count_Sale_By_Header;

                    _total_c += item.Count_Sale_By_Header;
                }

                txtTotalPrice.Text = _total_p.ToString();
                Call_PerDiscount();
                txtPayPrice.Text = (_total_p - _discount_price - _per_discount_price + _ship_price).ToString("###,##0");
                if (txtPayPrice.Text == "")
                {
                    txtPayPrice.Text = "0";
                }
                dgrProduct_Detail.Items.Refresh();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        #endregion


        #endregion
    }
}
