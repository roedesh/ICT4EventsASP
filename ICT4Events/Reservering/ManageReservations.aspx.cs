using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace ICT4Events.Reservering
{
    public partial class ManageReservations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                // get the categoryID of the clicked row
                int resID = Convert.ToInt32(e.CommandArgument);
                // Delete the record 
                new ReservationBAL().Delete(resID);
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int resID = (int)GridView1.DataKeys[e.RowIndex].Value;
            new ReservationBAL().Delete(resID);
        }
    }
}