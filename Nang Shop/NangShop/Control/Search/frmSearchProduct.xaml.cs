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
using NangShop.Control.View;

namespace NangShop.Control
{
    /// <summary>
    /// Interaction logic for frmSearchProduct.xaml
    /// </summary>
    public partial class frmSearchProduct : Window
    {
        public frmSearchProduct()
        {
            InitializeComponent();
        }

        public int c_ok = 0;
        public List<Product_Info> c_lst_Product_Info;
        Product_Controller c_Product_Controller = new Product_Controller();

        public Product_Info c_Product_Info_Search = new Product_Info();

        string c_code = "ALL";
        string c_name = "ALL";
        public bool c_is_QuickSearch = false;

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

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            Product_View();
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

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Product_Info _Product_Info = (Product_Info)dgrProduct.SelectedItem;
                //c_rowselect = dgrProduct.SelectedIndex;
                //if (_Product_Info.IsCheck == true)
                //{
                //    foreach (Product_Info item in dgrProduct.Items)
                //    {
                //        if (item != _Product_Info)
                //        {
                //            item.IsCheck = false;
                //        }
                //    }
                //    dgrProduct.Items.Refresh();
                //    DataGridHelper.NVSFocus(dgrProduct, c_rowselect, 0);
                //}
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
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
                    if (c_is_QuickSearch == true)
                    {
                        Product_View();
                    }
                    else
                    {
                        c_Product_Info_Search = _Product_Info;
                        c_ok = 1;
                        this.Close();
                    }
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

        void Product_View()
        {
            try
            {
                int _row_select = dgrProduct.SelectedIndex;
                Product_Info _Product_Info = (Product_Info)dgrProduct.SelectedItem;

                if (_Product_Info == null) return;

                View_Product_Detail _View_Product_Detail = new View_Product_Detail();
                _View_Product_Detail.p_Product_Info = _Product_Info;
                _View_Product_Detail.Owner = Window.GetWindow(this);
                _View_Product_Detail.ShowDialog();

                DataGridHelper.NVSFocus(dgrProduct, _row_select, 0);
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
                if (c_lst_Product_Info != null)
                    dgrProduct.ItemsSource = c_lst_Product_Info;
                else
                {
                    List<Product_Info> lst = c_Product_Controller.Product_Get_By_Code(c_code.ToUpper(), c_name.ToUpper());

                    dgrProduct.ItemsSource = lst;
                }
                txtProductCode.Focus();
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
               

                if (txtProductCode.Text != "")
                    c_code = txtProductCode.Text;
                else
                    c_code = "ALL";
                if (txtProduct_Name.Text != "")
                    c_name = txtProduct_Name.Text;
                else
                    c_name = "ALL";

                List<Product_Info> lst = c_Product_Controller.Product_Get_By_Code(c_code.ToUpper(), c_name.ToUpper());

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
