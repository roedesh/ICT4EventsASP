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
        public string filename = string.Empty;
        /// <summary>
        /// Gets or sets the identifier of the category stored
        /// </summary>
        public string C
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the category is a main category
        /// </summary>
        public bool IsMainCategory
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

        public bool FilesFound
        {
            get;
            set;
        }

        private string categoryName;
        private Label lbl_NoCategories;
        private Label lbl_NoFiles;

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
                    IsMainCategory = false;
                    DataTable subCategory = new PostBAL().GetCategories(this.C);
                    this.repSubCat.DataSource = subCategory;
                    this.repSubCat.DataBind();

                    try
                    {
                        bool temp = subCategory.Rows[0] != null;
                        lbl_NoCategories.Visible = false;
                    }
                    catch
                    {
                        lbl_NoCategories.Visible = true;
                    }

                    DataTable post = new PostBAL().GetAllPosts(this.C);
                    post.Columns.Add("NAAM");
                    post.Columns.Add("UPLOADER");
                    post.Columns.Add("LIKES");
                    post.Columns.Add("FLAGS");

                    foreach(DataRow Row in post.Rows)
                    {
                        filename = Row.Field<string>("BESTANDSLOCATIE").Split('\\').Last();
                        Row["NAAM"] = filename;

                        int uploaderID = Convert.ToInt32(Row.Field<long>("ACCOUNT_ID"));
                        string[] accountData = new AccountBAL().SelectAccount(uploaderID);
                        Row["UPLOADER"] = accountData[0];

                        List<int> likeFlagcount = new PostBAL().GetLikeFlagCount(Row.Field<long>("ID").ToString());
                        Row["LIKES"] = likeFlagcount[0];
                        Row["FLAGS"] = likeFlagcount[1];
                    }
                    this.repFile.DataSource = post;
                    this.repFile.DataBind();

                    try
                    {
                        bool temp = post.Rows[0] != null;
                        lbl_NoFiles.Visible = false;
                        this.FilesFound = true;
                    }
                    catch
                    {
                        lbl_NoFiles.Visible = true;
                        this.FilesFound = false;
                    }
                    

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
                    IsMainCategory = true;
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
            string parentID = new PostBAL().GetParentCategoryID(this.C).ToString();

            if (new PostBAL().DeleteCategory(this.C) > 0)
            {
                Response.Write(string.Format("<script language=javascript>alert('Categorie {0} is succesvol verwijderd.');</script>", categoryName));

                if (parentID == "0")
                {
                    Response.Redirect("../Post/Category.aspx");
                }

                Response.Redirect("../Post/Category.aspx?catid=" + parentID);
            }
            else
            {
                Response.Write(string.Format("<script language=javascript>alert('Error: Categorie {0} kon niet worden verwijderd.');</script>", categoryName));
            }
        }

        /// <summary>
        /// On button click redirect user to the page for creating categories
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnCreateCat_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Post/CreateCategory.aspx");
        }

        protected void RepSubCat_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = (RepeaterItem)e.Item;
            if (item.ItemType == ListItemType.Header)
            {
                Literal litCateroy = (Literal)item.FindControl("litCategory");
                categoryName = new PostBAL().GetCategoryName(C);
                litCateroy.Text = "Categorie - " + categoryName;

                lbl_NoCategories = (Label)item.FindControl("lbl_NoCategories");
            }
        }

        protected void RepFile_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = (RepeaterItem)e.Item;
            if (item.ItemType == ListItemType.Header)
            {
                lbl_NoFiles = (Label)item.FindControl("lbl_NoFiles");
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            string parentID = new PostBAL().GetParentCategoryID(this.C).ToString();

            if (parentID == "0")
            {
                Response.Redirect("../Post/Category.aspx");
            }
            
            Response.Redirect("../Post/Category.aspx?catid=" + parentID);
        }
    }
}