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

namespace NangShop.Display
{
    /// <summary>
    /// Interaction logic for Supplier_Display.xaml
    /// </summary>
    public partial class Supplier_Display : DockableContent
    {
        public Supplier_Display()
        {
            InitializeComponent();
        }

        List<Supplier_Info> c_lst = new List<Supplier_Info>();
        int c_row_select = 0;
        Supplier_Controller c_Supplier_Controller = new Supplier_Controller();

        private void frmSupplierDisplay_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void frmSupplierDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F3:
                    Supplier_Insert();
                    break;
                case Key.F9:
                    LoadData();
                    break;
                case Key.F4:
                    Supplier_Update();
                    break;
                case Key.F5:
                    Supplier_Delete();
                    break;
                case Key.Delete:
                    e.Handled = true;
                    break;
            }
        }

        private void dgrSupplier_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void dgrSupplier_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Delete)
                e.Handled = true;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Supplier_Insert();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Supplier_Update();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Supplier_Delete();
        }

        #region Methods

        void LoadData()
        {
            try
            {
                c_lst = c_Supplier_Controller.Get_All();
                dgrSupplier.ItemsSource = c_lst;
                DataGridHelper.NVSFocus(dgrSupplier, 0, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Supplier_Insert()
        {
            try
            {
                frmCreate_Supplier _frmCreate_Supplier = new frmCreate_Supplier();
                _frmCreate_Supplier.c_type = Convert.ToInt16(Form_Type.Insert);
                _frmCreate_Supplier.Owner = Window.GetWindow(this);
                _frmCreate_Supplier.ShowDialog();

                if (_frmCreate_Supplier.c_id_insert != 0)
                {
                    LoadData();

                    for (int i = 0; i < c_lst.Count; i++)
                    {
                        Supplier_Info ui = (Supplier_Info)c_lst[i];
                        if (ui.Supplier_Id == _frmCreate_Supplier.c_id_insert)
                        {
                            c_row_select = i;
                            _frmCreate_Supplier.c_id_insert = 0;
                            break;
                        }
                    }
                }

                DataGridHelper.NVSFocus(dgrSupplier, c_row_select, 0);
            }
            catch ( Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Supplier_Update()
        {
            try
            {
                c_row_select = dgrSupplier.SelectedIndex;
                Supplier_Info _Supplier_Info = (Supplier_Info)dgrSupplier.SelectedItem;

                if (_Supplier_Info == null) return;
                frmCreate_Supplier _frmCreate_Supplier = new frmCreate_Supplier();
                _frmCreate_Supplier.c_Supplier_Info = _Supplier_Info;
                _frmCreate_Supplier.c_type = Convert.ToInt16(Form_Type.Update);
                _frmCreate_Supplier.Owner = Window.GetWindow(this);
                _frmCreate_Supplier.ShowDialog();

                if (_frmCreate_Supplier.c_id_insert != 0)
                    LoadData();

                DataGridHelper.NVSFocus(dgrSupplier, c_row_select, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Supplier_Delete()
        {
            try
            {
                c_row_select = dgrSupplier.SelectedIndex;
                Supplier_Info _Supplier_Info = (Supplier_Info)dgrSupplier.SelectedItem;

                if (_Supplier_Info == null) return;

                MessageBoxResult result = NoteBox.Show("Bạn chắc chắn muốn xóa nhà cung cấp hay không?", "Thông báo", NoteBoxLevel.Question);
                if (MessageBoxResult.Yes == result)
                {
                    if (c_Supplier_Controller.Supplier_Delete(_Supplier_Info.Supplier_Id))
                    {
                        NoteBox.Show("Xóa dữ liệu thành công");
                        LoadData();
                    }
                }
                else
                    DataGridHelper.NVSFocus(dgrSupplier, c_row_select, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }
        #endregion

    }
}
