using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BO;
using BO.DBAccess;
using System.Threading;
using System.Globalization;
using System.Resources;
using System.Reflection;


namespace QDoorCheck
{
    public partial class CheckPasswordForm : Form
    {        

        private string _targetPassword;

        public string TargetPassword
        {
            get { return _targetPassword; }
            set { _targetPassword = value; }
        }

        private Area _areaId;

        public Area AreaId
        {
            get { return _areaId; }
            set { _areaId = value; }
        }

        public CheckPasswordForm(Area AreaId)
        {
            InitializeComponent();
            this.AreaId = AreaId;           
        }

        private void c_ok_Click(object sender, EventArgs e)
        {

            Sys_User SysUser = Sys_User.GetAllByUserName(this.text_UserName.Text);       
   
            if(SysUser==null)
            {
                MessageBox.Show("用戶名不存在!\r\n(ＵserNo Error!)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            AreaUsers AreaUsers = DB_Area.CheckPassWord_Admin(this.AreaId, SysUser, this.text_PassWord.Text);

                if (AreaUsers == null)
                {
                    MessageBox.Show("密碼錯誤!\r\n(Password Error!)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {


                    if ( AreaUsers.RoleId == "3")
                    {

                        List<Area> enableAreas;
                        bool isAdmin = false;
                        enableAreas = Area.GetAllAreas();
                        isAdmin = true;
                        AreaMaintainForm areaForm = new AreaMaintainForm(enableAreas, isAdmin);
                        this.Hide();
                        areaForm.ShowDialog();
                       
                      

                    }
                    else if (this.AreaId==null)
                    {

                        MessageBox.Show("沒有選擇區域!\r\n(Please select area!)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }

                    else
                    {

                        AreaUsers AreaUsers_New = DB_Area.CheckPassWord(this.AreaId, SysUser, this.text_PassWord.Text);

                        if (AreaUsers_New == null)
                        {

                            MessageBox.Show("密碼錯誤!\r\n(Password Error!)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }
                        else
                        {

                            QDoorCheckForm QCF = new QDoorCheckForm(this.AreaId, AreaUsers);

                            //QCF.TopMost = true;
                            this.Hide();
                            QCF.ShowDialog();
                
                           
                          
                         
                        }

                    }
                                    

                  

                }
        

        }

        private void c_cancel_Click(object sender, EventArgs e)
        {
            this.text_PassWord.Text = string.Empty;
            this.Close();
           
        }

        private void CheckPasswordForm_Load(object sender, EventArgs e)
        {




        }       


    }
}
