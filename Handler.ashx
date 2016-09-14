<%@ WebHandler Language="C#" Class="Handler" %>
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
using System.Web;
using System.Data;
using System.Data.SqlClient;


public class Handler : IHttpHandler
{
    static string URL = "";
    public void ProcessRequest(HttpContext context)
    {
        context.Response.Clear();
        if (!String.IsNullOrEmpty(context.Request.QueryString["ItemID"]))
        {
            string id = (context.Request.QueryString["ItemID"]);
            //string Fieldit = ("PDF");
            byte[] image = GetFile(id);

            if (image != null)
            {
                //FindMediaType
                if (string.Format(URL.Substring((int)URL.Length - 4).ToUpper()) == "JPG'"
                        || string.Format(URL.Substring((int)URL.Length - 5).ToUpper()) == "JPEG'")
                {
                    context.Response.ContentType = "Image/JPG";
                    context.Response.BinaryWrite(image);
                    context.Response.End();
                }
                if (string.Format(URL.Substring((int)URL.Length - 4).ToUpper()) == "PNG'")
                {
                    context.Response.ContentType = "Image/PNG";
                    context.Response.BinaryWrite(image);
                    context.Response.End();
                }
                if (string.Format(URL.Substring((int)URL.Length - 4).ToUpper()) == "GIF'")
                {
                    context.Response.ContentType = "Image/GIF";
                    context.Response.BinaryWrite(image);
                    context.Response.End();
                }
                if (string.Format(URL.Substring((int)URL.Length - 5).ToUpper()) == "TIFF'")
                {
                    context.Response.ContentType = "image/tiff";
                    context.Response.BinaryWrite(image);
                    context.Response.End();
                }
                if (string.Format(URL.Substring((int)URL.Length - 4).ToUpper()) == "BMP'")
                {
                    context.Response.ContentType = "image/bmp";
                    context.Response.BinaryWrite(image);
                    context.Response.End();
                }
                
                if (string.Format(URL.Substring((int)URL.Length - 4).ToUpper()) == "AVI'")
                {
                    context.Response.ContentType = "video/avi";
                    context.Response.BinaryWrite(image);
                    context.Response.End();
                }
                if (string.Format(URL.Substring((int)URL.Length - 4).ToUpper()) == "MPG'"
                       || string.Format(URL.Substring((int)URL.Length - 5).ToUpper()) == "MPEG'")
                {
                    context.Response.ContentType = "video/mp4";
                    context.Response.BinaryWrite(image);
                    context.Response.End();
                }
                if (string.Format(URL.Substring((int)URL.Length - 4).ToUpper()) == "PDF'"
                       )
                {
                    context.Response.ContentType = "application/pdf";
                    context.Response.BinaryWrite(image);
                    context.Response.End();
                }

                if (string.Format(URL.Substring((int)URL.Length - 4).ToUpper()) == "XML'"
                )
                {
                    context.Response.ContentType = "application/xml";
                    context.Response.BinaryWrite(image);
                    context.Response.End();
                }
                if (string.Format(URL.Substring((int)URL.Length - 4).ToUpper()) == "XLS'"
                        || string.Format(URL.Substring((int)URL.Length - 5).ToUpper()) == "XLSX'"
                )
                {
                    context.Response.ContentType = "application/vnd.ms-excel";
                    context.Response.BinaryWrite(image);
                    context.Response.End();
                }
                if (string.Format(URL.Substring((int)URL.Length - 4).ToUpper()) == "DOC'"
                        || string.Format(URL.Substring((int)URL.Length - 5).ToUpper()) == "DOCX'"
                )
                {
                    context.Response.ContentType = "application/msword";
                    context.Response.BinaryWrite(image);
                    context.Response.End();
                }
                if (string.Format(URL.Substring((int)URL.Length - 4).ToUpper()) == "XPS'"
                        || string.Format(URL.Substring((int)URL.Length - 5).ToUpper()) == "OSPX'"
                )
                {
                    context.Response.ContentType = "application/oxps";
                    context.Response.BinaryWrite(image);
                    context.Response.End();
                }
                 
                //context.Response.ContentType = "application/pdf";
                //    return image.ToString();
                //}
                //btImage = GetImage(id, Fieldit, context);

                //context.Response.ContentType = "application/pdf";

                //context.Response.AddHeader("content-disposition", "attachment; filename=Tr.pdf");

                //context.Response.Charset = "";
                //context.Response.Cache.SetCacheability(HttpCacheability.NoCache);

                // If you write,
                // Response.Write(bytFile1);
                // then you will get only 13 byte in bytFile.
                //context.Response.BinaryWrite(image);

                //context.Response.End();



            }
            else
            {
                context.Response.ContentType = "text/html";
                context.Response.Write("<p>Need a valid id</p>");
            }
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    private byte[] GetFile(string ItemID)
    {
        SqlConnection objConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        objConn.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = objConn;
        byte[] btImage = null;
        cmd.CommandText = string.Format("SELECT BeforeUrl,BeforeItem FROM Files where ItemID={0}", ItemID);
        SqlDataReader sqlDataReader = cmd.ExecuteReader();

        sqlDataReader.Read();
        URL = Convert.ToString(sqlDataReader["BeforeUrl"]);
        //FileStream fileStream = new FileStream(URL, FileMode.Create);
        try
        {
            btImage = (byte[])sqlDataReader["BeforeItem"];
            return btImage;
        }
        catch (NullReferenceException)
        {
            cmd.CommandText = string.Format("SELECT BeforeUrl,BeforeItem FROM Files where ItemID={0}", ItemID);
            sqlDataReader = cmd.ExecuteReader();
            byte[] btImageError = (byte[])sqlDataReader["BeforeItem"];
            return btImageError;
            //no data in PDF field for the row
        }
        finally
        {
            //fileStream.WriteAsync(btImage, 0, btImage.Length);
            sqlDataReader.Close();
            cmd.Dispose();
            objConn.Close();
            objConn.Dispose();
        }
    }
}