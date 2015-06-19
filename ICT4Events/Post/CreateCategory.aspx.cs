// <copyright file="CreateCategory.aspx.cs" company="Ict4Events">
//      Copyright (c) ICT4Events. All rights reserved.
// </copyright>
// <author>Sander Koch</author>
namespace ICT4Events.Post
{
using BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
    
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
            if (!IsPostBack)
            {
                DataTable categories = new PostBAL().GetAllCategories();
                ddlCategory.DataSource = categories;
                ddlCategory.DataTextField = "NAAM";
                ddlCategory.DataValueField = "NAAM";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, string.Empty);
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
        protected void btnCategory_Click(object sender, EventArgs e)
        {

            if(ddlCategory.SelectedValue == string.Empty)
            {
                if (new PostBAL().CreateCategory((Session["User_ID"].ToString()), string.Empty, tbCategory.Text) == 0)
                {
                    Response.Write("<script language=javascript>alert('Er ging wat fout met het toevoegen van de categorie');</script>");
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Categorie is toegevoegd');</script>");
                }
            }
            else
            {
                if (new PostBAL().CreateCategory((Session["User_ID"].ToString()), ddlCategory.SelectedValue, tbCategory.Text) == 0)
                {
                    Response.Write("<script language=javascript>alert('Er ging wat fout met het toevoegen van de categorie');</script>");
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Categorie is toegevoegd');</script>");
                }
            }

        }
    }
}