//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Data;
//using System.Data.Common;
//using System.Data.SqlClient;
//using XmlSetting;

//namespace BO.DBAccess
//{
//    public class DBCn
//    {
//        private DBCn()
//        { }

//        private DbConnection _cn;

//        public DbConnection Cn
//        {
//            get 
//            {
//                if (_cn==null)
//                {
//                    _cn = GetDbConnection();
//                }
//                return _cn; 
//            }
//        }

//        private DbConnection GetDbConnection()
//        {
//            string dbSettingFile = AppDomain.CurrentDomain.BaseDirectory + @"\DBConnection.xml";

//            XmlSettingManager manager = new XmlSettingManager(dbSettingFile);
//            XmlSetting.SettingRoot setting = manager.GetSetting();

//            string strCn= setting["DBConnection"]["DBConnection"].Value;

//            return new SqlConnection(strCn);
//        }

//    }
//}
