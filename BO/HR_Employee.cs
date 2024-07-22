using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public class HR_Employee
    {
        private string _emp_No;

        public virtual string Emp_No
        {
            get { return _emp_No; }
            set { _emp_No = value; }
        }

        private string _empName;

        public virtual string Emp_Name
        {
            get { return _empName; }
            set { _empName = value; }
        }

        private string _empID;

        public virtual string Emp_ID
        {
            get { return _empID; }
            set { _empID = value; }
        }

        private string _dept;

        public virtual string Dept
        {
            get { return _dept; }
            set { _dept = value; }
        }

        private string _job;

        public virtual string Job
        {
            get { return _job; }
            set { _job = value; }
        }


        public static HR_Employee GetAllByEmpNO(String UserName)
        {
            return DBAccess.DB_Area.GetAllByEmpNO(UserName);

        }

    }
     
}
