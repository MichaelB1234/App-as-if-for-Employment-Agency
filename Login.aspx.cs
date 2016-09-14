using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Security;


public partial class Account_Login2 : System.Web.UI.Page
{
    static int LoginAttempts = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //If the user requested to log out the sign the user out of the system
            //and reload the main page
            if ((string)Request.Params["action"] == "logout")
            {
                string ses = (string)Session["From"];
                if ((string)Session["FirstName"] != null || (string)Session["FirstName"] != "")
                {
                    Session["FirstName"] = "";
                    Session.Clear();
                    Session.Abandon();
                //    Response.Redirect("~/EmploymentAgencyAppDemo.aspx?From=" + ses);
                }
            }
            else if ((string)Request.Params["action"] == "tmrlogout")
            {
                if ((string)Session["FirstName"] != null || (string)Session["FirstName"] != "")
                {
                    Session["FirstName"] = "";
                    Session.Clear();
                }
            }
            //If the user checked the [Change Pin] box the set this global var which is used by the Asp page to show/hide certain controls

            //if (chkNewPwd.Checked == true)
            //    ChangePassword = 1;
            //else
            //    ChangePassword = 0;
        }

        //if an error occurs redirect the user to the error page
        catch (Exception ex)
        {
            lblMsg.Text = "An error occurred: '{0}'," + ex;

        }

    }

    protected void txtFirstName_TextChanged(object sender, EventArgs e)
    {

    }
    protected void cmdLogin_Click(object sender, EventArgs e)
    {
        LoginAttempts++;
        if (LoginAttempts > 5)
            Response.Redirect("~/TooManyLoginAttempts.aspx");
        string redirectURL = "~/Default.aspx";
        if (txtPassword.Text.Length < 1)
        {
            lblMsg.ForeColor = Color.Red;

            lblMsg.Text = "You can not enter a blank password!";
            return;
        }
        try
        {
            ///Todo: Create XSD to generate data layer
            //SqlConnection cn = new SqlConnection("Data source=(local);Database=Pictures;User id=esc1;pwd=esc1");
            SqlConnection objConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            objConn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "sploginuser @UserName = '"
                + txtUserName.Text.Replace("'", "''") +
                "',@Password = '" + txtPassword.Text.Replace("'", "''") +
                "',@LoginAttempts = " + Convert.ToInt32(LoginAttempts);            
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                        Session["FirstName"] = Convert.ToString(rd["FirstName"]);
                        Session["LastName"] = Convert.ToString(rd["LastName"]);                        
            }
            rd.Close();
            cmd.Dispose();
            objConn.Close();
            objConn.Dispose();
            if (redirectURL.Length > 0)
            {
                Response.Redirect(redirectURL);
            }
        }
    
        catch (System.Threading.ThreadAbortException ex_a)
        {
            throw ex_a;
        }
        //Application Domain changed
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
    }

    

    private static bool LoginSucceeded(SqlDataReader rd)
    {
        return (int)rd["Response"] == 1;
    }

    

    //protected void cmdUpdate_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        //update pin button event handler
    //        string strsql;
    //        if (txtPassword.Text == "")
    //        {
    //            lblMsg.ForeColor = Color.Red;
    //            lblMsg.Text = "You must enter your original password before you can change to a new password.";
    //            return;
    //        }
    //        //if the user typed the new pin correctly then proceed
    //        if (txtNewPwd1.Text == txtNewpwd2.Text)
    //        {
    //            strsql = "SpSetLDAPPIN @FirstName='" + txtUserName.Text.Replace("'", "''") + "',@LDAPResult=0,@LdapFeedback=''";
    //            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    //            SqlCommand cmd = new SqlCommand(strsql, cn);
    //            SqlDataReader rd;
    //            cn.Open();
    //            rd = cmd.ExecuteReader();
    //            while (rd.Read())
    //            {
    //                if ((string)rd[0] == "1")
    //                {
    //                    lblMsg.ForeColor = Color.Cyan;
    //                    lblMsg.Text = (string)rd[1];
    //                }
    //                else if ((string)rd[0] == "-1")
    //                {
    //                    lblMsg.ForeColor = Color.Red;
    //                    lblMsg.Text = (string)rd[1];
    //                }
    //            }
    //            rd.Close();
    //            cmd.Dispose();
    //            cn.Close();
    //        }
    //        else
    //        {
    //            lblMsg.ForeColor = Color.Red;
    //            lblMsg.Text = "Please ensure that you have typed the password correctly";
    //        }
    //    }
    //    //if an error occurs redirect the user to the error page
    //    catch (System.Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

    protected void chkNewPwd_CheckedChanged(object sender, EventArgs e)
    {
        
    }

    //protected void cmdNewAccount_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("NewAccount.aspx?NewAccount=true");
    //}
}
