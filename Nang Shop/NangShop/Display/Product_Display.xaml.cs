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
using NangShop.Control;
using NangShop.Control.View;

namespace NangShop.Display
{
    /// <summary>
    /// Interaction logic for Product_Display.xaml
    /// </summary>
    public partial class Product_Display : DockableContent
    {
        public Product_Display()
        {
            InitializeComponent();
        }

        List<Product_Info> c_lst = new List<Product_Info>();
        int c_row_select = 0;

        Product_Controller c_Product_Controller = new Product_Controller();

        private void frmProductDisplay_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void frmProductDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F3:
                    Product_Insert();
                    break;
                case Key.F9:
                    LoadData();
                    break;
                case Key.F5:
                    Product_View();
                    break;
                case Key.Delete:
                    Product_Delete();
                    break;
            }
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

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Product_Insert();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Product_Delete();
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            Product_View();
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
                Product_View();
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
                c_lst = c_Product_Controller.Get_All();
                dgrProduct.ItemsSource = c_lst;
                DataGridHelper.NVSFocus(dgrProduct, 0, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Product_Insert()
        {
            try
            {
                Frm_NhapHang _Frm_NhapHang = new Frm_NhapHang();
                _Frm_NhapHang.Owner = Window.GetWindow(this);
                _Frm_NhapHang.ShowDialog();

                if (_Frm_NhapHang.c_id_insert != 0)
                {
                    LoadData();

                    for (int i = 0; i < c_lst.Count; i++)
                    {
                        Product_Info ui = (Product_Info)c_lst[i];
                        if (ui.Supplier_Id == _Frm_NhapHang.c_id_insert)
                        {
                            c_row_select = i;
                            _Frm_NhapHang.c_id_insert = 0;
                            break;
                        }
                    }
                }

                DataGridHelper.NVSFocus(dgrProduct, c_row_select, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Product_Delete()
        {
            try
            {
                c_row_select = dgrProduct.SelectedIndex;
                Product_Info _Product_Info = (Product_Info)dgrProduct.SelectedItem;

                if (_Product_Info == null) return;

                MessageBoxResult result = NoteBox.Show("Bạn chắc chắn muốn xóa lô hàng hay không?", "Thông báo", NoteBoxLevel.Question);
                if (MessageBoxResult.Yes == result)
                {
                    if (c_Product_Controller.Product_Delete(_Product_Info.Product_Id))
                    {
                        NoteBox.Show("Xóa dữ liệu thành công");
                        LoadData();
                    }
                }
                else
                    DataGridHelper.NVSFocus(dgrProduct, c_row_select, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Product_View()
        {
            try
            {
                c_row_select = dgrProduct.SelectedIndex;
                Product_Info _Product_Info = (Product_Info)dgrProduct.SelectedItem;

                if (_Product_Info == null) return;

                View_Product_Detail _View_Product_Detail = new View_Product_Detail();
                _View_Product_Detail.p_Product_Info = _Product_Info;
                _View_Product_Detail.Owner = Window.GetWindow(this);
                _View_Product_Detail.ShowDialog();

                DataGridHelper.NVSFocus(dgrProduct, c_row_select, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }
        #endregion

    }
}
