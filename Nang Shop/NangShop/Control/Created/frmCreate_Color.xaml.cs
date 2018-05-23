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
    public partial class frmCreate_Color : Window
    {
        public frmCreate_Color()
        {
            InitializeComponent();
        }

        Hashtable c_hs_color = new Hashtable();
        public decimal c_id_insert = 0;

        public int c_type = 0;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetAllColor();
            txtCode.Focus();
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

                MessageBoxResult result = NoteBox.Show("Bạn chắc chắn muốn thêm mới màu hay không?", "Thông báo", NoteBoxLevel.Question);
                if (MessageBoxResult.Yes == result)
                {
                    Color_Info _Color_Info = new Color_Info();
                    _Color_Info.ColorName = txtName.Text;
                    _Color_Info.ColorCode = txtCode.Text;

                    decimal _id = 0;
                    Color_Controller _Color_Controller = new Color_Controller();

                    if (_Color_Controller.Color_Insert(_Color_Info, ref _id))
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
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void GetAllColor()
        {
            try
            {
                c_hs_color = new Hashtable();

                Color_Controller _Color_Controller = new Color_Controller();
                List<Color_Info> _lst = _Color_Controller.Get_All();

                foreach (Color_Info item in _lst)
                {
                    c_hs_color[item.Color_Id] = item;
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

                if (txtCode.Text == "")
                {
                    NoteBox.Show("Mã màu không được để trống");
                    txtName.Focus();
                    return false;
                }
                else if (txtName.Text == "")
                {
                    NoteBox.Show("Tên màu không được để trống");
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
