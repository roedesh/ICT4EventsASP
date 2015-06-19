// <copyright file="Post.aspx.cs" company="Ict4Events">
//      Copyright (c) ICT4Events. All rights reserved.
// </copyright>
// <author>Sander Koch</author>
namespace ICT4Events.Post
{
    using BAL;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;

    public partial class Post : System.Web.UI.Page
    {
        string p = string.Empty;
        int like = 0;
        int flag = 0;
        DataTable Submessages = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            p = Request.QueryString["postid"];
            if (!IsPostBack)
            {
                p = Request.QueryString["postid"];
                if (p != null)
                {
                    DataTable Post = new PostBAL().GetPost(p);
                    repPost.DataSource = Post;
                    repPost.DataBind();
                    DataTable Messages = new PostBAL().GetMessages(p);
                    repMessages.DataSource = Messages;
                    repMessages.DataBind();
                    
                    if (p == null)
                    {

                    }
                }
            }
            if (Session["User_ID"] == null)
            {

            }
            else if (Session["User_ID"] != null)
            {

                if ((like = new PostBAL().CheckLike(Session["User_ID"].ToString(), p)) > 0)
                {
                    btnLike.Text = "Unlike";
                    like = 1;
                }
                else
                {
                    btnLike.Text = "like";
                    like = 0;
                }
                if ((flag = new PostBAL().CheckFlag(Session["User_ID"].ToString(), p)) > 0)
                {
                    btnFlag.Text = "Gewenst";
                    flag = 1;
                }
                else
                {
                    btnFlag.Text = "Ongewenst";
                    flag = 0;
                }
            }
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
                        int mlike = new PostBAL().CheckLike(Session["User_ID"].ToString(), e.CommandArgument.ToString());
                        if (mlike == 0)
                        {
                            if ((mlike = new PostBAL().UpdateLike(Session["User_ID"].ToString(), e.CommandArgument.ToString(), 1)) > 0)
                            {
                                Response.Write("<script language=javascript>alert('Bijdrage is geliked');</script>");
                                btnLike.Text = "Unlike";
                            }
                            else
                            {
                                Response.Write("<script language=javascript>alert('Er ging wat fout met het liken');</script>");
                            }
                        }
                        else
                        {
                            if ((mlike = new PostBAL().UpdateLike(Session["User_ID"].ToString(), e.CommandArgument.ToString(), 0)) > 0)
                            {
                                Response.Write("<script language=javascript>alert('Bijdrage is gedisliked');</script>");
                                btnLike.Text = "Like";
                            }
                            else
                            {
                                Response.Write("<script language=javascript>alert('Er ging wat fout met het disliken');</script>");
                            }
                        }
                    }
                    break;

                case "Flag":
                    if((string)e.CommandArgument == "")
                    {

                    }
                    else
                    {
                        int mflag = new PostBAL().CheckFlag(Session["User_ID"].ToString(), e.CommandArgument.ToString());
                        if (mflag == 0)
                        {
                            if ((flag = new PostBAL().UpdateFlag(Session["User_ID"].ToString(), e.CommandArgument.ToString(), 1)) > 0)
                            {
                                Response.Write("<script language=javascript>alert('De bijdrage is ongewenst gemarkeerd');</script>");
                                btnFlag.Text = "Unflag";
                            }
                            else
                            {
                                Response.Write("<script language=javascript>alert('Er ging wat fout met het ongewenst markeren');</script>");

                            }
                        }
                        else
                        {
                            if ((flag = new PostBAL().UpdateFlag(Session["User_ID"].ToString(), e.CommandArgument.ToString(), 0)) > 0)
                            {
                                Response.Write("<script language=javascript>alert('De bijdrage is gewenst gemarkeerd');</script>");
                                btnFlag.Text = "Flag";
                            }
                            else
                            {
                                Response.Write("<script language=javascript>alert('Er ging wat fout met het gewenst markeren');</script>");
                            }
                        }
                    }
                    break;
            }
        }

        private void repMessages_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            if((item.ItemType == ListItemType.Item )|| (item.ItemType == ListItemType.AlternatingItem) )
            {
                Repeater repSubMessages = (Repeater)item.FindControl("repSubMessage");
                repSubMessages.DataSource = Submessages;
                repSubMessages.DataBind();
                
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if(new PostBAL().CreateMessage(Session["User_ID"].ToString(), tbTitle.Text, tbContent.Text, p) == 0)
            {
                Response.Write("<script language=javascript>alert('Er ging wat fout met het toevoegen van het bericht');</script>");
            }
            else
            {
                Response.Write("<script language=javascript>alert('Bericht is toegevoegd');</script>");
            }
        }

        protected void btnLike_Click(object sender, EventArgs e)
        {
            if(like == 0)
            {
                if((like = new PostBAL().UpdateLike(Session["User_ID"].ToString(), p, 1)) > 0)
                {
                    Response.Write("<script language=javascript>alert('Bijdrage is geliked');</script>");
                    btnLike.Text = "Unlike";
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Er ging wat fout met het liken');</script>");
                }
            }
            else
            {
                if((like = new PostBAL().UpdateLike(Session["User_ID"].ToString(), p, 0)) > 0)
                {
                    Response.Write("<script language=javascript>alert('Bijdrage is gedisliked');</script>");
                    btnLike.Text = "Like";
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Er ging wat fout met het disliken');</script>");
                }
            }

        }

        protected void btnFlag_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                if ((flag = new PostBAL().UpdateFlag(Session["User_ID"].ToString(), p, 1)) > 0)
                {
                    Response.Write("<script language=javascript>alert('De bijdrage is ongewenst gemarkeerd');</script>");
                    btnFlag.Text = "Unflag";
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Er ging wat fout met het ongewenst markeren');</script>");
                                    
                }
            }
            else
            {
                if ((flag = new PostBAL().UpdateFlag(Session["User_ID"].ToString(), p, 0)) > 0)
                {
                    Response.Write("<script language=javascript>alert('De bijdrage is gewenst gemarkeerd');</script>");
                    btnFlag.Text = "Flag";
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Er ging wat fout met het gewenst markeren');</script>");
                }
            }
        }
    }
}