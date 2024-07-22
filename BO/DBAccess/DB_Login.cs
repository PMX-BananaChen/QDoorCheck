using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace BO.DBAccess
{
    public class DB_Login
    {
        protected readonly Database db = DatabaseFactory.CreateDatabase();

        public bool Login(string userAccount, string password)
        {
            string sql = "Select count(1) from dbo.LoginAccount where UserAccount=@ac and UserPassword=@pwd and State='1'";

            DbCommand cmd = db.GetSqlStringCommand(sql);
            db.AddInParameter(cmd, "@ac", DbType.String, userAccount);
            db.AddInParameter(cmd, "@pwd", DbType.String, password);

            return (int)db.ExecuteScalar(cmd) > 0;
        }
    }
}
