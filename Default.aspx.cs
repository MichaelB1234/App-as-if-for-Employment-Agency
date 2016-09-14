using System;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;


public partial class Piclist : System.Web.UI.Page
{
    static int RowID = 0;
    static int R = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            CheckLogged();
            try
            {
                if (Request.QueryString["Title"] != null)
                {
                    Session["PageTitle"] = Request.QueryString["Title"].Replace("'", "");
                    Page.Title = Request.QueryString["Title"].Replace("'", "");
                }
                if (Request.QueryString["MenuID"] != null)
                {
                    Session["MenuID"] = Request.QueryString["MenuID"];
                }

            }
            catch
            {

                //PageSize.Text = "12";
                //MessageForUser.Text = MessageForUser.Text + "Page error, Paging size reset, sorry.";
                //PictureListGridView.PageSize = 12;
            }
            finally
            {
                //txtSetPageSize.Text = Convert.ToString(PictureListGridView.PageSize);
                if (Convert.ToString(Session["SortDir"]) == string.Empty)
                {
                    Session["SortDir"] = "ASC";
                    //MessageForUser.Text = MessageForUser.Text + "Default sort order";
                }
                if (Convert.ToString(Session["SortExp"]) == string.Empty)
                {
                    Session["SortExp"] = "MenuItemID";
                    // MessageForUser.Text = MessageForUser.Text + "Default sort column";
                }
                showgrid();

            }
        }
        else
        {
            try
            {
                if (Request.QueryString["Title"] != null)
                {
                    Session["PageTitle"] = Request.QueryString["Title"].Replace("'", "");
                    Page.Title = Request.QueryString["Title"].Replace("'", "");
                }
                if (Request.QueryString["MenuID"] != null)
                {
                    Session["MenuID"] = Request.QueryString["MenuID"];
                }
            }
            catch { }
            finally { }
        }
    }
    private void CheckLogged()
    {
        if (Session["FirstName"] == null || Session["LastName"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
    }

    private string RequestForm()
    {
        return Convert.ToString(Request["Form"]);
    }


   
    public string PicsLink(object Row)
    {
        string id = "";
        string queryString = "SELECT F.ItemID, F.BeforeUrl " +
"FROM dbo.MenuItems AS M INNER JOIN" +
                       " Files AS F ON M.MenuItemID = F.MenuItemID" +
" WHERE(ISNULL(M.Retired, 0) = 0) AND M.MenuItemID = " + Row;
        //" GROUP BY M.MenuItemID, M.BeforeUrl, F.BeforeItem, F.AfterItem, M.MenuID, M.MenuCategoryID, M.MenuItemDescription, M.EmploymentAgencyAppDemoDescription, M.AfterDescription, M.AfterUrl, M.Retired";
        SqlConnection objConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        using (objConn)
        {
            SqlCommand command = new SqlCommand(queryString, objConn);
            objConn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["BeforeUrl"].ToString() != string.Empty)
                //id += reader["BeforeUrl"].ToString();
                id += string.Format("<a target='_blank' href=" + "Handler.ashx?ItemID=" + reader["ItemID"].ToString() + "><img  style='color: White' alt=" + "\"" + "Open non-image file" + "\"" + " style=" + "\"" + "border: 0" + "\"" + " aria-live=" + "\"" + "assertive" + "\"" + " src='" +  "Handler.ashx?ItemID=" + reader["ItemID"].ToString()  + "' " + "width=" + "\"" + "180" + "\"" + " />" + "<div style='color: White'>" + " " + reader["BeforeUrl"].ToString().Replace("'", "") + " " + "</div></a>");
                if (reader["BeforeUrl"].ToString() == "'Me.jpg'")
                    Session["PictureUrl"] = "Handler.ashx?ItemID=" + reader["ItemID"].ToString();


            }
            reader.Close();
        }
        return id;
    }
    public string PicsLinkDelete(object Row)
    {
        string id = "";
        string queryString = "SELECT F.ItemID, F.BeforeUrl " +
"FROM dbo.MenuItems AS M INNER JOIN" +
                       " Files AS F ON M.MenuItemID = F.MenuItemID" +
" WHERE(ISNULL(M.Retired, 0) = 0) AND M.MenuItemID = " + Row;
        //" GROUP BY M.MenuItemID, M.BeforeUrl, F.BeforeItem, F.AfterItem, M.MenuID, M.MenuCategoryID, M.MenuItemDescription, M.EmploymentAgencyAppDemoDescription, M.AfterDescription, M.AfterUrl, M.Retired";
        SqlConnection objConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        using (objConn)
        {
            SqlCommand command = new SqlCommand(queryString, objConn);
            objConn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["BeforeUrl"].ToString() != string.Empty)
                    //id += reader["BeforeUrl"].ToString();
                    id += string.Format("<a target='_blank' href=" + "Handler.ashx?ItemID=" + reader["ItemID"].ToString() + "><input type='checkbox'   style='color: Red' alt=" + "\"" + "Open non-image file" + "\"" + " style=" + "\"" + "border: 0" + "\"" + " aria-live=" + "\"" + "assertive" + "\"" + " src='" + "Handler.ashx?ItemID=" + reader["ItemID"].ToString() + "' " + "width=" + "\"" + "180" + "\"" + " />" + "<div style='color: Red'>" + " " + "Delete " + reader["BeforeUrl"].ToString().Replace("'", "") + " " + "</div></a>" + "");

            }
            reader.Close();
        }
        return id;
    }
    
   
 

    public string OpinionDescription(object Row)
    {
        string id = "";
        string queryString = "SELECT C.BeforeComment " +
"FROM dbo.MenuItems AS M INNER JOIN" +
                       " Comments AS C ON M.MenuItemID = C.MenuItemID" +
" WHERE(ISNULL(M.Retired, 0) = 0) AND M.MenuItemID = " + Row;
        //" GROUP BY M.MenuItemID, M.BeforeUrl, F.BeforeItem, F.AfterItem, M.MenuID, M.MenuCategoryID, M.MenuItemDescription, M.EmploymentAgencyAppDemoDescription, M.AfterDescription, M.AfterUrl, M.Retired";
        SqlConnection objConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        using (objConn)
        {
            SqlCommand command = new SqlCommand(queryString, objConn);
            objConn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["BeforeComment"].ToString() != string.Empty)
                { 
                id += string.Format(reader["BeforeComment"].ToString());
                id += " ";
            }
        }
            reader.Close();
        }
        return id;
    }

  

    public void showgrid()
    {
        SqlConnection objConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        {

            objConn.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = objConn;
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SELECT DISTINCT M.MenuItemID, M.MenuID, M.MenuCategoryID, M.MenuItemDescription, M.BeforeDescription,M.AfterDescription, M.Retired FROM MenuItems AS M INNER JOIN Files AS F ON M.MenuItemID = F.MenuItemID" +
                 " WHERE(ISNULL(M.Retired, 0) = 0)";
            //cmd.Parameters.AddWithValue("@MenuID", Convert.ToInt32(Session["MenuID"]));
            //cmd.Parameters.AddWithValue("@PageTitle", Session["PageTitle"].ToString() != "" ? Session["PageTitle"].ToString() : "Plumbing");
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            sd.SelectCommand = cmd;
            sd.Fill(dt);
            try
            {
                dt.DefaultView.Sort = Convert.ToString(Session["SortExp"]) + " " + Convert.ToString(Session["SortDir"]);
                //PictureListGridView.PageIndex = Convert.ToInt32(Session["PicturePage"]);                
            }
            catch
            {
            }
            PictureListGridView.DataSource = dt;
            PictureListGridView.DataBind();
            cmd.Dispose();
            objConn.Close();
            objConn.Dispose();

        }
    }

    public void InsertMenuItemsandFileUploadContents(TextBox txtAsk, HttpPostedFile File)
    {
        string resultmessage = "";
        try
        {
            SqlConnection objConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            {
                objConn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = objConn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "spInsertBeforeMenuItems";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@MenuID", "1");
                cmd.Parameters.AddWithValue("@MenuItemDescription", Session["PageTitle"]);
                cmd.Parameters.AddWithValue("@BeforeDescription", txtAsk.Text);
                cmd.Parameters.AddWithValue("@Retired", false);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                objConn.Close();
                objConn.Dispose();
                Int32 temp;
                temp = Convert.ToInt32(RowID);
                if (temp != -1)
                {
                    try
                    {
                        UpdateAttachment("1", temp, txtAsk.Text, "'"  + File.FileName + "'",null, null, null, File,null,null,null,null);
                        MessageForUser.Text = MessageForUser.Text  + File.FileName;
                    }
                    catch (System.InvalidCastException ex)
                    {
                       // UpdateAttachment("1", temp, txtOpinionDescription.Text, "'"  + File.FileName + "'");
                        MessageForUser.Text = MessageForUser.Text + ex.Message.ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageForUser.Text = MessageForUser.Text + ex.Message.ToString();
                    }
                    finally
                    {
                        MessageForUser.Text = "Updated";
                        PictureListGridView.EditIndex = -1;
                        showgrid();
                    }
                }

            }
        }
        catch (Exception ex)
        {
            resultmessage = ex.Message.ToString();
            MessageForUser.Text = MessageForUser.Text + resultmessage;
        }
    }

   
    protected void PictureListGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string resultmessage = "";
        FileUpload FileUpload = (FileUpload)PictureListGridView.Rows[e.RowIndex].FindControl("FileUpload");
        
        HiddenField MenuItemID = (HiddenField)PictureListGridView.Rows[e.RowIndex].FindControl("Hidden1");
        Label PictureURL = (Label)PictureListGridView.Rows[e.RowIndex].FindControl("PictureURL");
        Label PDFURL = (Label)PictureListGridView.Rows[e.RowIndex].FindControl("PDFURL");
        Label AudioURL = (Label)PictureListGridView.Rows[e.RowIndex].FindControl("AudioURL");
        Label VideoURL = (Label)PictureListGridView.Rows[e.RowIndex].FindControl("VideoURL");
        Label TextURL = (Label)PictureListGridView.Rows[e.RowIndex].FindControl("TextURL");
        RowID = Convert.ToInt32(MenuItemID.Value);
        TextBox MenuItemDescription = (TextBox)PictureListGridView.Rows[e.RowIndex].FindControl("MenuItemDescription");

        TextBox txtAsk = (TextBox)PictureListGridView.Rows[e.RowIndex].FindControl("txtAsk");
        TextBox txtEmploymentAgencyAppDemo = (TextBox)PictureListGridView.Rows[e.RowIndex].FindControl("txtEmploymentAgencyAppDemo");
        
        ////Picture = (Image)PictureListGridView.Rows[e.RowIndex].FindControl("Picture"); //unused btnupload uploads
        CheckBox Retired = (CheckBox)PictureListGridView.Rows[e.RowIndex].FindControl("Retired");
        if (FileUpload.HasFile)
        {
            foreach (HttpPostedFile File in FileUpload.PostedFiles)
            {
                InsertMenuItemsandFileUploadContents(txtAsk, File);
            }
        }
        try
        {
            SqlConnection objConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            {
                objConn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = objConn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //Execute the command to insert/update
                //string sql = "update Resolution from [RiparClients] where [ClientID] = " + Session["ClientID"];
                cmd.CommandText = "spUpdateBeforeMenuItems";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@MenuID", "1");
                cmd.Parameters.AddWithValue("@MenuItemID", RowID);
                cmd.Parameters.AddWithValue("@MenuItemDescription", Session["PageTitle"]);
                cmd.Parameters.AddWithValue("@BeforeDescription", txtAsk.Text);
                cmd.Parameters.AddWithValue("@Retired", false);
                cmd.ExecuteNonQuery();
                string id = "";
                if (Session["FirstName"] != null)
                    id += "<span style='color:orange'>" + " " + Session["FirstName"].ToString() + " " + Session["LastName"].ToString() + " " + "</span>";
                if (txtEmploymentAgencyAppDemo.Text != string.Empty)
                {
                    cmd.CommandText = "spInsertBeforeComment";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@BeforeComment", "<span style='color:White'>" + txtEmploymentAgencyAppDemo.Text + "</span>" + id);
                    cmd.Parameters.AddWithValue("@MenuItemID", RowID);
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                objConn.Close();
                objConn.Dispose();
            }
        }
        catch (Exception ex)
        {
            resultmessage = ex.Message.ToString();
            MessageForUser.Text = MessageForUser.Text + resultmessage;
        }
        
            
        finally
        {
            PictureListGridView.EditIndex = -1;
            showgrid();
        }
                        }
         

    protected void PictureListGridView_RowInserting(object sender, GridViewUpdateEventArgs e)
    {
        Int32 result = 0;
        string resultmessage = "";
        FileUpload FileUpload = (FileUpload)PictureListGridView.Rows[e.RowIndex].FindControl("FileUpload");
      
        Label MenuItemID = (Label)PictureListGridView.Rows[e.RowIndex].FindControl("MenuItemID");
        Label PictureURL = (Label)PictureListGridView.Rows[e.RowIndex].FindControl("PictureURL");
        Label PDFURL = (Label)PictureListGridView.Rows[e.RowIndex].FindControl("PDFURL");
        Label AudioURL = (Label)PictureListGridView.Rows[e.RowIndex].FindControl("AudioURL");
        Label VideoURL = (Label)PictureListGridView.Rows[e.RowIndex].FindControl("VideoURL");
        Label TextURL = (Label)PictureListGridView.Rows[e.RowIndex].FindControl("TextURL");
        RowID = Convert.ToInt32(MenuItemID.Text);
        TextBox MenuItemDescription = (TextBox)PictureListGridView.Rows[e.RowIndex].FindControl("MenuItemDescription");
        TextBox txtOpinionDescription = (TextBox)PictureListGridView.Rows[e.RowIndex].FindControl("txtOpinionDescription");
        
        ////Picture = (Image)PictureListGridView.Rows[e.RowIndex].FindControl("Picture"); //unused btnupload uploads
        CheckBox Retired = (CheckBox)PictureListGridView.Rows[e.RowIndex].FindControl("Retired");
        if (FileUpload.FileName != "")
        {
            string ContentTypea = FileUpload.PostedFile.ContentType;
            if (ContentTypea.Substring(0, 5) == "image")
            {
                try
                {
                    SqlConnection objConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                    {
                        objConn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = objConn;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        //Execute the command to insert/update
                        //string sql = "update Resolution from [RiparClients] where [ClientID] = " + Session["ClientID"];
                        cmd.CommandText = "spInsertBeforeMenuItems";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@MenuID", "1");
                        cmd.Parameters.AddWithValue("@MenuItemDescription", Session["PageTitle"]);
                        cmd.Parameters.AddWithValue("@OpinionDescription", txtOpinionDescription.Text);
                        cmd.Parameters.AddWithValue("@Retired", false);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        objConn.Close();
                        objConn.Dispose();
                        //following is unused btnupload uploads
                        Int32 temp;
                        temp = Convert.ToInt32(RowID);
                        if (temp != -1)
                        {
                            try
                            {
                                UpdateAttachment("1", temp, txtOpinionDescription.Text, FileUpload.FileName, null, null, null, FileUpload.PostedFile,null,null,null,null);
                            }
                            catch (System.InvalidCastException ex)
                            {
                                //UpdateAttachment("1", temp, txtOpinionDescription.Text, FileUpload.FileName);
                                MessageForUser.Text = MessageForUser.Text + ex.Message.ToString();
                            }
                            catch (Exception ex)
                            {
                                MessageForUser.Text = MessageForUser.Text + ex.Message.ToString();
                            }
                            finally
                            {
                                MessageForUser.Text = "Updated";
                                PictureListGridView.EditIndex = -1;
                                showgrid();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    resultmessage = ex.Message.ToString();
                    MessageForUser.Text = MessageForUser.Text + resultmessage;
                }

                if (PictureActionSucceeded(result)) //If the return code is=1 [OK] redirect to confirmation page
                {
                    PictureListGridView.EditIndex = -1;
                    showgrid();
                }
                else
                    MessageForUser.Text = MessageForUser.Text + resultmessage;
            }
            if (FileUpload.FileName != "")
            {
                if (FileUpload.FileName.Substring(FileUpload.FileName.Length - 3, 3).ToUpper() == "PDF")
                {
                    try
                    {
                        SqlConnection objConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                        {
                            objConn.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = objConn;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            //Execute the command to insert/update
                            //string sql = "update Resolution from [RiparClients] where [ClientID] = " + Session["ClientID"];
                            cmd.CommandText = "spInsertBeforeMenuItems";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@MenuID", "1");
                            cmd.Parameters.AddWithValue("@MenuItemDescription", Session["PageTitle"]);
                            cmd.Parameters.AddWithValue("@OpinionDescription", txtOpinionDescription.Text);
                            cmd.Parameters.AddWithValue("@Retired", false);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                            objConn.Close();
                            objConn.Dispose();
                            //following is unused btnupload uploads
                            Int32 temp;
                            temp = Convert.ToInt32(RowID);
                            if (temp != -1)
                            {
                                try
                                {
                                    UpdateAttachment("1", temp, txtOpinionDescription.Text, null, FileUpload.FileName, null, null, FileUpload.PostedFile,null,null,null,null);
                                }
                                catch (System.InvalidCastException ex)
                                {
                                    //UpdateAttachment("1", temp, txtOpinionDescription.Text, null, FileUpload.FileName);
                                    MessageForUser.Text = MessageForUser.Text + ex.Message.ToString();
                                }
                                catch (Exception ex)
                                {
                                    MessageForUser.Text = MessageForUser.Text + ex.Message.ToString();
                                }
                                finally
                                {
                                    MessageForUser.Text = "Updated";
                                    PictureListGridView.EditIndex = -1;
                                    showgrid();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        resultmessage = ex.Message.ToString();
                        MessageForUser.Text = MessageForUser.Text + resultmessage;
                    }

                    if (PictureActionSucceeded(result)) //If the return code is=1 [OK] redirect to confirmation page
                    {
                        PictureListGridView.EditIndex = -1;
                        showgrid();
                    }
                    else
                        MessageForUser.Text = MessageForUser.Text + resultmessage;
                }
            }
            if (FileUpload.FileName != "")
            {
                string ContentTypeb = FileUpload.PostedFile.ContentType;
                if (ContentTypeb.Substring(0, 6) == "audio/")
                {
                    try
                    {
                        SqlConnection objConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                        {
                            objConn.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = objConn;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            //Execute the command to insert/update
                            //string sql = "update Resolution from [RiparClients] where [ClientID] = " + Session["ClientID"];
                            cmd.CommandText = "spInsertBeforeMenuItems";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@MenuID", "1");
                            cmd.Parameters.AddWithValue("@MenuItemDescription", Session["PageTitle"]);
                            cmd.Parameters.AddWithValue("@OpinionDescription", txtOpinionDescription.Text);
                            cmd.Parameters.AddWithValue("@Retired", false);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                            objConn.Close();
                            objConn.Dispose();
                            //following is unused btnupload uploads
                            Int32 temp;
                            temp = Convert.ToInt32(RowID);
                            if (temp != -1)
                            {
                                try
                                {
                                    UpdateAttachment("1", temp, txtOpinionDescription.Text, null, null, FileUpload.FileName, null, FileUpload.PostedFile,null,null,null,null);
                                }
                                catch (System.InvalidCastException ex)
                                {
                                    //UpdateAttachment("1", temp, txtOpinionDescription.Text, null, null, FileUpload.FileName);
                                    MessageForUser.Text = MessageForUser.Text + ex.Message.ToString();
                                }
                                catch (Exception ex)
                                {
                                    MessageForUser.Text = MessageForUser.Text + ex.Message.ToString();
                                }
                                finally
                                {
                                    MessageForUser.Text = "Updated";
                                    PictureListGridView.EditIndex = -1;
                                    showgrid();
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        resultmessage = ex.Message.ToString();
                        MessageForUser.Text = MessageForUser.Text + resultmessage;
                    }

                    if (PictureActionSucceeded(result)) //If the return code is=1 [OK] redirect to confirmation page
                    {
                        PictureListGridView.EditIndex = -1;
                        showgrid();
                    }
                    else
                        MessageForUser.Text = MessageForUser.Text + resultmessage;
                }
            }
            if (FileUpload.FileName != "")
            {
                string ContentTypec = FileUpload.PostedFile.ContentType;
                if (ContentTypec.Substring(0, 6) == "video/")
                {
                    try
                    {
                        SqlConnection objConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                        {
                            objConn.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = objConn;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            //Execute the command to insert/update
                            //string sql = "update Resolution from [RiparClients] where [ClientID] = " + Session["ClientID"];
                            cmd.CommandText = "spInsertBeforeMenuItems";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@MenuID", "1");
                            cmd.Parameters.AddWithValue("@MenuItemDescription", Session["PageTitle"]);
                            cmd.Parameters.AddWithValue("@OpinionDescription", txtOpinionDescription.Text);
                            cmd.Parameters.AddWithValue("@Retired", false);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                            objConn.Close();
                            objConn.Dispose();
                            //following is unused btnupload uploads
                            Int32 temp;
                            temp = Convert.ToInt32(RowID);
                            if (temp != -1)
                            {
                                try
                                {
                                    UpdateAttachment("1", temp, txtOpinionDescription.Text, null, null, null, FileUpload.FileName, FileUpload.PostedFile,null,null,null,null);
                                }
                                catch (System.InvalidCastException ex)
                                {
                                    //UpdateAttachment("1", temp, txtOpinionDescription.Text, null, null, null, FileUpload.FileName);
                                    MessageForUser.Text = MessageForUser.Text + ex.Message.ToString();
                                }
                                catch (Exception ex)
                                {
                                    MessageForUser.Text = MessageForUser.Text + ex.Message.ToString();
                                }
                                finally
                                {
                                    MessageForUser.Text = "Updated";
                                    PictureListGridView.EditIndex = -1;
                                    showgrid();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        resultmessage = ex.Message.ToString();
                        MessageForUser.Text = MessageForUser.Text + resultmessage;
                    }

                    //if (PictureActionSucceeded(result)) //If the return code is=1 [OK] redirect to confirmation page
                    //{
                    PictureListGridView.EditIndex = -1;
                    showgrid();
                    //}
                    //else
                    //    MessageForUser.Text = MessageForUser.Text + resultmessage;
                }
            }
            if (FileUpload.FileName != "")
            {
                string ContentTyped = FileUpload.PostedFile.ContentType;
                if (ContentTyped.Substring(0, 5) == "appli")
                {
                    if (ContentTyped.Substring(0, 15) == "application/vnd")
                    {
                        try
                        {
                            SqlConnection objConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                            {
                                objConn.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = objConn;
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                //Execute the command to insert/update
                                //string sql = "update Resolution from [RiparClients] where [ClientID] = " + Session["ClientID"];
                                cmd.CommandText = "spInsertBeforeMenuItems";
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@MenuID", "1");
                                cmd.Parameters.AddWithValue("@MenuItemDescription", Session["PageTitle"]);
                                cmd.Parameters.AddWithValue("@OpinionDescription", txtOpinionDescription.Text);
                                cmd.Parameters.AddWithValue("@Retired", false);
                                cmd.ExecuteNonQuery();
                                cmd.Dispose();
                                objConn.Close();
                                objConn.Dispose();
                                //following is unused btnupload uploads
                                Int32 temp;
                                temp = Convert.ToInt32(RowID);
                                if (temp != -1)
                                {
                                    try
                                    {
                                        UpdateAttachment("1", temp, txtOpinionDescription.Text, null, null, null, null, FileUpload.PostedFile, FileUpload.FileName,null,null,null);
                                    }
                                    catch (System.InvalidCastException ex)
                                    {
                                        //UpdateAttachment("1", temp, txtOpinionDescription.Text, null, null, null, null, null, FileUpload.FileName);
                                        MessageForUser.Text = MessageForUser.Text + ex.Message.ToString();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageForUser.Text = MessageForUser.Text + ex.Message.ToString();
                                    }
                                    finally
                                    {
                                        MessageForUser.Text = "Updated";
                                        PictureListGridView.EditIndex = -1;
                                        showgrid();
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            resultmessage = ex.Message.ToString();
                        }
                    }

                    if (PictureActionSucceeded(result)) //If the return code is=1 [OK] redirect to confirmation page
                    {
                        PictureListGridView.EditIndex = -1;
                        showgrid();
                    }
                    else
                        MessageForUser.Text = MessageForUser.Text + resultmessage;
                }
                else
                {
                    try
                    {
                        SqlConnection objConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                        {
                            objConn.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = objConn;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            //Execute the command to insert/update
                            //string sql = "update Resolution from [RiparClients] where [ClientID] = " + Session["ClientID"];
                            cmd.CommandText = "spInsertBeforeMenuItems";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@MenuID", "1");
                            cmd.Parameters.AddWithValue("@MenuItemDescription", Session["PageTitle"]);
                            cmd.Parameters.AddWithValue("@OpinionDescription", txtOpinionDescription.Text);
                            cmd.Parameters.AddWithValue("@Retired", false);
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                            objConn.Close();
                            objConn.Dispose();
                        }
                    }
                    catch (Exception ex)
                    {
                        resultmessage = ex.Message.ToString();
                        MessageForUser.Text = MessageForUser.Text + resultmessage;
                    }
                }
                if (PictureActionSucceeded(result)) //If the return code is=1 [OK] redirect to confirmation page
                {
                    PictureListGridView.EditIndex = -1;
                    showgrid();
                }
                else
                    MessageForUser.Text = MessageForUser.Text + resultmessage;
            }
            else
            {
            }
        }
        else
        {
            //fileupload empty
            try
            {
                SqlConnection objConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                {
                    objConn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = objConn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //Execute the command to insert/update
                    //string sql = "update Resolution from [RiparClients] where [ClientID] = " + Session["ClientID"];
                    cmd.CommandText = "spInsertBeforeMenuItems";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@MenuID", "1");
                    cmd.Parameters.AddWithValue("@MenuItemDescription", Session["PageTitle"]);
                    cmd.Parameters.AddWithValue("@OpinionDescription", txtOpinionDescription.Text);
                    cmd.Parameters.AddWithValue("@Retired", false);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    objConn.Close();
                    objConn.Dispose();
                }
            }
            catch (Exception ex)
            {
                resultmessage = ex.Message.ToString();
            }
            finally
            {
                MessageForUser.Text = "Updated";
                PictureListGridView.EditIndex = -1;
                showgrid();
            }
            //if (PictureActionSucceeded(result)) //If the return code is=1 [OK] redirect to confirmation page
            //{
            //    PictureListGridView.EditIndex = -1;
            //    showgrid();
            //}
            //else
            //    MessageForUser.Text = MessageForUser.Text + resultmessage;
        }
        
    }


    private static bool PictureActionSucceeded(int result)
    {
        return result == 1;
    }
    protected void PictureListGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string resultmessage = "";
        try
        {
            HiddenField MenuItemID = (HiddenField)PictureListGridView.Rows[e.RowIndex].FindControl("Hidden1");
            RowID = Convert.ToInt32(MenuItemID.Value);
            SqlConnection objConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            {
                objConn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = objConn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //Execute the command to insert/update
                //string sql = "update Resolution from [RiparClients] where [ClientID] = " + Session["ClientID"];
                cmd.CommandText = "spDeleteMenuItem";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@MenuItemID", RowID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                objConn.Close();
                objConn.Dispose();
            }
        }
        catch (Exception ex)
        {
            resultmessage = ex.Message.ToString();
            MessageForUser.Text = MessageForUser.Text + resultmessage;
        }
        finally
        {
            PictureListGridView.EditIndex = -1;
            showgrid();
        }
        //for (int i = 5; i < PictureListGridView.Columns.Count; i++)
        //    PictureListGridView.Columns[i].Visible = true;
    }
    protected void PictureListGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        PictureListGridView.EditIndex = -1;
        showgrid();
        //for (int i = 5; i < PictureListGridView.Columns.Count; i++)
        //    PictureListGridView.Columns[i].Visible = true;
    }
    protected void PictureListGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        PictureListGridView.EditIndex = e.NewEditIndex;
        //for (int i = 6; i < PictureListGridView.Columns.Count; i++)
        //    PictureListGridView.Columns[i].Visible = false;
        //Label lbl = (Label)PictureListGridView.Rows[PictureListGridView.EditIndex].FindControl("MenuItemID");
        RowID = Convert.ToInt32(PictureListGridView.EditIndex);
        showgrid();
    }
    public static byte[] GetPhoto(string filePath)
    {
        FileStream stream = new FileStream(
            filePath, FileMode.Open, FileAccess.Read);
        BinaryReader reader = new BinaryReader(stream);
        byte[] photo = reader.ReadBytes((int)stream.Length);
        reader.Close();
        stream.Close();
        return photo;
    }
    
    private void InsertAttachment(string PictureDescription, string MenuCategoryID, string PictureorPDFURL, HttpPostedFile optionalstrFile)
    {
        try
        {
            SqlConnection objConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            //if (PictureorPDFURL.Substring(PictureorPDFURL.Length - 3, 3).ToUpper() == "JPG")
            {                
                objConn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = objConn;
                //Check if PictureorPDFURL is a duplicate
                //cmd.CommandText = "Select BeforeURL,MenuCategoryID, MenuItemDescription From MenuItems WHERE ISNULL(Retired,0) = 0 AND BeforeURL ='" + PictureorPDFURL + "'" + " AND MenuCategoryID = " + MenuCategoryID;
                //SqlDataReader rd = cmd.ExecuteReader();
                //if (rd.Read())
                //{
                //    if (rd["MenuItemDescription"].ToString() != Session["Title"].ToString())
                //        //Picture is on another page already
                //        MessageForUser.Text = MessageForUser.Text + "This Picture is already available on " + Session["Title"].ToString() + " page.";
                //    else //Picture is on this page already
                //        MessageForUser.Text = MessageForUser.Text + "This Picture is already available on this page";
                //}
                //else
                //{
                //    rd.Close();
                //}
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                byte[] bytImg = null;
                //Find its length and convert it to byte array
                if (optionalstrFile != null)
                {
                    int ContentLength = optionalstrFile.ContentLength;
                    //Create Byte Array
                    bytImg = new byte[ContentLength];
                    //Read Uploaded file in Byte Array
                    optionalstrFile.InputStream.Read(bytImg, 0, ContentLength);
                }
                cmd.CommandText = "spInsertPicture";
                //              command.Parameters.AddWithValue("@Picture",
                //SqlDbType.Image, photo.Length).Value = photo;
                cmd.Parameters.Clear();
                if (optionalstrFile != null && bytImg.Length > 0)
                {
                    cmd.Parameters.AddWithValue("@BeforeItem", bytImg).SqlDbType = SqlDbType.Binary;
                }
                int MID = Convert.ToInt32(Session["MenuID"]);
                cmd.Parameters.AddWithValue("@MenuID", MID);
                cmd.Parameters.AddWithValue("@BeforeDescription", PictureDescription);
                if (R > 0)
                {
                    cmd.Parameters.AddWithValue("MenuItemID", R);
                }
                else
                {
                    cmd.Parameters.AddWithValue("MenuItemID", null);
                }
                cmd.Parameters.AddWithValue("@MenuItemDescription", Session["PageTitle"]);
                cmd.Parameters.AddWithValue("@BeforeURL", "'" + (PictureorPDFURL.Remove(0,PictureorPDFURL.LastIndexOf("\\") + 1)));
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                R++;
                objConn.Close();
                objConn.Dispose();
            }
        }
        catch
        { }
   }

 
    private void UpdateAttachment(string strField, int Row, string PictureDescription, string PictureURL, string PDFURL, string AudioURL, string VideoURL, HttpPostedFile optionalstrFile, string txtText, string AfterDescription, string PictureURL2, HttpPostedFile optionalstrFile2)
    {

        SqlConnection objConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        objConn.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = objConn;
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        byte[] bytImg = null;
        int ContentLength = 0;

        //Find its length and convert it to byte array

        if (optionalstrFile != null && txtText != null)//don't do for text
        {
            ContentLength = optionalstrFile.ContentLength;

            //Create Text Array
            var t = optionalstrFile.GetType();
            var e = optionalstrFile.FileName;
            if (e.EndsWith("txt"))
            {
                //optionalstrFile.SaveAs(e);
            }
            //Cater for Office Docs
            if (e.EndsWith("doc") || e.EndsWith("docx"))
            {

                ContentLength = optionalstrFile.ContentLength;

                //Create Byte Array
                bytImg = new byte[ContentLength];

                //Read Uploaded file in Byte Array
                optionalstrFile.InputStream.Read(bytImg, 0, ContentLength);

            }
            if (e.EndsWith("xls") || e.EndsWith("xlsx"))
            {
                ContentLength = optionalstrFile.ContentLength;

                //Create Byte Array
                bytImg = new byte[ContentLength];

                //Read Uploaded file in Byte Array
                optionalstrFile.InputStream.Read(bytImg, 0, ContentLength);

            }
            else
            {
                ContentLength = optionalstrFile.ContentLength;

                //Create Byte Array
                bytImg = new byte[ContentLength];

                //Read Uploaded file in Byte Array
                optionalstrFile.InputStream.Read(bytImg, 0, ContentLength);

            }

            //if (t = )
            //txtText.GetEnumerator();
            //txtText.ToCharArray(txtTextDest);
            ////Read Uploaded file in Text Array
            //optionalstrFile.InputStream.BeginRead(InputStream.Read(txtText, 0, ContentLength);
        }
       

        if (optionalstrFile != null && txtText == null)//don't do for text
        {
            ContentLength = optionalstrFile.ContentLength;

            //Create Byte Array
            bytImg = new byte[ContentLength];

            //Read Uploaded file in Byte Array
            optionalstrFile.InputStream.Read(bytImg, 0, ContentLength);

            if (PictureURL != null)
            {
                cmd.CommandText = "spInsertBefore";
                //              command.Parameters.AddWithValue("@Picture",
                //SqlDbType.Image, photo.Length).Value = photo;
                cmd.Parameters.Clear();
                if (optionalstrFile != null && bytImg.Length > 0)

                {
                    cmd.Parameters.AddWithValue("@BeforeItem", bytImg).SqlDbType = SqlDbType.Binary;
                }
                cmd.Parameters.AddWithValue("@MenuItemID", Row);
                cmd.Parameters.AddWithValue("@BeforeDescription", PictureDescription);
                cmd.Parameters.AddWithValue("@BeforeURL", "'" + (PictureURL.Remove(0, PictureURL.LastIndexOf("\\") + 1)));
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                objConn.Close();
                objConn.Dispose();
                MessageForUser.Text = MessageForUser.Text + "Updated";
            }



            if (PDFURL != null && PDFURL.Substring(PDFURL.Length - 3, 3).ToUpper() == "PDF")
            {
                try
                {
                    cmd.CommandText = "spUpdatePDF";
                    //              command.Parameters.AddWithValue("@Picture",
                    //SqlDbType.Image, photo.Length).Value = photo;
                    cmd.Parameters.Clear();
                    if (optionalstrFile != null && bytImg.Length > 0)

                    {
                        cmd.Parameters.AddWithValue("@PDF", bytImg).SqlDbType = SqlDbType.Binary;
                    }
                    cmd.Parameters.AddWithValue("@MenuItemID", Row);
                    cmd.Parameters.AddWithValue("@BeforeDescription", PictureDescription);
                    cmd.Parameters.AddWithValue("@PDFURL", PDFURL);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    objConn.Close();
                    objConn.Dispose();
                    MessageForUser.Text = MessageForUser.Text + "Updated";
                }

                catch (Exception ex)
                {
                    MessageForUser.Text = ex.Message.ToString();
                }
            }
            if (AudioURL != null)
            {
                try
                {
                    cmd.CommandText = "spUpdateAudio";
                    //              command.Parameters.AddWithValue("@Picture",
                    //SqlDbType.Image, photo.Length).Value = photo;
                    cmd.Parameters.Clear();
                    if (optionalstrFile != null && bytImg.Length > 0)

                    {
                        cmd.Parameters.AddWithValue("@Audio", bytImg).SqlDbType = SqlDbType.Binary;
                    }
                    cmd.Parameters.AddWithValue("@MenuItemID", Row);
                    cmd.Parameters.AddWithValue("@BeforeDescription", PictureDescription);
                    cmd.Parameters.AddWithValue("@AudioURL", AudioURL);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    objConn.Close();
                    objConn.Dispose();
                    MessageForUser.Text = MessageForUser.Text + "Updated";
                }

                catch (Exception ex)
                {
                    MessageForUser.Text = ex.Message.ToString();
                }
            }
            if (VideoURL != null)
            {
                try
                {
                    cmd.CommandText = "spUpdateVideo";
                    //              command.Parameters.AddWithValue("@Picture",
                    //SqlDbType.Image, photo.Length).Value = photo;
                    cmd.Parameters.Clear();
                    if (optionalstrFile != null && bytImg.Length > 0)

                    {
                        cmd.Parameters.AddWithValue("@Video", bytImg).SqlDbType = SqlDbType.Binary;
                    }
                    cmd.Parameters.AddWithValue("@MenuItemID", Row);
                    cmd.Parameters.AddWithValue("@BeforeDescription", PictureDescription);
                    cmd.Parameters.AddWithValue("@VideoURL", VideoURL);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    objConn.Close();
                    objConn.Dispose();
                    MessageForUser.Text = MessageForUser.Text + "Updated";
                }

                catch (Exception ex)
                {
                    MessageForUser.Text = ex.Message.ToString();
                }
            }
            if (txtText != null)
            {
                try
                {
                    cmd.CommandText = "spUpdateText";
                    //              command.Parameters.AddWithValue("@Picture",
                    //SqlDbType.Image, photo.Length).Value = photo;
                    cmd.Parameters.Clear();
                    if (optionalstrFile != null)


                    {
                        cmd.Parameters.AddWithValue("@Text", bytImg).SqlDbType = SqlDbType.Binary;
                    }
                    cmd.Parameters.AddWithValue("@MenuItemID", Row);
                    cmd.Parameters.AddWithValue("@BeforeDescription", PictureDescription);
                    cmd.Parameters.AddWithValue("@TextURL", txtText);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    objConn.Close();
                    objConn.Dispose();
                    MessageForUser.Text = MessageForUser.Text + "Updated";
                }

                catch (Exception ex)
                {
                    MessageForUser.Text = ex.Message.ToString();
                }
            }
        }
    }

    private static bool UpdateSucceeded(SqlDataReader rd)
    {
        return (int)rd["Response"] == 1;
    }
    //protected void PictureListGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    Session["PicturePage"] = e.NewPageIndex;
    //    //PictureListGridView.PageIndex = e.NewPageIndex;
    //    showgrid();
    //}



    //protected void SetPageSize_Click(object sender, EventArgs e)
    //{
       
    //    try
    //    {
    //        //PictureListGridView.PageSize = Int32.Parse(txtSetPageSize.Text);
    //        Session["PageSize"] = Int32.Parse(txtSetPageSize.Text);
    //        Session["PicturePage"] = 0;
    //        MessageForUser.Text = MessageForUser.Text + "";
    //        showgrid();
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageForUser.Text = ex.Message.ToString();
    //    }
    //    finally
    //    {
    //        MessageForUser.Text = MessageForUser.Text + "";
            
    //    }
    //}
    //protected void BtnUploadAdd_Click(object sender, EventArgs e)
    //{
    //    Int32 temp;
    //    temp = Convert.ToInt32(RowID);
    //    if (temp > -1)
    //    {
    //        FileUpload FileU1 = (FileUpload)PictureListGridView.Rows[RowID].FindControl("FileUploadAdd");
    //        string t = FormatImageUrl(FileU1.FileName);
    //        try
    //        {
    //            UpdateAttachment("1", temp, EmploymentAgencyAppDemoDescription.Text, "~/Images/" + FileU1.FileName, FileU1.PostedFile);
    //        }
    //        catch (System.InvalidCastException ex)
    //        {
    //            UpdateAttachment("1", temp, EmploymentAgencyAppDemoDescription.Text, "~/Images/" + FileU1.FileName);
    //            MessageForUser.Text = ex.Message.ToString();
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageForUser.Text = ex.Message.ToString();
    //        }
    //        finally
    //        {
    //            MessageForUser.Text = MessageForUser.Text + "File Uploaded";
    //            //////showgrid();
    //        }
    //    }
    //    else
    //        // Notify the user that a file was not uploaded.
    //        MessageForUser.Text = MessageForUser.Text + "You did not specify a file to upload.";
    //}
    protected void PictureListGridView_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (Convert.ToString(Session["SortDir"]) == "ASC")
        {
            Session["SortDir"] = "DESC";
        }
        else
        {
            Session["SortDir"] = "ASC";
        }
        Session["SortExp"] = e.SortExpression;
        showgrid();
    }

    protected void BackToMenuButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }

    protected void InsertPictures_Click(object sender, EventArgs e)
    {
        if (FileUploadInsert.HasFile)
        {
            //if (!FileUploadInsert.HasFile)
                R = 0; //Reset to start adding set         
            foreach (HttpPostedFile File in FileUploadInsert.PostedFiles)
            {
                { 
                    //Insert the picture or file first it takes the longest        
                    try
                    {
                        InsertAttachment(txtBeforeAdd.Text, Session["MenuCategoryID"].ToString(), "'"  + File.FileName + "'", File);
                        MessageForUser.Text += File.FileName.Remove(0, File.FileName.LastIndexOf("\\") + 1);
                    }
                    catch (System.InvalidCastException)
                    {
                        //InsertAttachment(txtBeforeAdd.Text, Session["MenuCategoryID"].ToString(), "'"  + File.FileName + "'");
                    }
                    catch (Exception ex)
                    {
                        MessageForUser.Text = ex.Message.ToString();
                    }
                    finally
                    {

                        //PictureListGridView.EditIndex = -1;
                        showgrid();
                    }
                  }
            }
            MessageForUser.Text += " Uploaded";
        }
        
      

        else //not picture of types allowed for
        {
            foreach (HttpPostedFile File in FileUploadInsert.PostedFiles)
            {
                if (File.FileName != string.Empty)//user trying to add no files
                {
                    if (File.FileName.Substring(File.FileName.Length - 3, 3).ToUpper() == "PDF")
                    {
                        //using (SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                        //{
                        //    cn.Open();
                        InsertAttachment(txtBeforeAdd.Text, Session["MenuCategoryID"].ToString(), "'"  + File.FileName + "'", File);
                        //MessageForUser.Text = ("Pdf File Saved");
                        //PictureListGridView.EditIndex = -1;
                        showgrid();
                    }
                }
            }
        }
        
}
    
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Label MenuItemIDLabel = (Label)PictureListGridView.Rows[RowID].FindControl("MenuItemID");
        Response.Redirect("~/mnu/Image.aspx?MenuItemID=" + MenuItemIDLabel.Text);
    }


    protected void PDFView_Click(object sender, EventArgs e)
    {
       
        string link = "";
        try
        {
            LinkButton PDFView = (LinkButton)sender;
            RowID = Convert.ToInt32(PDFView.CommandArgument);
            Label PDFUrl = (Label)PictureListGridView.Rows[RowID].FindControl("PDFUrl");
            if (PDFUrl.Text != "")
            {
                string ToSaveFileTo = Server.MapPath("//" + PDFUrl.Text);

                using (SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("select PDF from MenuItems  where MenuItemID='" + RowID + "' ", cn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                        {
                            if (dr.Read())
                            {

                                byte[] fileData = (byte[])dr.GetValue(0);
                                using (System.IO.FileStream fs = new System.IO.FileStream(ToSaveFileTo, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                                {
                                    using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                                    {
                                        bw.Write(fileData);
                                        bw.Close();
                                    }
                                }
                            }

                            dr.Close();
                            MessageForUser.ForeColor = System.Drawing.Color.Cyan;
                            MessageForUser.Text = MessageForUser.Text + "";
                            link = PDFUrl.Text;
                        }
                    }
                }
            }

            else
            {
                MessageForUser.ForeColor = System.Drawing.Color.Red;
                MessageForUser.Text = MessageForUser.Text + "No PDF Stored for this row";
            }

        }
        catch
        { }
        finally
        {
            Response.Redirect(link);
           
        }
    }


    protected void PictureView_Click(object sender, EventArgs e)
    {
        
        Label PictureUrl = (Label)PictureListGridView.Rows[RowID].FindControl("PictureUrl");
        Response.Redirect(PictureUrl.Text);
       
    }
    public string ProcessMyDataItem(Object myValue)
    {
        if (myValue == null)
        {
            return "No Data value";
        }
        return myValue.ToString();
                
    }
    //public string ProcessMyDataList(Object myValue[])
    //{
    //    if (myValue == null)
    //    {
    //        return "No Data value";
    //    }
    //    foreach (Object prime in myValue[]) // Loop through List with foreach.
    //    {
    //        return myValue.ToString();
    //    }        
    //}
    protected void PlaySound_Click(object sender, EventArgs e)
    {
       
        LinkButton AudioView = (LinkButton)sender;
        RowID = Convert.ToInt32(AudioView.CommandArgument);
        Label AudioUrl = (Label)PictureListGridView.Rows[RowID].FindControl("AudioUrl");
        if (AudioUrl.Text != "")
        {
            string ToSaveFileTo = Server.MapPath("//" + AudioUrl.Text);

            using (SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("select Audio from MenuItems  where MenuItemID='" + RowID + "' ", cn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                    {
                        if (dr.Read())
                        {

                            byte[] fileData = (byte[])dr.GetValue(0);
                            using (System.IO.FileStream fs = new System.IO.FileStream(ToSaveFileTo, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                            {
                                using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                                {
                                    bw.Write(fileData);
                                    bw.Close();
                                }
                            }
                        }

                        dr.Close();
                        MessageForUser.ForeColor = System.Drawing.Color.Cyan;
                        MessageForUser.Text = MessageForUser.Text + "";
                        Response.Redirect(AudioUrl.Text);
                        
                    }
                }
            }
        }

        else
        {
            MessageForUser.ForeColor = System.Drawing.Color.Red;
            MessageForUser.Text = MessageForUser.Text + "No Audio Stored for this row";
        }
    }

    protected void ViewVideo_Click(object sender, EventArgs e)
    {
        LinkButton VideoView = (LinkButton)sender;
        RowID = Convert.ToInt32(VideoView.CommandArgument);
        Label VideoUrl = (Label)PictureListGridView.Rows[RowID].FindControl("VideoUrl");
        if (VideoUrl.Text != "")
        {
            string ToSaveFileTo = Server.MapPath("//" + VideoUrl.Text);

            using (SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("select Video from MenuItems  where MenuItemID='" + RowID + "' ", cn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                    {
                        if (dr.Read())
                        {

                            byte[] fileData = (byte[])dr.GetValue(0);
                            using (System.IO.FileStream fs = new System.IO.FileStream(ToSaveFileTo, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                            {
                                using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                                {
                                    bw.Write(fileData);
                                    bw.Close();
                                }
                            }
                        }

                        dr.Close();
                        MessageForUser.ForeColor = System.Drawing.Color.Cyan;
                        MessageForUser.Text = MessageForUser.Text + "";
                        Response.Redirect(VideoUrl.Text);

                    }
                }
            }
        }

        else
        {
            MessageForUser.ForeColor = System.Drawing.Color.Red;
            MessageForUser.Text = MessageForUser.Text + "No Video Stored for this row";
        }
    }

    protected void TextView_Click(object sender, EventArgs e)
    {
        
        LinkButton TextView = (LinkButton)sender;
        RowID = Convert.ToInt32(TextView.CommandArgument);
        Label TextUrl = (Label)PictureListGridView.Rows[RowID].FindControl("TextUrl");
        if (TextUrl.Text != "")
        {
            string ToSaveFileTo = Server.MapPath("//" + TextUrl.Text);

            using (SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("select BeforeItem from Files where MenuItemID='" + RowID + "' ", cn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default))
                    {
                        if (dr.Read())
                        {

                            byte[] fileData = (byte[])dr.GetValue(0);
                            using (System.IO.FileStream fs = new System.IO.FileStream(ToSaveFileTo, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                            {
                                using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                                {
                                    bw.Write(fileData);
                                    bw.Close();
                                }
                            }
                        }

                        dr.Close();
                        MessageForUser.ForeColor = System.Drawing.Color.Cyan;
                        MessageForUser.Text = MessageForUser.Text + "";
                        Response.Redirect(TextUrl.Text);
                        
                    }
                }
            }
        }

        else
        {
            MessageForUser.ForeColor = System.Drawing.Color.Red;
            MessageForUser.Text = MessageForUser.Text + "No Text Stored for this row";
        }
    }

    protected void PictureListGridView_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        //for (int i = 5; i < PictureListGridView.Columns.Count; i++)
        //    PictureListGridView.Columns[i].Visible = true;
    }
}

   

