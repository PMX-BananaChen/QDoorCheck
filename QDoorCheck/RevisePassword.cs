using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BO;
using System.Resources;
using System.Reflection;

namespace QDoorCheck
{
    public partial class RevisePassword : Form
    {  
      
        #region properties    
 
        private AreaUsers _curUser;

        protected AreaUsers TargetUser
        {
            get { return _curUser; }
            set { _curUser = value; }
        }       


        #endregion

        public RevisePassword(AreaUsers CurUser)
        {
            this.TargetUser = CurUser;

            InitializeComponent();
            
        }

        private void RevisePassword_Load(object sender, EventArgs e)
        {
          

        }

        private void c_OK_Click(object sender, EventArgs e)
        {

            if (this.textBox1.Text!=this.TargetUser.PassWord)
            {
                //原始密碼不正確
                MessageBox.Show("原始密碼不正確!\r\n(The original password  is error!)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
                return;
            }

            if (this.textBox2.Text!=this.textBox3.Text)
            {
                //兩次輸入的新密碼不一致!
                MessageBox.Show("兩次輸入的新密碼不一致!\r\n(Two input do not match the new password!)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(this.textBox2.Text))
            {
                //新密碼不能為空!
                MessageBox.Show("新密碼不能為空!\r\n(The new password is not null!)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.TargetUser.PassWord = this.textBox2.Text;
            try
            {
                //密碼修改成功!
                AreaUsers.SaveAreaUsers(this.TargetUser);
                MessageBox.Show("密碼修改成功!\r\n(Password modification success!)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show("ERROR:" + er.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }     

     
    }
}