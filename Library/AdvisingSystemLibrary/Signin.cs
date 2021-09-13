using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Foundation;
using System.Data;
using System.Data.SqlClient;

namespace AdvisingSystemLibrary
{
    public partial class SysAdminModel:_Database
    {
        public string UserPassword = string.Empty;
        public string RecID = string.Empty;
        public string FirstName = string.Empty;
        public string sUsername = string.Empty;
        public bool GetStudentProfile(string username, string sPassword)
        {
            try
            {
                string sPasswordDB = string.Empty;
                DataSet ds = new DataSet();
                string sSQL = "select * from tbl_student where username=@UserName ";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.Parameters.AddWithValue("@UserName", username);
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "Invalid User. Contact Administrator.";
                    return false;
                }
                sPasswordDB = ds.Tables[0].Rows[0]["user_password"].ToString();
                if (sPasswordDB.Trim() == string.Empty)
                {
                    ErrorMessage = "Password Not found in the database.";
                }
                else
                {

                    if (sPassword != sPasswordDB)
                    {
                        ErrorMessage = "Invalid password.";
                        return false;
                    }
                }
                UserPassword = sPasswordDB;
                RecID = ds.Tables[0].Rows[0]["rec_id"].ToString();
                FirstName = ds.Tables[0].Rows[0]["firstname"].ToString();
                sUsername = ds.Tables[0].Rows[0]["username"].ToString();

                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = "No Login Connection.";
                return false;
            }
        }

    }
}
