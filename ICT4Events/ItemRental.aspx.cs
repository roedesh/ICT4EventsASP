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
            if (this.Session["USER_ID"] == null)
            {
                Response.Redirect("~/account/login.aspx");
            }
            if (Session["USER_ROLE"].ToString() != "ADMIN")
            {
                Response.Redirect("~/default.aspx");
            }
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
            if (this.GvRental.SelectedIndex == -1)
            {
                Response.Write("<script>alert('Selecteer een rij');</script>");
                return;
            }
            if (this.TbLeenUitBarcode.Text == "")
            {
                Response.Write("<script>alert('Vul een barcode in');</script>");
                return;
            }
            if (this.TbLeenUitItemID.Text == null)
            {
                Response.Write("<script>alert('Vul een Item ID in');</script>");
                return;
            }
            if (this.TbLeenUitDatum.Text == null)
            {
                Response.Write("<script>alert('Vul een datum in');</script>");
                return;
            }
            int id = Convert.ToInt32(this.TbLeenUitItemID.Text);
            try
            {
                int succes = this.rentalBAL.CreateRental(id, this.TbLeenUitBarcode.Text, this.TbLeenUitDatum.Text);
                if (succes == 1)
                {
                    Response.Redirect("ItemRental.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Uitlenen mislukt');</script>");
                }
            }
            catch(Exception x)
            {
                Response.Write("<script>alert('Ongeldige barcode');</script>");
            }

            
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
            this.TbArtikelAantal.Text = this.GvArtikel.SelectedRow.Cells[8].Text;
        }

        /// <summary>
        /// Add an item to the database and update the page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnArtikelVoegToe_Click(object sender, EventArgs e)
        {
            double prijs = 0;
            int aantal = 0;
            if (this.TbArtikelNaam.Text == "" || TbArtikelMerk.Text == "" || TbArtikelSerie.Text == "")
            {
                Response.Write("<script>alert('Vul alle velden in.');</script>");
                return;
            }
            try
            {
                string prijsTemp = this.TbArtikelPrijs.Text;
                prijs = Convert.ToDouble(prijsTemp, new System.Globalization.CultureInfo("nl"));
            }
            catch
            {
                Response.Write("<script>alert('Ongeldige prijs.');</script>");
                return;
            } 
            try
            {
                aantal = Convert.ToInt32(this.TbArtikelAantal.Text);
            }
            catch
            {
                Response.Write("<script>alert('Ongeldig aantal.');</script>");
                return;
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
            if (this.GvRental.SelectedIndex == -1)
            {
                Response.Write("<script>alert('Selecteer een rij');</script>");
                return;
            }
            int id = Convert.ToInt32(this.GvRental.SelectedRow.Cells[0].Text);
            int succes = this.rentalBAL.UpdateExemplaar(id, 0);
            if (succes == 1)
            {
                Response.Redirect("ItemRental.aspx");
            }
            else
            {
                Response.Write("<script>alert('Innemen mislukt');</script>");
            }
        }

        /// <summary>
        /// Adjust the info of an item.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnArtikelPasAan_Click(object sender, EventArgs e)
        {
            double prijs = 0;
            int aantalNew = 0;
            if (this.TbArtikelNaam.Text == "" || TbArtikelMerk.Text == "" || TbArtikelSerie.Text == "")
            {
                Response.Write("<script>alert('Vul alle velden in.');</script>");
                return;
            }
            if(GvArtikel.SelectedIndex == -1)
            {
                Response.Write("<script>alert('Selecteer een product.');</script>");
                return;
            }
            try
            {
                prijs = Convert.ToDouble(this.TbArtikelPrijs.Text, new System.Globalization.CultureInfo("nl"));
                
            }
            catch
            {
                Response.Write("<script>alert('Ongeldige prijs.');</script>");
                return;
            }
            try
            {
                aantalNew = Convert.ToInt32(this.TbArtikelAantal.Text);

            }
            catch
            {
                Response.Write("<script>alert('Ongeldig aantal.');</script>");
                return;
            }
            int id = Convert.ToInt32(this.GvArtikel.SelectedRow.Cells[2].Text);
            int aantalOld = Convert.ToInt32(this.GvArtikel.SelectedRow.Cells[8].Text);
            int typenummer = Convert.ToInt32(this.GvArtikel.SelectedRow.Cells[7].Text);
            if(aantalNew < aantalOld)
            {
                Response.Write("<script>alert('Aantal kan niet minder zijn dan het originele aantal. Als je exemplaren wil verwijderen kan dat hierboven.');</script>");
                return;
            }
            int succes = this.rentalBAL.UpdateItem(id, this.TbArtikelNaam.Text, this.TbArtikelMerk.Text, this.TbArtikelSerie.Text, prijs, aantalOld, aantalNew,typenummer);
            Response.Redirect("ItemRental.aspx");
        }

        protected void BtnZoekenExemplaar_Click(object sender, EventArgs e)
        {
            this.dt = this.rentalBAL.LoadExemplaar(this.TbZoekExemplaar.Text);
            this.GvRental.DataSource = this.dt;
            this.GvRental.DataBind();
        }

        protected void BtnZoekenPersoon_Click(object sender, EventArgs e)
        {
            this.dt = this.rentalBAL.LoadRentalFromPerson(this.TbZoekPersoon.Text);
            this.GvZoekPersoon.DataSource = this.dt;
            this.GvZoekPersoon.DataBind();
        }

        protected void BtnVerwijder_Click(object sender, EventArgs e)
        {
            if (GvRental.SelectedIndex == -1)
            {
                Response.Write("<script>alert('Selecteer een rij.');</script>");
                return;
            }
            int id = Convert.ToInt32(GvRental.SelectedRow.Cells[0].Text);
            int status = this.rentalBAL.LoadItemStatus(id);
            if(status == -1)
            {
                Response.Write("<script>alert('Error. Kan het exemplaar niet vinden.');</script>");
                return;
            }
            if (status == 1)
            {
                Response.Write("<script>alert('Kan geen uitgeleende artikelen verwijderen. Neem het exemplaar eerst in.');</script>");
                return;
            }
            //delete all verhuur
            List<int> ids = this.rentalBAL.GetAllItemsFromVerhuur(id);
            foreach(int i in ids)
            {
                int succes = this.rentalBAL.DeleteVerhuur(i);
            }
            // delete het exemplaar
            this.rentalBAL.DeleteItem(id);
            Response.Redirect("ItemRental.aspx");
        }

        protected void BtnArtikelVerwijder_Click(object sender, EventArgs e)
        {
            if (GvArtikel.SelectedIndex == -1)
            {
                Response.Write("<script>alert('Selecteer een rij.');</script>");
                return;
            }
            //delete het aantal exemplaren
            int id = Convert.ToInt32(GvArtikel.SelectedRow.Cells[2].Text);
            List<int> ids = this.rentalBAL.GetAllItemsFromProduct(id);
            foreach(int i in ids)
            {
                //delete het aantal verhuurs
                List<int> idsVerhuur = this.rentalBAL.GetAllItemsFromVerhuur(i);
                foreach (int i2 in idsVerhuur)
                {
                    this.rentalBAL.DeleteVerhuur(i2);
                }
                this.rentalBAL.DeleteItem(i);
            }
            //delete het product
            this.rentalBAL.DeleteProduct(id);
            Response.Redirect("ItemRental.aspx");
        }
    }
}