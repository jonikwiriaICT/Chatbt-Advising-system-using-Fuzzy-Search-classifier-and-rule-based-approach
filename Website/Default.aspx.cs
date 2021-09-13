using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdvisingSystemLibrary;

public partial class _Default : System.Web.UI.Page
{
    SysAdminModel objAdm = new SysAdminModel();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {

            }
        }
        catch (Exception ex)
        {

        }
    }
    public enum MsgType
    {
        Error = 0,
        Success = 1,
        Warning = 2
    }
    public void DisplayMessage(String sMessage, MsgType type)
    {
        try
        {
            if (sMessage.Trim() == "")
            {
                pnlAlert.Visible = false;
            }
            else
            {
                lblMsg.Text = sMessage;
                if (type == MsgType.Success)
                {
                    pnlAlert.CssClass = "alert alert-success alert-dismissible";
                    spIcon.InnerHtml = "<i class='fa fa-check-circle-o'></i>";
                }
                else if (type == MsgType.Warning)
                {
                    pnlAlert.CssClass = "alert alert-warning alert-dismissible";
                    spIcon.InnerHtml = "<i class='fa fa-exclamation-triangle'></i>";
                }
                else
                {
                    pnlAlert.CssClass = "alert alert-danger alert-dismissible";
                    spIcon.InnerHtml = "<i class='fa fa-exclamation-circle'></i>";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "displayMsg", "alert('" + sMessage + "');", true);
                }
                pnlAlert.Visible = true;
                //ClientScript.RegisterStartupScript(this.GetType(), "displayMsg", "alert('" + sMessage + "');", true);
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            pnlAlert.Visible = true;
        }
    }
    protected void Page_UnLoad(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {

        }
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {

        }
    }
    //This is the method for student Login
    protected void StudentLoginClicked(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(username.Value))
            {
                DisplayMessage("Enter username", MsgType.Error);
            }
            else if (string.IsNullOrEmpty(password.Value))
            {
                DisplayMessage("Enter your Password", MsgType.Error);
            }
            else
            {
                if (objAdm.GetStudentProfile(username.Value, password.Value) == true)
                {
                    Session["audit_username"] = objAdm.sUsername;
                    Session["RecID"] = objAdm.RecID;
                    Session["firstname"] = objAdm.FirstName;
                    Response.Redirect("Dashboard");
                }
                else
                {

                    DisplayMessage(objAdm.ErrorMessage, MsgType.Error);
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
}