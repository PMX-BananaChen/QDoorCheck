namespace QDoorCheck
{
    partial class CheckPassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckPassword));
            this.c_msg = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.c_txt_password = new System.Windows.Forms.TextBox();
            this.c_ok = new System.Windows.Forms.Button();
            this.c_cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // c_msg
            // 
            resources.ApplyResources(this.c_msg, "c_msg");
            this.c_msg.Name = "c_msg";
            this.c_msg.Click += new System.EventHandler(this.c_msg_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.c_txt_password);
            this.groupBox1.Controls.Add(this.c_msg);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // c_txt_password
            // 
            resources.ApplyResources(this.c_txt_password, "c_txt_password");
            this.c_txt_password.Name = "c_txt_password";
            // 
            // c_ok
            // 
            resources.ApplyResources(this.c_ok, "c_ok");
            this.c_ok.Name = "c_ok";
            this.c_ok.UseVisualStyleBackColor = true;
            this.c_ok.Click += new System.EventHandler(this.c_ok_Click);
            // 
            // c_cancel
            // 
            this.c_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.c_cancel, "c_cancel");
            this.c_cancel.Name = "c_cancel";
            this.c_cancel.UseVisualStyleBackColor = true;
            this.c_cancel.Click += new System.EventHandler(this.c_cancel_Click);
            // 
            // CheckPassword
            // 
            this.AcceptButton = this.c_ok;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.c_cancel;
            this.Controls.Add(this.c_cancel);
            this.Controls.Add(this.c_ok);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckPassword";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CheckPassword_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label c_msg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox c_txt_password;
        private System.Windows.Forms.Button c_ok;
        private System.Windows.Forms.Button c_cancel;
    }
}