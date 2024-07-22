using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BO;
using System.Threading;
using System.Globalization;
using System.Resources;
using System.Reflection;

namespace QDoorCheck
{
    public partial class CheckPassword : Form
    {
       
        

        #region Properties

        protected string Prompt
        {
            get 
            {
                return this.c_msg.Text;
            }
            set 
            {
                this.c_msg.Text = value;
            }
        }

        private string _targetPassword;

        public string TargetPassword
        {
            get { return _targetPassword; }
            set { _targetPassword = value; }
        }


        private static CheckPassword _instance = null;
        public static CheckPassword Instance
        {
            get
            {
                if (_instance==null || _instance.IsDisposed)
                {
                    _instance = new CheckPassword();
                }
                return _instance;
            }
        }

        private int _count=0;

        protected int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        private int _countAllowInput = 0;

        protected int CountAllowInput
        {
            get { return _countAllowInput; }
            set { _countAllowInput = value; }
        }

        #endregion
        
        

        private CheckPassword()
        {
            InitializeComponent();
        }

        public static bool CheckUserPassword(string targetPassword, string prompt,int timesAllowInput)
        {
            
            CheckPassword checkForm = CheckPassword.Instance;
            checkForm.Count = 0;
            checkForm.CountAllowInput = timesAllowInput;
            checkForm.Prompt = prompt;
            checkForm.TargetPassword =targetPassword;
            checkForm.c_txt_password.Focus();
            
            if (checkForm.ShowDialog()!=DialogResult.OK)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void c_ok_Click(object sender, EventArgs e)
        {
            if (this.c_txt_password.Text==this.TargetPassword)
            {
                this.c_txt_password.Text = string.Empty;
                this.DialogResult = DialogResult.OK;
                
            }
            else    
            {
                MessageBox.Show("密碼錯誤!\r\n(Password Error!)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.c_txt_password.SelectAll();
                Count++;
                CheckCount();
            }
        }

        private void c_cancel_Click(object sender, EventArgs e)
        {
            this.c_txt_password.Text = string.Empty;
            this.DialogResult = DialogResult.Cancel;
        }

        private void CheckCount()
        {
            if (this.Count>=this.CountAllowInput)
            {
                this.c_txt_password.Text = string.Empty;
                this.DialogResult = DialogResult.Cancel;
            }
        }

       
       

     

      

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

      

      
        private void c_msg_Click(object sender, EventArgs e)
        {
           
        }

        private void CheckPassword_Load(object sender, EventArgs e)
        {

        }



    }
}