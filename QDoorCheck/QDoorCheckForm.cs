using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BO;
using QDoorCheck.BI;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Security.Principal;
using System.Security.Permissions;
using System.Resources;
using System.Reflection;

namespace QDoorCheck
{
    public partial class QDoorCheckForm : Form
    {

        //ResourceManager rm = new ResourceManager("QDoorCheck.QDoorCheckForm", Assembly.GetExecutingAssembly());

        #region Properties

        DateTime DTStart = DateTime.Now;
        DateTime DTEnd = DateTime.Now;
        double dDays = 10000;


        private Area _curArea;

        protected Area CurArea
        {
            get { return _curArea; }
            set { _curArea = value; }
        }

        private AreaUsers _curUser;

        protected AreaUsers CurUser
        {
            get { return _curUser; }
            set { _curUser = value; }
        }


        private AreaUsers _curSysUser;
        protected AreaUsers CurSysUser
        {
            get { return _curSysUser; }
            set { _curSysUser = value; }
        }

        private BI.BarcodeScan _barcodeScan;

        protected BI.BarcodeScan thisBarcodeScan
        {
            get
            {
                if (_barcodeScan == null)
                {
                    _barcodeScan = new QDoorCheck.BI.BarcodeScan();
                }
                return _barcodeScan;
            }
        }

        protected string UserName
        {
            get
            { return WindowsIdentity.GetCurrent().Name; }
        }

        protected string statusMsg
        {
            get { return this.c_status_state.Text; }
            set { this.c_status_state.Text = value; this.statusStrip1.Refresh(); }
        }

        #endregion


        public QDoorCheckForm(BO.Area curArea,AreaUsers CurUser)
        {
            
            if (null == curArea)
            {
                //当前区域不能设置为NULL
                throw new ArgumentException("Current area can not set to NULL !", "CurArea");
            }
            else
            {
                this.CurArea = curArea;
                this.CurUser = CurUser;
                InitializeComponent();

            }         
          

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text += "--" + this.CurArea.AreaName + "--"+this.CurArea.Vision ;
            this.c_status_msg.Text = WindowsIdentity.GetCurrent().Name;
            ProcessPerson(Person.GetEmptyPerson(),string.Empty, false);

            string RoleId = this._curUser.RoleId;

            switch(RoleId)
            {

                case "1" : //內保人員
                this.c_menu_area.Visible = false;
                this.c_menu_person_auth.Visible = false;
                this.c_menu_area_guard.Visible = false;
                break;

                case "2":　//區域管理員
                this.c_menu_area.Visible = false;                
                break;

                case "3":　//超級管理員              
              
                break;

            }

   
       
        }

        private static SearchResultCollection _ADHelper(string domainADsPath, string username, string password, string schemaClassNameToSearch)
        {
            DirectorySearcher searcher = new DirectorySearcher();

            searcher.SearchRoot = new DirectoryEntry(domainADsPath,
                                                        username, password);
            searcher.Filter = "(objectClass=" + schemaClassNameToSearch + ")";

            searcher.SearchScope = SearchScope.Subtree;
            searcher.Sort = new SortOption("name",
                                                SortDirection.Ascending);
            // If there is a large set to be return ser page size for a paged search

            searcher.PageSize = 512;

            searcher.PropertiesToLoad.AddRange(new string[] { "name", "Path", "displayname", "samaccountname", "mail" });

            SearchResultCollection results = searcher.FindAll();
            return results;
        }

        //private void StartScan()
        //{
        //    this.thisBarcodeScan.BarcodeScanned += new BarcodeScannedHandler(thisBarcodeScan_BarcodeScanned);
        //    this.thisBarcodeScan.Start();   
        //}

        delegate void ProcessAuthHandle(Authority auth,bool allowLog);

        //void ProcessAuth(Authority auth,bool allowLog)
        //{
        //    if (this.IsDisposed)
        //    {
        //        return;
        //    }

        //    if (null==auth)
        //    {
        //        this.c_result.Text = "禁止進入!";
        //    }
        //    if (null == auth || (!auth.EnableEnterIn))
        //    {
        //        this.c_result.Text = "禁止進入!";
        //    }
        //    else
        //    {
        //        this.c_result.Text = "允許進入!";
        //    }

        //    this.c_bind_Authority.DataSource = auth==null?Authority.GetEmptyAuthority():auth;
        //    this.c_bind_Person.DataSource = auth==null?Person.GetEmptyPerson(): auth.ThisPerson;

        //    this.c_result.ForeColor = (null == auth || (!auth.EnableEnterIn)) ? Color.Red : Color.Green;
        //    this.c_pic_result_OK.Visible = (null != auth && auth.EnableEnterIn);
        //    this.c_pic_result_no.Visible = (null == auth || !auth.EnableEnterIn);

        //    //this.pictureBox4.Visible = !this.pictureBox1.Visible;
        //    this.pictureBox5.Visible = !this.pictureBox2.Visible;
        //    this.pictureBox6.Visible = !this.pictureBox3.Visible;

        //    if (allowLog)
        //    {
        //        CheckLog.Log(auth);
        //    }
        //}

        //void thisBarcodeScan_BarcodeScanned(object sender, BarcodeScanEventArgs e)
        //{
        //   if (!this.IsDisposed)
        //    {
        //        string cardNo = e.BarcodeNo;
        //        Authority auth = Authority.GetAuthority(this.CurArea, cardNo,true);

        //        try
        //        {
        //            this.Invoke(new ProcessAuthHandle(ProcessAuth), new object[] { auth,true });
        //        }
        //        catch
        //        {
        //        }

        //        //ProcessAuth(auth);
        //    }
        //}

      
        /// <summary>
        /// 扫描工号显示权限信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c_cardNo_KeyDown(object sender, KeyEventArgs e)
        {

           
         
          
        }

        private void ProcessPerson(Person person,string cardNo, bool allowLog)
        {
            if (this.IsDisposed)
            {
                return;
            }           


            Authority auth = null;
            for (int i = 0;person!=null && i < person.Authorities.Count; i++)
            {
                if (person.Authorities[i].ThisArea.Equals(this.CurArea))
                {
                    auth = person.Authorities[i];
                    break;
                }
            }

            if (null == person)
            {
                // "禁止進入--查無此人!"
                this.c_result.Text = "禁止進入--查無此人\r\nProhibited to enter--No such person";
            }
            else if (auth==null || !auth.EnableEnterIn)
            {
                //禁止進入
                this.c_result.Text = "禁止進入\r\nProhibited to enter";
            }
            else
            {
                //允許進入
                this.c_result.Text = "允許進入\r\nAuthorized to enter"; 

            }

            this.c_bind_Person.DataSource = (person == null ? Person.GetEmptyPerson() : person);
            this.c_bind_Authority.DataSource = auth == null ? Authority.GetEmptyAuthority() : auth;

            this.c_result.ForeColor = (null == auth || (!auth.EnableEnterIn)) ? Color.Red : Color.Green;
            this.c_pic_result_OK.Visible = (null != auth && auth.EnableEnterIn);
            this.c_pic_result_no.Visible = (null == auth || !auth.EnableEnterIn);

            //this.pictureBox4.Visible = !this.pictureBox1.Visible;
            this.pictureBox5.Visible = !this.pictureBox2.Visible;
            this.c_msg_photo.Text = (null != auth && auth.EnablePhoto) ? "允許拍照\r\nAuthorized to take pictures" : "禁止拍照\r\nProhibited to take pictures";
            this.c_msg_photo.ForeColor = (null == auth || (!auth.EnablePhoto)) ? Color.Red : Color.Green;
            

            this.pictureBox6.Visible = !this.pictureBox3.Visible;
            this.c_msg_movematerial.Text = (null != auth && auth.EnableMoveMaterial) ? "允許移動材料\r\nAuthorized to remove material" : "禁止移動材料\r\nProhibited to remove material";
            this.c_msg_movematerial.ForeColor = (null == auth || (!auth.EnableMoveMaterial)) ? Color.Red : Color.Green;


            this.pictureBox1.Visible = !this.pictureBox4.Visible;
            this.c_msg_mobile.Text = (null != auth && auth.EnableMobile) ? "允許攜帶手機（限無攝像頭手機）\r\nAuthorized to take dumb phone" : "禁止攜帶手機\r\nProhibited to take dumb phone";
            this.c_msg_mobile.ForeColor = (null == auth || (!auth.EnableMobile)) ? Color.Red : Color.Green;
           

            this.pictureBox9.Visible = !this.pictureBox8.Visible;
            this.c_msg_laptop.Text = (null != auth && auth.enableLaptop) ? "允許攜帶电脑\r\nAuthorized to take laptop" : "禁止攜帶电脑\r\nProhibited to take laptop";
            this.c_msg_laptop.ForeColor = (null == auth || (!auth.enableLaptop)) ? Color.Red : Color.Green;


            this.pictureBox11.Visible = !this.pictureBox10.Visible;
            this.c_msg_U.Text = (null != auth && auth.enableU) ? "允許攜帶U盘\r\nAuthorized to carry USB drive" : "禁止攜帶U盘\r\nProhibited to carry USB drive";
            this.c_msg_U.ForeColor = (null == auth || (!auth.enableU)) ? Color.Red : Color.Green;






            //if ( auth==null)
            //{
            //    label13.Text = "";
            //}
            //else if (auth.cptNo != null)
            //{
            //    label13.Text = auth.cptNo;
            //}

            

            if (allowLog)
            {
                CheckLog.Log(person,this.CurArea, auth,cardNo,this.UserName);
            }

            


        }


        private void c_menu_area_Click(object sender, EventArgs e)
        {
            List<Area> enableAreas;
            List<AreaUsers> enableSysUser;
            bool isAdmin = false;
            //"以管理員身份維護?  Use administrator Identity Maintenance ?
            if (this.CurUser.RoleId=="3")
            {              
                enableAreas = Area.GetAllAreas();              
                isAdmin = true;
            }
            else
            {
              
                enableAreas = new List<Area>();
                enableAreas.Add(this.CurArea);   
                isAdmin = false;
            }

            AreaMaintainForm areaForm = new AreaMaintainForm(enableAreas,isAdmin);
            areaForm.ShowDialog();

            FormWindowState state = this.WindowState;
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = state;
            GC.Collect();

        }

        private bool CheckAdminPassword()
        {
            AppUser admin = AppUser.GetAdminUser();

            //請輸入管理員密碼
            return CheckPassword.CheckUserPassword(admin.Password, "請輸入管理員密碼：\r\n(Please enter administrator password:)", 3);
        }
       

        private void c_menu_person_auth_Click(object sender, EventArgs e)
        {

            List<Area> enableAreas=null;

            string RoleId = this._curUser.RoleId;

            switch (RoleId)
            {

                case "1": //內保人員                  
                    break;

                case "2":　//區域管理員

                  　enableAreas = new List<Area>();
            　　    enableAreas.Add(this.CurArea);
                    break;
                case "3":　//超級管理員
                    enableAreas = Area.GetAllAreas();
                    break;

            }
           
            PersonAndAuthMaintain personAndAuthForm = new PersonAndAuthMaintain(enableAreas);
            //personAndAuthForm.TopMost = true;
            personAndAuthForm.ShowDialog();
         

            FormWindowState state = this.WindowState;
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = state;
            GC.Collect();
        }

        private void c_menu_exit_Click(object sender, EventArgs e)
        {
            //確定退出？ 
            if (MessageBox.Show("確定退出(Determined to quit)?", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
            {
                return;
            }
            this.Close();
        }        

        private void c_menu_area_guard_Click(object sender, EventArgs e)
        {
            List<Area> enableAreas = null;

            string RoleId = this._curUser.RoleId;

            switch (RoleId)
            {

                case "1": //內保人員                  
                    break;

                case "2":　//區域管理員

                    enableAreas = new List<Area>();
                    enableAreas.Add(this.CurArea);

                    break;

                case "3":　//超級管理員

                    enableAreas = Area.GetAllAreas();

                    break;

            }


            AreaMaintainFormGuard AMF = new AreaMaintainFormGuard(enableAreas,true);

            //AMF.TopMost = true;

            AMF.ShowDialog();          

        }       
        

        private void menu_about_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void c_menu_system_Click(object sender, EventArgs e)
        {

        }

        private void c_msg_laptop_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void c_result_Click(object sender, EventArgs e)
        {

        }

        private void c_msg_movematerial_Click(object sender, EventArgs e)
        {


        }

        private void c_cardNo_TextChanged(object sender, EventArgs e)
        {      


        }

        private void c_cardNo_KeyUp(object sender, KeyEventArgs e)
        {

            if (c_cardNo.Text == "")
            {
                return;
            }

            if (this.CurUser.RoleId != "2")  //區域管理員可以手輸
            {

                label11.Text = "";               

                if (c_cardNo.Text.Length == 1)
                {
                    DTStart = DateTime.Now;
                    return;
                }

                if (c_cardNo.Text.Length == 2)
                {
                    DTEnd = DateTime.Now;
                    TimeSpan ts1 = new TimeSpan(DTStart.Ticks);
                    TimeSpan ts2 = new TimeSpan(DTEnd.Ticks);
                    TimeSpan ts3 = ts1.Subtract(ts2).Duration();
                    dDays = ts3.TotalMilliseconds;
                }

                if (dDays < 50)
                {
                    if (e.KeyData == Keys.Enter)
                    {
                        //this.c_status_msg.Text = "正在檢查，請稍候......";
                        this.statusMsg = "正在檢查，請稍候(Please wait while you are checking)....";

                        string cardNo = this.c_cardNo.Text;
                        label11.Text = this.c_cardNo.Text;

                        Person aPerson = Person.GetPerson(cardNo, true);

                        try
                        {
                            ProcessPerson(aPerson, cardNo, true);
                            this.c_cardNo.SelectAll();
                        }
                        catch (Exception er)
                        {
                            MessageBox.Show(er.Message);
                        }
                        finally
                        {
                            //就緒
                            this.statusMsg = "就緒(Ready)";

                            c_cardNo.Text = "";

                        }

                    }


                }
                else
                {
                    c_cardNo.Text = "";

                }
            }
            else
            {               

                if (e.KeyData == Keys.Enter)
                {
                    //this.c_status_msg.Text = "正在檢查，請稍候......";
                    this.statusMsg = "正在檢查，請稍候(Please wait while you are checking)....";

                    string cardNo = this.c_cardNo.Text;
                    label11.Text = this.c_cardNo.Text;

                    Person aPerson = Person.GetPerson(cardNo, true);

                    try
                    {
                        ProcessPerson(aPerson, cardNo, true);
                        this.c_cardNo.SelectAll();
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                    finally
                    {
                        //就緒
                        this.statusMsg = "就緒(Ready)";

                        c_cardNo.Text = "";

                    }

                }


            }



           

        }

        private void c_menu_password_Click(object sender, EventArgs e)
        {
            RevisePassword revisePwd = new RevisePassword(CurUser);
            revisePwd.ShowDialog();

        }       
       

    }
}

