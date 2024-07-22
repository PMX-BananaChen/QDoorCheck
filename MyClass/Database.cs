using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Myclass
{   
    public class database
    {
        public String con = System.Configuration.ConfigurationManager.ConnectionStrings["IDE_Local"].ToString();
        public SqlConnection mycon;
        public DataSet mydata;

        //#region 打开数据连接
        public SqlConnection getcon()
        {
            mycon = new SqlConnection(con);
            if (mycon.State == ConnectionState.Closed)
            {
                mycon.Open();

            }
            return mycon;
        }

        //'#End Region

        //'#region  关闭数据连接

        public void con_close()
        {
            if (mycon.State == ConnectionState.Open)
            {
                mycon.Close();

            }
        }
        // '#End Region

        // '#region 以读取数据方式打开

        public SqlDataReader myread(String SQLstr)
        {
            //'打开数据  getcon()
            mycon = getcon();
            SqlCommand My_com = mycon.CreateCommand();
            My_com.CommandText = SQLstr;  // '定义SQL
            SqlDataReader My_read = My_com.ExecuteReader(); //'执行SQL读取          
            return My_read;
        }
        //'#End Region

        // '#region  读取数据到MYDATA

        public DataSet mydataset(String mysql)
        {
            mycon = getcon();
            // 'SqlConnection mycon = new SqlConnection(con);
            SqlDataAdapter myda = new SqlDataAdapter(mysql, mycon);
            mydata = new DataSet();
            myda.Fill(mydata);
            con_close();
            myda.Dispose();
            return mydata;    //  '返回dataset数据

        }

        public DataView mydataview(String mysql)
        {
            mycon = getcon();
            SqlDataAdapter myda = new SqlDataAdapter(mysql, mycon);
            mydata = new DataSet();
            myda.Fill(mydata);
            con_close();
            myda.Dispose();
            return mydata.Tables[0].DefaultView;
        }

        #region  SQL执行

        public void sql_store(String mysql)
        {
            getcon();
            SqlCommand mycomm = new SqlCommand(mysql, mycon);
            mycomm.ExecuteNonQuery();
            con_close();
            mycomm.Dispose();
        }
        #endregion


        public Int32 return_val(String mysql)
        {
            mycon = getcon();
            SqlCommand mycomm = new SqlCommand(mysql, mycon);
            Int32 val = (int)mycomm.ExecuteScalar();
            con_close();
            return val;
        }

        //执行存储过程
        public void exec_proc(CommandType cmdtype, String cmdtext, SqlParameter[] parms)
        {
            mycon = getcon();
            SqlCommand cmd = new SqlCommand(cmdtext, mycon);
            cmd.CommandType = cmdtype;

            if (parms != null)
            {

                foreach (SqlParameter pa in parms)
                {
                    cmd.Parameters.Add(pa);
                }
            }

            cmd.ExecuteNonQuery();

        }

        ////将datatable中的数据插入数据库
        //public void dt_to_db(DataTable dt)
        //{
        //    mycon = getcon();
        //    SqlBulkCopy bcp = new SqlBulkCopy(mycon);

        //    //指定目标数据库的表名
        //    bcp.DestinationTableName = "Modul";
        //    //建立数据源表字段和目标表中的列之间的映射

        //    SqlBulkCopyColumnMapping MapUserID = new SqlBulkCopyColumnMapping();
        //    MapUserID.DestinationColumn = "NPP_NO";
        //    MapUserID.SourceColumn = "NPP_NO";
        //    bcp.ColumnMappings.Add(MapUserID);

        //    SqlBulkCopyColumnMapping MapQID = new SqlBulkCopyColumnMapping();
        //    MapQID.DestinationColumn = "model_ID";
        //    MapQID.SourceColumn = "Model_ID";
        //    bcp.ColumnMappings.Add(MapQID);

        //    SqlBulkCopyColumnMapping MapAnswer = new SqlBulkCopyColumnMapping();
        //    MapAnswer.DestinationColumn = "owner";
        //    MapAnswer.SourceColumn = "owner";
        //    bcp.ColumnMappings.Add(MapAnswer);

        //    SqlBulkCopyColumnMapping Mapdate = new SqlBulkCopyColumnMapping();
        //    Mapdate.DestinationColumn = "plan_date";
        //    Mapdate.SourceColumn = "datetime";
        //    bcp.ColumnMappings.Add(Mapdate);

        //    SqlBulkCopyColumnMapping MapRemark = new SqlBulkCopyColumnMapping();
        //    MapRemark.DestinationColumn = "remark";
        //    MapRemark.SourceColumn = "remark";
        //    bcp.ColumnMappings.Add(MapRemark);
        //    //写入数据库表
        //    bcp.WriteToServer(dt);
        //    bcp.Close();

        //}

        //将datatable中的数据插入数据库
        public void dt_to_db_persontask(DataTable dt)
        {
            mycon = getcon();
            SqlBulkCopy bcp = new SqlBulkCopy(mycon);

            //指定目标数据库的表名
            bcp.DestinationTableName = "person_task";
            //建立数据源表字段和目标表中的列之间的映射

            SqlBulkCopyColumnMapping MapUserFASNO = new SqlBulkCopyColumnMapping();
            MapUserFASNO.DestinationColumn = "FAS_NO";
            MapUserFASNO.SourceColumn = "FAS_NO";
            bcp.ColumnMappings.Add(MapUserFASNO);

            SqlBulkCopyColumnMapping MapUserType = new SqlBulkCopyColumnMapping();
            MapUserType.DestinationColumn = "Type";
            MapUserType.SourceColumn = "Type";
            bcp.ColumnMappings.Add(MapUserType);

            SqlBulkCopyColumnMapping MapUserID = new SqlBulkCopyColumnMapping();
            MapUserID.DestinationColumn = "NPP_NO";
            MapUserID.SourceColumn = "NPP_NO";
            bcp.ColumnMappings.Add(MapUserID);

            SqlBulkCopyColumnMapping MapQID = new SqlBulkCopyColumnMapping();
            MapQID.DestinationColumn = "task_ID";
            MapQID.SourceColumn = "Task_ID";
            bcp.ColumnMappings.Add(MapQID);

            SqlBulkCopyColumnMapping MapAnswer = new SqlBulkCopyColumnMapping();
            MapAnswer.DestinationColumn = "owner";
            MapAnswer.SourceColumn = "owner";
            bcp.ColumnMappings.Add(MapAnswer);

            SqlBulkCopyColumnMapping Mapdate = new SqlBulkCopyColumnMapping();
            Mapdate.DestinationColumn = "Request_Date";
            Mapdate.SourceColumn = "Request_Date";
            bcp.ColumnMappings.Add(Mapdate);

            SqlBulkCopyColumnMapping MapRemark = new SqlBulkCopyColumnMapping();
            MapRemark.DestinationColumn = "remark";
            MapRemark.SourceColumn = "remark";
            bcp.ColumnMappings.Add(MapRemark);
            //写入数据库表
            bcp.WriteToServer(dt);
            bcp.Close();
        }

        //将datatable中的数据插入数据库

        public void dt_to_db_ModelID(DataTable dt)
        {
            con = System.Configuration.ConfigurationManager.ConnectionStrings["MPTSConnectionString"].ToString();
            mycon = getcon();
            SqlBulkCopy bcp = new SqlBulkCopy(mycon);


            //指定目标数据库的表名
            bcp.DestinationTableName = "common..Model_ID";
            //建立数据源表字段和目标表中的列之间的映射

            SqlBulkCopyColumnMapping MapUserFASNO = new SqlBulkCopyColumnMapping();
            MapUserFASNO.DestinationColumn = "Model_ID";
            MapUserFASNO.SourceColumn = "Model_ID";
            bcp.ColumnMappings.Add(MapUserFASNO);

            SqlBulkCopyColumnMapping MapUserType = new SqlBulkCopyColumnMapping();
            MapUserType.DestinationColumn = "Model";
            MapUserType.SourceColumn = "Model";
            bcp.ColumnMappings.Add(MapUserType);

            SqlBulkCopyColumnMapping MapUserID = new SqlBulkCopyColumnMapping();
            MapUserID.DestinationColumn = "Board_PartNo";
            MapUserID.SourceColumn = "Board_PartNo";
            bcp.ColumnMappings.Add(MapUserID);

            SqlBulkCopyColumnMapping MapQID = new SqlBulkCopyColumnMapping();
            MapQID.DestinationColumn = "Created_Dt";
            MapQID.SourceColumn = "Created_Dt";
            bcp.ColumnMappings.Add(MapQID);

            //写入数据库表
            bcp.WriteToServer(dt);
            bcp.Close();
        }


        public void dt_to_db_MacSet(DataTable dt)
        {
            con = System.Configuration.ConfigurationManager.ConnectionStrings["MPTSConnectionString"].ToString();
            mycon = getcon();
            SqlBulkCopy bcp = new SqlBulkCopy(mycon);


            //指定目标数据库的表名
            bcp.DestinationTableName = "Testing..MAC_SET";
            //建立数据源表字段和目标表中的列之间的映射

            SqlBulkCopyColumnMapping MapUserFASNO = new SqlBulkCopyColumnMapping();
            MapUserFASNO.DestinationColumn = "Model_ID";
            MapUserFASNO.SourceColumn = "Model_ID";
            bcp.ColumnMappings.Add(MapUserFASNO);

            SqlBulkCopyColumnMapping MapUserType = new SqlBulkCopyColumnMapping();
            MapUserType.DestinationColumn = "Model";
            MapUserType.SourceColumn = "Model";
            bcp.ColumnMappings.Add(MapUserType);

            SqlBulkCopyColumnMapping MapUserID = new SqlBulkCopyColumnMapping();
            MapUserID.DestinationColumn = "Board_PartNo";
            MapUserID.SourceColumn = "Board_PartNo";
            bcp.ColumnMappings.Add(MapUserID);

            SqlBulkCopyColumnMapping MapQID = new SqlBulkCopyColumnMapping();
            MapQID.DestinationColumn = "Created_Dt";
            MapQID.SourceColumn = "Created_Dt";
            bcp.ColumnMappings.Add(MapQID);

            //写入数据库表
            bcp.WriteToServer(dt);
            bcp.Close();
        }

        /// <summary>
        /// 保存数据到Route
        /// </summary>
        /// <param name="dt"></param>
        public void dt_to_db_Route(DataTable dt)
        {

            con = System.Configuration.ConfigurationManager.ConnectionStrings["MPTSConnectionString"].ToString();
            mycon = getcon();
            SqlBulkCopy bcp = new SqlBulkCopy(mycon);

            //指定目标数据库的表名
            bcp.DestinationTableName = "Route";
            //建立数据源表字段和目标表中的列之间的映射

            SqlBulkCopyColumnMapping Unit_PartNo = new SqlBulkCopyColumnMapping();
            Unit_PartNo.DestinationColumn = "Unit_PartNo";
            Unit_PartNo.SourceColumn = "Unit_PartNo";
            bcp.ColumnMappings.Add(Unit_PartNo);

            SqlBulkCopyColumnMapping Modelid = new SqlBulkCopyColumnMapping();
            Modelid.DestinationColumn = "Model_Id";
            Modelid.SourceColumn = "Model_Id";
            bcp.ColumnMappings.Add(Modelid);

            SqlBulkCopyColumnMapping Routeorder = new SqlBulkCopyColumnMapping();
            Routeorder.DestinationColumn = "Route_Order";
            Routeorder.SourceColumn = "Route_Order";
            bcp.ColumnMappings.Add(Routeorder);

            SqlBulkCopyColumnMapping Routeid = new SqlBulkCopyColumnMapping();
            Routeid.DestinationColumn = "Route_Id";
            Routeid.SourceColumn = "Route_Id";
            bcp.ColumnMappings.Add(Routeid);

            SqlBulkCopyColumnMapping Scan_model_id = new SqlBulkCopyColumnMapping();
            Scan_model_id.DestinationColumn = "Scan_Model_Id";
            Scan_model_id.SourceColumn = "Scan_Model_Id";
            bcp.ColumnMappings.Add(Scan_model_id);

            SqlBulkCopyColumnMapping Scan_board_sno1 = new SqlBulkCopyColumnMapping();
            Scan_board_sno1.DestinationColumn = "Scan_Board_Sno1";
            Scan_board_sno1.SourceColumn = "Scan_Board_Sno1";
            bcp.ColumnMappings.Add(Scan_board_sno1);

            SqlBulkCopyColumnMapping Scan_board_sno2 = new SqlBulkCopyColumnMapping();
            Scan_board_sno2.DestinationColumn = "Scan_Board_Sno2";
            Scan_board_sno2.SourceColumn = "Scan_Board_Sno2";
            bcp.ColumnMappings.Add(Scan_board_sno2);


            SqlBulkCopyColumnMapping Scan_board_sno3 = new SqlBulkCopyColumnMapping();
            Scan_board_sno3.DestinationColumn = "Scan_Board_Sno3";
            Scan_board_sno3.SourceColumn = "Scan_Board_Sno3";
            bcp.ColumnMappings.Add(Scan_board_sno3);


            SqlBulkCopyColumnMapping Scan_board_sno4 = new SqlBulkCopyColumnMapping();
            Scan_board_sno4.DestinationColumn = "Scan_Board_Sno4";
            Scan_board_sno4.SourceColumn = "Scan_Board_Sno4";
            bcp.ColumnMappings.Add(Scan_board_sno4);


            SqlBulkCopyColumnMapping Scan_board_sno5 = new SqlBulkCopyColumnMapping();
            Scan_board_sno5.DestinationColumn = "Scan_Board_Sno5";
            Scan_board_sno5.SourceColumn = "Scan_Board_Sno5";
            bcp.ColumnMappings.Add(Scan_board_sno5);

            SqlBulkCopyColumnMapping Scan_macadd1 = new SqlBulkCopyColumnMapping();
            Scan_macadd1.DestinationColumn = "Scan_MacAdd1";
            Scan_macadd1.SourceColumn = "Scan_MacAdd1";
            bcp.ColumnMappings.Add(Scan_macadd1);


            SqlBulkCopyColumnMapping Scan_macadd2 = new SqlBulkCopyColumnMapping();
            Scan_macadd2.DestinationColumn = "Scan_MacAdd2";
            Scan_macadd2.SourceColumn = "Scan_MacAdd2";
            bcp.ColumnMappings.Add(Scan_macadd2);

            SqlBulkCopyColumnMapping Scan_macadd3 = new SqlBulkCopyColumnMapping();
            Scan_macadd3.DestinationColumn = "Scan_MacAdd3";
            Scan_macadd3.SourceColumn = "Scan_MacAdd3";
            bcp.ColumnMappings.Add(Scan_macadd3);

            SqlBulkCopyColumnMapping Scan_unit_sno1 = new SqlBulkCopyColumnMapping();
            Scan_unit_sno1.DestinationColumn = "Scan_Unit_Sno1";
            Scan_unit_sno1.SourceColumn = "Scan_Unit_Sno1";
            bcp.ColumnMappings.Add(Scan_unit_sno1);

            SqlBulkCopyColumnMapping Scan_unit_sno2 = new SqlBulkCopyColumnMapping();
            Scan_unit_sno2.DestinationColumn = "Scan_Unit_Sno2";
            Scan_unit_sno2.SourceColumn = "Scan_Unit_Sno2";
            bcp.ColumnMappings.Add(Scan_unit_sno2);


            SqlBulkCopyColumnMapping Scan_unit_sno3 = new SqlBulkCopyColumnMapping();
            Scan_unit_sno3.DestinationColumn = "Scan_Unit_Sno3";
            Scan_unit_sno3.SourceColumn = "Scan_Unit_Sno3";
            bcp.ColumnMappings.Add(Scan_unit_sno3);


            SqlBulkCopyColumnMapping Scan_unit_sno4 = new SqlBulkCopyColumnMapping();
            Scan_unit_sno4.DestinationColumn = "Scan_Unit_Sno4";
            Scan_unit_sno4.SourceColumn = "Scan_Unit_Sno4";
            bcp.ColumnMappings.Add(Scan_unit_sno4);

            SqlBulkCopyColumnMapping Scan_unit_sno5 = new SqlBulkCopyColumnMapping();
            Scan_unit_sno5.DestinationColumn = "Scan_Unit_Sno5";
            Scan_unit_sno5.SourceColumn = "Scan_Unit_Sno5";
            bcp.ColumnMappings.Add(Scan_unit_sno5);

            SqlBulkCopyColumnMapping Scan_elec_sno = new SqlBulkCopyColumnMapping();
            Scan_elec_sno.DestinationColumn = "Scan_Elec_Sno";
            Scan_elec_sno.SourceColumn = "Scan_Elec_Sno";
            bcp.ColumnMappings.Add(Scan_elec_sno);

            SqlBulkCopyColumnMapping Scan_part_no = new SqlBulkCopyColumnMapping();
            Scan_part_no.DestinationColumn = "Scan_Part_No";
            Scan_part_no.SourceColumn = "Scan_Part_No";
            bcp.ColumnMappings.Add(Scan_part_no);

            SqlBulkCopyColumnMapping Scan_jan_no = new SqlBulkCopyColumnMapping();
            Scan_jan_no.DestinationColumn = "Scan_Jan_No";
            Scan_jan_no.SourceColumn = "Scan_Jan_No";
            bcp.ColumnMappings.Add(Scan_jan_no);

            SqlBulkCopyColumnMapping Scan_emc_sno = new SqlBulkCopyColumnMapping();
            Scan_emc_sno.DestinationColumn = "Scan_EMC_Sno";
            Scan_emc_sno.SourceColumn = "Scan_EMC_Sno";
            bcp.ColumnMappings.Add(Scan_emc_sno);


            SqlBulkCopyColumnMapping LastUpdateUser = new SqlBulkCopyColumnMapping();
            LastUpdateUser.DestinationColumn = "LastUpdateUser";
            LastUpdateUser.SourceColumn = "LastUpdateUser";
            bcp.ColumnMappings.Add(LastUpdateUser);

            SqlBulkCopyColumnMapping CreateDt = new SqlBulkCopyColumnMapping();
            CreateDt.DestinationColumn = "CreateDt";
            CreateDt.SourceColumn = "CreateDt";
            bcp.ColumnMappings.Add(CreateDt);


            SqlBulkCopyColumnMapping RouteCopyUser = new SqlBulkCopyColumnMapping();
            RouteCopyUser.DestinationColumn = "RouteCopyUser";
            RouteCopyUser.SourceColumn = "RouteCopyUser";
            bcp.ColumnMappings.Add(RouteCopyUser);

            SqlBulkCopyColumnMapping LastUpdateDt = new SqlBulkCopyColumnMapping();
            LastUpdateDt.DestinationColumn = "LastUpdateDt";
            LastUpdateDt.SourceColumn = "LastUpdateDt";
            bcp.ColumnMappings.Add(LastUpdateDt);


            //写入数据库表
            bcp.WriteToServer(dt);
            bcp.Close();
        }


        // 执行语句不用返回结果！

        public void exec_sql(String sql)
        {
            mycon = getcon();
            SqlCommand mycomm = new SqlCommand(sql, mycon);
            mycomm.CommandTimeout = 500;
            mycomm.ExecuteNonQuery();
            con_close();
        }


        //由userid 得到用户名

        public string username(string ID)
        {
            DataTable dt = (DataTable)mydataset("select [name] from login where id='" + ID + "'").Tables[0];
            return dt.Rows[0][0].ToString();

        }
        public string Shortname(Int32 ID)
        {
            DataTable dt = (DataTable)mydataset("select Shortname from login where id=" + ID).Tables[0];
            return dt.Rows[0][0].ToString();

        }
        /// <summary>
        /// 根据用户ID得到权限
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string ReturnRight(Int32 ID)
        {
            string right = "";

            DataTable dt = (DataTable)mydataset("select Assign_ck_PE,Assign_ck_PM,Assign_ck_DCC from limit where id=" + ID).Tables[0];
            if (dt.Rows.Count == 0)
            {
                right = "General";

            }
            else
            {
                if ((bool)dt.Rows[0][0])
                {
                    right = "PE";
                }
                if ((bool)dt.Rows[0][1])
                {
                    right = "PM";
                }
                if ((bool)dt.Rows[0][2])
                {
                    right = "DCC";
                }
            }

            return right;

        }

        public string mail(string ID)
        {
            DataTable dt = (DataTable)mydataset("select mail_dress from login where id='" + ID + "'").Tables[0];
            return dt.Rows[0][0].ToString();

        }


        // 由taskid 得到taskdes
        public string Task_Des(string Task_ID)
        {
            DataTable dt_taskdes = (DataTable)this.mydataset("select task_des from task_details where task_id='" + Task_ID + "'").Tables[0];
            return dt_taskdes.Rows[0][0].ToString();

        }

        //由tast_id得到task_des
        public string split_item(string str)
        {
            string[] bArray = str.TrimEnd(',').Split(',');
            string task_des = "";
            foreach (string i in bArray)
            {
                task_des += Task_Des(i.ToString()) + ",";

            }
            return task_des;
        }

        public void update_status(string npp_no, string task_id, string url, string finish_date, string remark)
        {
            string[] aArray = npp_no.Trim().TrimEnd(',').Split(',');
            string[] bArray = task_id.TrimEnd(',').Split(',');
            for (int i = 0; i < aArray.Length; i++)
            {
                //保存路径,日期,备注,将个人任务状态改为1，代表已完成
                this.sql_store("update person_task set status='1',url='" + url + "',Finished_Date='" + finish_date + "',remark='" + remark + "' where npp_no='" + aArray[i].ToString() + "' and task_id='" + bArray[i].ToString() + "'");

            }


        }
        //自动产生单号
        public string npp_no()
        {
            string npp = "NPP-" + DateTime.Now.ToString("yyyyMMdd") + "-";

            string new_npp = "";

            DataTable dt_npp = (DataTable)this.mydataset("select isnull(max(npp_no),'') from npp where npp_no like '" + npp + "%'").Tables[0];

            if (dt_npp.Rows[0][0].ToString().Trim() == "")
            {

                new_npp = npp + "001";

            }
            else
            {
                Int32 ID = Convert.ToInt32(dt_npp.Rows[0][0].ToString().Substring(13, 3)) + 1;

                new_npp = dt_npp.Rows[0][0].ToString().Substring(0, 13) + string.Format("{0:D3}", ID);
            }


            return new_npp;


        }

        //得到844#的描述

        public string GetDes844(string partno)
        {
            DataTable dt = (DataTable)mydataset("select description_845 from common..MFG845990 where part_no_845='" + partno + "'").Tables[0];
            return dt.Rows[0][0].ToString();

        }


        //得到Vendor身份描述

        public string GetDesVendor(string Vendor)
        {
            DataTable dt = (DataTable)mydataset("select identity_des from dbo.QuestionnaireTypeDescription where vendor_identity='" + Vendor + "'").Tables[0];
            return dt.Rows[0][0].ToString();

        }

        //得到990#的描述

        public string GetFASDes(string FAS_NO)
        {
            DataTable dt = (DataTable)mydataset("select Model_Name from FAS where FAS_NO='" + FAS_NO + "'").Tables[0];
            return dt.Rows[0][0].ToString();

        }

        //得到Model_ID

        public string GetModelID(string partno)
        {
            con = System.Configuration.ConfigurationManager.ConnectionStrings["MPTSConnectionString"].ToString();
            DataTable dt = (DataTable)mydataset("select Model_ID from common..Model_ID where board_PartNo='" + partno + "'").Tables[0];
            if (dt.Rows.Count == 0)
            {
                return "";
            }
            else
            {
                return dt.Rows[0][0].ToString();

            }

        }

    }

    }

