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

    public partial class ItemRental : System.Web.UI.Page
    {
        DataTable dt;
        RentalBAL rentalBAL = new RentalBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.dt = this.rentalBAL.GetAllAvaillableItems(0);
                this.gvRental.DataSource = dt;
                this.gvRental.DataBind();
                this.dt = this.rentalBAL.GetAllItems();
                this.gvArtikel.DataSource = dt;
                this.gvArtikel.DataBind();
                string dateFormat = "d-MM-yyyy HH:mm:ss";
                string now = DateTime.Now.ToString(dateFormat);
                this.tbLeenUitDatum.Text = now;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.dt = this.rentalBAL.GetAllAvaillableItems(1);
            this.gvRental.DataSource = dt;
            this.gvRental.DataBind();
        }

        protected void btnVrijeArtikelen_Click(object sender, EventArgs e)
        {
            this.dt = this.rentalBAL.GetAllAvaillableItems(0);
            this.gvRental.DataSource = dt;
            this.gvRental.DataBind();
        }

        protected void btnLeenUit_Click(object sender, EventArgs e)
        {
            int id = -1;
            try
            {
                id = Convert.ToInt32(tbLeenUitItemID.Text);
            }
            catch
            {
                //foutmelding
            }
            int succes = rentalBAL.CreateRental(id, tbLeenUitBarcode.Text, tbLeenUitDatum.Text);
            Response.Redirect("ItemRental.aspx");
        }

        protected void gvRental_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.gvRental, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void gvRental_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in this.gvRental.Rows)
            {
                row.BackColor = Color.White;
            }

            this.gvRental.SelectedRow.BackColor = Color.Pink;
            this.tbLeenUitItemID.Text = this.gvRental.SelectedRow.Cells[0].Text;

        }

        protected void gvArtikel_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.gvArtikel, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void gvArtikel_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in this.gvArtikel.Rows)
            {
                row.BackColor = Color.White;
            }

            this.gvArtikel.SelectedRow.BackColor = Color.Pink;
            this.tbArtikelNaam.Text = this.gvArtikel.SelectedRow.Cells[1].Text;
            this.tbArtikelMerk.Text = this.gvArtikel.SelectedRow.Cells[3].Text;
            this.tbArtikelSerie.Text = this.gvArtikel.SelectedRow.Cells[4].Text;
            this.tbArtikelPrijs.Text = this.gvArtikel.SelectedRow.Cells[6].Text;
            this.tbArtikelAantal.Text = this.gvArtikel.SelectedRow.Cells[7].Text;
        }

        protected void btnArtikelVoegToe_Click(object sender, EventArgs e)
        {
            decimal prijs = 0;
            int aantal = 0;
            try
            {
                prijs = Convert.ToDecimal(tbArtikelPrijs.Text);
                aantal = Convert.ToInt32(tbArtikelAantal.Text);
            }
            catch
            {
                //invalid prijs of aantal
            }
            this.rentalBAL.CreateItem(tbArtikelNaam.Text,tbArtikelMerk.Text, tbArtikelSerie.Text, prijs, aantal);
            Response.Redirect("ItemRental.aspx");
        }

    }
}