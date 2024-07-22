namespace QDoorCheck
{
    partial class AreaMaintainFormGuard
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txt_Job = new System.Windows.Forms.TextBox();
            this.Sys_UserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txt_Dept = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Username = new System.Windows.Forms.TextBox();
            this.txt_EmpNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.AreaUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.c_close = new System.Windows.Forms.Button();
            this.c_save = new System.Windows.Forms.Button();
            this.c_new = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.areaBindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sys_UserBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AreaUserBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BU,
            this.areaNameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.areaBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(2, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(628, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // BU
            // 
            this.BU.DataPropertyName = "BU";
            this.BU.HeaderText = "BU";
            this.BU.Name = "BU";
            this.BU.ReadOnly = true;
            this.BU.Width = 50;
            // 
            // areaNameDataGridViewTextBoxColumn
            // 
            this.areaNameDataGridViewTextBoxColumn.DataPropertyName = "AreaName";
            this.areaNameDataGridViewTextBoxColumn.HeaderText = "區域(Area)";
            this.areaNameDataGridViewTextBoxColumn.Name = "areaNameDataGridViewTextBoxColumn";
            this.areaNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.areaNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "描述(Depict)";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Width = 250;
            // 
            // areaBindingSource
            // 
            this.areaBindingSource.DataSource = typeof(BO.Area);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(2, 156);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(502, 365);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txt_Job);
            this.tabPage1.Controls.Add(this.txt_Dept);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txt_Username);
            this.tabPage1.Controls.Add(this.txt_EmpNo);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.dataGridView2);
            this.tabPage1.Controls.Add(this.textBox4);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(494, 339);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "區域內保人員(Area Guard)";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txt_Job
            // 
            this.txt_Job.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Sys_UserBindingSource, "Job", true));
            this.txt_Job.Location = new System.Drawing.Point(283, 39);
            this.txt_Job.Name = "txt_Job";
            this.txt_Job.ReadOnly = true;
            this.txt_Job.Size = new System.Drawing.Size(79, 22);
            this.txt_Job.TabIndex = 28;
            // 
            // Sys_UserBindingSource
            // 
            this.Sys_UserBindingSource.DataSource = typeof(BO.Sys_User);
            // 
            // txt_Dept
            // 
            this.txt_Dept.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Sys_UserBindingSource, "Dept", true));
            this.txt_Dept.Location = new System.Drawing.Point(99, 39);
            this.txt_Dept.Name = "txt_Dept";
            this.txt_Dept.ReadOnly = true;
            this.txt_Dept.Size = new System.Drawing.Size(86, 22);
            this.txt_Dept.TabIndex = 27;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.Sys_UserBindingSource, "enable", true));
            this.checkBox1.Location = new System.Drawing.Point(110, 102);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 26;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "有效(Effective)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "部門(Depart)";
            // 
            // txt_Username
            // 
            this.txt_Username.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Sys_UserBindingSource, "UserName", true));
            this.txt_Username.Location = new System.Drawing.Point(283, 11);
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.ReadOnly = true;
            this.txt_Username.Size = new System.Drawing.Size(79, 22);
            this.txt_Username.TabIndex = 20;
            // 
            // txt_EmpNo
            // 
            this.txt_EmpNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.Sys_UserBindingSource, "WorkNo", true));
            this.txt_EmpNo.Location = new System.Drawing.Point(99, 10);
            this.txt_EmpNo.Name = "txt_EmpNo";
            this.txt_EmpNo.Size = new System.Drawing.Size(86, 22);
            this.txt_EmpNo.TabIndex = 21;
            this.txt_EmpNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_EmpNo_KeyUp);
            this.txt_EmpNo.Leave += new System.EventHandler(this.txt_EmpNo_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(206, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "職位(Job)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(205, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "姓名(Name)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "工號(Emp_No)";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewCheckBoxColumn1});
            this.dataGridView2.DataSource = this.Sys_UserBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(0, 124);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(491, 209);
            this.dataGridView2.TabIndex = 14;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "WorkNo";
            this.dataGridViewTextBoxColumn2.HeaderText = "工號(Emp_No)";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "UserName";
            this.dataGridViewTextBoxColumn3.HeaderText = "姓名(Name)";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Dept";
            this.dataGridViewTextBoxColumn4.HeaderText = "部門(Dept)";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Job";
            this.dataGridViewTextBoxColumn5.HeaderText = "職位(Job)";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "enable";
            this.dataGridViewCheckBoxColumn1.HeaderText = "有效(Effective)";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Width = 80;
            // 
            // textBox4
            // 
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.AreaUserBindingSource, "PassWord", true));
            this.textBox4.Location = new System.Drawing.Point(168, 68);
            this.textBox4.Name = "textBox4";
            this.textBox4.PasswordChar = '*';
            this.textBox4.Size = new System.Drawing.Size(194, 22);
            this.textBox4.TabIndex = 13;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // AreaUserBindingSource
            // 
            this.AreaUserBindingSource.DataSource = typeof(BO.AreaUsers);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "維護密碼(Maintain password):";
            // 
            // c_close
            // 
            this.c_close.Location = new System.Drawing.Point(514, 362);
            this.c_close.Name = "c_close";
            this.c_close.Size = new System.Drawing.Size(105, 23);
            this.c_close.TabIndex = 15;
            this.c_close.Text = "關閉(Close):";
            this.c_close.UseVisualStyleBackColor = true;
            this.c_close.Click += new System.EventHandler(this.c_close_Click);
            // 
            // c_save
            // 
            this.c_save.Location = new System.Drawing.Point(514, 320);
            this.c_save.Name = "c_save";
            this.c_save.Size = new System.Drawing.Size(105, 23);
            this.c_save.TabIndex = 14;
            this.c_save.Text = "保存(Save):";
            this.c_save.UseVisualStyleBackColor = true;
            this.c_save.Click += new System.EventHandler(this.c_save_Click);
            // 
            // c_new
            // 
            this.c_new.Location = new System.Drawing.Point(514, 273);
            this.c_new.Name = "c_new";
            this.c_new.Size = new System.Drawing.Size(105, 23);
            this.c_new.TabIndex = 13;
            this.c_new.Text = "新增(Add):";
            this.c_new.UseVisualStyleBackColor = true;
            this.c_new.Click += new System.EventHandler(this.c_new_Click);
            // 
            // AreaMaintainFormGuard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 524);
            this.Controls.Add(this.c_close);
            this.Controls.Add(this.c_save);
            this.Controls.Add(this.c_new);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AreaMaintainFormGuard";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "區域訊息維護(Regional message maintenance)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AreaMaintainForm_FormClosing);
            this.Load += new System.EventHandler(this.AreaMaintainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.areaBindingSource)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sys_UserBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AreaUserBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource areaBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button c_close;
        private System.Windows.Forms.Button c_save;
        private System.Windows.Forms.Button c_new;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Username;
        private System.Windows.Forms.TextBox txt_EmpNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn BU;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource Sys_UserBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn workNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deptDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jobDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enableDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource AreaUserBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.TextBox txt_Job;
        private System.Windows.Forms.TextBox txt_Dept;     
       
       
    }
}