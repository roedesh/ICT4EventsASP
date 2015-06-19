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
        public string C
        {
            get;
            set;
        }
        public bool IsLoggedInAsAdmin
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {


                C = Request.QueryString["catid"];
                if (C != null)
                {
                    DataTable SubCategory = new PostBAL().GetCategories(C);
                    this.repSubCat.DataSource = SubCategory;
                    this.repSubCat.DataBind();
                    DataTable Post = new PostBAL().GetAllPosts(C);
                    this.repFile.DataSource = Post;
                    this.repFile.DataBind();
                    if(Session["User_ID"] != null)
                    {
                        if (this.Session["USER_ROLE"].ToString() == "ADMIN")
                        {
                            this.IsLoggedInAsAdmin = true;
                        }
                    }
                }

                if (this.C == null)
                {
                    DataTable Category = new PostBAL().GetCategories();
                    this.repMainCat.DataSource = Category;
                    this.repMainCat.DataBind();
                }
        }

        protected void btnCreatePost_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("../Post/CreatePost.aspx?catid="+this.C);
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            if (new PostBAL().DeletePost(C) > 0)
            {
                Response.Write("<script language=javascript>alert('Post is verwijderd');</script>");
            }
            else
            {
                Response.Write("<script language=javascript>alert('Post is niet verwijderd');</script>");
            }
        }
    }
}