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
using NangShop.Control.Created;
using NangShop_DataControl;
using System.Collections;

namespace NangShop.Control.View
{
    /// <summary>
    /// Interaction logic for View_HeaderProduct_Detail.xaml
    /// </summary>
    public partial class View_HeaderProduct_Detail : Window
    {
        public View_HeaderProduct_Detail()
        {
            InitializeComponent();
        }

        public Sale_Header_Info c_Sale_Header_Info;

        List<Product_Info> c_list_Product_Buy = new List<Product_Info>(); // chứa danh sách sp mua
  
        #region Events

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgrProduct_Detail_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void dgrProduct_Detail_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                e.Handled = true;
            }
        }

        private void txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBox textbox = (TextBox)e.Source;
                switch (textbox.Name)
                {
                    //case "txtPerDiscount":
                    //    Call_PerDiscount();
                    //    break;

                    //case "txtShipPrice":
                    //    Call_Ship_Price();
                    //    break;

                    //case "txtDiscount":
                    //    Call_Discount();
                    //    break;

                    case "txtPayPrice":
                        CommonFunction.Text_Change_Format_Money(txtPayPrice);
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        #endregion

        #region Methods

        void LoadData()
        {
            try
            {
                Sale_Header_Controller _Product_Controller = new Sale_Header_Controller();
                c_list_Product_Buy = _Product_Controller.Get_Product_By_Sale_Header(c_Sale_Header_Info.SoHoaDon);
                dgrProduct_Detail.ItemsSource = c_list_Product_Buy;
                 
                foreach (Product_Info item in c_list_Product_Buy)
                {
                    item.Change_Type = 0;
                    item.Total_Price = item.DonGia_By_Type * item.Count_Sale_By_Header;
                }

                if (c_Sale_Header_Info.SalesType == Convert.ToInt16(ThuChi_Type.Ban_Buon))
                {
                    this.Title = "Hóa đơn bán buôn " + c_Sale_Header_Info.SoHoaDon;
                }
                else if (c_Sale_Header_Info.SalesType == Convert.ToInt16(ThuChi_Type.Ban_Le))
                {
                    this.Title = "Hóa đơn bán lẻ " + c_Sale_Header_Info.SoHoaDon;
                }

                txtCustomer_Name.Text = c_Sale_Header_Info.Customer_Name;
                txtDiscount.Text = c_Sale_Header_Info.Discount.ToString();
                txtPayPrice.Text = c_Sale_Header_Info.Total_Amount.ToString();
                txtSaleDate.Text = c_Sale_Header_Info.Sale_Date.ToString("dd/MM/yyyy");
                txtShipPrice.Text = c_Sale_Header_Info.Ship_Price.ToString();

                if (c_Sale_Header_Info.Per_Discont != 0)
                    txtPerDiscount.Text = c_Sale_Header_Info.Per_Discont.ToString("###,###,0") + "%";
                else
                    txtPerDiscount.Text = c_Sale_Header_Info.Per_Discount_Price.ToString();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }
        #endregion
    }
}
