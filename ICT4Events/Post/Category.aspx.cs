// <copyright file="Category.aspx.cs" company="ICT4EventsASP">
//     Copyright (c) ICT4EventsASP. All rights reserved.
// </copyright>
// <author>Sander Koch</author>
namespace ICT4Events.Post
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using BAL;
 
    /// <summary>
    /// Category page
    /// </summary>
    public partial class Category : System.Web.UI.Page
    {
        /// <summary>
        /// Gets or sets the identifier of the category stored
        /// </summary>
        public string C
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the user is logged in as an admin
        /// </summary>
        public bool IsLoggedInAsAdmin
        {
            get;
            set;
        }

        /// <summary>
        /// On page load this method will be triggered, everything inside this
        /// method will be executed.
        /// This builds the website content.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
                this.C = Request.QueryString["catid"];
                if (this.C != null)
                {
                    DataTable subCategory = new PostBAL().GetCategories(this.C);
                    this.repSubCat.DataSource = subCategory;
                    this.repSubCat.DataBind();
                    DataTable post = new PostBAL().GetAllPosts(this.C);
                    this.repFile.DataSource = post;
                    this.repFile.DataBind();
                    if (this.Session["User_ID"] != null)
                    {
                        if (this.Session["USER_ROLE"].ToString() == "ADMIN")
                        {
                            this.IsLoggedInAsAdmin = true;
                        }
                    }
                }

                if (this.C == null)
                {
                    DataTable category = new PostBAL().GetCategories();
                    this.repMainCat.DataSource = category;
                    this.repMainCat.DataBind();
                }
        }

        /// <summary>
        /// On button click redirect user to the page for creating posts
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnCreatePost_Click(object sender, EventArgs e)
        {           
            Response.Redirect("../Post/CreatePost.aspx?catid=" + this.C);
        }

        /// <summary>
        /// On button click delete the post and show a message.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnDel_Click(object sender, EventArgs e)
        {
            if (new PostBAL().DeletePost(this.C) > 0)
            {
                Response.Write("<script language=javascript>alert('Post is verwijderd');</script>");
            }
            else
            {
                Response.Write("<script language=javascript>alert('Post is niet verwijderd');</script>");
            }
        }
    }
}