namespace ICT4Events.Post

{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;
    using BAL;

    public partial class Post : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string p = Request.QueryString["postid"];
                if (p != null)
                {
                    DataTable Post = new PostBAL().GetPost(p);
                    repPost.DataSource = Post;
                    repPost.DataBind();
                    DataTable Messages = new PostBAL().GetMessages(p);
                    repMessages.DataSource = Messages;
                    repMessages.DataBind();
                }
                if (p == null)
                {

                }
            }
           
        }

        protected void btnLike_Click(object sender, EventArgs e)
        {
            Response.Write("<script language=javascript>alert(hiii);</script>");
        }

        protected void btnFlag_Click(object sender, EventArgs e)
        {

        }

        protected void CommandBtn_Click(object sender, CommandEventArgs e)
        {
            switch(e.CommandName)
            {
                case "Like":
                    if((string)e.CommandArgument == "")
                    {

                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert('"+(string)e.CommandArgument+"');</script>");
                    }
                    break;

                case "Flag":
                    if((string)e.CommandArgument == "")
                    {

                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert('" + (string)e.CommandArgument + "');</script>");
                    }
                    break;
            }
        }

        protected void repMessagesCommand(object Sender, RepeaterCommandEventArgs e)
            {
                switch (e.CommandName)
                {
                    case "Like":
                        if ((string)e.CommandArgument == "")
                        {

                        }
                        else
                        {
                            Response.Write("<script language=javascript>alert('" + (string)e.CommandArgument + "');</script>");
                        }
                        break;

                    case "Flag":
                        if ((string)e.CommandArgument == "")
                        {

                        }
                        else
                        {
                            Response.Write("<script language=javascript>alert('" + (string)e.CommandArgument + "');</script>");
                        }
                        break;
                }

            }

        protected void btnMLike_Command(object sender, CommandEventArgs e)
        {

        }
         
    }
}