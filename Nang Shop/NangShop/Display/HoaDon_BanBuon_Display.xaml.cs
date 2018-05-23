using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using System.Collections;
using NangShopObj;
using NangShop_DataControl;
using NangShop.Control.Created;
using AvalonDock;
using NangShop.Control.View;
using System.Data;
using NangShop.Common;

namespace NangShop.Display
{
    /// <summary>
    /// Interaction logic for HoaDon_Display.xaml
    /// </summary>
    public partial class HoaDon_BanBuon_Display : DockableContent
    {
        public HoaDon_BanBuon_Display()
        {
            InitializeComponent();
        }

        Sale_Header_Controller c_Product_Controller = new Sale_Header_Controller();
        Sale_Header_Controller c_Sale_Header_Controller = new Sale_Header_Controller();
        List<Sale_Header_Info> c_lst = new List<Sale_Header_Info>();
        string c_customer_name = "ALL";
        string c_shd = "ALL";

        string c_str_date = "ALL";
        string c_str_date_to = "ALL";

        private void frmSaleHeaderDisplay_Loaded(object sender, RoutedEventArgs e)
        {
            dpSaleDate.Text = DateTime.Now.AddDays(-30).ToString("dd/MM/yyyy");
            dpSaleDateTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
            LoadData();
        }

        private void frmSaleHeaderDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F3:
                    Export();
                    break;
                //case Key.F4:
                //    Chage_Product();
                //    break;
                case Key.F5:
                    Sale_Header_View();
                    break;
                case Key.F9:
                    LoadData();
                    break;
                case Key.Print:
                    Print();
                    break;
                case Key.Delete:
                    e.Handled = true;
                    break;
            }
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            Export();
        }

        private void dgrSaleHeader_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void dgrSaleHeader_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
                e.Handled = true;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtCustomer_Name.Text != "")
                    c_customer_name = txtCustomer_Name.Text;
                else
                    c_customer_name = "ALL";

                if (txtSoHoaDon.Text != "")
                    c_shd = txtSoHoaDon.Text;
                else
                    c_shd = "ALL";

                if (dpSaleDate.Text != "" && !CheckValidate.CheckValidDate(dpSaleDate.Text))
                {
                    NoteBox.Show("Ngày bán từ không đúng định dạng", "", NoteBoxLevel.Error);
                    dpSaleDate.Focus();
                    return;
                }


                if (dpSaleDateTo.Text != "" && !CheckValidate.CheckValidDate(dpSaleDateTo.Text))
                {
                    NoteBox.Show("Ngày bán đến không đúng định dạng", "", NoteBoxLevel.Error);
                    dpSaleDate.Focus();
                    return;
                }

                if (dpSaleDate.Text != "" && dpSaleDateTo.Text != "" && Common.ConvertData.ConvertString2Date(dpSaleDate.Text) > Common.ConvertData.ConvertString2Date(dpSaleDate.Text))
                {
                    NoteBox.Show("Ngày bán từ phải nhỏ hơn ngày bán đến không đúng định dạng", "", NoteBoxLevel.Error);
                    dpSaleDate.Focus();
                    return;
                }

                if (dpSaleDate.Text != "")
                {
                    c_str_date = Common.ConvertData.ConvertString2Date(dpSaleDate.Text).ToString("dd/MM/yyyy");
                }
                else
                    c_str_date = "ALL";
                if (dpSaleDateTo.Text != "")
                {
                    c_str_date_to = Common.ConvertData.ConvertString2Date(dpSaleDateTo.Text).ToString("dd/MM/yyyy");
                }
                else
                    c_str_date_to = "ALL";

                c_lst = c_Sale_Header_Controller.Sale_Header_Search(c_shd, c_str_date, c_str_date_to, c_customer_name, Convert.ToInt16(ThuChi_Type.Ban_Buon));
                dgrSaleHeader.ItemsSource = c_lst;
                DataGridHelper.NVSFocus(dgrSaleHeader, 0, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void btnChangeProduct_Click(object sender, RoutedEventArgs e)
        {
            Chage_Product();
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            Print();
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
                Sale_Header_View();
                e.Handled = true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void LoadData()
        {
            try
            {
                c_str_date = Common.ConvertData.ConvertString2Date(dpSaleDate.Text).ToString("dd/MM/yyyy");
                c_str_date_to = Common.ConvertData.ConvertString2Date(dpSaleDateTo.Text).ToString("dd/MM/yyyy");

                c_lst = c_Sale_Header_Controller.Sale_Header_Search(c_shd, c_str_date, c_str_date_to, c_customer_name, Convert.ToInt16(ThuChi_Type.Ban_Buon));

                dgrSaleHeader.ItemsSource = c_lst;
                txtSoHoaDon.Focus();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Export()
        {
            CommonFunction.Export_Excel_List<Sale_Header_Info>("Hóa đơn bán lẻ ngày " + Common.ConvertData.ConvertString2Date(dpSaleDate.Text).ToString("dd_MM_yyyy"),
                "Hóa đơn bán lẻ ngày " + Common.ConvertData.ConvertString2Date(dpSaleDate.Text).ToString("dd_MM_yyyy"), c_lst, PrePare_Column_Name());
        }

        /// <summary>
        /// Tạo hash với key là tên column, value là tên diễn giải của column đó
        /// </summary>
        Dictionary<string, string> PrePare_Column_Name()
        {
            try
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();

                dictionary.Add("SoHoaDon", "Số Hóa Đơn");
                dictionary.Add("Sale_Date", "Ngày bán");
                dictionary.Add("Customer_Name", "Tên khách hàng");
                dictionary.Add("Total_Amount", "Tổng số tiền TT");
                dictionary.Add("Discount", "Tiền khuyến mại");
                dictionary.Add("UserName", "Người lập hóa đơn");

                return dictionary;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new Dictionary<string, string>();
            }
        }

        void Chage_Product()
        {
            try
            {
                int _row_select = dgrSaleHeader.SelectedIndex;
                Sale_Header_Info _Sale_Header_Info = (Sale_Header_Info)dgrSaleHeader.SelectedItem;
                if (_Sale_Header_Info == null) return;

                Change_HeaderProduct_Detail _View_HeaderProduct_Detail = new Change_HeaderProduct_Detail();
                _View_HeaderProduct_Detail.Owner = Window.GetWindow(this);
                _View_HeaderProduct_Detail.c_Sale_Header_Info = _Sale_Header_Info;
                _View_HeaderProduct_Detail.ShowDialog();

                if (_View_HeaderProduct_Detail.c_ok == true)
                {
                    LoadData();
                    DataGridHelper.NVSFocus(dgrSaleHeader, 0, 0);
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Sale_Header_View()
        {
            try
            {
                int _row_select = dgrSaleHeader.SelectedIndex;
                Sale_Header_Info _Sale_Header_Info = (Sale_Header_Info)dgrSaleHeader.SelectedItem;
                if (_Sale_Header_Info == null) return;

                View_HeaderProduct_Detail _View_HeaderProduct_Detail = new View_HeaderProduct_Detail();
                _View_HeaderProduct_Detail.Owner = Window.GetWindow(this);
                _View_HeaderProduct_Detail.c_Sale_Header_Info = _Sale_Header_Info;
                _View_HeaderProduct_Detail.ShowDialog();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Print()
        {
            try
            {
                Sale_Header_Info _Sale_Header_Info = (Sale_Header_Info)dgrSaleHeader.SelectedItem;
                if (_Sale_Header_Info == null) return;

                List<Product_Info> _list_Product_Buy = c_Product_Controller.Get_Product_By_Sale_Header(_Sale_Header_Info.SoHoaDon);

                #region Kết xuất

                FlexCel.Report.FlexCelReport flcReport = new FlexCel.Report.FlexCelReport();
                string _path = CommonData.ExcelDesignFilePath;
                string _fileExcelName = "Hoa_Don_Ban_Buon.xls";
                DataSet ds_all = new DataSet();
                DataTable _dt = ConvertData.ConvertToDatatable(_list_Product_Buy);
                _dt.Columns.Add("STT");
                int index = 1;
                foreach (DataRow item in _dt.Rows)
                {
                    item["STT"] = index;
                    index++;
                }

                ds_all.Tables.Add(_dt);
                ds_all.Tables[0].TableName = "BanBuon";

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

                CommonFunction.SetValueExportByString(ref flcReport, "SoHoaDon", _Sale_Header_Info.SoHoaDon);
                CommonFunction.SetValueExportByString(ref flcReport, "Customer", _Sale_Header_Info.Customer_Name);
                CommonFunction.SetValueExportByString(ref flcReport, "Address", _Sale_Header_Info.Address);

                string _tienBangChu = ConvertData.ConvertMoneyToStr(Convert.ToDouble(_Sale_Header_Info.Total_Amount));
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

    }
}
