using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Events
{
    public partial class LoginForm : System.Web.UI.Page
    {
        private int counter;
        protected void Page_Load(object sender, EventArgs e)
        {
            counter = 0;
        }

        protected void bt_login_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseConnectionClass dcc = new DatabaseConnectionClass();
                dcc.Connect();
            }
            catch(Exception x)
            {
                Label1.Text = x.ToString();
                counter++;
            }
            finally
            {
                if (counter == 0)
                {
                    Label1.Text = "Succes";
                } counter = 0;
            }
        }
    }
}