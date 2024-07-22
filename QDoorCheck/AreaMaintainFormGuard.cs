using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BO;
using SortableBindingList;
using System.Resources;
using System.Reflection;

namespace QDoorCheck
{

    public partial class AreaMaintainFormGuard : Form
    {        

        private List<Area> _enableAreas;

        protected List<Area> EnableAreas
        {
            get { return _enableAreas; }
            set { _enableAreas = value; }
        }      

        private bool _enableAdd;

        protected bool EnableAdd
        {
            get { return _enableAdd; }
            set { _enableAdd = value; }
        }


        public AreaMaintainFormGuard(List<Area> enableAreas, bool enableAdd)
        {
            InitializeComponent();
            this.EnableAreas = enableAreas;
            this.EnableAdd = enableAdd;           

        }
      

        private void c_close_Click(object sender, EventArgs e)
        { 
            //使用資源文件切換中英文 ‘確定關閉？’
            if (MessageBox.Show("確定關閉？\r\n(Determine the closure?)", "區域維護", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                return;
            }
            this.Close();
        }

        private void c_save_Click(object sender, EventArgs e)
        {

            Int32 index = this.tabControl1.SelectedIndex;
            Area curArea = this.areaBindingSource.Current as Area;

           
                                       
            Sys_User SysUser = this.Sys_UserBindingSource.Current as Sys_User;
            AreaUsers AreaUsers = this.AreaUserBindingSource.Current as AreaUsers;

            if (null == curArea)
            {

                //使用資源文件切換中英文  ‘請選擇當前區域？’
                MessageBox.Show("請選擇當前區域!\r\n(Please select the current region!)", "區域維護", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (curArea.AreaName == null || string.Empty == curArea.AreaName.Trim())
            {
                MessageBox.Show("請輸入区域名称！\r\n(Please enter cardno!)", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (null == SysUser)
            {
                //使用資源文件 中英文轉換 ‘請選定人員後再保存!’
                MessageBox.Show("請選定人員後再保存!\r\n(Please select the personnel and then save!)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (SysUser.WorkNo == null || string.Empty == SysUser.WorkNo.Trim())
            {
                MessageBox.Show("請輸入工號！\r\n(Please enter cardno!)", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Sys_User SysUserOld = Sys_User.GetAllByUserName(SysUser.WorkNo);

            try
            {

                if (SysUserOld == null)
                {
                    Sys_User.SaveSysUser(SysUser);
                    AreaUsers.UserId = SysUser.Sid;
                }
                else
                {
                    AreaUsers.UserId = SysUserOld.Sid;
                }

                AreaUsers.UserId = AreaUsers.UserId;
                AreaUsers.RoleId = "1";
                AreaUsers.AreaId = curArea.Sid;

                AreaUsers.SaveAreaUsers(AreaUsers);


                //使用資源文件切換中英文  ‘保存成功’
                MessageBox.Show("保存成功！\r\n(Save success!)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception er)
            {
                MessageBox.Show("ERROR:" + er.Message, "區域維護", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            

           
        }

        private void AreaMaintainForm_Load(object sender, EventArgs e)
        {
           
            SortableBindingList<Area> allAreas = new SortableBindingList<Area>();

            //List<Area> areas = Area.GetAllAreas();
            foreach (Area item in this.EnableAreas)
            {
                allAreas.Add(item);
            }

            this.areaBindingSource.DataSource = allAreas;
            if (!this.EnableAdd)
            {
                this.c_new.Enabled = false;
            }

            
            Area currentArea = this.areaBindingSource.Current as Area;

            SortableBindingList<AreaUsers> allAreaUsers = new SortableBindingList<AreaUsers>();

            List<AreaUsers> AreaUserList = AreaUsers.GetAllAreaUsers(currentArea,"1");

            foreach (AreaUsers item in AreaUserList)
            {
                allAreaUsers.Add(item);
            }
            this.AreaUserBindingSource.DataSource = allAreaUsers;

            SortableBindingList<Sys_User> allSysUser = new SortableBindingList<Sys_User>();

            List<Sys_User> SysUser = AreaUsers.GetAllSysUser(AreaUserList);

            foreach (Sys_User item in SysUser)
            {
                allSysUser.Add(item);
            }

            this.Sys_UserBindingSource.DataSource = allSysUser;

            this.txt_EmpNo.ReadOnly = true;

          

        }

        private void AreaMaintainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //BO.DBAccess.SessionFactory.Reset();
            //GC.Collect();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }      

       
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void c_new_Click(object sender, EventArgs e)
        {
           this.txt_EmpNo.ReadOnly = false;
           Sys_User newSysUser = this.Sys_UserBindingSource.AddNew() as Sys_User;
           this.Sys_UserBindingSource.Position = (this.Sys_UserBindingSource.DataSource as SortableBindingList<Sys_User>).IndexOf(newSysUser);

           AreaUsers newAreaUsers = this.AreaUserBindingSource.AddNew() as AreaUsers;
           this.AreaUserBindingSource.Position = (this.AreaUserBindingSource.DataSource as SortableBindingList<AreaUsers>).IndexOf(newAreaUsers);
       
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            Area currentArea = this.areaBindingSource.Current as Area;

            SortableBindingList<AreaUsers> allAreaUsers = new SortableBindingList<AreaUsers>();

            List<AreaUsers> AreaUserList = AreaUsers.GetAllAreaUsers(currentArea,"1");

            foreach (AreaUsers item in AreaUserList)
            {
                allAreaUsers.Add(item);
            }
            this.AreaUserBindingSource.DataSource = allAreaUsers;

            SortableBindingList<Sys_User> allSysUser = new SortableBindingList<Sys_User>();

            List<Sys_User> SysUser = AreaUsers.GetAllSysUser(AreaUserList);

            foreach (Sys_User item in SysUser)
            {
                allSysUser.Add(item);
            }

            this.Sys_UserBindingSource.DataSource = allSysUser;   

        }

        //失去焦點事件

        private void txt_EmpNo_Leave(object sender, EventArgs e)
        {


            if (txt_EmpNo.Text == string.Empty ||txt_EmpNo.ReadOnly==true )
            {
                return;
            }
            else
            {
                HR_Employee HREmployee = HR_Employee.GetAllByEmpNO(this.txt_EmpNo.Text);
                if (HREmployee == null)
                {
                    //使用資源文件切換中英文  ‘請選擇當前區域？’
                    MessageBox.Show("工號:" + this.txt_EmpNo.Text + "查找無此人,請輸入正確的工號!\r\n(Please Input Correct EmpNo !)", "區域維護", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txt_EmpNo.Text = "";
                    return;

                }
                else
                {

                    //判斷此用戶是否存在 

                    SortableBindingList<Sys_User> SysUserlist = this.Sys_UserBindingSource.DataSource as SortableBindingList<Sys_User>;

                    if (SysUserlist.Count > 1)
                    {
                        foreach (Sys_User sysuser in SysUserlist)
                        {

                            if (sysuser.WorkNo == null)
                            {
                                //新增的空
                                break;

                            }
                            else if (sysuser.WorkNo.Trim().ToUpper() == this.txt_EmpNo.Text.Trim().ToUpper())
                            {
                                MessageBox.Show("工號:" + this.txt_EmpNo.Text + "已經是此區域內保人員,請重新輸入正確的用戶!\r\n(Please Input Correct EmpNo !)", "區域維護", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.txt_EmpNo.Text = "";
                                return;
                            }

                        }

                    }    

                    Sys_User curSysUser = this.Sys_UserBindingSource.Current as Sys_User;

                    if (curSysUser == null)
                    {
                        MessageBox.Show("請先點擊新增按鈕!\r\n(Please click Add Buttom !)", "區域維護", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txt_EmpNo.Text = "";
                        return;

                    }
                    else
                    {
                        txt_Username.Text = HREmployee.Emp_Name;
                        txt_Dept.Text = HREmployee.Dept;
                        txt_Job.Text = HREmployee.Job;
                        curSysUser.UserName = HREmployee.Emp_Name;
                        curSysUser.Dept = HREmployee.Dept;
                        curSysUser.Job = HREmployee.Job;
                        textBox4.Focus();

                    }      

                }


            }

        }


        private void txt_EmpNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && txt_EmpNo.Text != "")
            {
                txt_EmpNo_Leave(sender, e);
            }
        }


      
    }

}