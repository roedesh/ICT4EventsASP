// <copyright file="CreateCategory.aspx.cs" company="Ict4Events">
//      Copyright (c) ICT4Events. All rights reserved.
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
    /// WebForm for creating a new category.
    /// </summary>
    public partial class CreateCategory : System.Web.UI.Page
    {
        /// <summary>
        /// On page load this method will be triggered, everything inside this
        /// method will be executed.
        /// This builds the website content.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataTable categories = new PostBAL().GetAllCategories();
                this.ddlCategory.DataSource = categories;
                this.ddlCategory.DataTextField = "NAAM";
                this.ddlCategory.DataValueField = "NAAM";
                this.ddlCategory.DataBind();
                this.ddlCategory.Items.Insert(0, string.Empty);
                ViewState["PreviousPageURL"] = Request.UrlReferrer.ToString();
            }
        }

        /// <summary>
        /// Calls two different methods in BAL depending on the selected value
        /// in the drop down list category.
        /// Depending on the selected value, the category made
        /// will either be a parent category, or a child.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnCategory_Click(object sender, EventArgs e)
        {
            if (this.ddlCategory.SelectedValue == string.Empty)
            {
                if (new PostBAL().CreateCategory(Session["User_ID"].ToString(), string.Empty, this.tbCategory.Text) == 0)
                {
                    Response.Write("<script language=javascript>alert('Er ging wat fout met het toevoegen van de categorie');</script>");
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Categorie is toegevoegd');</script>");
                    Response.Redirect(ViewState["PreviousPageURL"].ToString());
                }
            }
            else
            {
                if (new PostBAL().CreateCategory(Session["User_ID"].ToString(), this.ddlCategory.SelectedValue, this.tbCategory.Text) == 0)
                {
                    Response.Write("<script language=javascript>alert('Er ging wat fout met het toevoegen van de categorie');</script>");
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Categorie is toegevoegd');</script>");
                    Response.Redirect(ViewState["PreviousPageURL"].ToString());
                }
            }
        }
    }
}