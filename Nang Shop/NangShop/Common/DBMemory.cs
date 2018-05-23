using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NangShop_DataControl;
using NangShopObj;

namespace NangShop.Common
{
    public class DBMemory
    {
        public static Hashtable c_hash_User = new Hashtable(); //luu UserInfo, key: Id

        /// <summary>
        /// load tham số hệ thống
        /// </summary>
        public static void LoadParamSystem()
        {
            try
            {
                #region User

                lock (c_hash_User.SyncRoot)
                {
                    User_Controller _User_Controller = new User_Controller();
                    c_hash_User.Clear();
                    List<User_Info> _lst_us = _User_Controller.User_Get_All();
                    if (_lst_us.Count > 0)
                    {
                        foreach (User_Info item in _lst_us)
                        {
                            c_hash_User[item.User_Id] = item;
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                CommonData.log.Error(ex.ToString());
            }
        }
    }
}
