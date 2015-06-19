// <copyright file="ItemRental.aspx.cs" company="ThomInc">
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
    /// Class for managing items and renting them.
    /// </summary>
    public partial class ItemRental : System.Web.UI.Page
    {
        /// <summary>
        /// Often used data table that contains the info from the database
        /// </summary>
        private DataTable dt;

        /// <summary>
        /// An initiation of the business class used to get the information needed.
        /// </summary>
        private RentalBAL rentalBAL = new RentalBAL();

        /// <summary>
        /// Gets all the information from the database into the grid views.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.dt = this.rentalBAL.GetAllAvaillableItems(0);
                this.GvRental.DataSource = this.dt;
                this.GvRental.DataBind();
                this.dt = this.rentalBAL.GetAllItems();
                this.GvArtikel.DataSource = this.dt;
                this.GvArtikel.DataBind();
                string dateFormat = "d-MM-yyyy HH:mm:ss";
                string now = DateTime.Now.ToString(dateFormat);
                this.TbLeenUitDatum.Text = now;
            }
        }

        /// <summary>
        /// Get all the borrowed items.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            this.dt = this.rentalBAL.GetAllAvaillableItems(1);
            this.GvRental.DataSource = this.dt;
            this.GvRental.DataBind();
        }

        /// <summary>
        /// Gets all the items that aren't borrowed.
        /// </summary>
        /// <param name="sender">Auto generated</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnVrijeArtikelen_Click(object sender, EventArgs e)
        {
            this.dt = this.rentalBAL.GetAllAvaillableItems(0);
            this.GvRental.DataSource = this.dt;
            this.GvRental.DataBind();
        }

        /// <summary>
        /// Set an item to be rented out with the personal info attached
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnLeenUit_Click(object sender, EventArgs e)
        {
            int id = -1;
            try
            {
                id = Convert.ToInt32(this.TbLeenUitItemID.Text);
            }
            catch
            {
                // foutmelding
            }

            int succes = this.rentalBAL.CreateRental(id, this.TbLeenUitBarcode.Text, this.TbLeenUitDatum.Text);
            Response.Redirect("ItemRental.aspx");
        }

        /// <summary>
        /// When a data table is bound to a grid view, make a click event for the grid view.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void GvRental_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.GvRental, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        /// <summary>
        /// Makes the rows of the grid view pink when selected
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void GvRental_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in this.GvRental.Rows)
            {
                row.BackColor = Color.White;
            }

            this.GvRental.SelectedRow.BackColor = Color.Pink;
            this.TbLeenUitItemID.Text = this.GvRental.SelectedRow.Cells[0].Text;
        }

        /// <summary>
        /// When a data table is bound to a grid view, make a click event for the grid view.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void GvArtikel_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.GvArtikel, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        /// <summary>
        /// Makes the rows of the grid view pink when selected and updates the user interface.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void GvArtikel_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in this.GvArtikel.Rows)
            {
                row.BackColor = Color.White;
            }

            this.GvArtikel.SelectedRow.BackColor = Color.Pink;
            this.TbArtikelNaam.Text = this.GvArtikel.SelectedRow.Cells[1].Text;
            this.TbArtikelMerk.Text = this.GvArtikel.SelectedRow.Cells[3].Text;
            this.TbArtikelSerie.Text = this.GvArtikel.SelectedRow.Cells[4].Text;
            this.TbArtikelPrijs.Text = this.GvArtikel.SelectedRow.Cells[6].Text;
            this.TbArtikelAantal.Text = this.GvArtikel.SelectedRow.Cells[7].Text;
        }

        /// <summary>
        /// Add an item to the database and update the page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnArtikelVoegToe_Click(object sender, EventArgs e)
        {
            decimal prijs = 0;
            int aantal = 0;
            try
            {
                prijs = Convert.ToDecimal(this.TbArtikelPrijs.Text);
                aantal = Convert.ToInt32(this.TbArtikelAantal.Text);
            }
            catch
            {
                // invalid prijs of aantal
            }

            this.rentalBAL.CreateItem(this.TbArtikelNaam.Text, this.TbArtikelMerk.Text, this.TbArtikelSerie.Text, prijs, aantal);

            Response.Redirect("ItemRental.aspx");
        }

        /// <summary>
        /// Take a rented item and set it to be free to be rented again.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnNeemIn_Click(object sender, EventArgs e)
        {
            int id = -1;
            try
            {
                id = Convert.ToInt32(this.GvRental.SelectedRow.Cells[0].Text);
            }
            catch
            {
                // foutmelding
            }

            int succes = this.rentalBAL.UpdateExemplaar(id, 0);
            Response.Redirect("ItemRental.aspx");
        }

        /// <summary>
        /// Adjust the info of an item.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnArtikelPasAan_Click(object sender, EventArgs e)
        {
            decimal prijs = 0;
            int aantal = 0;
            try
            {
                prijs = Convert.ToDecimal(this.TbArtikelPrijs.Text);
                aantal = Convert.ToInt32(this.TbArtikelAantal.Text);
            }
            catch
            {
                // invalid prijs of aantal
            }

            this.rentalBAL.CreateItem(this.TbArtikelNaam.Text, this.TbArtikelMerk.Text, this.TbArtikelSerie.Text, prijs, aantal);
            Response.Redirect("ItemRental.aspx");
        }
    }
}