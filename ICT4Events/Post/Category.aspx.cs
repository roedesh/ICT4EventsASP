using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BAL;

namespace ICT4Events.Post
{
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            string c = Request.QueryString["catid"];
                if(c != null)
                {
                    DataTable SubCategory = new PostBAL().GetCategories(c);
                    repSubCat.DataSource = SubCategory;
                    repSubCat.DataBind();
                }
                if(c == null)
                {
                    DataTable Category = new PostBAL().GetCategories();
                    repMainCat.DataSource = Category;
                    repMainCat.DataBind();
                }

        }
    }
}