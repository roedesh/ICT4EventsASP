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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton l = (LinkButton)e.Row.FindControl("btDelete");
                l.Attributes.Add("onclick", "javascript:return " +
                "confirm('Weet je zeker dat je dit record wil verwijderen? " +
                DataBinder.Eval(e.Row.DataItem, "ID") + "')");
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                // get the categoryID of the clicked row
                int resID = Convert.ToInt32(e.CommandArgument);
                // Delete the record 
                new ReservationBAL().DeleteReservation(resID);
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int resID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            new ReservationBAL().DeleteReservation(resID);
        }
    }
}