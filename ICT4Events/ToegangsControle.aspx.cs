using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;

namespace ICT4Events
{
    public partial class ToegangsControle : System.Web.UI.Page
    {
        BAL.AccountBAL accountBal = new BAL.AccountBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            tbBarcode.Focus();
            imgPaymentStatus.ImageUrl = "";
            imgPaymentStatus.ImageUrl = "";
            imgPaymentStatus.ImageUrl = "";
        }

        protected void btnSearchPerson0_Click(object sender, EventArgs e)
        {
            lbPersonInfo.Items.Clear();
            DataTable dt = this.accountBal.GetAccountByBarcode(tbBarcode.Text);
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    string naam = row.Field<string>(1); 
                    string tussenvoegsel = row.Field<string>(2);
                    string achternaam = row.Field<string>(3);
                    short betaald = row.Field<short>(8);
                    string info = naam + " " + tussenvoegsel + " " + achternaam +": ";
                    if (betaald == 1)
                    {
                        info += "Betaald";
                    }
                    else
                    {
                        info += "Niet betaald";
                    }
                    lbPersonInfo.Items.Add(info);
                    info = "";

                }
            }
            catch
            {

            }
        }
    }
}