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
        private string data;
        protected void Page_Load(object sender, EventArgs e)
        {
            counter = 0;

            if (Session["username"] != null)
            {
                Label1.Text = Session["username"].ToString();
            }
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
                data = x.ToString();
                counter++;
            }
            finally
            {
                if (counter == 0)
                {
                    data = "succes";
                    Session["username"] = data;
                } counter = 0;
            }
        }
    }
}