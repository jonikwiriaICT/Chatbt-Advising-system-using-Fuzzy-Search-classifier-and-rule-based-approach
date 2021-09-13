using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Foundation;
using System.Data;
using System.Data.SqlClient;

using System.Web;


namespace AdvisingSystemLibrary
{
    public partial class SysAdminModel : _Database
    {
      


    }
    public class PerformanceClass
    {
        public string StudentID { get; set; }
        public string MatricNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductProfile { get; set; }
        public string SellingPrice { get; set; }


    }
}
