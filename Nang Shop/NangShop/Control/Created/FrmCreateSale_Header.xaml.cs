using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

using NangShopObj;
using System.Data;
using NangShop.Common;
using NangShop_DataControl;
using System.Collections;
using NangShop.Control.Search;
using NangShop.Control.View;
namespace NangShop.Control.Created
{
    /// <summary>
    /// Interaction logic for FrmCreateSale_Header.xaml
    /// </summary>
    public partial class FrmCreateSale_Header : Window
    {
        public FrmCreateSale_Header()
        {
            InitializeComponent();
        }

        Product_Controller c_Product_Controller = new Product_Controller();

        List<Product_Info> c_list_Product_Buy = new List<Product_Info>(); // chứa danh sách sp mua
        Hashtable c_hs_Product = new Hashtable();

        Product_Info c_Product_Info_Search = new Product_Info(); // sản phẩm vừa tìm kiếm được

        //bool c_error = false;

        decimal _discount_price = 0;
        decimal _per_discount_price = 0;
        decimal _total_price = 0;
        decimal _per = 0;
        decimal _ship_price = 0;

        Customer_Info c_Customer_Info = new Customer_Info();

        #region Events

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) exitForm();
            else if (e.Key == Key.Enter) Accept();
            else if (e.Key == Key.F3)
                btnChose_Click(null, null);

            else if (e.Key == Key.F6)
            {
                txtProductCode.Text = "";
                txtProductCode.Focus();
            }
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            Export();
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            Accept();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            exitForm();
        }

        private void dgrProduct_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void dgrProduct_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                Delete_Product();
                e.Handled = true;
            }
        }

        private void btnChose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                frmSearchProduct _frmSearchProduct = new frmSearchProduct();
                _frmSearchProduct.Owner = Window.GetWindow(this);
                _frmSearchProduct.ShowDialog();
                if (_frmSearchProduct.c_ok == 1)
                {
                    c_Product_Info_Search = _frmSearchProduct.c_Product_Info_Search;
                    txtProductCode.Text = c_Product_Info_Search.Product_Code;
                    txtCount.Text = "";
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBox textbox = (TextBox)e.Source;
                switch (textbox.Name)
                {
                    case "txtCount_Grid":
                        CommonFunction.Text_Change_Format_Money(txtCount_Grid);
                        break;

                    case "txtTotal_Count":
                        CommonFunction.Text_Change_Format_Money(txtTotal_Count);
                        break;
                    case "txtCount":
                        CommonFunction.Text_Change_Format_Money(txtCount);
                        break;

                    case "txtTotalPrice":
                        CommonFunction.Text_Change_Format_Money(txtTotalPrice);
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

        private void dgrProduct_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                int _rowselect = dgrProduct.SelectedIndex;
                Product_Info _Product_Info = (Product_Info)dgrProduct.SelectedItem;

                string tem = "";
                if (e.EditingElement.ToString() != "")
                {
                    tem = ((System.Windows.Controls.TextBox)(e.EditingElement)).Text;
                    tem = tem.Replace(",", "").Trim();
                    tem = tem.Replace(".", "").Trim();
                }

                if (tem != "" && !Check_Price(tem))
                {
                    DataGridHelper.NVSFocus(dgrProduct, _rowselect, 10);
                    NoteBox.Show("Chiết khấu không đúng định dạng", "Lỗi", NoteBoxLevel.Error);
                }
                else
                {
                    Call_Price_Sale_Header();
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

        /// <summary>
        /// hàm dùng cho EventsSetter trong form display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DoubleClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Product_Info _Product_Info = (Product_Info)dgrProduct.SelectedItem;
                if (_Product_Info != null)
                {
                    c_Product_Info_Search = _Product_Info;
                    txtProductCode.Text = c_Product_Info_Search.Product_Code;
                    lblProduct_Name.Content = c_Product_Info_Search.Name.ToUpper();

                    lblSalePrice.Content = c_Product_Info_Search.BanLe_Price.ToString("###,###");
                    lblRemain.Content = c_Product_Info_Search.Total_Remain.ToString("###,###");
                    txtCount.Text = c_Product_Info_Search.Count_Sale_By_Header.ToString();
                }
                e.Handled = true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void btnSearchCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                frmSearch_Customer _frmSearch_Customer = new frmSearch_Customer();
                _frmSearch_Customer.Owner = Window.GetWindow(this);
                _frmSearch_Customer.ShowDialog();
                if (_frmSearch_Customer.c_ok == 1)
                {
                    c_Customer_Info = _frmSearch_Customer.c_Customer_Info_Search;
                    txtCustomer_Name.Text = c_Customer_Info.Customer_Name;

                    txtPhone.Text = c_Customer_Info.Phone;
                    txtAddress.Text = c_Customer_Info.Address;
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void btnViewProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (c_Product_Info_Search == null) return;
                View_Product_Detail _View_Product_Detail = new View_Product_Detail();
                _View_Product_Detail.p_Product_Info = c_Product_Info_Search;
                _View_Product_Detail.Owner = Window.GetWindow(this);
                _View_Product_Detail.ShowDialog();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void btnQuickSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                frmSearchProduct _frmSearchProduct = new frmSearchProduct();
                _frmSearchProduct.Owner = Window.GetWindow(this);
                _frmSearchProduct.ShowDialog();
                if (_frmSearchProduct.c_ok == 1)
                {
                    c_Product_Info_Search = _frmSearchProduct.c_Product_Info_Search;
                    lblProduct_Name.Content = c_Product_Info_Search.Name.ToUpper();

                    lblSalePrice.Content = c_Product_Info_Search.BanLe_Price.ToString("###,###");
                    lblRemain.Content = c_Product_Info_Search.Total_Remain.ToString("###,###");
                    txtProductCode.Text = c_Product_Info_Search.Product_Code.ToUpper();
                    txtCount.Text = "";

                    Get_Product_Color(c_Product_Info_Search.Product_Id);
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }

        }

        #endregion

        #region Methods

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

        void LoadData()
        {
            try
            {
                dpSaleDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtProductCode.Focus();

                Allcode_Controller _Allcode_Controller = new Allcode_Controller();
                List<AllCode_Info> _lst = _Allcode_Controller.Get_AllCode_ByCdNameCdType("SALE_HEADER", "PAY_TYPE");

                cboPayType.SelectedValuePath = "CdValue";
                cboPayType.DisplayMemberPath = "Content";
                cboPayType.ItemsSource = _lst;
                cboPayType.SelectedIndex = 0;

                Create_Sale_Header_Code();
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
                MessageBoxResult result = NoteBox.Show("Bạn có muốn xóa sản phẩm hay không?", "Thông báo", NoteBoxLevel.Question);
                if (result != MessageBoxResult.Yes) return;

                Product_Info _Product_Info = (Product_Info)dgrProduct.SelectedItem;
                c_list_Product_Buy.Remove(_Product_Info);
                c_hs_Product.Remove(_Product_Info.Product_Code.ToUpper());
                Call_Price_Sale_Header();
                dgrProduct.Items.Refresh();
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
                if (!CheckValidate()) return;

                MessageBoxResult result = NoteBox.Show("Bạn có muốn tạo hóa đơn này hay không?", "Thông báo", NoteBoxLevel.Question);
                if (result != MessageBoxResult.Yes) return;

                // insert vao bảng sale header 

                Sale_Header_Controller _Sale_Header_Controller = new Sale_Header_Controller();
                List<Sale_Detail_Info> _Sale_Detail_Info = new List<Sale_Detail_Info>();

                Sale_Header_Info _Sale_Header_Info = Get_Sale_Header(ref _Sale_Detail_Info);

                if (_Sale_Header_Info == null)
                {
                    NoteBox.Show("Lỗi rồi", "", NoteBoxLevel.Error);
                    return;
                }

                decimal _id = 0;

                if (_Sale_Header_Controller.Sale_Header_Insert(_Sale_Header_Info, ref _id))
                {
                    #region insert vào bảng thu chi
                    ThuChi_Controller _ThuChi_Controller = new ThuChi_Controller();
                    ThuChi_Info _ThuChi_Info = Get_ThuChi();
                    _ThuChi_Info.Customer_Id = _Sale_Header_Info.Customer_Id;
                    if (_ThuChi_Info == null)
                    {
                        NoteBox.Show("Lỗi rồi", "", NoteBoxLevel.Error);
                        _Sale_Header_Controller.Sale_Header_Delete(_id);
                        return;
                    }
                    if (!_ThuChi_Controller.ThuChi_Insert(_ThuChi_Info))
                    {
                        NoteBox.Show("Lỗi rồi", "", NoteBoxLevel.Error);
                        _Sale_Header_Controller.Sale_Header_Delete(_id);
                        return;
                    }
                    #endregion

                    foreach (Sale_Detail_Info item in _Sale_Detail_Info)
                    {
                        _Sale_Header_Controller.Sale_Detail_Insert(item, _id);
                        _ThuChi_Controller.Update_Product_Sale_Count(item.Product_Id, item.Count, item.Color_Id);
                    }

                    // cập nhật lại số lượng bán của thằng product

                    Export();

                    NoteBox.Show("Tạo hóa đơn thành công");
                    this.Close();
                }
                else
                {
                    NoteBox.Show("Lỗi rồi", "", NoteBoxLevel.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        /// <summary>
        /// Kiểm tra xem có lớn hơn 0 hay không
        /// </summary>
        bool Check_Price(string st)
        {
            try
            {
                if (st.Contains(",") || st.Contains("."))
                    return false;
                else
                {
                    decimal Num;

                    bool isNum = decimal.TryParse(st, out Num);

                    if (isNum)
                    {
                        decimal.TryParse(st, out Num);
                        if (Num < 0)
                            return false;
                        else return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        void Call_PerDiscount()
        {
            try
            {
                if (txtPerDiscount.Text == "")
                {
                    _per_discount_price = 0;
                    txtPayPrice.Text = (_total_price - _discount_price - _per_discount_price + _ship_price).ToString();
                }
                else if (!txtPerDiscount.Text.Contains("%"))
                {
                    CommonFunction.Text_Change_Format_Money(txtPerDiscount);

                    if (txtTotalPrice.Text == "") return;
                    _total_price = Convert.ToDecimal(txtTotalPrice.Text);

                    _per_discount_price = Convert.ToDecimal(txtPerDiscount.Text);

                    txtPayPrice.Text = (_total_price - _per_discount_price - _discount_price + _ship_price).ToString();
                }
                else
                {
                    if (txtTotalPrice.Text == "") return;
                    _total_price = Convert.ToDecimal(txtTotalPrice.Text);

                    _per = Convert.ToDecimal(txtPerDiscount.Text.Remove(txtPerDiscount.Text.Length - 1, 1));

                    _per_discount_price = (_total_price / 100) * _per;

                    txtPayPrice.Text = (_total_price - _per_discount_price - _discount_price + _ship_price).ToString();
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

                txtPayPrice.Text = (_total_price - _per_discount_price - _discount_price + _ship_price).ToString();

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

                txtPayPrice.Text = (_total_price - _discount_price - _per_discount_price + _ship_price).ToString();
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

                    Get_Product_Color(c_Product_Info_Search.Product_Id);
                }
                else if (_lst.Count == 0)
                {
                    lblProduct_Name.Content = "";
                    lblSalePrice.Content = "";
                    lblRemain.Content = "";
                    c_Product_Info_Search = null;
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

                        lblSalePrice.Content = c_Product_Info_Search.BanLe_Price.ToString("###,###");
                        lblRemain.Content = c_Product_Info_Search.Total_Remain.ToString("###,###");
                        txtProductCode.Text = c_Product_Info_Search.Product_Code.ToUpper();
                        txtCount.Text = "";

                        Get_Product_Color(c_Product_Info_Search.Product_Id);
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
                    NoteBox.Show("Mua nhiều thế !!!!! Số lượng trong hàng không đủ, hiện tại chỉ còn " + c_Product_Info_Search.Total_Remain.ToString("###,###,0") + " sản phẩm", "", NoteBoxLevel.Error);
                    txtCount.Focus();
                    txtCount.SelectAll();
                    return;
                }

                decimal _color_id = 0;

                if (cboColor.Text != "")
                {
                    _color_id = Convert.ToDecimal(cboColor.SelectedValue);
                    c_Product_Info_Search.Color_Name = cboColor.Text;
                    c_Product_Info_Search.Color_Id = _color_id;

                    Product_Detail_Info _Product_Detail_Info = (Product_Detail_Info)cboColor.SelectedItem;

                    if (_count > _Product_Detail_Info.Remain_Count)
                    {
                        NoteBox.Show("Mua nhiều thế !!!!! Số lượng trong hàng không đủ, hiện tại chỉ còn " + _Product_Detail_Info.Remain_Count.ToString("###,###,0") + " sản phẩm", "", NoteBoxLevel.Error);
                        txtCount.Focus();
                        txtCount.SelectAll();
                        return;
                    }
                }

                string _key = c_Product_Info_Search.Product_Code.ToUpper() + "_" + _color_id.ToString();

                if (!c_hs_Product.ContainsKey(_key))
                {
                    c_Product_Info_Search.Count_Sale_By_Header = _count;
                    c_Product_Info_Search.Total_Price = c_Product_Info_Search.Count_Sale_By_Header * c_Product_Info_Search.BanLe_Price;
                    c_list_Product_Buy.Add(c_Product_Info_Search);

                    c_hs_Product[_key] = c_Product_Info_Search;
                }
                else
                {
                    Product_Info _Product_Info = (Product_Info)c_hs_Product[_key];
                    //_Product_Info.Count_Sale_By_Header = _Product_Info.Count_Sale_By_Header + _count;
                    _Product_Info.Count_Sale_By_Header = _count;
                    _Product_Info.Total_Price = c_Product_Info_Search.Count_Sale_By_Header * c_Product_Info_Search.BanLe_Price;
                }

                txtProductCode.Focus();
                txtProductCode.Text = "";
                lblProduct_Name.Content = "";
                lblRemain.Content = "";
                lblSalePrice.Content = "";
                txtCount.Text = "";

                dgrProduct.ItemsSource = c_list_Product_Buy;
                dgrProduct.Items.Refresh();
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
                txtTotal_Count.Text = _total_c.ToString();
                txtCount_Grid.Text = c_list_Product_Buy.Count.ToString();

                txtPayPrice.Text = (_total_p - _discount_price - _per_discount_price + _ship_price).ToString();

                dgrProduct.Items.Refresh();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        Sale_Header_Info Get_Sale_Header(ref List<Sale_Detail_Info> p_Sale_Detail_Info)
        {
            try
            {
                Sale_Header_Info _Sale_Header_Info = new Sale_Header_Info();
                _Sale_Header_Info.UserName = CommonData.c_Urser_Info.User_Name;

                _Sale_Header_Info.Customer_Id = Insert_Customer();
                _Sale_Header_Info.BranchId = 0;
                _Sale_Header_Info.Sale_Date = ConvertData.ConvertString2Date(dpSaleDate.Text);
                _Sale_Header_Info.SalesType = Convert.ToInt16(ThuChi_Type.Ban_Le);
                _Sale_Header_Info.Total_Amount = Convert.ToDecimal(txtPayPrice.Text);
                _Sale_Header_Info.Debt_Amount = 0;

                _Sale_Header_Info.CreatedDate = DateTime.Now;
                _Sale_Header_Info.Comment = txtNote.Text;
                _Sale_Header_Info.SoHoaDon = txtSaleHeader.Text;

                if (txtShipPrice.Text != "")
                    _Sale_Header_Info.Ship_Price = Convert.ToDecimal(txtShipPrice.Text);
                else
                    _Sale_Header_Info.Ship_Price = 0;

                if (txtDiscount.Text != "")
                    _Sale_Header_Info.Discount = Convert.ToDecimal(txtDiscount.Text);
                else
                    _Sale_Header_Info.Discount = 0;

                if (txtPerDiscount.Text.Contains("%"))
                {
                    _Sale_Header_Info.Per_Discont = Convert.ToDecimal(txtPerDiscount.Text.Remove(txtPerDiscount.Text.Length - 1, 1));
                    _Sale_Header_Info.Per_Discount_Price = 0;
                }
                else
                {
                    _Sale_Header_Info.Per_Discont = 0;

                    if (txtPerDiscount.Text != "" && txtPerDiscount.Text != "0")
                        _Sale_Header_Info.Per_Discount_Price = Convert.ToDecimal(txtPerDiscount.Text);
                    else
                        _Sale_Header_Info.Per_Discount_Price = 0;
                }

                _Sale_Header_Info.Pay_Type = Convert.ToInt16(cboPayType.SelectedValue);
                p_Sale_Detail_Info = new List<Sale_Detail_Info>();

                foreach (Product_Info item in c_list_Product_Buy)
                {
                    Sale_Detail_Info _Sale_Detail_Info = new Sale_Detail_Info();

                    _Sale_Detail_Info.Product_Id = item.Product_Id;
                    _Sale_Detail_Info.Status = Convert.ToInt16(Status_Type.DaBan);
                    _Sale_Detail_Info.Count = Convert.ToInt16(item.Count_Sale_By_Header);
                    _Sale_Detail_Info.Color_Id = Convert.ToInt16(item.Color_Id);

                    p_Sale_Detail_Info.Add(_Sale_Detail_Info);
                }

                return _Sale_Header_Info;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Tạo mã hóa đơn
        /// </summary>
        void Create_Sale_Header_Code()
        {
            try
            {
                Sale_Header_Controller _Sale_Header_Controller = new Sale_Header_Controller();

                // lấy ra id hiện tại của thằng product
                decimal _max_id = _Sale_Header_Controller.Sale_Header_Get_Max_Id();

                txtSaleHeader.Text = "HD_SALE_ODD_" + DateTime.Now.ToString("dd_MM_yyyy") + "_" + (_max_id + 1).ToString();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        ThuChi_Info Get_ThuChi()
        {
            try
            {
                ThuChi_Info _ThuChi_Info = new ThuChi_Info();

                _ThuChi_Info.SoHoadon = txtSaleHeader.Text;
                _ThuChi_Info.Price = Convert.ToDecimal(txtPayPrice.Text);

                _ThuChi_Info.ThuChi = Convert.ToInt16(ThuChi_Type.Ban_Le);
                _ThuChi_Info.Create_Date = DateTime.Now;
                _ThuChi_Info.DienGiai = txtNote.Text;
                _ThuChi_Info.Supplier_Id = 0;
                _ThuChi_Info.Customer_Id = 0; // ID khách hàng
                return _ThuChi_Info;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Nếu có ng dùng đó rồi thì ko insert nữa
        /// </summary>
        int Insert_Customer()
        {
            try
            {
                decimal _kq = 0;

                Customer_Controller _Customer_Controller = new Customer_Controller();
                List<Customer_Info> _lst = _Customer_Controller.Search_Customer(txtCustomer_Name.Text, txtPhone.Text);

                if (_lst.Count == 0)
                {
                    Customer_Info _Customer_Info = new Customer_Info();
                    _Customer_Info.Customer_Name = txtCustomer_Name.Text;
                    _Customer_Info.Phone = txtPhone.Text;
                    _Customer_Info.Address = txtAddress.Text;

                    if (!_Customer_Controller.Customer_Insert(_Customer_Info, ref _kq))
                    {
                        // Thêm mới 
                        NoteBox.Show("Lỗi rồi Nắng. Thêm mới khách hàng ko thành công", "", NoteBoxLevel.Error);
                        return -1;
                    }
                    else return Convert.ToInt32(_kq);
                }
                else if (_lst.Count == 1)
                {
                    return _lst[0].Customer_Id;
                }

                return Convert.ToInt32(_kq);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return -1;
            }
        }

        void Get_Product_Color(decimal p_id_product)
        {
            try
            {
                List<Product_Detail_Info> _lst_color = c_Product_Controller.Get_Detail_By_Product(p_id_product);

                cboColor.ItemsSource = _lst_color;
                cboColor.DisplayMemberPath = "Color_Name";
                cboColor.SelectedValuePath = "Color_Id";
                if (_lst_color.Count > 0)
                    cboColor.SelectedIndex = 0;

                string _remain_count = "";
                foreach (Product_Detail_Info item in _lst_color)
                {
                    _remain_count += item.Remain_Count.ToString("###,###,0") + ":" + item.Color_Name + " | ";
                }
                if (_remain_count.Length > 0)
                {
                    _remain_count = _remain_count.Remove(_remain_count.Length - 2, 1);
                    lblRemain.Content = _remain_count;
                }
                else
                    lblRemain.Content = c_Product_Info_Search.Total_Remain.ToString("###,###");
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        bool CheckValidate()
        {
            try
            {
                if (txtCustomer_Name.Text == "")
                {
                    NoteBox.Show("Tên khách hàng không được để trống", "", NoteBoxLevel.Error);
                    txtCustomer_Name.Focus();
                    return false;
                }

                if (txtTotalPrice.Text == "")
                {
                    NoteBox.Show("Tiền hàng không được để trống", "", NoteBoxLevel.Error);
                    txtTotalPrice.Focus();
                    return false;
                }

                if (txtTotalPrice.Text == "0")
                {
                    NoteBox.Show("Tiền hàng không được bằng 0", "", NoteBoxLevel.Error);
                    txtTotalPrice.Focus();
                    return false;
                }

                if (txtPayPrice.Text == "")
                {
                    NoteBox.Show("Số tiền thanh toán không được để trống", "", NoteBoxLevel.Error);
                    txtPayPrice.Focus();
                    return false;
                }

                if (txtPayPrice.Text == "0")
                {
                    NoteBox.Show("Số tiền thanh toán không được bằng 0", "", NoteBoxLevel.Error);
                    txtPayPrice.Focus();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        void Export()
        {
            try
            {
                #region Kết xuất

                FlexCel.Report.FlexCelReport flcReport = new FlexCel.Report.FlexCelReport();
                string _path = CommonData.ExcelDesignFilePath;
                string _fileExcelName = "Hoa_Don_Ban_Le.xls";
                DataSet ds_all = new DataSet();
                DataTable _dt = ConvertData.ConvertToDatatable(c_list_Product_Buy);
                _dt.Columns.Add("STT");
                int index = 1;
                foreach (DataRow item in _dt.Rows)
                {
                    item["STT"] = index;
                    index++;
                }

                ds_all.Tables.Add(_dt);
                ds_all.Tables[0].TableName = "BanLe";

                if (ds_all.Tables.Count <= 0)
                {
                    Mouse.OverrideCursor = null;
                    NoteBox.Show("Không có dữ liệu để kết xuất", "Thông báo", NoteBoxLevel.Note);
                    return;
                }
                if (ds_all.Tables[0].Rows.Count <= 0)
                {
                    Mouse.OverrideCursor = null;
                    NoteBox.Show("Không có dữ liệu để kết xuất", "Thông báo", NoteBoxLevel.Note);
                    return;
                }

                _path += _fileExcelName;

                CommonFunction.SetValueExportByDataTable(ref flcReport, ds_all);

                CommonFunction.SetValueExportByString(ref flcReport, "SoHoaDon", txtSaleHeader.Text);
                CommonFunction.SetValueExportByString(ref flcReport, "Customer", txtCustomer_Name.Text);
                CommonFunction.SetValueExportByString(ref flcReport, "Address", txtAddress.Text);

                string _tienBangChu = ConvertData.ConvertMoneyToStr(Convert.ToDouble(txtPayPrice.Text));


                CommonFunction.SetValueExportByString(ref flcReport, "TienBangChu", _tienBangChu);

                System.Windows.Forms.SaveFileDialog saveReport = new System.Windows.Forms.SaveFileDialog();
                saveReport.Filter = "Excel files (*.xls)|*.xls";
                if (saveReport.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    CommonFunction.ExportExcel(flcReport, _path, saveReport);
                }
                #endregion
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

    
        #endregion
    }
}

