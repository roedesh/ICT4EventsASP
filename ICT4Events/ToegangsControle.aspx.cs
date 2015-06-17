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

    public partial class ToegangsControle : System.Web.UI.Page
    {
        private BAL.AccountBAL accountBal = new BAL.AccountBAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.tbBarcode.Focus();
            if (!this.IsPostBack)
            {
                DataTable dt = this.accountBal.GetPersonByAanwezig(1);
                this.gvData.DataSource = dt;
                this.gvData.DataBind();
            }
        }

        protected void btnSearchPerson0_Click(object sender, EventArgs e)
        {
            DataTable dt = this.accountBal.GetAccountByBarcode(this.tbBarcode.Text);
            this.gvData.DataSource = dt;
            this.gvData.DataBind();
        }

        protected void btnSearchPerson_Click(object sender, EventArgs e)
        {            
        }

        protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.gvData, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

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
                    int test = this.accountBal.UpdatePresence(id2, 0);
                }
                else if (aanwezig2 == 0)
                {
                    this.accountBal.UpdatePresence(id2, 1);
                } 

                Response.Redirect("ToegangsControle.aspx");
            }
            catch
            {
            }            
        }

        protected void btnShowAttendants_Click(object sender, EventArgs e)
        {
            DataTable dt = this.accountBal.GetPersonByAanwezig(1);
            this.gvData.DataSource = dt;
            this.gvData.DataBind();
        }
    }
}