// <copyright file="Reply.aspx.cs" company="Ict4Events">
//      Copyright (c) ICT4Events. All rights reserved.
// </copyright>
// <author>Sander Koch</author>
namespace ICT4Events.Post
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using BAL;

    /// <summary>
    /// Reply webform page
    /// </summary>
    public partial class Reply : System.Web.UI.Page
    {
        /// <summary>
        /// String id is used to store id
        /// </summary>
        private string id = string.Empty;

        /// <summary>
        /// On page load this method will be triggered, everything inside this
        /// method will be executed.
        /// This builds the website content.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            {

                ViewState["PreviousPageURL"] = Request.UrlReferrer.ToString();
            }
            this.id = Request.QueryString["id"];

        }

        /// <summary>
        /// Creates a new message, and sends user back to previous page
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnReply_Click(object sender, EventArgs e)
        {
            if (new PostBAL().CreateMessage(Session["User_ID"].ToString(), this.tbTitle.Text, this.tbContent.Text, this.id) == 0)
            {
                Response.Write("<script language=javascript>alert('Er ging wat fout met het toevoegen van het bericht');</script>");
            }
            else
            {
                Response.Write("<script language=javascript>alert('Bericht is toegevoegd');</script>");
                Response.Redirect(ViewState["PreviousPageURL"].ToString());
            }
        }
    }
}