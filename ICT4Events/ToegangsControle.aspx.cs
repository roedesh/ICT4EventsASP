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
        BAL.AccountBAL accountBal = new BAL.AccountBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            tbBarcode.Focus();
            if(!IsPostBack)
            {
                DataTable dt = this.accountBal.GetPersonByAanwezig(1);
                gvData.DataSource = dt;
                gvData.DataBind();
            }
        }

        protected void btnSearchPerson0_Click(object sender, EventArgs e)
        {
            DataTable dt = this.accountBal.GetAccountByBarcode(tbBarcode.Text);
            gvData.DataSource = dt;
            gvData.DataBind();
        }

        protected void btnSearchPerson_Click(object sender, EventArgs e)
        {
            
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

        }

        protected void btnShowAttendants_Click(object sender, EventArgs e)
        {
            DataTable dt = this.accountBal.GetPersonByAanwezig(1);
            gvData.DataSource = dt;
            gvData.DataBind();
        }
    }
}