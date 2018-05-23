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
using NangShop_DataControl;

namespace NangShop.Control.Created
{
    /// <summary>
    /// Interaction logic for frmCreate_Supplier.xaml
    /// </summary>
    public partial class frmCreate_Supplier : Window
    {
        public frmCreate_Supplier()
        {
            InitializeComponent();
        }

        public int c_type = 0;
        public Supplier_Info c_Supplier_Info;

        public decimal c_id_insert = 0;

        #region Event

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)  
        {
            if (e.Key == Key.Escape) exitForm();
            else if (e.Key == Key.Enter) Accept();
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            Accept();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            exitForm();
        }
        #endregion

        #region Methods

        void LoadData()
        {
            try
            {
                if (c_type == Convert.ToInt16(Form_Type.Insert))
                {
                    txtName.Focus();
                }
                else
                {
                    this.Title = "Cập nhật nhà cung cấp";

                    txtName.Text = c_Supplier_Info.Supplier_Name;
                    txtPhone.Text = c_Supplier_Info.Phone;
                    txtAddress.Text = c_Supplier_Info.Address;
                    txtName.Focus();
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Accept()
        {
            try
            {
                if (!CheckValidate_F()) return;
                Supplier_Controller _Supplier_Controller = new Supplier_Controller();

                if (c_type == Convert.ToInt16(Form_Type.Insert))
                {
                    
                     MessageBoxResult result = NoteBox.Show("Bạn chắc chắn muốn thêm mới nhà cung cấp hay không?", "Thông báo", NoteBoxLevel.Question);
                     if (MessageBoxResult.Yes == result)
                     {
                         Supplier_Info _Supplier_Info = new Supplier_Info();
                         _Supplier_Info.Supplier_Name = txtName.Text;
                         _Supplier_Info.Phone = txtPhone.Text;
                         _Supplier_Info.Address = txtAddress.Text;

                         decimal _id = 0;

                         if (_Supplier_Controller.Supplier_Insert(_Supplier_Info,ref _id))
                         {
                             NoteBox.Show("Thêm mới thành công");
                             c_id_insert = _id;
                             this.Close();
                         }
                         else {
                             NoteBox.Show("Có lỗi trong quá trình thêm mới", "", NoteBoxLevel.Error);
                         }
                     }
                }
                else
                {
                    MessageBoxResult result = NoteBox.Show("Bạn chắc chắn muốn cập nhật hay không?", "Thông báo", NoteBoxLevel.Question);
                    if (MessageBoxResult.Yes == result)
                    {
                        Supplier_Info _Supplier_Info = new Supplier_Info();
                        _Supplier_Info.Supplier_Name = txtName.Text;
                        _Supplier_Info.Phone = txtPhone.Text;
                        _Supplier_Info.Address = txtAddress.Text;

                        if (_Supplier_Controller.Supplier_Update(c_Supplier_Info.Supplier_Id,_Supplier_Info))
                        {
                            NoteBox.Show("Cập nhật dữ liệu thành công");
                            c_id_insert = 1;
                            this.Close();
                        }
                        else
                        {
                            NoteBox.Show("Có lỗi trong quá trình cập nhật dữ liệu", "", NoteBoxLevel.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        bool CheckValidate_F()
        {
            try
            {

                if (txtName.Text == "")
                {
                    NoteBox.Show("Tên nhà cung cấp không được để trống");
                    txtName.Focus();
                    return false;
                }
                else if (txtPhone.Text == "")
                {
                    NoteBox.Show("SĐT nhà cung cấp không được để trống");
                    txtPhone.Focus();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return false;
            }
        }

        private void exitForm()
        {
            MessageBoxResult result = NoteBox.Show("Bạn có muốn thoát khỏi form hay không?", "Thông báo", NoteBoxLevel.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
            else
                this.Focus();
        }

        #endregion
    }
}
