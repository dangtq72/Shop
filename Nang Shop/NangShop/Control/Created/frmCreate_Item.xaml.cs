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
    /// Interaction logic for frmCreateItems.xaml
    /// </summary>
    public partial class frmCreate_Item : Window
    {
        public frmCreate_Item()
        {
            InitializeComponent();
        }

        public Product_Info c_ProductInfo;
        public int c_ok = 0;

        /// <summary>
        /// Tổng số dây được phép nhập
        /// </summary>
        public decimal c_count = 0;
        Hashtable c_hs_color = new Hashtable();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetAllColor();
            txtCount.Focus();
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

        private void txtCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                txtCount.Text = Common.ConvertData.NhapMoney(txtCount);
                if (txtCount.Text == "," || txtCount.Text == ".")
                    txtCount.Text = "";

                else if (txtCount.Text != "" || txtCount.Text != "0")
                    txtCount.Text = Convert.ToDecimal(txtCount.Text).ToString("###,###");
                txtCount.Select(txtCount.Text.Length, 0);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void btnAddColor_Click(object sender, RoutedEventArgs e)
        {
            frmCreate_Color _frmCreate_Color = new frmCreate_Color();
            _frmCreate_Color.Owner = Window.GetWindow(this);
            _frmCreate_Color.ShowDialog();

            GetAllColor();
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

        void Accept()
        {
            try
            {
                if (txtCount.Text == "")
                {
                    NoteBox.Show("Số dây áo không được để trống");
                    txtCount.Focus();
                    return;
                }

                decimal _count_input = Convert.ToDecimal(txtCount.Text);

                if (_count_input > c_count)
                {
                    NoteBox.Show("Số dây áo vượt quá số lượng nhập");
                    txtCount.Focus();
                    return;
                }

                MessageBoxResult result = NoteBox.Show("Bạn chắc chắn muốn thêm " + Convert.ToDecimal(txtCount.Text) + " có màu " + cboColor.Text + " hay không?", "Thông báo", NoteBoxLevel.Question);
                if (MessageBoxResult.Yes == result)
                {
                    c_ProductInfo = new Product_Info();
                    c_ProductInfo.Color_Name = cboColor.Text;
                    c_ProductInfo.Color_Id = Convert.ToDecimal(cboColor.SelectedValue);
                    c_ProductInfo.Count_Ri_by_Color = Convert.ToDecimal(txtCount.Text);
                    c_ok = 1;
                    this.Close();
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

                cboColor.SelectedValuePath = "Color_Id";
                cboColor.DisplayMemberPath = "ColorName";

                cboColor.ItemsSource = _lst;
                cboColor.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

       
    }
}
