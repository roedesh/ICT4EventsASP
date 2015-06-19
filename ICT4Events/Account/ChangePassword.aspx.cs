// <copyright file="ChangePassword.aspx.cs" company="RuudIT">
//      Copyright (c) ICT4Events. All rights reserved.
// </copyright>
// <author>Ruud Schroën</author>
namespace ICT4Events.Account
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
    /// WebForm for changing someone's password
    /// </summary>
    public partial class ChangePassword : System.Web.UI.Page
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
                tbUserName.Text = this.Session["USER_ID"].ToString();
            }
        }

        /// <summary>
        /// Click handler for the save button
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            AccountBAL aBal = new AccountBAL();

            DataTable account = aBal.GetAccount(this.tbUserName.Text, this.tbOldPassword.Text);
            if (account.Rows.Count == 0)
            {
                return;
            }

            aBal.UpdateAccount(Convert.ToInt32(account.Rows[0]["ID"]), this.tbNewPassword.Text);
        }
    }
}