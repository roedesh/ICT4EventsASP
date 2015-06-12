using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Events.Reservering
{
    public partial class PlaatsReservering : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void calBeginData_SelectionChanged(object sender, EventArgs e)
        {
            cusValBeginDate.Validate();
        }

        protected void cusValBeginDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (calBeginData.SelectedDate <= DateTime.Now)
            {
                args.IsValid = false;
            }
        }

        protected void calEndDate_SelectionChanged(object sender, EventArgs e)
        {
            cusValEndDate.Validate();
        }

        protected void cusValEndDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (calEndDate.SelectedDate <= calBeginData.SelectedDate)
            {
                args.IsValid = false;
            }
        }

    }
}