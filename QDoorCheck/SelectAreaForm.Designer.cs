namespace QDoorCheck
{
    partial class SelectAreaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectAreaForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.c_AreaList = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.c_OK = new System.Windows.Forms.Button();
            this.c_Cancel = new System.Windows.Forms.Button();
            this.c_area_maintain = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.c_AreaList);
            this.groupBox1.Location = new System.Drawing.Point(3, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 352);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // c_AreaList
            // 
            this.c_AreaList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.c_AreaList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.c_AreaList.LabelWrap = false;
            this.c_AreaList.LargeImageList = this.imageList1;
            this.c_AreaList.Location = new System.Drawing.Point(9, 5);
            this.c_AreaList.MultiSelect = false;
            this.c_AreaList.Name = "c_AreaList";
            this.c_AreaList.Size = new System.Drawing.Size(372, 341);
            this.c_AreaList.SmallImageList = this.imageList1;
            this.c_AreaList.TabIndex = 0;
            this.c_AreaList.TileSize = new System.Drawing.Size(100, 50);
            this.c_AreaList.UseCompatibleStateImageBehavior = false;
            this.c_AreaList.View = System.Windows.Forms.View.Details;
            this.c_AreaList.DoubleClick += new System.EventHandler(this.c_AreaList_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "pda.ico");
            // 
            // c_OK
            // 
            this.c_OK.Location = new System.Drawing.Point(21, 373);
            this.c_OK.Name = "c_OK";
            this.c_OK.Size = new System.Drawing.Size(99, 23);
            this.c_OK.TabIndex = 1;
            this.c_OK.Text = "確定(OK)";
            this.c_OK.UseVisualStyleBackColor = true;
            this.c_OK.Click += new System.EventHandler(this.c_OK_Click);
            // 
            // c_Cancel
            // 
            this.c_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.c_Cancel.Location = new System.Drawing.Point(126, 373);
            this.c_Cancel.Name = "c_Cancel";
            this.c_Cancel.Size = new System.Drawing.Size(91, 23);
            this.c_Cancel.TabIndex = 2;
            this.c_Cancel.Text = "取消(Cancel)";
            this.c_Cancel.UseVisualStyleBackColor = true;
            this.c_Cancel.Click += new System.EventHandler(this.c_Cancel_Click);
            // 
            // c_area_maintain
            // 
            this.c_area_maintain.Location = new System.Drawing.Point(223, 373);
            this.c_area_maintain.Name = "c_area_maintain";
            this.c_area_maintain.Size = new System.Drawing.Size(153, 23);
            this.c_area_maintain.TabIndex = 3;
            this.c_area_maintain.Text = "維護區域(Maintenance area)";
            this.c_area_maintain.UseVisualStyleBackColor = true;
            this.c_area_maintain.Click += new System.EventHandler(this.c_area_maintain_Click);
            // 
            // SelectAreaForm
            // 
            this.AcceptButton = this.c_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.c_Cancel;
            this.ClientSize = new System.Drawing.Size(407, 423);
            this.Controls.Add(this.c_area_maintain);
            this.Controls.Add(this.c_Cancel);
            this.Controls.Add(this.c_OK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectAreaForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "選擇目前區域(Select current region)";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SelectAreaForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button c_OK;
        private System.Windows.Forms.Button c_Cancel;
        private System.Windows.Forms.ListView c_AreaList;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button c_area_maintain;
    }
}