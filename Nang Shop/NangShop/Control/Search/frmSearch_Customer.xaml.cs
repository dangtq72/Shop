using System;
using System.Collections.Generic;
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

namespace NangShop.Control.Search
{
    /// <summary>
    /// Interaction logic for frmSearch_Customer.xaml
    /// </summary>
    public partial class frmSearch_Customer : Window
    {
        public frmSearch_Customer()
        {
            InitializeComponent();
        }

        public int c_ok = 0;

        Customer_Controller c_Customer_Controller = new Customer_Controller();

        public Customer_Info c_Customer_Info_Search = new Customer_Info();

        string c_code = "all";
        string c_name = "all";

        #region Event

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) this.Close();
            else if (e.Key == Key.Enter) Search();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        /// <summary>
        /// hàm dùng cho EventsSetter trong form display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DoubleClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer_Info _Customer_Info = (Customer_Info)dgrProduct.SelectedItem;
                if (_Customer_Info != null)
                {
                    c_Customer_Info_Search = _Customer_Info;
                    c_ok = 1;
                    this.Close();
                }
                e.Handled = true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }
        #endregion

        #region Methods

        void LoadData()
        {
            try
            {
                List<Customer_Info> lst = c_Customer_Controller.Search_Customer(c_code, c_name);
                dgrProduct.ItemsSource = lst;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Search()
        {
            try
            {


                if (txtCustomer_Name.Text != "")
                    c_code = txtCustomer_Name.Text;
                else
                    c_code = "all";
                if (txtPhone.Text != "")
                    c_name = txtPhone.Text;
                else
                    c_name = "all";
                List<Customer_Info> lst = c_Customer_Controller.Search_Customer(c_code.ToUpper(), c_name.ToUpper());

                dgrProduct.ItemsSource = lst;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        #endregion

    }
}
