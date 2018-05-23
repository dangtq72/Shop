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

namespace NangShop.Control.Created
{
    /// <summary>
    /// Interaction logic for frmCreate_Color.xaml
    /// </summary>
    public partial class frmCreate_Customer : Window
    {
        public frmCreate_Customer()
        {
            InitializeComponent();
        }

        Hashtable c_hs_color = new Hashtable();
        public decimal c_id_insert = 0;
        public Customer_Info c_Customer_Info;
        public int c_type = 0;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (c_type == Convert.ToInt16(Form_Type.Insert))
            {
                txtName.Focus();
            }
            else
            {
                this.Title = "Cập nhật khách hàng";

                txtName.Text = c_Customer_Info.Customer_Name;
                txtPhone.Text = c_Customer_Info.Phone;
                txtAddress.Text = c_Customer_Info.Address;
                txtName.Focus();
            }
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

        void exitForm()
        {
            MessageBoxResult result = NoteBox.Show("Bạn có muốn thoát khỏi form hay không?", "Thông báo", NoteBoxLevel.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
            else
                this.Focus();
        }

        void Accept()
        {
            try
            {
                if (!CheckValidate_F()) return;
                Customer_Controller _Customer_Controller = new Customer_Controller();

                if (c_type == Convert.ToInt16(Form_Type.Insert))
                {
                    MessageBoxResult result = NoteBox.Show("Bạn chắc chắn muốn thêm mới khách hàng " + txtName.Text + " hay không?", "Thông báo", NoteBoxLevel.Question);
                    if (MessageBoxResult.Yes == result)
                    {
                        Customer_Info _Customer_Info = new Customer_Info();
                        _Customer_Info.Customer_Name = txtName.Text;
                        _Customer_Info.Phone = txtPhone.Text;
                        _Customer_Info.Address = txtAddress.Text;

                        decimal _id = 0;
                        if (_Customer_Controller.Customer_Insert(_Customer_Info, ref _id))
                        {
                            NoteBox.Show("Thêm mới thành công");
                            c_id_insert = _id;
                            this.Close();
                        }
                        else
                        {
                            NoteBox.Show("Có lỗi trong quá trình thêm mới", "", NoteBoxLevel.Error);
                        }
                    }
                }
                else
                {
                    MessageBoxResult result = NoteBox.Show("Bạn chắc chắn muốn cập nhật hay không?", "Thông báo", NoteBoxLevel.Question);
                    if (MessageBoxResult.Yes == result)
                    {
                        Customer_Info _Customer_Info = new Customer_Info();
                        _Customer_Info.Customer_Name = txtName.Text;
                        _Customer_Info.Phone = txtPhone.Text;
                        _Customer_Info.Address = txtAddress.Text;

                        if (_Customer_Controller.Customer_Update(c_Customer_Info.Customer_Id, _Customer_Info))
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
                    NoteBox.Show("Tên khách hàng không được để trống");
                    txtName.Focus();
                    return false;
                }
                else if (txtPhone.Text == "")
                {
                    NoteBox.Show("Số đt không được để trống");
                    txtName.Focus();
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
    }
}

