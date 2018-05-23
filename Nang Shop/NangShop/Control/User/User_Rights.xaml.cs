
using System;
using System.Collections.Generic;

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using NangShop_DataControl;
using System.Collections;
using NangShopObj;
using System.Windows.Media;

namespace NangShop.User
{
    /// <summary>
    /// Interaction logic for USER_RIGHTS.xaml
    /// </summary>
    public partial class User_Rights : Window
    {

        #region Constructor and Param

        public User_Rights()
        {
            InitializeComponent();
        }

        User_RightsController c_User_RightsController = new User_RightsController();
        ArrayList c_arrFunction = new ArrayList();
        bool c_change = false;

        public User_Info c_UsersInfo = new User_Info();
        BrushConverter bc = new BrushConverter();

        #endregion

        #region Events

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                txtSearch.Focus();

                if (c_UsersInfo.Group_Id == 0)
                    this.Title = "Phân quyền cho người dùng" + " " + c_UsersInfo.User_Name;
                else
                    this.Title = "Phân quyền cho người dùng" + " " + c_UsersInfo.User_Name;

                // nếu là chuyên viên thì mới lấy quyền của Core Monitor
                // nếu là thành viên thì giao dịch trực tuyến là ko có phân quyền
                // chỉ phân quyền cho user là giao dịch từ xa và lấy lên của Brocker FrontEnd
                c_arrFunction = c_User_RightsController.User_Rights_GetByUser(c_UsersInfo.User_Name, "", c_UsersInfo.Group_Id, CommonData.c_cultureName_lang);

                foreach (User_FunctionsInfo item in c_arrFunction)
                {
                    if (item.last == "Y")
                    {
                        //item.Show = System.Windows.Visibility.Visible;

                        Brush brush = (Brush)bc.ConvertFromString("#003D76");
                        brush.Freeze();
                        item.Br_N = brush;
                    }
                    else
                    {
                        //item.Show = System.Windows.Visibility.Hidden;
                        item.Br_N = Brushes.Red;
                    }
                    if (item.right == "111111")
                    {
                        item.Full_Right = 1;
                    }
                    else
                    {
                        item.Full_Right = 0;
                    }

                    if (c_UsersInfo.Group_Id == 0)
                    {
                        grUser_Rights.Columns[2].Visibility = Visibility.Hidden;
                        grUser_Rights.Columns[3].Visibility = Visibility.Hidden;
                        grUser_Rights.Columns[4].Visibility = Visibility.Hidden;
                        grUser_Rights.Columns[5].Visibility = Visibility.Hidden;
                        grUser_Rights.Columns[6].Visibility = Visibility.Hidden;
                        grUser_Rights.Columns[7].Visibility = Visibility.Hidden;
                    }
                }

                grUser_Rights.ItemsSource = c_arrFunction;

            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                exitForm();
            //else if (e.Key == Key.Enter && !grUser_Rights.Focus() && !txtSearch.Focus())
            //    User_Right_Insert();
            else if (e.Key == Key.F6)
                txtSearch.Focus();
        }

        private void btnChapNhan_Click(object sender, RoutedEventArgs e)
        {
            User_Right_Insert();
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            exitForm();
        }

        #region VietNam datagrid

        private void chkCheckAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chkCheckAll.IsChecked == true)
                {
                    foreach (User_FunctionsInfo _User_FunctionsInfo in grUser_Rights.ItemsSource)
                    {
                        _User_FunctionsInfo.use_right = 1;
                        _User_FunctionsInfo.view_right = 1;
                        _User_FunctionsInfo.insert_right = 1;
                        _User_FunctionsInfo.update_right = 1;
                        _User_FunctionsInfo.delete_right = 1;
                        _User_FunctionsInfo.approveInfo_right = 1;
                        _User_FunctionsInfo.Full_Right = 1;
                        grUser_Rights.EndInit();
                        grUser_Rights.Items.Refresh();
                    }
                }
                else
                {
                    foreach (User_FunctionsInfo _User_FunctionsInfo in grUser_Rights.ItemsSource)
                    {
                        _User_FunctionsInfo.use_right = 0;
                        _User_FunctionsInfo.view_right = 0;
                        _User_FunctionsInfo.insert_right = 0;
                        _User_FunctionsInfo.update_right = 0;
                        _User_FunctionsInfo.delete_right = 0;
                        _User_FunctionsInfo.approveInfo_right = 0;
                        _User_FunctionsInfo.Full_Right = 0;
                        grUser_Rights.EndInit();
                        grUser_Rights.Items.Refresh();
                    }
                }
                c_change = true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        #region checkbox click

        private void Use_Right_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User_FunctionsInfo _User_FunctionsInfo = (User_FunctionsInfo)grUser_Rights.SelectedItem;
                int rowselect = grUser_Rights.SelectedIndex;

                if (_User_FunctionsInfo.last == "N") // nếu là cha
                {
                    #region nếu mà là cha
                    // duyệt tất cả thằng con của nó
                    // thì gán all theo thằng cha
                    foreach (User_FunctionsInfo ufri in c_arrFunction)
                    {
                        if (ufri.prid == _User_FunctionsInfo.functionId)
                        {
                            if (_User_FunctionsInfo.use_right == 0)
                            {
                                ufri.use_right = 1;
                            }
                            else
                            {
                                ufri.use_right = 0;
                                ufri.view_right = 0;
                                ufri.insert_right = 0;
                                ufri.update_right = 0;
                                ufri.delete_right = 0;
                                ufri.approveInfo_right = 0;
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region nếu mà là con
                    if (_User_FunctionsInfo.use_right == 1)
                    {
                        #region nếu bỏ chọn thì bỏ check thằng cha
                        foreach (User_FunctionsInfo ufri in c_arrFunction)
                        {
                            if (ufri.functionId == _User_FunctionsInfo.prid)
                            {
                                ufri.use_right = 0;
                                ufri.view_right = 0;
                                ufri.insert_right = 0;
                                ufri.update_right = 0;
                                ufri.delete_right = 0;
                                ufri.approveInfo_right = 0;
                                break;
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        #region nếu mà chọn thì check all thằng con cùng cha vs nó nếu mà all thằng con cùng check thì,thì check thằng cha đó

                        bool _ck_all_view = true;
                        foreach (User_FunctionsInfo ufri in c_arrFunction)
                        {
                            // kiểm tra tất cả thằng con cùng cha vs nó
                            // nếu mà tick hết thì check thằng cha, không kiểm tra chính thằng đang được chọn
                            if (ufri.prid == _User_FunctionsInfo.prid && ufri.functionId != _User_FunctionsInfo.functionId)
                            {
                                if (ufri.use_right == 0)
                                {
                                    _ck_all_view = false;
                                    break;
                                }
                            }
                        }

                        if (_ck_all_view)
                        {
                            foreach (User_FunctionsInfo ufri in c_arrFunction)
                            {
                                if (ufri.functionId == _User_FunctionsInfo.prid)
                                {
                                    ufri.use_right = 1;
                                    break;
                                }
                            }
                        }
                        #endregion
                    }
                    #endregion
                }

                if (_User_FunctionsInfo.use_right == 0)
                {
                    _User_FunctionsInfo.use_right = 1;
                    grUser_Rights.EndInit();
                    grUser_Rights.Items.Refresh();
                }
                else
                {
                    chkCheckAll.IsChecked = false;
                    _User_FunctionsInfo.use_right = 0;
                    _User_FunctionsInfo.view_right = 0;
                    _User_FunctionsInfo.insert_right = 0;
                    _User_FunctionsInfo.update_right = 0;
                    _User_FunctionsInfo.delete_right = 0;
                    _User_FunctionsInfo.approveInfo_right = 0;
                    grUser_Rights.EndInit();
                    grUser_Rights.Items.Refresh();
                }

                Check_Is_CheckALl();
                DataGridHelper.NVSFocus(grUser_Rights, rowselect, (grUser_Rights.CurrentColumn).DisplayIndex);

                c_change = true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void view_right_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User_FunctionsInfo _User_FunctionsInfo = (User_FunctionsInfo)grUser_Rights.SelectedItem;
                int rowselect = grUser_Rights.SelectedIndex;

                if (_User_FunctionsInfo.last == "N") // nếu là cha
                {
                    #region nếu mà là cha
                    // duyệt tất cả thằng con của nó
                    // thì gán all theo thằng cha
                    foreach (User_FunctionsInfo ufri in c_arrFunction)
                    {
                        if (ufri.prid == _User_FunctionsInfo.functionId)
                        {
                            if (_User_FunctionsInfo.view_right == 0)
                            {
                                ufri.view_right = 1;
                                ufri.use_right = 1;
                            }
                            else
                            {
                                ufri.view_right = 0;
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region nếu mà là con
                    if (_User_FunctionsInfo.view_right == 1)
                    {
                        #region nếu bỏ chọn thì bỏ check thằng cha
                        foreach (User_FunctionsInfo ufri in c_arrFunction)
                        {
                            if (ufri.functionId == _User_FunctionsInfo.prid)
                            {
                                ufri.view_right = 0;
                                break;
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        #region nếu mà chọn thì ktra all thằng con cùng cha vs nó nếu mà all thằng con cùng check thì,thì check thằng cha đó

                        bool _ck_all_view = true;
                        foreach (User_FunctionsInfo ufri in c_arrFunction)
                        {
                            // kiểm tra tất cả thằng con cùng cha vs nó
                            // nếu mà tick hết thì check thằng cha
                            if (ufri.prid == _User_FunctionsInfo.prid && ufri.functionId != _User_FunctionsInfo.functionId)
                            {
                                if (ufri.view_right == 0)
                                {
                                    _ck_all_view = false;
                                    break;
                                }
                            }
                        }

                        if (_ck_all_view)
                        {
                            foreach (User_FunctionsInfo ufri in c_arrFunction)
                            {
                                if (ufri.functionId == _User_FunctionsInfo.prid)
                                {
                                    ufri.view_right = 1;
                                    break;
                                }
                            }
                        }
                        #endregion
                    }
                    #endregion
                }

                if (_User_FunctionsInfo.view_right == 0)
                {
                    _User_FunctionsInfo.view_right = 1;
                    _User_FunctionsInfo.use_right = 1;
                    grUser_Rights.EndInit();
                    grUser_Rights.Items.Refresh();
                }
                else
                {
                    chkCheckAll.IsChecked = false;
                    _User_FunctionsInfo.view_right = 0;
                    grUser_Rights.EndInit();
                    grUser_Rights.Items.Refresh();
                }
                Check_Is_CheckALl();
                DataGridHelper.NVSFocus(grUser_Rights, rowselect, (grUser_Rights.CurrentColumn).DisplayIndex);

                c_change = true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void insert_right_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User_FunctionsInfo _User_FunctionsInfo = (User_FunctionsInfo)grUser_Rights.SelectedItem;
                int rowselect = grUser_Rights.SelectedIndex;

                if (_User_FunctionsInfo.last == "N") // nếu là cha
                {
                    #region nếu mà là cha
                    // duyệt tất cả thằng con của nó
                    // thì gán all theo thằng cha
                    foreach (User_FunctionsInfo ufri in c_arrFunction)
                    {
                        if (ufri.prid == _User_FunctionsInfo.functionId)
                        {
                            if (_User_FunctionsInfo.insert_right == 0)
                            {
                                ufri.insert_right = 1;
                                ufri.use_right = 1;
                            }
                            else
                            {
                                ufri.insert_right = 0;
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region nếu mà là con
                    if (_User_FunctionsInfo.insert_right == 1)
                    {
                        #region nếu bỏ chọn thì bỏ check thằng cha
                        foreach (User_FunctionsInfo ufri in c_arrFunction)
                        {
                            if (ufri.functionId == _User_FunctionsInfo.prid)
                            {
                                ufri.insert_right = 0;
                                break;
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        #region nếu mà chọn thì ktra all thằng con cùng cha vs nó nếu mà all thằng con cùng check thì,thì check thằng cha đó

                        bool _ck_all_view = true;
                        foreach (User_FunctionsInfo ufri in c_arrFunction)
                        {
                            // kiểm tra tất cả thằng con cùng cha vs nó
                            // nếu mà tick hết thì check thằng cha
                            if (ufri.prid == _User_FunctionsInfo.prid && ufri.functionId != _User_FunctionsInfo.functionId)
                            {
                                if (ufri.insert_right == 0)
                                {
                                    _ck_all_view = false;
                                    break;
                                }
                            }
                        }

                        if (_ck_all_view)
                        {
                            foreach (User_FunctionsInfo ufri in c_arrFunction)
                            {
                                if (ufri.functionId == _User_FunctionsInfo.prid)
                                {
                                    ufri.insert_right = 1;
                                    break;
                                }
                            }
                        }
                        #endregion
                    }
                    #endregion
                }

                if (_User_FunctionsInfo.insert_right == 0)
                {
                    _User_FunctionsInfo.insert_right = 1;
                    _User_FunctionsInfo.use_right = 1;
                    grUser_Rights.EndInit();
                    grUser_Rights.Items.Refresh();
                }
                else
                {
                    chkCheckAll.IsChecked = false;
                    _User_FunctionsInfo.insert_right = 0;
                    grUser_Rights.EndInit();
                    grUser_Rights.Items.Refresh();
                }
                Check_Is_CheckALl();
                DataGridHelper.NVSFocus(grUser_Rights, rowselect, (grUser_Rights.CurrentColumn).DisplayIndex);

                c_change = true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void delete_right_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User_FunctionsInfo _User_FunctionsInfo = (User_FunctionsInfo)grUser_Rights.SelectedItem;
                int rowselect = grUser_Rights.SelectedIndex;

                if (_User_FunctionsInfo.last == "N") // nếu là cha
                {
                    #region nếu mà là cha
                    // duyệt tất cả thằng con của nó
                    // thì gán all theo thằng cha
                    foreach (User_FunctionsInfo ufri in c_arrFunction)
                    {
                        if (ufri.prid == _User_FunctionsInfo.functionId)
                        {
                            if (_User_FunctionsInfo.delete_right == 0)
                            {
                                ufri.delete_right = 1;
                                ufri.use_right = 1;
                            }
                            else
                            {
                                ufri.delete_right = 0;
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region nếu mà là con
                    if (_User_FunctionsInfo.delete_right == 1)
                    {
                        #region nếu bỏ chọn thì bỏ check thằng cha
                        foreach (User_FunctionsInfo ufri in c_arrFunction)
                        {
                            if (ufri.functionId == _User_FunctionsInfo.prid)
                            {
                                ufri.delete_right = 0;
                                break;
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        #region nếu mà chọn thì ktra all thằng con cùng cha vs nó nếu mà all thằng con cùng check thì,thì check thằng cha đó

                        bool _ck_all_view = true;
                        foreach (User_FunctionsInfo ufri in c_arrFunction)
                        {
                            // kiểm tra tất cả thằng con cùng cha vs nó
                            // nếu mà tick hết thì check thằng cha
                            if (ufri.prid == _User_FunctionsInfo.prid && ufri.functionId != _User_FunctionsInfo.functionId)
                            {
                                if (ufri.delete_right == 0)
                                {
                                    _ck_all_view = false;
                                    break;
                                }
                            }
                        }

                        if (_ck_all_view)
                        {
                            foreach (User_FunctionsInfo ufri in c_arrFunction)
                            {
                                if (ufri.functionId == _User_FunctionsInfo.prid)
                                {
                                    ufri.delete_right = 1;
                                    break;
                                }
                            }
                        }
                        #endregion
                    }
                    #endregion
                }

                if (_User_FunctionsInfo.delete_right == 0)
                {
                    _User_FunctionsInfo.delete_right = 1;
                    _User_FunctionsInfo.use_right = 1;
                    grUser_Rights.EndInit();
                    grUser_Rights.Items.Refresh();
                }
                else
                {
                    chkCheckAll.IsChecked = false;
                    _User_FunctionsInfo.delete_right = 0;
                    grUser_Rights.EndInit();
                    grUser_Rights.Items.Refresh();
                }
                Check_Is_CheckALl();
                DataGridHelper.NVSFocus(grUser_Rights, rowselect, (grUser_Rights.CurrentColumn).DisplayIndex);

                c_change = true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void update_right_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                int rowselect = grUser_Rights.SelectedIndex;
                User_FunctionsInfo _User_FunctionsInfo = (User_FunctionsInfo)grUser_Rights.SelectedItem;

                if (_User_FunctionsInfo.last == "N") // nếu là cha
                {
                    #region nếu mà là cha
                    // duyệt tất cả thằng con của nó
                    // thì gán all theo thằng cha
                    foreach (User_FunctionsInfo ufri in c_arrFunction)
                    {
                        if (ufri.prid == _User_FunctionsInfo.functionId)
                        {
                            if (_User_FunctionsInfo.update_right == 0)
                            {
                                ufri.update_right = 1;
                                ufri.use_right = 1;
                            }
                            else
                            {
                                ufri.update_right = 0;
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region nếu mà là con
                    if (_User_FunctionsInfo.update_right == 1)
                    {
                        #region nếu bỏ chọn thì bỏ check thằng cha
                        foreach (User_FunctionsInfo ufri in c_arrFunction)
                        {
                            if (ufri.functionId == _User_FunctionsInfo.prid)
                            {
                                ufri.update_right = 0;
                                break;
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        #region nếu mà chọn thì ktra all thằng con cùng cha vs nó nếu mà all thằng con cùng check thì,thì check thằng cha đó

                        bool _ck_all_view = true;
                        foreach (User_FunctionsInfo ufri in c_arrFunction)
                        {
                            // kiểm tra tất cả thằng con cùng cha vs nó
                            // nếu mà tick hết thì check thằng cha
                            if (ufri.prid == _User_FunctionsInfo.prid && ufri.functionId != _User_FunctionsInfo.functionId)
                            {
                                if (ufri.update_right == 0)
                                {
                                    _ck_all_view = false;
                                    break;
                                }
                            }
                        }

                        if (_ck_all_view)
                        {
                            foreach (User_FunctionsInfo ufri in c_arrFunction)
                            {
                                if (ufri.functionId == _User_FunctionsInfo.prid)
                                {
                                    ufri.update_right = 1;
                                    break;
                                }
                            }
                        }
                        #endregion
                    }
                    #endregion
                }

                if (_User_FunctionsInfo.update_right == 0)
                {
                    _User_FunctionsInfo.update_right = 1;
                    _User_FunctionsInfo.use_right = 1;
                    grUser_Rights.EndInit();
                    grUser_Rights.Items.Refresh();
                }
                else
                {
                    chkCheckAll.IsChecked = false;
                    _User_FunctionsInfo.update_right = 0;
                    grUser_Rights.EndInit();
                    grUser_Rights.Items.Refresh();
                }

                Check_Is_CheckALl();
                DataGridHelper.NVSFocus(grUser_Rights, rowselect, (grUser_Rights.CurrentColumn).DisplayIndex);

                c_change = true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void approveInfo_right_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int rowselect = grUser_Rights.SelectedIndex;
                User_FunctionsInfo _User_FunctionsInfo = (User_FunctionsInfo)grUser_Rights.SelectedItem;

                if (_User_FunctionsInfo.last == "N") // nếu là cha
                {
                    #region nếu mà là cha
                    // duyệt tất cả thằng con của nó
                    // thì gán all theo thằng cha
                    foreach (User_FunctionsInfo ufri in c_arrFunction)
                    {
                        if (ufri.prid == _User_FunctionsInfo.functionId)
                        {
                            if (_User_FunctionsInfo.update_right == 0)
                            {
                                ufri.approveInfo_right = 1;
                                ufri.use_right = 1;
                            }
                            else
                            {
                                ufri.approveInfo_right = 0;
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region nếu mà là con
                    if (_User_FunctionsInfo.approveInfo_right == 1)
                    {
                        #region nếu bỏ chọn thì bỏ check thằng cha
                        foreach (User_FunctionsInfo ufri in c_arrFunction)
                        {
                            if (ufri.functionId == _User_FunctionsInfo.prid)
                            {
                                ufri.approveInfo_right = 0;
                                break;
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        #region nếu mà chọn thì ktra all thằng con cùng cha vs nó nếu mà all thằng con cùng check thì,thì check thằng cha đó

                        bool _ck_all_view = true;
                        foreach (User_FunctionsInfo ufri in c_arrFunction)
                        {
                            // kiểm tra tất cả thằng con cùng cha vs nó
                            // nếu mà tick hết thì check thằng cha
                            if (ufri.prid == _User_FunctionsInfo.prid && ufri.functionId != _User_FunctionsInfo.functionId)
                            {
                                if (ufri.approveInfo_right == 0)
                                {
                                    _ck_all_view = false;
                                    break;
                                }
                            }
                        }

                        if (_ck_all_view)
                        {
                            foreach (User_FunctionsInfo ufri in c_arrFunction)
                            {
                                if (ufri.functionId == _User_FunctionsInfo.prid)
                                {
                                    ufri.approveInfo_right = 1;
                                    break;
                                }
                            }
                        }
                        #endregion
                    }
                    #endregion
                }
                if (_User_FunctionsInfo.approveInfo_right == 0)
                {
                    _User_FunctionsInfo.approveInfo_right = 1;
                    _User_FunctionsInfo.use_right = 1;
                    grUser_Rights.EndInit();
                    grUser_Rights.Items.Refresh();
                }
                else
                {
                    chkCheckAll.IsChecked = false;
                    _User_FunctionsInfo.approveInfo_right = 0;
                    grUser_Rights.EndInit();
                    grUser_Rights.Items.Refresh();
                }
                Check_Is_CheckALl();
                DataGridHelper.NVSFocus(grUser_Rights, rowselect, (grUser_Rights.CurrentColumn).DisplayIndex);

                c_change = true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void Full_Right_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int rowselect = grUser_Rights.SelectedIndex;
                User_FunctionsInfo _User_FunctionsInfo = (User_FunctionsInfo)grUser_Rights.SelectedItem;

                if (_User_FunctionsInfo.Full_Right == 0)
                {
                    _User_FunctionsInfo.use_right = 1;
                    _User_FunctionsInfo.view_right = 1;
                    _User_FunctionsInfo.insert_right = 1;
                    _User_FunctionsInfo.update_right = 1;
                    _User_FunctionsInfo.delete_right = 1;
                    _User_FunctionsInfo.approveInfo_right = 1;
                    _User_FunctionsInfo.Full_Right = 1;
                    grUser_Rights.EndInit();
                    grUser_Rights.Items.Refresh();
                }
                else
                {
                    chkCheckAll.IsChecked = false;
                    _User_FunctionsInfo.use_right = 0;
                    _User_FunctionsInfo.view_right = 0;
                    _User_FunctionsInfo.insert_right = 0;
                    _User_FunctionsInfo.update_right = 0;
                    _User_FunctionsInfo.delete_right = 0;
                    _User_FunctionsInfo.approveInfo_right = 0;
                    _User_FunctionsInfo.Full_Right = 0;
                    grUser_Rights.EndInit();
                    grUser_Rights.Items.Refresh();
                }

                if (_User_FunctionsInfo.last == "N") // nếu là cha
                {
                    #region nếu mà là cha
                    // duyệt tất cả thằng con của nó
                    // thì gán all theo thằng cha
                    foreach (User_FunctionsInfo ufri in c_arrFunction)
                    {
                        if (ufri.prid == _User_FunctionsInfo.functionId)
                        {
                            if (_User_FunctionsInfo.update_right == 1)
                            {
                                ufri.use_right = 1;
                                ufri.view_right = 1;
                                ufri.insert_right = 1;
                                ufri.update_right = 1;
                                ufri.delete_right = 1;
                                ufri.approveInfo_right = 1;
                            }
                            else
                            {
                                ufri.use_right = 0;
                                ufri.view_right = 0;
                                ufri.insert_right = 0;
                                ufri.update_right = 0;
                                ufri.delete_right = 0;
                                ufri.approveInfo_right = 0;
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region nếu mà là con
                    if (_User_FunctionsInfo.Full_Right == 0)
                    {
                        #region nếu bỏ chọn thì bỏ check thằng cha
                        foreach (User_FunctionsInfo ufri in c_arrFunction)
                        {
                            if (ufri.functionId == _User_FunctionsInfo.prid)
                            {
                                ufri.use_right = 0;
                                ufri.view_right = 0;
                                ufri.insert_right = 0;
                                ufri.update_right = 0;
                                ufri.delete_right = 0;
                                ufri.approveInfo_right = 0;
                                break;
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        #region nếu mà chọn thì ktra all thằng con cùng cha vs nó nếu mà all thằng con cùng check thì,thì check thằng cha đó

                        bool _ck_all_view = true;
                        foreach (User_FunctionsInfo ufri in c_arrFunction)
                        {
                            // kiểm tra tất cả thằng con cùng cha vs nó
                            // nếu mà tick hết thì check thằng cha
                            if (ufri.prid == _User_FunctionsInfo.prid)
                            {
                                if (ufri.approveInfo_right == 0 || ufri.use_right == 0 || ufri.view_right == 0 ||
                                    ufri.insert_right == 0 || ufri.update_right == 0 || ufri.delete_right == 0)
                                {
                                    _ck_all_view = false;
                                    break;
                                }
                            }
                        }

                        if (_ck_all_view) // nếu mà tất cả thằng con cùng check thì 
                        {
                            foreach (User_FunctionsInfo ufri in c_arrFunction)
                            {
                                if (ufri.functionId == _User_FunctionsInfo.prid)
                                {
                                    ufri.use_right = 1;
                                    ufri.view_right = 1;
                                    ufri.insert_right = 1;
                                    ufri.update_right = 1;
                                    ufri.delete_right = 1;
                                    ufri.approveInfo_right = 1;
                                    break;
                                }
                            }
                        }
                        #endregion
                    }
                    #endregion
                }


                Check_Is_CheckALl();
                DataGridHelper.NVSFocus(grUser_Rights, rowselect, (grUser_Rights.CurrentColumn).DisplayIndex);

                c_change = true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        #endregion

        #region Checkbox previewkeydown

        private void Use_Right_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                Use_Right_Click(null, null);
            }
        }

        private void view_right_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                view_right_Click(null, null);
            }
        }

        private void insert_right_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                insert_right_Click(null, null);
            }
        }

        private void update_right_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                update_right_Click(null, null);
            }
        }

        private void delete_right_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                delete_right_Click(null, null);
            }
        }

        private void approveInfo_right_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                approveInfo_right_Click(null, null);
            }
        }

        private void Full_Right_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                Full_Right_Click(null, null);
            }
        }

        #endregion

        private void grUser_Rights_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Delete) e.Handled = true;

                if (e.Key == Key.Enter) e.Handled = true;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private void grUser_Rights_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        #endregion

        private void txtSearch_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Search();
                e.Handled = true;
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }

        #endregion

        #region Private Methods

        private void User_Right_Insert()
        {
            try
            {
                if (c_change)
                {

                    User_RightsController _User_RightsController = new User_RightsController();

                    ArrayList arrRight = new ArrayList();
                    foreach (User_FunctionsInfo item in c_arrFunction)
                    {
                        if (item.right != "000000")
                        {
                            User_RightsInfo _User_RightsInfo = ConvertToUser_RightsInfo(item, c_UsersInfo.User_Id);
                            arrRight.Add(_User_RightsInfo);
                        }
                    }
                    if (arrRight.Count > 0)
                    {
                        MessageBoxResult result1 = NoteBox.Show("Bạn có muốn sửa thông tin này hay không?", "Thông báo", NoteBoxLevel.Question);
                        if (result1 == MessageBoxResult.Yes)
                        {
                            _User_RightsController.User_Rights_DelByUser(c_UsersInfo.User_Name);
                            _User_RightsController.User_Rights_Insert_Barth(arrRight, c_UsersInfo.User_Name);
                            User_Controller _usC0n = new User_Controller();
                            _usC0n.User_Change_SetRight(c_UsersInfo.User_Id);
                            NoteBox.Show("Cập nhật dữ liệu thành công");
                            this.Close();
                        }
                    }
                    else
                    {
                        NoteBox.Show("Bạn chưa đặt quyền cho chức năng nào", "Thông báo", NoteBoxLevel.Error);
                    }
                }
                else
                {
                    NoteBox.Show("Bạn chưa thực hiện thay đổi quyền nào", "Thông báo", NoteBoxLevel.Error);
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                NoteBox.Show("Cập nhật dữ liệu không thành công", "Lỗi", NoteBoxLevel.Error);
            }

        }

        private User_RightsInfo ConvertToUser_RightsInfo(User_FunctionsInfo _User_FunctionsInfo, decimal user_id)
        {
            try
            {
                User_RightsInfo _User_RightsInfo = new User_RightsInfo();
                _User_RightsInfo.userid = user_id;
                _User_RightsInfo.funcid = _User_FunctionsInfo.functionId;
                _User_RightsInfo.authcode = _User_FunctionsInfo.right;
                _User_RightsInfo.notes = "";
                _User_RightsInfo.deleted = 0;
                _User_RightsInfo.created_by = CommonData.c_Urser_Info.User_Name;
                _User_RightsInfo.created_date = DateTime.Now;
                return _User_RightsInfo;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return null;
            }
        }

        private void exitForm()
        {
            MessageBoxResult result = NoteBox.Show("Bạn có muốn thoát form này hay không?", "Thông báo", NoteBoxLevel.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
            else
                this.Focus();
        }

        //private delegate void focus(HolePattern NewActivePattern);

        private void Search()
        {
            try
            {
                bool _ck = true;
                string _str = txtSearch.Text.ToUpper().Trim();
                if (_str != "")
                {
                    foreach (User_FunctionsInfo item in c_arrFunction)
                    {
                        if (item.name.ToUpper().Trim().Contains(_str))
                        {
                            grUser_Rights.ScrollIntoView(item);
                            grUser_Rights.SelectedItem = item;
                            grUser_Rights.Items.Refresh();
                            DataGridHelper.NVSFocus(grUser_Rights, grUser_Rights.SelectedIndex, 1);

                            _ck = false;
                            break;
                        }

                    }
                    if (_ck == true)
                        txtSearch.Focus();
                }
                else
                {
                    txtSearch.Clear();
                    DataGridHelper.NVSFocus(grUser_Rights, 1, 1);
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        void Check_Is_CheckALl()
        {
            try
            {
                bool _ck = true;
                foreach (User_FunctionsInfo item in c_arrFunction)
                {
                    if (item.use_right == 0 || item.view_right == 0 || item.Full_Right == 0 || item.insert_right == 0 ||
                        item.update_right == 0 || item.delete_right == 0 || item.approveInfo_right == 0)
                    {
                        _ck = false;
                        break;
                    }
                }

                if (_ck)
                    chkCheckAll.IsChecked = true;
                else
                    chkCheckAll.IsChecked = false;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_User_FunctionsInfo">thằng cha</param>
        /// <param name="p_type"></param>
        void Check_Is_CheckAll_Right(User_FunctionsInfo p_User_FunctionsInfo, int p_type)
        {
            try
            {
                bool _ck = true;
                foreach (User_FunctionsInfo item in c_arrFunction)
                {
                    // kiểm tra all thằng con của nó
                    if (item.prid == p_User_FunctionsInfo.functionId)
                    {
                        if (p_type == 1 && item.view_right == 0) // view
                        {
                            _ck = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        #endregion


    }
}
