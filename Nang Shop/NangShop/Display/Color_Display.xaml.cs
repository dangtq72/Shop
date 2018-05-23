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
    /// Interaction logic for Color_Display.xaml
    /// </summary>
    public partial class Color_Display : DockableContent
    {
        public Color_Display()
        {
            InitializeComponent();
        }

        List<Color_Info> c_lst = new List<Color_Info>();
        int c_row_select = 0;
        Color_Controller c_Color_Controller = new Color_Controller();

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
                    Color_Insert();
                    break;
                case Key.F9:
                    LoadData();
                    break;
                //case Key.F4:
                //    Supplier_Update();
                //    break;
                case Key.F5:
                    Color_Delete();
                    break;
                case Key.Delete:
                    e.Handled = true;
                    break;
            }
        }

        private void dgrColor_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void dgrColor_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
                e.Handled = true;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Color_Insert();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Color_Delete();
        }

        #region Methods

        void LoadData()
        {
            try
            {
                c_lst = c_Color_Controller.Get_All();
                dgrColor.ItemsSource = c_lst;
                DataGridHelper.NVSFocus(dgrColor, 0, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Color_Insert()
        {
            try
            {
                frmCreate_Color _frmCreate_Color = new frmCreate_Color();
                _frmCreate_Color.c_type = Convert.ToInt16(Form_Type.Insert);
                _frmCreate_Color.Owner = Window.GetWindow(this);
                _frmCreate_Color.ShowDialog();

                if (_frmCreate_Color.c_id_insert != 0)
                {
                    LoadData();

                    for (int i = 0; i < c_lst.Count; i++)
                    {
                        Color_Info ui = (Color_Info)c_lst[i];
                        if (ui.Color_Id == _frmCreate_Color.c_id_insert)
                        {
                            c_row_select = i;
                            _frmCreate_Color.c_id_insert = 0;
                            break;
                        }
                    }
                }

                DataGridHelper.NVSFocus(dgrColor, c_row_select, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Color_Delete()
        {
            try
            {
                c_row_select = dgrColor.SelectedIndex;
                Color_Info _Color_Info = (Color_Info)dgrColor.SelectedItem;

                if (_Color_Info == null) return;

                MessageBoxResult result = NoteBox.Show("Bạn chắc chắn muốn xóa màu này hay không?", "Thông báo", NoteBoxLevel.Question);
                if (MessageBoxResult.Yes == result)
                {
                    if (c_Color_Controller.Color_Delete(_Color_Info.Color_Id))
                    {
                        NoteBox.Show("Xóa dữ liệu thành công");
                        LoadData();
                    }
                }
                else
                    DataGridHelper.NVSFocus(dgrColor, c_row_select, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }
        #endregion
    }
}
