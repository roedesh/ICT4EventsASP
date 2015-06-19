// <copyright file="Logout.aspx.cs" company="JonneIT">
//      Copyright (c) ICT4Events. All rights reserved.
// </copyright>
// <author>Jonne van Dreven</author>
namespace ICT4Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    /// <summary>
    /// WebForm for logging out a users
    /// </summary>
    public partial class Logout : System.Web.UI.Page
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["USER_ID"] != null)
            {
                // logout:
                Session.Remove("USER_ID");
                Session.RemoveAll();
                Response.Write("<script>alert('u bent succesvol uitgelogd');</script>");
                Response.Redirect("../Default.aspx");
            }
            else
            {
                Response.Redirect("../Account/Login.aspx");
            }
        }
    }
}