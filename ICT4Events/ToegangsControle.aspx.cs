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
        DataTable dt;
        BAL.RentalBAL rentalBal = new BAL.RentalBAL();
        private BAL.AccountBAL accountBal = new BAL.AccountBAL();

        /// <summary>
        /// When the page is loaded for the first time update the gridview.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.tbBarcode.Focus();
            if (!this.IsPostBack)
            {
                this.dt = this.rentalBal.GetPersonByAanwezig(1);
                gvData.DataSource = dt;
                gvData.DataBind();
                this.gvData.DataSource = dt;
                this.gvData.DataBind();
            }
        }

        /// <summary>
        /// Search a person by barcode.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btnSearchPerson0_Click(object sender, EventArgs e)
        {
            this.dt = this.rentalBal.GetAccountByBarcode(tbBarcode.Text);
            gvData.DataSource = dt;
            gvData.DataBind();
        }

        /// <summary>
        /// Search a person by id or name;
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btnSearchPerson_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(tbSearchPerson.Text);
                this.dt = this.rentalBal.GetAccountByID(id);
            }
            catch
            {
                string name = tbSearchPerson.Text;
                this.dt = this.rentalBal.GetAccountByName(name);
            }
            gvData.DataSource = dt;
            gvData.DataBind();
            this.gvData.DataSource = dt;
            this.gvData.DataBind();
        }


        /// <summary>
        /// When a datatable is bound to the gridview, update the gridview.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.gvData, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        /// <summary>
        /// When a row is selected: Make it pink and check whether he has paid. Then update the gui.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void gvData_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in this.gvData.Rows)
            {
                row.BackColor = Color.White;
            }

            this.gvData.SelectedRow.BackColor = Color.Pink;
            string betaald = this.gvData.SelectedRow.Cells[9].Text;
            try
            {
                if (Convert.ToInt32(betaald) == 1)
                {
                    this.tbBetaald.BackColor = Color.Green;
                }
                else
                {
                    this.tbBetaald.BackColor = Color.Red;
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
        protected void btnCheckInOut_Click(object sender, EventArgs e)
        {
            string id = this.gvData.SelectedRow.Cells[0].Text;
            string aanwezig = this.gvData.SelectedRow.Cells[8].Text;
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
        /// Get all the people present and update the gui.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btnShowAttendants_Click(object sender, EventArgs e)
        {
            DataTable dt = this.rentalBal.GetPersonByAanwezig(1);
            this.gvData.DataSource = dt;
            this.gvData.DataBind();
        }
    }
}