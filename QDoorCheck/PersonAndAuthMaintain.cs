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
    public partial class PersonAndAuthMaintain : Form
    {

       // ResourceManager rm = new ResourceManager("QDoorCheck.PersonAndAuthMaintain", Assembly.GetExecutingAssembly());
        public PersonAndAuthMaintain(List<Area> enableAreas)
        {
            InitializeComponent();

            this.Areas = enableAreas;
        }

        private List<Area> _areas;

        public List<Area> Areas
        {
            get 
            {
                return _areas; 
            }
            protected set
            {
                _areas = value;
            }
        }


        private void PersonAndAuthMaintain_Load(object sender, EventArgs e)
        {
            SortableBindingList<Person> allPersons = new SortableBindingList<Person>();
            
            //介面加載時不加載所有人員的資料，只留待查找使用

            //List<Person> persons = Person.GetAllPersons();
            //foreach (Person item in persons)
            //{
            //    allPersons.Add(item);
            //}

            this.personBindingSource.DataSource = allPersons;
            //this.c_lst_areas.Items.AddRange(Areas.ToArray());
            this.c_lst_jobs.Items.AddRange(Person.GetExistsJobs().ToArray());
            this.c_lst_depart.Items.AddRange(Person.GetExistsDeparts().ToArray());
            //this.editCol.Items.AddRange(Area.GetAllAreas().ToArray());
        }

        private void personBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Person curPerson = this.personBindingSource.Current as Person;
            //this.authorityBindingSource.DataSource=(null==curPerson?new List<Authority>():curPerson.Authorities);
            RefreshAuthorityBind();
        }

        private void dataGridView2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            return;
            
            //if (e.ColumnIndex!=this.AreaName.Index)
            //{
            //    this.c_lst_areas.Visible = false;
            //    return;
            //}

            //Authority curAuth = this.authorityBindingSource.Current as Authority;
            //if (null==curAuth)
            //{
            //    return;
            //}

            //if (curAuth.ThisArea!=null)
            //{
            //    for (int i = 0; i < this.c_lst_areas.Items.Count; i++)
            //    {
            //        if ((c_lst_areas.Items[i] as Area).Equals(curAuth.ThisArea))
            //        {
            //            c_lst_areas.SelectedIndex = i;
            //            break;
            //        }
            //    }
            //}

            //refreshComboPosition();
            ////this.c_lst_areas.Height = this.dataGridView2.CurrentCell.Size.Height;
            ////this.c_lst_areas.Width = this.dataGridView2.CurrentCell.Size.Width;
            ////this.c_lst_areas.Location = this.dataGridView2.CurrentCell.ContentBounds.Location;

            //this.c_lst_areas.Visible = true;
        }

        private void dataGridView2_Scroll(object sender, ScrollEventArgs e)
        {
            //refreshComboPosition();
        }

        #region Garbage
        
        //void refreshComboPosition()
        //{
        //    DataGridViewCell currentCell = dataGridView2.CurrentCell;
        //    if (currentCell==null)
        //    {
        //        return;
        //    }
        //    c_lst_areas.Top = dataGridView2.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, true).Top + dataGridView2.Top;
        //    c_lst_areas.Left = dataGridView2.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, true).Left + dataGridView2.Left;
        //    c_lst_areas.Width = dataGridView2.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, true).Width;
        //    c_lst_areas.Height = dataGridView2.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, false).Height;

        //    //c_lst_areas.ItemHeight = dataGridView2.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, false).Height;
        //}

        //private void c_lst_areas_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (!this.c_lst_areas.Visible)
        //    {
        //        return;
        //    }

        //    Area selectedArea = c_lst_areas.SelectedItem as Area;

        //    Authority curAuth = this.authorityBindingSource.Current as Authority;
        //    if (null == curAuth)
        //    {
        //        return;
        //    }

        //    if (selectedArea!=null)
        //    {
        //        bool existsInList = false;
        //        for (int i = 0; i < this.authorityBindingSource.CurrencyManager.Count; i++)
        //        {
        //            Area aArea = (this.authorityBindingSource[i] as Authority).ThisArea;
        //            if (selectedArea.Equals(aArea))
        //            {
        //                existsInList = true;
        //                break;
        //            }
        //        }

        //        if (existsInList || ( curAuth.ThisPerson!=null && Authority.ExistsAuthority(selectedArea,curAuth.ThisPerson)))
        //        {
        //            MessageBox.Show("此區域的設置已經存在，不可以再選擇此區域!","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        //            return;
        //        }
        //        curAuth.ThisArea = selectedArea;
        //    }
        //}


        #endregion

        private void c_close_Click(object sender, EventArgs e)
        {
            //使用資源文件  中文轉英文  ‘確定關閉？’
            if (MessageBox.Show("確定關閉？\r\n(Determine the closure?)", "人員/權限維護", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                return;
            }
            this.Close();
        }

        private void c_new_Click(object sender, EventArgs e)
        {
            Person newPerson= this.personBindingSource.AddNew() as Person;
            newPerson.CardNo = string.Empty;
            newPerson.AddTime = DateTime.Now;
        }

        private void dataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            //this.c_lst_areas.Visible = false;
        }

        private void authorityBindingSource_DataSourceChanged(object sender, EventArgs e)
        {
            //RefreshAuthorityBind();
        }

        List<Authority> enableViewAuths = new List<Authority>();

        private void RefreshAuthorityBind()
        {
            //此處應處理若不是管理員身份登入，則只允許修改當前區域的人員

            Person curPerson = this.personBindingSource.Current as Person;
            if (null == curPerson)
            {
                return;
            }

            enableViewAuths.Clear();

            IList<Authority> existsAuths = curPerson.Authorities;

            //加入已存在的權限項中有當前區域的項目
            foreach (Authority item in existsAuths)
            {
                if (this.Areas.Contains(item.ThisArea))
                {
                    enableViewAuths.Add(item);
                }
            }


            //加入當前允許的區域中還未有權限項目的
            foreach (Area area in this.Areas)
            {
                bool exists = false;
                foreach (Authority item in existsAuths)
                {
                    if (item.ThisArea.Equals(area))
                    {
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                {
                    Authority auth = new Authority();
                    auth.ThisPerson = curPerson;
                    auth.ThisArea = area;

                    enableViewAuths.Add(auth);
                    curPerson.Authorities.Add(auth);
                }
            }

            //this.authorityBindingSource.Add(auth);
            this.authorityBindingSource.DataSource = enableViewAuths;
            this.authorityBindingSource.ResetBindings(false);
        }

        private void c_save_Click(object sender, EventArgs e)
        {
            Person curPerson = this.personBindingSource.Current as Person;
            if (curPerson==null)
            {
                //使用資源文件 中英文轉換 ‘請選定人員後再保存!’
                MessageBox.Show("請選定人員後再保存!\r\n(Please select the personnel and then save!)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (null==curPerson.CardNo || string.Empty==curPerson.CardNo.Trim())
            {
                //使用資源文件 中英文轉換 ‘請輸入卡號！’
                MessageBox.Show("請輸入卡號！\r\n(Please enter cardno!)", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //if ( true == curPerson.IsInner && string.Empty == curPerson.WorkNo.Trim())
            //{
            //    //使用資源文件 中英文轉換 ‘請輸入卡號！’
            //    MessageBox.Show("內部人員工號不能為空！\r\n(If inner person,Please enter workno!)", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            try
            {
                curPerson.CardNo = curPerson.CardNo.ToUpper();
                if (curPerson.IsNew && Person.IsCardExists(curPerson.CardNo))
                {
                    //使用資源文件 中英文轉換 ‘此卡號已經存在，不能新增！’
                    MessageBox.Show("此卡號已經存在，不能新增！\r\n(This cardno already exists, can not add!)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                Person.SavePerson(curPerson);
                //使用資源文件 中英文轉換 ‘保存成功！’
                MessageBox.Show("保存成功！\r\n(Save success!)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception er)
            {
                string msg = er.Message;
                if (er.InnerException!=null)
                {
                    msg += "\r\n" + er.InnerException.Message;
                }
                //使用資源文件 中英文轉換  ‘保存失敗!’
                MessageBox.Show("保存失敗!\r\n(Save failure!)"+ msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

        private void c_menu_loadImg_Click(object sender, EventArgs e)
        {
            Person curPerson = this.personBindingSource.Current as Person;
            if (curPerson==null)
            {
                //使用資源文件 中英文轉換 '請選定人員！'
                MessageBox.Show("請選定人員！\r\n(Pease select a person!)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.c_dlg_img.ShowDialog()!=DialogResult.OK)
            {
                return;
            }

            string imgFile = this.c_dlg_img.FileName;
            try
            {
                curPerson.Photo = Image.FromFile(imgFile);
            }
            catch (Exception er)
            {
                MessageBox.Show("ERROR:" + er.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.personBindingSource.ResetCurrentItem();
        }

        private void PersonAndAuthMaintain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //BO.DBAccess.SessionFactory.Reset();
            //GC.Collect();
        }

        private void c_search_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                SearchAndShowPersons(this.c_keyValue.Text.Trim());
            }            
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(this.c_keyValue.Text.Trim()))
            {
                //使用資源文件 中英文轉換 '請輸入工號或姓名！'
                MessageBox.Show("請輸入工號或姓名！\r\n(Please enter name or emp_no!)", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void SearchAndShowPersons(string keyValue)
        {
            SortableBindingList<Person> allPersons = new SortableBindingList<Person>();

            List<Person> persons = new List<Person>(Person.GetPersons(keyValue));

            if (persons.Count == 0)
            {
                //使用資源文件 中英文轉換 '找不到符合條件的人員資料！'
                MessageBox.Show("找不到符合條件的人員資料！\r\n(Search not person information)", "查找結果", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            foreach (Person item in persons)
            {
                allPersons.Add(item);
            }

            this.personBindingSource.DataSource = allPersons;
        }



        private void c_keyValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode!=Keys.Enter)
            {
                return;
            }

            if (CheckInput())
            {
                SearchAndShowPersons(this.c_keyValue.Text.Trim());
            }     
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void checkbox()
        {
            this.textBox3.Text = "";
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.c_lst_depart.Text = "";
            this.c_lst_jobs.Text = "";
            this.checkBox2.Checked = false;

            if (checkBox1.Checked)
            {

                //內部人員    
                this.textBox3.ReadOnly = false;
                this.textBox1.ReadOnly = false;
                this.textBox2.ReadOnly = false;
                this.c_lst_depart.Enabled = true;
                this.c_lst_jobs.Enabled = true;
                this.checkBox2.Enabled = true;

            }
            else
            {
                //外部人員
                this.textBox3.ReadOnly = true;
                this.textBox1.ReadOnly = false;
                this.textBox2.ReadOnly = false;
                this.c_lst_depart.Enabled = true;
                this.c_lst_jobs.Enabled = true;
                this.checkBox2.Enabled = true;

            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {

            if (textBox3.Text == string.Empty)
            {
                return;
            }
            else
            {
                HR_Employee HREmployee = HR_Employee.GetAllByEmpNO(this.textBox3.Text);
                if (HREmployee == null)
                {
                    //使用資源文件切換中英文  ‘請選擇當前區域？’
                    MessageBox.Show("工號:" + this.textBox3.Text + "查找無此人,請輸入正確的工號!\r\n(Please Input Correct EmpNo !)", "區域維護", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 
                    return;

                }
                else
                {

                    ////判斷此用戶是否存在 

                    //SortableBindingList<Person> Personlist = this.personBindingSource.DataSource as SortableBindingList<Person>;
                    //if (Personlist.Count > 1)
                    //{

                    //    foreach (Person person in Personlist)
                    //    {
                    //        if (person.WorkNo == null)
                    //        {
                    //            //新增的空
                    //            break;

                    //        }
                    //        else if (person.CardNo.Trim().ToUpper() == this.textBox1.Text.Trim().ToUpper())
                    //        {
                    //            MessageBox.Show("卡號:" + this.textBox1.Text + "已經存在,請重新輸入正確的卡號!\r\n(Please Input Correct EmpNo !)", "區域維護", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //            this.textBox1.Text = "";
                    //            return;
                    //        }

                    //    }
                    //}
                    

                    Person curPerson = this.personBindingSource.Current as Person;

                    if (curPerson == null)
                    {
                        MessageBox.Show("請先點擊新增按鈕!\r\n(Please click Add Buttom !)", "區域維護", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.textBox3.Text = "";
                        return;

                    }
                    else
                    {
                        //this.textBox1.Text = HREmployee.Emp_ID;
                        this.textBox2.Text = HREmployee.Emp_Name;
                        this.c_lst_depart.Text = HREmployee.Dept;
                        this.c_lst_jobs.Text = HREmployee.Job;

                        curPerson.PersonName = HREmployee.Emp_Name;
                        curPerson.Depart = HREmployee.Dept;
                        curPerson.Job = HREmployee.Job;
                        //curPerson.CardNo = HREmployee.Emp_ID;
                        curPerson.WorkNo = HREmployee.Emp_No;

                        this.checkBox2.Focus();

                    }
                  
                    
                }


            }     


        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && textBox3.Text != "")
            {
                textBox3_Leave(sender, e);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

      
    }
}