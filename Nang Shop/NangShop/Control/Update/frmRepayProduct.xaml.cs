using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using NangShopObj;
using NangShop_DataControl;

namespace NangShop.Control.Update
{
    /// <summary>
    /// Interaction logic for frmRepayProduct.xaml
    /// </summary>
    public partial class frmRepayProduct : Window
    {
        public frmRepayProduct()
        {
            InitializeComponent();
        }

        public Product_Info c_Product_Info;
        public Sale_Header_Info c_Sale_Header_Info;
        public int c_count_repay = 0;
        public int c_ok = 0;
        private void frmRePay_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void frmRePay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                exitForm();
            }
            else if (e.Key == Key.Enter)
            {
                Accept();
            }
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            Accept();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            exitForm();
        }

        private void txtRePay_TextChanged(object sender, TextChangedEventArgs e)
        {
            CommonFunction.Text_Change_Format_Money(txtRePay);
        }

        void LoadData()
        {
            try
            {
                txtSoHoaDon.Text = c_Sale_Header_Info.SoHoaDon;
                txtCustomer_Name.Text = c_Sale_Header_Info.Customer_Name;
                txtProductCode.Text = c_Product_Info.Product_Code;
                txtProduct_Name.Text = c_Product_Info.Name;

                txtQtty.Text = c_Product_Info.Count_Sale_By_Header.ToString("###,##0");
                txtRePay.Focus();
            }
            catch(Exception ex)
            {
                CommonData.log.Error(ex.ToString());
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

        void Accept()
        {
            try
            {
                if (txtRePay.Text == "")
                {
                    NoteBox.Show("Số lượng trả lại không được để trống","",NoteBoxLevel.Error);
                    txtRePay.Focus();
                    return;
                }

                if (Convert.ToInt16(txtRePay.Text) > Convert.ToInt16(txtQtty.Text) )
                {
                    NoteBox.Show("Số lượng trả lại vượt quá số lượng đã mua","",NoteBoxLevel.Error);
                    txtRePay.Focus();
                    return;
                }
                 MessageBoxResult result = NoteBox.Show("Bạn có muốn TRẢ LẠI sản phẩm này hay không?", "Thông báo", NoteBoxLevel.Question);
                 if (result == MessageBoxResult.Yes)
                 {
                     c_count_repay = Convert.ToInt16(txtRePay.Text);
                     c_ok = 1;

                     this.Close();
                 }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }
      
    }
}
