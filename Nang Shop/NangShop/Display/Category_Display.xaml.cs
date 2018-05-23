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
    /// Interaction logic for Category_Display.xaml
    /// </summary>
    public partial class Category_Display : DockableContent
    {
        public Category_Display()
        {
            InitializeComponent();
        }

        List<Category_Info> c_lst = new List<Category_Info>();
        int c_row_select = 0;
        Category_Controller c_Category_Controller = new Category_Controller();

        private void frmCategoryDisplay_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void frmCategoryDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F3:
                    Insert_Category();
                    break;
                case Key.F9:
                    LoadData();
                    break;
                case Key.F4:
                    Category_Update();
                    break;
                case Key.F5:
                    Category_Delete();
                    break;
                case Key.Delete:
                    e.Handled = true;
                    break;
            }
        }

        private void dgrCategory_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void dgrCategory_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
                e.Handled = true;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Insert_Category();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Category_Update();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Category_Delete();
        }

        #region Methods

        void LoadData()
        {
            try
            {
                c_lst = c_Category_Controller.Get_All();
                dgrCategory.ItemsSource = c_lst;
                DataGridHelper.NVSFocus(dgrCategory, 0, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Insert_Category()
        {
            try
            {
                frmCreate_Category _frmCreate_Category = new frmCreate_Category();
                _frmCreate_Category.c_type = Convert.ToInt16(Form_Type.Insert);
                _frmCreate_Category.Owner = Window.GetWindow(this);
                _frmCreate_Category.ShowDialog();

                if (_frmCreate_Category.c_id_insert != 0)
                {
                    LoadData();

                    for (int i = 0; i < c_lst.Count; i++)
                    {
                        Category_Info ui = (Category_Info)c_lst[i];
                        if (ui.Category_Id == _frmCreate_Category.c_id_insert)
                        {
                            c_row_select = i;
                            _frmCreate_Category.c_id_insert = 0;
                            break;
                        }
                    }
                }

                DataGridHelper.NVSFocus(dgrCategory, c_row_select, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Category_Update()
        {
            try
            {
                c_row_select = dgrCategory.SelectedIndex;
                Category_Info _Category_Info = (Category_Info)dgrCategory.SelectedItem;

                if (_Category_Info == null) return;
                frmCreate_Category _frmCreate_Category = new frmCreate_Category();
                _frmCreate_Category.c_type = Convert.ToInt16(Form_Type.Update);
                _frmCreate_Category.c_Category_Info = _Category_Info;
                _frmCreate_Category.Owner = Window.GetWindow(this);
                _frmCreate_Category.ShowDialog();

                if (_frmCreate_Category.c_id_insert != 0)
                    LoadData();

                DataGridHelper.NVSFocus(dgrCategory, c_row_select, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Category_Delete()
        {
            try
            {
                c_row_select = dgrCategory.SelectedIndex;
                Category_Info _Category_Info = (Category_Info)dgrCategory.SelectedItem;

                if (_Category_Info == null) return;

                MessageBoxResult result = NoteBox.Show("Bạn chắc chắn muốn xóa loại sản phẩm hay không?", "Thông báo", NoteBoxLevel.Question);
                if (MessageBoxResult.Yes == result)
                {
                    if (c_Category_Controller.Categor_Delete(_Category_Info.Category_Id))
                    {
                        NoteBox.Show("Xóa dữ liệu thành công");
                        LoadData();
                    }
                }
                else
                    DataGridHelper.NVSFocus(dgrCategory, c_row_select, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        #endregion
    }
}
