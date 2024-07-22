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
using System.Net;
using System.Xml;
using System.Management;

namespace QDoorCheck
{
    public partial class SelectAreaForm : Form
    {
        public static Area selectarea;
        ResourceManager rm = new ResourceManager("QDoorCheck.SelectAreaForm", Assembly.GetExecutingAssembly());
        
        #region properties

        private List<Area> _allAreas;
        

        protected List<Area> AllAreas
        {
            get { return _allAreas; }
            set { _allAreas = value; }
        }

        public Area SelectedArea
        {
            get
            {
                if (0==this.c_AreaList.SelectedItems.Count)
                {
                    return null;
                }
                return this.c_AreaList.SelectedItems[0].Tag as Area;
            }
        }
        
        #endregion


        public SelectAreaForm()
        {
            InitializeComponent();
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            AddAllAreas();
        }

        private void AddAllAreas()
        {
            this.c_AreaList.Groups.Clear();
            this.c_AreaList.Items.Clear();
            AllAreas = Area.GetAllAreas();
            
            ColumnHeader columnHeader0 = new ColumnHeader();
            columnHeader0.Text = "";
            columnHeader0.Width = 200;            

            if (this.c_AreaList.Columns.Count < 3)
            {
                this.c_AreaList.Columns.AddRange(new ColumnHeader[] { columnHeader0 });
            }


            //加入组:
            List<String> AllBUs=Area.GetAllBUs();         

            foreach (string item in AllBUs)
            {
                ListViewGroup group = new ListViewGroup(item);
                this.c_AreaList.Groups.Add(group);
               
                foreach (Area Aitem in AllAreas)
                {
                    if (item == Aitem.BU)
                    {
                        ListViewItem items = new ListViewItem(new string[] { Aitem.AreaName }, 0, group);
                        this.c_AreaList.Items.Add(items);
                        this.c_AreaList.Tag = Aitem;
                        items.Tag = Aitem;
                    }                  
                }
            }  
        }

        private void c_OK_Click(object sender, EventArgs e)
        {
            if (null==this.SelectedArea)
            {
                //請選擇一個目前區域!
                MessageBox.Show("請選擇一個目前區域!\r\n(Please choose a current region!)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            bool ischeckIP = Properties.Settings.Default.IsCheckIPComputerName;

            if (ischeckIP)
            {

                //判斷連接的電腦名稱,IP是否OK!

                string hostname = System.Net.Dns.GetHostName(); //主机
                System.Net.IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(hostname);//网卡IP地址集合






                string mac = "";
                ManagementClass mc;

                mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if (mo["IPEnabled"].ToString() == "True")
                    {
                        mac = mo["MacAddress"].ToString().Replace(@":", @"-");
                    }
                }


                if (string.IsNullOrEmpty(mac))
                {
                    MessageBox.Show("電腦無法抓取到MAC地址!\r\n(The computer can't grab the MAC address !)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }




                //多個IP地址,只要有一個存在即可

                IPAddress[] IPS = ipEntry.AddressList;

                bool isReturn = false;





                //foreach (IPAddress IP in IPS)
                //{
                if (CheckUserIP(mac.ToString(), hostname, this.SelectedArea))
                    {
                        isReturn = true;

                    }
                //}

                if (!isReturn)
                {

                    MessageBox.Show("當前電腦沒有訪問此專案區域的權限!\r\n(This Computer has no access to this Area !)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }


              

            }


            bool ischeckVision = Properties.Settings.Default.IsCheckVision;

            if (ischeckVision)
            {

                //获取版本配置信息
                //检查版本是否正确,不正确给出提醒
                //1、创建XmlDocument对象
                XmlDocument xmlDoc = new XmlDocument();
                //2、加载源文件
                xmlDoc.Load("./Vision.xml");
                //3、获取根结点
                XmlElement xmlRoot = xmlDoc.DocumentElement;
                //4、获取根结点下的子节点

                bool isOK = false;

                foreach (XmlNode node in xmlRoot.ChildNodes)
                {
                    if (this.SelectedArea.Vision.ToUpper()=="V1.0")
                    {
                        //新增加我区域版本都为V1.0  不用检查版本
                        isOK = true;
                    }

                    if (this.SelectedArea.Sid.ToString().ToUpper() == node["Areaid"].InnerText.ToUpper() && this.SelectedArea.Vision.ToUpper() == node["Vision"].InnerText.ToUpper())
                    {
                        isOK = true;
                    }

                }

                if (!isOK)
                {

                    MessageBox.Show("您正在使用的程序版本不对,请升级为最新版本的程序!\r\n(Please Upgrade The Program !)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }              

            }
            selectarea = this.SelectedArea;
            CheckPasswordForm checkPW = new CheckPasswordForm(this.SelectedArea);
            this.Hide();
            checkPW.ShowDialog();
        
            
        }

        private void c_AreaList_DoubleClick(object sender, EventArgs e)
        {
            c_OK_Click(sender, e);
        }

        //区域维掮
        private void c_area_maintain_Click(object sender, EventArgs e)
        {
            CheckPasswordForm checkPW = new CheckPasswordForm(this.SelectedArea);
            checkPW.ShowDialog();             
            
        }
        private bool CheckAdminPassword()
        {
            AppUser admin = AppUser.GetAdminUser();
            return CheckPassword.CheckUserPassword(admin.Password, "請輸入超級管理員密碼：\r\n(Please enter administrator password:)", 3);
            
        }

        private void SelectAreaForm_Load(object sender, EventArgs e)
        {

        }

        private void c_Cancel_Click(object sender, EventArgs e)
        {



        }

        public static bool CheckUserIP(string targetIP, string targetComputerName, Area area)
        {
            AreaConfiguration AF = AreaConfiguration.GetAllIPByArea(area.Sid.ToString(), targetIP, targetComputerName);

            if (AF==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}