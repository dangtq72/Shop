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
    public partial class View_Customer_Product : Window
    {
        public View_Customer_Product()
        {
            InitializeComponent();
        }

        public Customer_Info c_Customer_Info;

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
                Customer_Controller _Customer_Controller = new Customer_Controller();
                List<Customer_Buy_Product_Info> _lst = _Customer_Controller.Get_Customer_Buy_Product(c_Customer_Info.Customer_Id);
                dgrProduct_Detail.ItemsSource = _lst;

                this.Title = "Thông tin khách hàng " + c_Customer_Info.Customer_Name;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }
    }
}
