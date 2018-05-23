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

namespace NangShop.Display
{
    /// <summary>
    /// Interaction logic for Customer_Display.xaml
    /// </summary>
    public partial class Customer_Display : DockableContent
    {
        public Customer_Display()
        {
            InitializeComponent();
        }


        List<Customer_Info> c_lst = new List<Customer_Info>();
        int c_row_select = 0;
        Customer_Controller c_Customer_Controller = new Customer_Controller();

        Product_Controller c_Product_Controller = new Product_Controller();

        private void frmColorDisplay_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void frmColorDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F3:
                    Customer_Insert();
                    break;
                case Key.F9:
                    LoadData();
                    break;
                case Key.F4:
                    Customer_Update();
                    break;
                case Key.F5:
                    Customer_Delete();
                    break;
                case Key.F6:
                    Customer_View();
                    break;
                case Key.Delete:
                    e.Handled = true;
                    break;
            }
        }

        private void dgrCustomer_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void dgrCustomer_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
                e.Handled = true;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Customer_Insert();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Customer_Update();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Customer_Delete();
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            Customer_View();
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
                Customer_View();
                e.Handled = true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }
        #region Methods

        void LoadData()
        {
            try
            {
                c_lst = c_Customer_Controller.Customer_GetAll();
                dgrCustomer.ItemsSource = c_lst;
                DataGridHelper.NVSFocus(dgrCustomer, 0, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Customer_Insert()
        {
            try
            {
                frmCreate_Customer _frmCreate_Customer = new frmCreate_Customer();
                _frmCreate_Customer.c_type = Convert.ToInt16(Form_Type.Insert);
                _frmCreate_Customer.Owner = Window.GetWindow(this);
                _frmCreate_Customer.ShowDialog();

                if (_frmCreate_Customer.c_id_insert != 0)
                {
                    LoadData();

                    for (int i = 0; i < c_lst.Count; i++)
                    {
                        Customer_Info ui = (Customer_Info)c_lst[i];
                        if (ui.Customer_Id == _frmCreate_Customer.c_id_insert)
                        {
                            c_row_select = i;
                            _frmCreate_Customer.c_id_insert = 0;
                            break;
                        }
                    }
                }

                DataGridHelper.NVSFocus(dgrCustomer, c_row_select, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Customer_Delete()
        {
            try
            {
                c_row_select = dgrCustomer.SelectedIndex;
                Customer_Info _Customer_Info = (Customer_Info)dgrCustomer.SelectedItem;

                if (_Customer_Info == null) return;

                MessageBoxResult result = NoteBox.Show("Bạn chắc chắn muốn khách hàng này hay không?", "Thông báo", NoteBoxLevel.Question);
                if (MessageBoxResult.Yes == result)
                {
                    if (c_Customer_Controller.Customer_Delete(_Customer_Info.Customer_Id))
                    {
                        NoteBox.Show("Xóa dữ liệu thành công");
                        LoadData();
                    }
                }
                else
                    DataGridHelper.NVSFocus(dgrCustomer, c_row_select, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Customer_Update()
        {
            c_row_select = dgrCustomer.SelectedIndex;
            Customer_Info _Customer_Info = (Customer_Info)dgrCustomer.SelectedItem;

            if (_Customer_Info == null) return;
            frmCreate_Customer _frmCreate_Customer = new frmCreate_Customer();
            _frmCreate_Customer.c_type = Convert.ToInt16(Form_Type.Update);
            _frmCreate_Customer.c_Customer_Info = _Customer_Info;
            _frmCreate_Customer.Owner = Window.GetWindow(this);
            _frmCreate_Customer.ShowDialog();

            if (_frmCreate_Customer.c_id_insert != 0)
                LoadData();

            DataGridHelper.NVSFocus(dgrCustomer, c_row_select, 0);
        }

        void Customer_View()
        {
            try
            {
                c_row_select = dgrCustomer.SelectedIndex;
                Customer_Info _Customer_Info = (Customer_Info)dgrCustomer.SelectedItem;

                if (_Customer_Info == null) return;

                View_Customer_Product _View_Customer_Product = new View_Customer_Product();
                _View_Customer_Product.c_Customer_Info = _Customer_Info;
                _View_Customer_Product.Owner = Window.GetWindow(this);
                _View_Customer_Product.ShowDialog();

                DataGridHelper.NVSFocus(dgrCustomer, c_row_select, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }
        #endregion
    }
}
