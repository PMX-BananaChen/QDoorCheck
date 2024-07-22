namespace QDoorCheck
{
    partial class CheckPasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckPasswordForm));
            this.c_ok = new System.Windows.Forms.Button();
            this.c_cancel = new System.Windows.Forms.Button();
            this.text_UserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.text_PassWord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            // text_UserName
            // 
            resources.ApplyResources(this.text_UserName, "text_UserName");
            this.text_UserName.Name = "text_UserName";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // text_PassWord
            // 
            resources.ApplyResources(this.text_PassWord, "text_PassWord");
            this.text_PassWord.Name = "text_PassWord";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // CheckPasswordForm
            // 
            this.AcceptButton = this.c_ok;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.c_cancel;
            this.Controls.Add(this.text_PassWord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text_UserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.c_cancel);
            this.Controls.Add(this.c_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckPasswordForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CheckPasswordForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button c_ok;
        private System.Windows.Forms.Button c_cancel;
        private System.Windows.Forms.TextBox text_UserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_PassWord;
        private System.Windows.Forms.Label label2;
    }
}