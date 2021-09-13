using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using AdvisingSystemLibrary;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for ChatService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class ChatService : System.Web.Services.WebService
{
    SysAdminModel objAdm = new SysAdminModel();
    public static string ChatType = string.Empty;

    public ChatService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    public void KeepRecordwithBot(string ClientMessage, string botMessage)
    {
        string r = string.Empty;

        try
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                objAdm.con .Open();
                cmd.CommandText = "insert into tbl_message_log (client_message, bot_message, client_id) values(@ClientMessage, @BotMessage, @uid)";
                cmd.Parameters.AddWithValue("@ClientMessage", ClientMessage);
                cmd.Parameters.AddWithValue("@BotMessage", botMessage);
                cmd.Parameters.AddWithValue("@uid", HttpContext.Current.Session["RecID"].ToString());
                cmd.Connection = objAdm .con ;
                cmd.ExecuteNonQuery();
                objAdm .con.Close();
            }

        }
        catch (SqlException exx)
        {
            string ab = string.Empty;

            r = "There is a problem cancelling your order. ";




        }
        catch (Exception ex)
        {

        }
        finally
        {
            if (objAdm.con .State == ConnectionState.Open)
                objAdm.con .Close();

        }


    }
    [WebMethod(EnableSession =true )]
    public string IntelligentBotChat(string text)
    {
        string sText = text.ToLower().ToString();
        string Number = new string(sText.Where(char.IsDigit).ToArray());
        ChatType = text.ToLower().ToString();
       
            if( ChatType.Contains("score"))
            {
                if (objAdm.GetPerformance(sText, HttpContext.Current.Session["RecID"].ToString()) == true)
                {
                    KeepRecordwithBot(sText, objAdm.Message);
                    return objAdm .Message;
                 }
                
                return objAdm.ErrorMessage;
            }
        if (ChatType.Contains("performance"))
        {
            if (objAdm.GetPerformanceEvaluation(sText, HttpContext.Current.Session["RecID"].ToString()) == true)
            {
                KeepRecordwithBot(sText, objAdm.Message);
                return objAdm.Message;
            }

            return objAdm.ErrorMessage;
        }
        if (objAdm.GetMessage(sText ) == true)
        {
            KeepRecordwithBot(sText, objAdm.Message);
            return objAdm.Message;
        }
        return objAdm.ErrorMessage;
        }
        
           
       
    



   
   

}
