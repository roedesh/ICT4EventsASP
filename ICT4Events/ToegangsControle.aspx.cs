// <copyright file="ToegangsControle.aspx.cs" company="ThomInc">
//      Copyright (c) ICT4Events. All rights reserved.
// </copyright>
// <author>Thom van Poppel</author>

namespace ICT4Events
{
    using System;
    using System.Collections.Generic;    
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using BAL;

    /// <summary>
    /// A class for managing the entry of the event.
    /// </summary>
    public partial class ToegangsControle : System.Web.UI.Page
    {
        /// <summary>
        /// Contains the data from the database
        /// </summary>
        private DataTable dt;

        /// <summary>
        /// A new instance to access the rentalBAL
        /// </summary>
        private BAL.RentalBAL rentalBal = new BAL.RentalBAL();

        /// <summary>
        /// A new instance to access the AccountBAL
        /// </summary>
        private BAL.AccountBAL accountBal = new BAL.AccountBAL();

        /// <summary>
        /// When the page is loaded for the first time update the grid view.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.TbBarcode.Focus();
            if (!this.IsPostBack)
            {
                this.dt = this.rentalBal.GetPersonByAanwezig(1);
                this.GvData.DataSource = this.dt;
                this.GvData.DataBind();
                this.GvData.DataSource = this.dt;
                this.GvData.DataBind();
            }
        }

        /// <summary>
        /// Search a person by barcode.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnSearchPerson0_Click(object sender, EventArgs e)
        {
            this.dt = this.rentalBal.GetAccountByBarcode(this.TbBarcode.Text);
            this.GvData.DataSource = this.dt;
            this.GvData.DataBind();
        }

        /// <summary>
        /// Search a person by id or name;
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnSearchPerson_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(this.TbSearchPerson.Text);
                this.dt = this.rentalBal.GetAccountByID(id);
            }
            catch
            {
                string name = this.TbSearchPerson.Text;
                this.dt = this.rentalBal.GetAccountByName(name);
            }

            this.GvData.DataSource = this.dt;
            this.GvData.DataBind();
            this.GvData.DataSource = this.dt;
            this.GvData.DataBind();
        }

        /// <summary>
        /// When a data table is bound to the grid view, update the grid view.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void GvData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.GvData, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        /// <summary>
        /// When a row is selected: Make it pink and check whether he has paid. Then update the User Interface.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void GvData_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in this.GvData.Rows)
            {
                row.BackColor = Color.White;
            }

            this.GvData.SelectedRow.BackColor = Color.Pink;
            string betaald = this.GvData.SelectedRow.Cells[9].Text;
            try
            {
                if (Convert.ToInt32(betaald) == 1)
                {
                    this.TbBetaald.BackColor = Color.Green;
                }
                else
                {
                    this.TbBetaald.BackColor = Color.Red;
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Set a person to be present or not present.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnCheckInOut_Click(object sender, EventArgs e)
        {
            string id = this.GvData.SelectedRow.Cells[0].Text;
            string aanwezig = this.GvData.SelectedRow.Cells[8].Text;
            try
            {
                int id2 = Convert.ToInt32(id);
                int aanwezig2 = Convert.ToInt32(aanwezig);
                if (aanwezig2 == 1)
                {
                    int test = this.rentalBal.UpdatePresence(id2, 0);
                }
                else if (aanwezig2 == 0)
                {
                    this.rentalBal.UpdatePresence(id2, 1);
                }

                Response.Redirect("ToegangsControle.aspx");
            }
            catch
            {
            }            
        }

        /// <summary>
        /// Get all the people present and update the User interface.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnShowAttendants_Click(object sender, EventArgs e)
        {
            DataTable dt = this.rentalBal.GetPersonByAanwezig(1);
            this.GvData.DataSource = dt;
            this.GvData.DataBind();
        }
    }
}