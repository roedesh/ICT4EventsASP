// <copyright file="Site.Master.cs" company="RuudIT">
//      Copyright (c) ICT4Events. All rights reserved.
// </copyright>
// <author>Ruud Schroën</author>
namespace ICT4Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    /// <summary>
    /// The main master page
    /// </summary>
    public partial class Site : System.Web.UI.MasterPage
    {
        /// <summary>
        /// Gets or sets a value indicating whether a user is logged in or not.
        /// </summary>
        public bool IsLoggedIn
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether a user is an administrator.
        /// </summary>
        public bool IsLoggedInAsAdmin
        {
            get;
            set;
        }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["USER_ID"] != null)
            {
                this.lbWelkom.Text = "(Welkom " + this.Session["USER_ID"] + ")";
                this.IsLoggedIn = true;

                if (this.Session["USER_ROLE"].ToString() == "ADMIN")
                {
                    this.IsLoggedInAsAdmin = true;
                }
            }
            else
            {
                this.lbWelkom.Text = string.Empty;
                this.IsLoggedIn = false;
                this.IsLoggedInAsAdmin = false;
            }
        }
    }
}