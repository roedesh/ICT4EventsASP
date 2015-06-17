using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using System.Drawing;

namespace ICT4Events
{
    public partial class ToegangsControle : System.Web.UI.Page
    {
        BAL.RentalBAL rentalBal = new BAL.RentalBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            tbBarcode.Focus();
            if(!IsPostBack)
            {
                DataTable dt = this.rentalBal.GetPersonByAanwezig(1);
                gvData.DataSource = dt;
                gvData.DataBind();
            }
        }

        protected void btnSearchPerson0_Click(object sender, EventArgs e)
        {
            DataTable dt = this.rentalBal.GetAccountByBarcode(tbBarcode.Text);
            gvData.DataSource = dt;
            gvData.DataBind();
        }

        protected void btnSearchPerson_Click(object sender, EventArgs e)
        {
            DataTable dt;
            try
            {
                int id = Convert.ToInt32(tbSearchPerson.Text);
                dt = this.rentalBal.GetAccountByID(id);
            }
            catch
            {
                string name = tbSearchPerson.Text;
                dt = this.rentalBal.GetAccountByName(name);
            }
            gvData.DataSource = dt;
            gvData.DataBind();
        }

        protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvData, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void gvData_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(GridViewRow row in gvData.Rows)
            {
                row.BackColor = Color.White;
            }
            gvData.SelectedRow.BackColor = Color.Pink;
            string betaald = gvData.SelectedRow.Cells[9].Text;
            try
            {
                if(Convert.ToInt32(betaald) == 1)
                {
                    tbBetaald.BackColor = Color.Green;
                }
                else
                {
                    tbBetaald.BackColor = Color.Red;
                }
            }
            catch
            {
                //kijk bij registreren, noob!
            }
        }

        protected void btnCheckInOut_Click(object sender, EventArgs e)
        {
            string id = gvData.SelectedRow.Cells[0].Text;
            string aanwezig = gvData.SelectedRow.Cells[8].Text;
            try
            {
                int id2 = Convert.ToInt32(id);
                int aanwezig2 = Convert.ToInt32(aanwezig);
                if(aanwezig2 == 1 )
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
                //foutmelding
            }
            
        }

        protected void btnShowAttendants_Click(object sender, EventArgs e)
        {
            DataTable dt = this.rentalBal.GetPersonByAanwezig(1);
            gvData.DataSource = dt;
            gvData.DataBind();
        }
    }
}