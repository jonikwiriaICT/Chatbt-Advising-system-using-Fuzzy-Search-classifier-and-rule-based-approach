using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdvisingSystemLibrary;

public partial class VeritasMaster : System.Web.UI.MasterPage
{
    SysAdminModel objAdm = new SysAdminModel();
    public string ChatWelcome = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if(!this.IsPostBack)
            {
                if (Session["audit_username"] == null)
                {
                    Response.Redirect("index");
                }
                else
                {
                    ChatWelcome = "You are welcome" + " " + FirstName.ToString () + " " + " with matric number " + " " + UserName .ToString () + " " + " to the advising bot. Here i can automatically register your courses, check your course results, evaluate your performance and advise you on how you can study";
                }
            }
        }
        catch(Exception ex)
        {

        }
    }
    protected void LogOut(object sender, EventArgs e)
    {
        try
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("index");
        }
        catch(Exception ex)
        {

        }
    }
    protected void Page_UnLoad(object sender, EventArgs e)
    {
        try
        {
            objAdm.CloseConnection();
        }
        catch(Exception ex)
        {

        }
    }
    protected void Page_Init(object sender, EventArgs e)
    {
    }
    public string RecID
    {
        get
        {
            try
            {
                string sValue = string.Empty;

                if (string.IsNullOrEmpty(sValue) == true)
                {
                    sValue = Session["RecID"].ToString();
                }
                return sValue;
            }
            catch (Exception ex)
            {
                try
                {
                    return Session["RecID"].ToString();
                }
                catch (Exception ex2) { }
                return string.Empty;
            }
        }
    }
    public string UserName
    {
        get
        {
            try
            {
                string sValue = string.Empty;

                if (string.IsNullOrEmpty(sValue) == true)
                {
                    sValue = Session["audit_username"].ToString();
                }
                return sValue;
            }
            catch (Exception ex)
            {
                try
                {
                    return Session["audit_username"].ToString();
                }
                catch (Exception ex2) { }
                return string.Empty;
            }
        }
    }
    public string FirstName
    {
        get
        {
            try
            {
                string sValue = string.Empty;

                if (string.IsNullOrEmpty(sValue) == true)
                {
                    sValue = Session["firstname"].ToString();
                }
                return sValue;
            }
            catch (Exception ex)
            {
                try
                {
                    return Session["firstname"].ToString();
                }
                catch (Exception ex2) { }
                return string.Empty;
            }
        }
    }
}
