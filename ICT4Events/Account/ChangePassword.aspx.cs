namespace ICT4Events.Account
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using BAL;

    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER_ID"] != null)
            {
                tbUserName.Text = Session["USER_ID"].ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            AccountBAL aBal = new AccountBAL();

            DataTable account = aBal.GetAccount(tbUserName.Text, tbOldPassword.Text);
            if (account.Rows.Count == 0)
            {
                return;
            }
            aBal.UpdateAccount(Convert.ToInt32(account.Rows[0]["ID"]), tbNewPassword.Text);
        }
    }
}