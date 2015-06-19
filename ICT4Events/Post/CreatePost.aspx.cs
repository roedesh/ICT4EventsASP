// <copyright file="CreatePost.aspx.cs" company="Ict4Events">
//      Copyright (c) ICT4Events. All rights reserved.
// </copyright>
// <author>Sander Koch</author>
namespace ICT4Events.Post
{
    using BAL;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    /// <summary>
    /// 
    /// </summary>
    public partial class CreatePost : System.Web.UI.Page
    {
        string c = string.Empty;
        string cn = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.c = Request.QueryString["catid"];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpload_Click(object sender, EventArgs e)
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
        /// 
        /// </summary>
        /// <param name="category"></param>
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