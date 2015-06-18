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
        }
    }
}