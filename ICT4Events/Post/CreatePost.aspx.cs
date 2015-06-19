// <copyright file="CreatePost.aspx.cs" company="Ict4Events">
//      Copyright (c) ICT4Events. All rights reserved.
// </copyright>
// <author>Sander Koch</author>
namespace ICT4Events.Post
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using BAL;

    /// <summary>
    /// WebForm for creating a new post.
    /// </summary>
    public partial class CreatePost : System.Web.UI.Page
    {
        /// <summary>
        /// C contains the CatID parameter
        /// </summary>
        private string c = string.Empty;

        /// <summary>
        /// CN contains the CatName parameter
        /// </summary>
        private string cn = string.Empty;

        /// <summary>
        /// On page load this method will be triggered, everything inside this
        /// method will be executed.
        /// This builds the website content.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.c = Request.QueryString["catid"];
        }

        /// <summary>
        /// Checks to see if the destination directory already exists.
        /// If not the directory will be created
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Media/"));
            if (!dir.Exists)
            {
                dir.Create();
            }
            else
            {
                if (this.c != string.Empty)
                {
                    DirectoryInfo subdir = new DirectoryInfo(Server.MapPath("~/Media/" + this.c));
                    if (!subdir.Exists)
                    {
                        subdir.Create();
                        this.Upload(this.c);
                    }
                    else
                    {
                        this.Upload(this.c);
                    }
                }
            }
        }

        /// <summary>
        /// Uploads a file if the destination directory is valid
        /// Will display message if file has successfully been uploaded,
        /// of if it failed.
        /// </summary>
        /// <param name="category">Is the category where the file will be placed in.</param>
        private void Upload(string category)
        {
            if ((inputFile.PostedFile != null) && (inputFile.PostedFile.ContentLength > 0))
            {
                string fn = System.IO.Path.GetFileName(inputFile.PostedFile.FileName);
                string savelocation = Server.MapPath("~\\Media") + "\\" + category + "\\" + fn;
                try
                {
                    inputFile.PostedFile.SaveAs(savelocation);
                    string filelength = Convert.ToString(new FileInfo(savelocation).Length);
                    if (new PostBAL().CreateFile(Session["USER_ID"].ToString(), this.c, savelocation, filelength) == 0)
                    {
                        File.Delete(savelocation);
                        Response.Write("<script language=javascript>alert('Bestand is niet toegevoegd');</script>");
                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert('Bestand is toegevoegd');</script>");
                    }   
                }
                catch (Exception ex)
                {
                    Response.Write("<script language=javascript>alert(" + ex.Message + ");</script>");
                }
            }
            else
            {
                Response.Write("Please select a file to upload.");
            }
        }
    }
}