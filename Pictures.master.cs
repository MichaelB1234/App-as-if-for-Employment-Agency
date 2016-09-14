using System;
using System.Configuration;
using System.Web.UI.HtmlControls;

public partial class Pictures1 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FirstName"] != null)
            lblName.Text = Session["FirstName"].ToString();
        if (Session["LastName"] != null)
            lblName.Text += " " + Session["LastName"].ToString();
        if (Application["BackGroundUrl"] != null)
        {
            //Inject onload and unload

            //Attributes.Add("background",Application["BackGroundUrl"].ToString());
        }
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect(ConfigurationManager.AppSettings["LoginURL"]);
    }
}
