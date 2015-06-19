namespace ICT4Events.Post
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.IO;
    using BAL;

    public partial class CreatePost : System.Web.UI.Page
    {
        string c = "";
        string cn = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            c = Request.QueryString["catid"];
                if (c != null)
                {

                }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Media/"));
            if (!dir.Exists)
            {
                dir.Create();
            }
            else
            {
                if (c != "")
                {
                    DirectoryInfo subdir = new DirectoryInfo(Server.MapPath("~/Media/" + c));
                    if (!subdir.Exists)
                    {
                        subdir.Create();
                        Upload(c);
                    }
                    else
                    {
                        Upload(c);
                    }
                }
            }
        }
        private void Upload(string category)
        {
            if ((inputFile.PostedFile != null) && (inputFile.PostedFile.ContentLength > 0))
            {
                
                string fn = System.IO.Path.GetFileName(inputFile.PostedFile.FileName);
                string SaveLocation = Server.MapPath("~\\Media") + "\\" + category + "\\" + fn;
                try
                {
                    inputFile.PostedFile.SaveAs(SaveLocation);
                    string filelength = Convert.ToString(new FileInfo(SaveLocation).Length);
                    if (new PostBAL().CreatePost((Session["USER_ID"].ToString()), c, SaveLocation, filelength) == 0)
                    {
                        File.Delete(SaveLocation);
                        Response.Write("<script language=javascript>alert('Bestand is niet toegevoegd');</script>");
                    }
                    else
                    {
                        
                        Response.Write("<script language=javascript>alert('Bestand is toegevoegd');</script>");
                    }   
                }
                catch (Exception ex)
                {
                    Response.Write("<script language=javascript>alert("+ ex.Message+");</script>");
                    //Note: Exception.Message returns a detailed message that describes the current exception. 
                    //For security reasons, we do not recommend that you return Exception.Message to end users in 
                    //production environments. It would be better to return a generic error message. 
                }
            }
            else
            {
                Response.Write("Please select a file to upload.");
            }
        }
    }
}