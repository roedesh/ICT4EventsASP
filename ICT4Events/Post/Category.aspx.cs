namespace ICT4Events.Post
{
    using BAL;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class Category : System.Web.UI.Page
    {
        string c = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {


                c = Request.QueryString["catid"];
                if (c != null)
                {
                    DataTable SubCategory = new PostBAL().GetCategories(c);
                    this.repSubCat.DataSource = SubCategory;
                    this.repSubCat.DataBind();
                    DataTable Post = new PostBAL().GetAllPosts(c);
                    this.repFile.DataSource = Post;
                    this.repFile.DataBind();
                }

                if (c == null)
                {
                    DataTable Category = new PostBAL().GetCategories();
                    this.repMainCat.DataSource = Category;
                    this.repMainCat.DataBind();
                }
        }

        protected void btnCreatePost_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("../Post/CreatePost.aspx?catid="+c);
        }
    }
}