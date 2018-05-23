using System;
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
using System.Windows.Shapes;
using System.Collections;

using NangShopObj;
using System.Data;
using NangShop.Common;
using NangShop.Control.Created;
using NangShop_DataControl;

namespace NangShop.Control
{
    /// <summary>
    /// Interaction logic for Frm_NhapHang.xaml
    /// </summary>
    public partial class Frm_NhapHang : Window
    {

        #region Contrustor and params

        public Frm_NhapHang()
        {
            InitializeComponent();
        }

        List<Detail_Items_Info> c_lst_Detail_Items = new List<Detail_Items_Info>();
        //List<Product_Info> c_lst_Products = new List<Product_Info>();

        List<Product_Detail_Info> c_lst_Products_Detail = new List<Product_Detail_Info>();

        public decimal c_id_insert = 0;
        public int c_ok = 0;

        /// <summary>
        /// số dây áo
        /// </summary>
        decimal c_j_ao = 0;

        /// <summary>
        /// Số áo trên 1 dây
        /// </summary>
        decimal c_count = 0;

        decimal c_receive_price = 0;
        decimal c_per_ban_le = 0;
        decimal c_per_ban_buon = 0;
        decimal c_ship_price = 0;

        int c_from = 0; // size từ
        int c_to = 0;  // size đến


        Hashtable c_hs_color = new Hashtable(); // Danh sách màu Key ID
        #endregion

        #region Events

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dpReceiveDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtProduct_Name.Focus();

                Category_Controller _Category_Controller = new Category_Controller();
                List<Category_Info> _lst = _Category_Controller.Get_All();

                cboItem_Type.DisplayMemberPath = "Category_Name";
                cboItem_Type.SelectedValuePath = "Category_Id";

                cboItem_Type.ItemsSource = _lst;
                cboItem_Type.SelectedIndex = 0;

                Supplier_Controller _Supplier_Controller = new Supplier_Controller();
                List<Supplier_Info> _lst1 = _Supplier_Controller.Get_All();

                cboSupplier.DisplayMemberPath = "Supplier_Name";
                cboSupplier.SelectedValuePath = "Supplier_Id";

                cboSupplier.ItemsSource = _lst1;
                cboSupplier.SelectedIndex = 0;


                Allcode_Controller _Allcode_Controller = new Allcode_Controller();
                List<AllCode_Info> _lst2 = _Allcode_Controller.Get_AllCode_ByCdNameCdType("PRODUCT", "UNIT");

                cboUnit.SelectedValuePath = "CdValue";
                cboUnit.DisplayMemberPath = "Content";
                cboUnit.ItemsSource = _lst2;
                cboUnit.SelectedIndex = 0;

                Create_SoHoaDon();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                exitForm();
            else if (e.Key == Key.Enter)
                Accept();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            exitForm();
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            Accept();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    if (dgr_SalesProduct.SelectedItem != null)
            //    {
            //        MessageBoxResult result = NoteBox.Show("Bạn có bỏ xe này ko?", "Hỏi", NoteBoxLevel.Question);
            //        if (result == MessageBoxResult.Yes)
            //        {
            //            Products_ViewInfo data = dgr_SalesProduct.SelectedItem as Products_ViewInfo;
            //            for (int i = 0; i < lstProView.Count; i++)
            //            {
            //                if (lstProView[i].BarCode == data.BarCode && lstProView[i].SoMay == data.SoMay)
            //                {
            //                    lstProView.RemoveAt(i);
            //                    lstProIns.RemoveAt(i);
            //                    lstRecDetail.RemoveAt(i);
            //                }
            //            }
            //            dgr_SalesProduct.Items.Refresh();
            //        }
            //    }
            //    else
            //    {
            //        NoteBox.Show("Bạn hãy chọn xe loại bỏ trên lưới!");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    CommonData.log.Error(ex.ToString());
            //}
        }

        private void btnAuto_Click(object sender, RoutedEventArgs e)
        {
            Creat_Ri_by_Color();
        }

        private void dgrProduct_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void dgrProduct_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
                e.Handled = true;
        }

        private void ckb_Is_XuatDu_Checked(object sender, RoutedEventArgs e)
        {
            btnAuto.IsEnabled = false;
        }

        private void ckb_Is_XuatDu_UnChecked(object sender, RoutedEventArgs e)
        {
            btnAuto.IsEnabled = true;
        }

        private void cboItem_Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtProductCode.Text = Create_Product_Code();
        }

        #region Text Change

        private void txtCount_J_TextChanged(object sender, TextChangedEventArgs e)
        {
            CommonFunction.Text_Change_Format_Money(txtCount_J);

            if (txtCount_J.Text == "")
                c_j_ao = 0;
            else
                c_j_ao = Convert.ToDecimal(txtCount_J.Text);

            Call_Price();
        }

        private void txtCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            CommonFunction.Text_Change_Format_Money(txtCount);

            if (txtCount.Text == "")
                c_count = 0;
            else
                c_count = Convert.ToDecimal(txtCount.Text);

            Call_Price();
        }

        private void txtFromAge_TextChanged(object sender, TextChangedEventArgs e)
        {
            CommonFunction.Text_Change_Format_Money(txtFromAge);
        }

        private void txtToAge_TextChanged(object sender, TextChangedEventArgs e)
        {
            CommonFunction.Text_Change_Format_Money(txtToAge);
        }

        private void txtReceive_Price_TextChanged(object sender, TextChangedEventArgs e)
        {
            CommonFunction.Text_Change_Format_Money(txtReceive_Price);

            if (txtReceive_Price.Text == "")
                c_receive_price = 0;
            else
                c_receive_price = Convert.ToDecimal(txtReceive_Price.Text);

            Call_Price();
        }

        private void txtPerBanLe_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                txtPerBanLe.Text = Common.ConvertData.NhapSoTp(txtPerBanLe);

                if (txtPerBanLe.Text == "")
                    c_per_ban_le = 0;
                else
                    c_per_ban_le = Convert.ToDecimal(txtPerBanLe.Text);

                Call_Price();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void txtPerBanBuon_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                txtPerBanBuon.Text = Common.ConvertData.NhapSoTp(txtPerBanBuon);

                if (txtPerBanBuon.Text == "")
                    c_per_ban_buon = 0;
                else
                    c_per_ban_buon = Convert.ToDecimal(txtPerBanBuon.Text);

                Call_Price();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void txtPrice_BanBuon_TextChanged(object sender, TextChangedEventArgs e)
        {
            CommonFunction.Text_Change_Format_Money(txtPrice_BanBuon);
        }

        private void txtPrice_BanLe_TextChanged(object sender, TextChangedEventArgs e)
        {
            CommonFunction.Text_Change_Format_Money(txtPrice_BanLe);
        }

        private void txtTotal_Price_TextChanged(object sender, TextChangedEventArgs e)
        {
            CommonFunction.Text_Change_Format_Money(txtTotal_Price);
        }

        private void txtShip_Price_TextChanged(object sender, TextChangedEventArgs e)
        {
            CommonFunction.Text_Change_Format_Money(txtShip_Price);

            if (txtShip_Price.Text == "")
                c_ship_price = 0;
            else
                c_ship_price = Convert.ToDecimal(txtShip_Price.Text);

            Call_Price();

        }

        #endregion

        #endregion

        #region Methods

        private void exitForm()
        {
            MessageBoxResult result = NoteBox.Show("Bạn có muốn thoát khỏi form hay không?", "Thông báo", NoteBoxLevel.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
            else
                this.Focus();
        }

        bool CheckValidate_F()
        {
            try
            {
                if (txtProduct_Name.Text == "")
                {
                    NoteBox.Show("Tên áo không được để trống");
                    txtProduct_Name.Focus();
                    return false;
                }
                else if (cboItem_Type.Text == "")
                {
                    NoteBox.Show("Loại sản phẩm không được để trống");
                    cboItem_Type.Focus();
                    return false;
                }
                else if (txtProductCode.Text == "")
                {
                    NoteBox.Show("Mã sản phẩm không được để trống");
                    txtProductCode.Focus();
                    return false;
                }
                else if (txtCount_J.Text == "")
                {
                    NoteBox.Show("Số dây áo không được để trống");
                    txtCount_J.Focus();
                    return false;
                }

                //else if (ckb_Is_XuatDu.IsChecked == true && c_j_ao > 1)
                //{
                //    NoteBox.Show("Hàng xuất dư chỉ được nhập 1 dây áo");
                //    txtCount_J.Focus();
                //    return false;
                //}

                else if (txtCount.Text == "")
                {
                    NoteBox.Show("Số áo/dây không được để trống");
                    txtCount.Focus();
                    return false;
                }

                else if (dpReceiveDate.Text == "")
                {
                    NoteBox.Show("Ngày nhập không được để trống");
                    txtToAge.Focus();
                    return false;
                }
                else if (!CheckValidate.CheckValidDate(dpReceiveDate.Text))
                {
                    NoteBox.Show("Ngày nhập không đúng định dạng");
                    txtToAge.Focus();
                    return false;
                }

                else if (txtFromAge.Text == "")
                {
                    NoteBox.Show("Size áo từ không được để trống");
                    txtFromAge.Focus();
                    return false;
                }

                else if (txtToAge.Text == "")
                {
                    NoteBox.Show("Size áo đến không được để trống");
                    txtToAge.Focus();
                    return false;
                }
                else if (Convert.ToInt16(txtFromAge.Text) > Convert.ToInt16(txtToAge.Text))
                {
                    NoteBox.Show("Size áo từ không được lớn hơn Size áo đến");
                    txtFromAge.Focus();
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

        void Accept()
        {
            try
            {
                if (!CheckValidate_F()) return;

                #region  Insert vào bảng Items trước, trả ra mã ID vừa nhập

                Product_Info _Product_Info = Get_ItemInfo_FromControl();
                if (ckb_Is_XuatDu.IsChecked == true)
                    _Product_Info.Is_XuatDu = 1;
                else _Product_Info.Is_XuatDu = 0;

                Product_Controller _Product_Controller = new Product_Controller();
                ThuChi_Controller _ThuChi_Controller = new ThuChi_Controller();
                if (!_Product_Controller.Product_Insert(_Product_Info, ref c_id_insert))
                {
                    NoteBox.Show("Lỗi rồi Nắng ơi", "", NoteBoxLevel.Error);
                    return;
                }
                else
                {
                    #region insert vào bảng thu chi
                    ThuChi_Info _ThuChi_Info = Get_ThuChi();
                    if (_ThuChi_Info == null)
                    {
                        NoteBox.Show("Lỗi rồi Nắng ơi", "", NoteBoxLevel.Error);
                        _Product_Controller.Product_Delete(c_id_insert);
                        return;
                    }
                    if (!_ThuChi_Controller.ThuChi_Insert(_ThuChi_Info))
                    {
                        NoteBox.Show("Lỗi rồi Nắng ơi", "", NoteBoxLevel.Error);
                        _Product_Controller.Product_Delete(c_id_insert);
                        return;
                    }
                    #endregion

                    foreach (Product_Detail_Info item in c_lst_Products_Detail)
                    {
                        item.Product_Id = c_id_insert;

                        if (!_Product_Controller.Product_Detail_Insert(item))
                        {
                            NoteBox.Show("Lỗi rồi", "", NoteBoxLevel.Error);
                            _Product_Controller.Product_Detail_Delete(c_id_insert);
                            _Product_Controller.Product_Delete(c_id_insert);
                            return;
                        }
                    }

                    NoteBox.Show("Thêm mới thành công");
                    this.c_ok = 1;
                    this.Close();
                }


                #endregion

            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        /// <summary>
        /// Lấy màu cho lô áo nhập về
        /// </summary>
        /// <returns></returns>
        string Get_Color()
        {
            try
            {
                string _color_name = "";

                if (ckb_Is_XuatDu.IsChecked == true)
                {
                    return "Nhiều màu :)";
                }
                foreach (Product_Detail_Info item in c_lst_Products_Detail)
                {
                    _color_name += item.Color_Name + "|";
                }

                if (_color_name != "")
                    _color_name = _color_name.Remove(_color_name.Length - 1, 1);

                return _color_name;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return "";
            }
        }

        /// <summary>
        /// Lấy dữ liệu ItemInfo từ control
        /// </summary>
        /// <returns></returns>
        Product_Info Get_ItemInfo_FromControl()
        {
            try
            {
                Product_Info _Product_Info = new Product_Info();
                _Product_Info.Name = txtProduct_Name.Text; // tên
                _Product_Info.Receive_Price = Convert.ToDecimal(txtReceive_Price.Text); //
                _Product_Info.Per_BanBuon = Convert.ToDecimal(txtPerBanLe.Text); //
                _Product_Info.Per_BanLe = Convert.ToDecimal(txtPerBanBuon.Text); //

                _Product_Info.BanBuon_Price = Convert.ToDecimal(txtPrice_BanBuon.Text); //
                _Product_Info.BanLe_Price = Convert.ToDecimal(txtPrice_BanLe.Text); //

                _Product_Info.Category_Id = Convert.ToDecimal(cboItem_Type.SelectedValue);
                _Product_Info.Receive_Date = ConvertData.ConvertString2Date(dpReceiveDate.Text);
                _Product_Info.Color_Name = Get_Color();
                _Product_Info.Receive_Count = c_j_ao;
                _Product_Info.Count_by_Ri = c_count;
                _Product_Info.Total_Receive = c_j_ao * c_count;
                _Product_Info.Total_Sale = 0;
                _Product_Info.Unit = Convert.ToInt16(cboUnit.SelectedValue);

                if (txtShip_Price.Text != "")
                    _Product_Info.Ship_Price = Convert.ToDecimal(txtShip_Price.Text);
                else _Product_Info.Ship_Price = 0;

                if (cboSupplier.Text != "")
                    _Product_Info.Supplier_Id = Convert.ToDecimal(cboSupplier.SelectedValue);
                _Product_Info.Product_Code = txtProductCode.Text;
                _Product_Info.Note = txtNote.Text;
                _Product_Info.Size = c_from.ToString() + " - " + c_to.ToString();
                _Product_Info.User_Name = CommonData.c_Urser_Info.User_Name;

                return _Product_Info;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return null;
            }
        }

        ThuChi_Info Get_ThuChi()
        {
            try
            {
                ThuChi_Info _ThuChi_Info = new ThuChi_Info();

                _ThuChi_Info.SoHoadon = txtSoHoaDon.Text;
                _ThuChi_Info.Price = Convert.ToDecimal(txtTotal_Price.Text);
                _ThuChi_Info.ThuChi = Convert.ToInt16(ThuChi_Type.Nhap_Hang);
                _ThuChi_Info.Create_Date = DateTime.Now;
                _ThuChi_Info.DienGiai = txtNote.Text;
                _ThuChi_Info.Supplier_Id = Convert.ToInt16(cboSupplier.SelectedValue);
                _ThuChi_Info.Customer_Id = 0;
                return _ThuChi_Info;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return null;
            }
        }

        void Creat_Ri_by_Color()
        {
            try
            {
                if (!CheckValidate_F()) return;

                c_j_ao = Convert.ToInt16(txtCount_J.Text);
                c_from = Convert.ToInt16(txtFromAge.Text);
                c_to = Convert.ToInt16(txtToAge.Text);
                c_count = Convert.ToInt16(txtCount.Text);

                decimal _count = 0;
                foreach (Product_Detail_Info item in c_lst_Products_Detail)
                {
                    _count += item.Total_Count / c_count;
                }

                if (_count == c_j_ao)
                {
                    NoteBox.Show("Bạn đã nhập đủ số dây áo");
                    return;
                }

                frmCreate_Item _frmCreateItems = new frmCreate_Item();
                _frmCreateItems.Owner = Window.GetWindow(this);
                _frmCreateItems.c_count = c_j_ao - _count;
                _frmCreateItems.ShowDialog();
                if (_frmCreateItems.c_ok == 1)
                {
                    Product_Detail_Info _Product_Detail_Info = new Product_Detail_Info();
                    _Product_Detail_Info.Name = " Ri " + (c_lst_Products_Detail.Count + 1).ToString();
                    _Product_Detail_Info.Color_Id = _frmCreateItems.c_ProductInfo.Color_Id;
                    _Product_Detail_Info.Total_Count = _frmCreateItems.c_ProductInfo.Count_Ri_by_Color * c_count;
                    _Product_Detail_Info.Ri_Count = _frmCreateItems.c_ProductInfo.Count_Ri_by_Color;
                    _Product_Detail_Info.Size = c_from.ToString() + " - " + c_to.ToString();
                    _Product_Detail_Info.Color_Name = _frmCreateItems.c_ProductInfo.Color_Name;
                    c_lst_Products_Detail.Add(_Product_Detail_Info);

                    dgrProduct_VietNam.ItemsSource = c_lst_Products_Detail;
                    dgrProduct_VietNam.Items.Refresh();
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        string Create_Product_Code()
        {
            try
            {
                if (cboItem_Type == null) return "";

                string _res = "";
                Product_Controller _Product_Controller = new Product_Controller();

                Category_Info _Category_Info = (Category_Info)cboItem_Type.SelectedItem;

                string _name = CommonFunction.ConvertVN(_Category_Info.Category_Name);

                // lấy ra id hiện tại của thằng product
                decimal _max_id = _Product_Controller.Product_Get_Max_Id();

                _res = "NS_" + _name.ToUpper() + "_" + (_max_id + 1).ToString();

                return _res;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return "";
            }
        }

        void Create_SoHoaDon()
        {
            try
            {
                Sale_Header_Controller _Sale_Header_Controller = new Sale_Header_Controller();

                // lấy ra id hiện tại của thằng product
                decimal _max_id = _Sale_Header_Controller.Sale_Header_Get_Max_Id();

                txtSoHoaDon.Text = "HD_RECEIVE_" + DateTime.Now.ToString("dd_MM_yyyy") + "_" + (_max_id + 1).ToString();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        decimal c_total_sp = 0;
        decimal c_totol_price = 0;

        void Call_Price()
        {
            try
            {
                c_total_sp = c_count * c_j_ao;
                c_totol_price = c_total_sp * c_receive_price + c_ship_price;
                txtTotal_Price.Text = c_totol_price.ToString();

                if (c_total_sp == 0) return;

                decimal _price_banle = (c_receive_price + (c_ship_price / c_total_sp)) * c_per_ban_le;
                decimal _price_banBuon = (c_receive_price + (c_ship_price / c_total_sp)) * c_per_ban_buon;

                if (_price_banle != 0)
                    txtPrice_BanLe.Text = _price_banle.ToString();
                else txtPrice_BanLe.Text = "";
                if (_price_banBuon != 0)
                    txtPrice_BanBuon.Text = _price_banBuon.ToString();
                else txtPrice_BanBuon.Text = "";
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        #endregion
    }

    public static class Color_Member
    {
        public static DataView Get_Color()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Color_Id");
            dt.Columns.Add("ColorName");

            Color_Controller _Color_Controller = new Color_Controller();
            List<Color_Info> _lst = _Color_Controller.Get_All();

            foreach (Color_Info item in _lst)
            {
                dt.Rows.Add(item.Color_Id.ToString(), item.ColorName);
            }

            return dt.DefaultView;
        }
    }
}
