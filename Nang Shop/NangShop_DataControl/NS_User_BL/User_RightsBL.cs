
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using System.Configuration;
using System.Data;
using ZetaCompressionLibrary;

using NangShopObj;

namespace NangShop_DataControl
{

    public class User_RightsController
    {
        public void User_Rights_DelByUser(string username)
        {
            try
            {
                //Common.CommonData.c_serviceWCF.User_Rights_DelByUser(username);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        public void User_Rights_Insert_Barth(ArrayList userInfo, string username)
        {
            try
            {
                //int lenth = userInfo.Count;

                //string[] p_userid = new string[lenth];
                //string[] p_funcid = new string[lenth];
                //string[] p_authcode = new string[lenth];
                //string[] p_notes = new string[lenth];
                //decimal[] p_deleted = new decimal[lenth];
                //string[] p_created_by = new string[lenth];
                //DateTime[] p_created_date = new DateTime[lenth];
                //for (int i = 0; i < userInfo.Count; i++)
                //{
                //    User_RightsInfo _User_RightsInfo = (User_RightsInfo)userInfo[i];
                //    p_userid[i] = username;
                //    p_funcid[i] = _User_RightsInfo.funcid;
                //    p_authcode[i] = _User_RightsInfo.authcode;
                //    p_notes[i] = _User_RightsInfo.notes;
                //    p_deleted[i] = _User_RightsInfo.deleted;
                //    p_created_by[i] = _User_RightsInfo.created_by;
                //    p_created_date[i] = _User_RightsInfo.created_date;
                //}
                //Common.CommonData.c_serviceWCF.User_Rights_Insert_Barth(p_userid, p_funcid, p_authcode, p_notes, p_deleted,
                //    p_created_by, p_created_date);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }

        }

        /// <summary>
        /// lấy quyền theo user, type (nhóm người sử dụng), và theo hệ thống
        /// </summary>
        /// <returns></returns>
        public ArrayList User_Rights_GetByUser(string username, string system, decimal group_id, string p_lang)
        {
            try
            {
                //byte[] byteGetbyRight = Common.CommonData.c_serviceWCF.User_Rights_GetByUser(system, username, group_id); // lấy danh sách quyền của user theo hệ thống

                //DataSet dsGetbyRight = CompressionHelper.DecompressDataSet(byteGetbyRight);

                //ArrayList arrGetbyRight = CBO.FillCollectionFromDataSet(dsGetbyRight, typeof(User_FunctionsInfo));

                //// sắp sếp thằng nào là con thì cho thêm 1 khoảng trắng vào
                //ArrayList functionTree = GetChildofFunction(arrGetbyRight, p_lang);

                //return functionTree;

                return new ArrayList();
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new ArrayList();
            }
        }

        public void User_Rights_Update_Barth(decimal[] p_id, decimal[] p_userid, string[] p_funcid, string[] p_authcode,
            string[] p_notes, decimal[] p_deleted, string[] p_modified_by, DateTime[] p_modified_date, string[] p_created_by,
            DateTime[] p_created_date)
        {
            try
            {
                //Common.CommonData.c_serviceWCF.User_Rights_Update_Barth(p_id, p_userid, p_funcid, p_authcode, p_notes, p_deleted, p_modified_by,
                //    p_modified_date, p_created_by, p_created_date);
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }

        }

        /// <summary>
        /// sắp sếp thằng nào là con thì cho thêm 1 khoảng trắng vào
        /// </summary>
        /// <param name="arrAllFunction"></param>
        /// <param name="p_lang"></param>
        /// <returns></returns>
        private ArrayList GetChildofFunction(ArrayList arrAllFunction, string p_lang)
        {
            ArrayList new_arr = new ArrayList();
            string _cach = "          ";

            foreach (User_FunctionsInfo _info in arrAllFunction)
            {
                if (_info.prid == "0")
                {
                    new_arr.Add(_info);
                    User_FunctionsInfo _tem = new User_FunctionsInfo(_info);

                    //Lấy những function con từ function cha
                    BuidlTreeFuction(_tem, _info.functionId.ToString(), arrAllFunction, ref new_arr, _cach, p_lang);
                }

            }
            return new_arr;
        }

        /// <summary>
        /// Lấy những function con từ function cha
        /// </summary>
        private void BuidlTreeFuction(User_FunctionsInfo p_parentItem, string p_parentID, ArrayList arrAllFunction, ref ArrayList new_arr, string cach, string p_lang)
        {
            foreach (User_FunctionsInfo _info in arrAllFunction)
            {
                if (_info.prid == p_parentID)
                {
                    if (p_parentItem.use_right == 0)
                    {
                        p_parentItem.use_right = _info.use_right;
                    }
                    if (p_parentItem.view_right == 0)
                    {
                        p_parentItem.view_right = _info.view_right;
                    }
                    if (p_parentItem.insert_right == 0)
                    {
                        p_parentItem.insert_right = _info.insert_right;
                    }
                    if (p_parentItem.update_right == 0)
                    {
                        p_parentItem.update_right = _info.update_right;
                    }
                    if (p_parentItem.delete_right == 0)
                    {
                        p_parentItem.delete_right = _info.delete_right;
                    }
                    if (p_parentItem.approveInfo_right == 0)
                    {
                        p_parentItem.approveInfo_right = _info.approveInfo_right;
                    }
                    _info.name = cach + _info.name;
                    _info.Name_Eng = cach + _info.Name_Eng;
                    new_arr.Add(_info);
                    BuidlTreeFuction(_info, _info.functionId.ToString(), arrAllFunction, ref new_arr, cach + "          ", p_lang);
                }
            }
        }

        private ArrayList GetParentOfFunction(ArrayList arr, ArrayList arrAllFunction)
        {
            try
            {
                ArrayList new_arr = new ArrayList();
                Hashtable _hs = new Hashtable(); // lưu những quyền để check sự trùng lặp
                for (int i = 0; i < arr.Count; i++)
                {

                    User_FunctionsInfo _info = (User_FunctionsInfo)arr[i];
                    //if (_info.prid == "0")
                    //    continue;
                    //else
                    //{
                    new_arr.Add(_info);
                    User_FunctionsInfo _tem = new User_FunctionsInfo(_info);
                    BuidlTreeFuction(_tem, arrAllFunction, ref new_arr);
                    //}
                }
                return new_arr;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return new ArrayList();
            }
        }

        /// <summary>
        /// lấy function cha từ function con
        /// </summary>
        /// <param name="p_ChildItem"></param>
        /// <param name="arrAllFunction"></param>
        /// <param name="new_arr"></param>
        private void BuidlTreeFuction(User_FunctionsInfo p_ChildItem, ArrayList arrAllFunction, ref ArrayList new_arr)
        {
            try
            {
                foreach (FunctionsInfo _info in arrAllFunction)
                {
                    if (p_ChildItem.prid == _info.id)
                    {
                        User_FunctionsInfo _User_FunctionsInfo = ConvertToUser_FunctionsInfo(_info);
                        bool t = false;
                        foreach (User_FunctionsInfo item in new_arr)
                        {
                            if (item.functionId == _User_FunctionsInfo.functionId)
                            {
                                t = true;
                                break;
                            }
                        }
                        if (!t)
                        {
                            new_arr.Add(_User_FunctionsInfo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }

        private User_FunctionsInfo ConvertToUser_FunctionsInfo(FunctionsInfo _FunctionsInfo)
        {
            try
            {
                User_FunctionsInfo _User_FunctionsInfo = new User_FunctionsInfo();

                _User_FunctionsInfo.functionId = _FunctionsInfo.id;
                _User_FunctionsInfo.name = _FunctionsInfo.name;
                _User_FunctionsInfo.Name_Eng = _FunctionsInfo.Name_Eng;
                _User_FunctionsInfo.lev = _FunctionsInfo.lev;
                _User_FunctionsInfo.prid = _FunctionsInfo.prid;
                _User_FunctionsInfo.last = _FunctionsInfo.last;
                return _User_FunctionsInfo;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return null;
            }
        }

        public decimal Delete_User_Right_By_UserFuntion(string p_username, string p_fun_id)
        {
            try
            {
                //return Common.CommonData.c_serviceWCF.Delete_User_Right_By_UserFuntion(p_username, p_fun_id);
                return 0;
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
                return -1;
            }
        }
    }
}
