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

namespace NangShop.Control.View
{
    /// <summary>
    /// Interaction logic for View_Product_Detail.xaml
    /// </summary>
    public partial class View_Product_Detail : Window
    {
        public View_Product_Detail()
        {
            InitializeComponent();
        }

        public Product_Info p_Product_Info;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgrProduct_Detail_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void dgrProduct_Detail_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
                e.Handled = true;
        }

        void LoadData()
        {
            try
            {
                this.Title = this.Title + ": " + p_Product_Info.Name;
                txtProduct_Name.Text = p_Product_Info.Name;
                txtProductCode.Text = p_Product_Info.Product_Code;

                txtCount_J.Text = p_Product_Info.Count_by_Ri.ToString();
                txtCount.Text = p_Product_Info.Receive_Count.ToString();

                txtReceiveDate.Text = p_Product_Info.Receive_Date.ToString("dd/MM/yyyy");
                txtSize.Text = p_Product_Info.Size;
                txtReceive_Price.Text = p_Product_Info.Receive_Price.ToString("###,##0");
                txtShip_Price.Text = p_Product_Info.Ship_Price.ToString("###,##0");

                txtTotal_Price.Text = p_Product_Info.Total_Price.ToString("###,##0");
                txtPerBanBuon.Text = p_Product_Info.Per_BanBuon.ToString();
                txtPerBanLe.Text = p_Product_Info.Per_BanLe.ToString();
                txtPrice_BanLe.Text = p_Product_Info.BanLe_Price.ToString("###,##0");
                txtPrice_BanBuon.Text = p_Product_Info.BanBuon_Price.ToString("###,##0");
                txtNote.Text = p_Product_Info.Note;

                txtItem_Type.Text = p_Product_Info.Category_Name;
                txtUnitName.Text = p_Product_Info.Unit_Name;
                txtSupplier.Text = p_Product_Info.Supplier_Name;

                Product_Controller _Product_Controller = new Product_Controller();
                List<Product_Detail_Info> _lst = _Product_Controller.Get_Detail_By_Product(p_Product_Info.Product_Id);
                dgrProduct_Detail.ItemsSource = _lst;

                this.Title = "Thông tin lô hàng " + p_Product_Info.Name;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }
    }
}
