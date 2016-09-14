using System;
using System.Web.UI;

public partial class Account_loginstatus2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        {
            lblmsg.Text = "Please note that you have already signed in elsewhere." + "\r\n" + "** Always ensure that you log out when you are done otherwise the system will wait until you are automatically logged off.";
            return;
        }
            catch
        {
            //if an error occurs redirect the user to the error page
            Response.Redirect("../Account/errorpage.aspx");
        }
    }
    protected void icmdclose_Click(object sender, ImageClickEventArgs e)
    {
        string s;
        s = "<Script language=''javascript''>window.close()</script>";
        Response.Write(s);
    }
}