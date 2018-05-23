using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;

using NangShopObj;


namespace NangShop.Common
{
    /// <summary>
    /// Interaction logic for Us_Grid_Product.xaml
    /// </summary>
    public partial class Us_Grid_Product : UserControl
    {
        public Us_Grid_Product()
        {
            InitializeComponent();
        }

        public List<Detail_Items_Info> _lst = new List<Detail_Items_Info>();

        private void dgrProduct_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

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


        public void LoadData(int p_from, int p_to,string p_name)
        {
            try
            {
                for (int i = p_from; i <= p_to; i++)
                {
                    Detail_Items_Info _Product_Info = new Detail_Items_Info();
                    _Product_Info.Color_Id = 0;
                    _Product_Info.Size = i.ToString();

                    _Product_Info.Status = Convert.ToDecimal(Status_Type.ConHang);

                    _Product_Info.Name = p_name + " Size " + i.ToString();
                    _lst.Add(_Product_Info);
                }

                dgrProduct.ItemsSource = _lst;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }
    }
}
