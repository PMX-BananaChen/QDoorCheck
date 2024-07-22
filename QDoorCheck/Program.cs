using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BO;
using System.Resources;
using System.Reflection;

namespace QDoorCheck
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                AppUser generalUser = AppUser.GetGeneralUser();

                if (!CheckPassword.CheckUserPassword(generalUser.Password, "請輸入啟動密碼：\r\nPlease enter start password", 3))
                {
                    return;
                }

                SelectAreaForm selectArea = new SelectAreaForm();

                if (selectArea.ShowDialog()!=DialogResult.OK)
                {
                    return;
                }

                Application.Run(new QDoorCheckForm(selectArea.SelectedArea,null));
            }
            catch (Exception er)
            {
                MessageBox.Show("ERROR:" + er.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

     

        }
    }
}