// <copyright file="Post.aspx.cs" company="Ict4Events">
//      Copyright (c) ICT4Events. All rights reserved.
// </copyright>
// <author>Sander Koch</author>
namespace ICT4Events.Post
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using BAL;

    public partial class Post : System.Web.UI.Page
    {
        private string p = string.Empty;
        private int like = 0;
        private int flag = 0;
        private DataTable Submessages = new DataTable();

        public bool IsLoggedInAsAdmin
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.p = Request.QueryString["postid"];
            if (!this.IsPostBack)
            {
                this.p = Request.QueryString["postid"];
                if (this.p != null)
                {
                    DataTable post = new PostBAL().GetPost(this.p);
                    repPost.DataSource = post;
                    repPost.DataBind();
                    DataTable messages = new PostBAL().GetMessages(this.p);
                    repMessages.DataSource = messages;
                    repMessages.DataBind();
                    
                    if (this.p == null)
                    {
                        Response.Redirect("~/category.aspx");
                    }
                }
            }

            if (this.Session["User_ID"] == null)
            {
                Response.Redirect("~/account/login.aspx");
            }
            else if (this.Session["User_ID"] != null)
            {
                if ((this.like = new PostBAL().CheckLike(Session["User_ID"].ToString(), this.p)) > 0)
                {
                    btnLike.Text = "Unlike";
                    this.like = 1;
                }
                else
                {
                    btnLike.Text = "like";
                    this.like = 0;
                }

                if ((this.flag = new PostBAL().CheckFlag(Session["User_ID"].ToString(), this.p)) > 0)
                {
                    btnFlag.Text = "Gewenst";
                    this.flag = 1;
                }
                else
                {
                    btnFlag.Text = "Ongewenst";
                    this.flag = 0;
                }

                if (this.Session["USER_ROLE"].ToString() == "ADMIN")
                {
                    this.IsLoggedInAsAdmin = true;
                }
            }
        }

        protected void CommandBtn_Click(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Like":
                    if ((string)e.CommandArgument == string.Empty)
                    {
                        Response.Write("<script language=javascript>alert('Er is geen bestand om te liken');</script>");
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
                    if ((string)e.CommandArgument == string.Empty)
                    {
                        Response.Write("<script language=javascript>alert('Er is geen bestand om te flaggen');</script>");
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
                case "delete":
                    if ((string)e.CommandArgument == string.Empty)
                    {
                        Response.Write("<script language=javascript>alert('Post is niet bekend in database');</script>");
                    }
                    else
                    {
                        if (new PostBAL().DeletePost(e.CommandArgument.ToString()) > 0)
                        {
                            Response.Write("<script language=javascript>alert('Post is verwijderd');</script>");
                        }
                        else
                        {
                            Response.Write("<script language=javascript>alert('Post is niet verwijderd');</script>");
                        }
                    }

                    break;
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (new PostBAL().CreateMessage(Session["User_ID"].ToString(), tbTitle.Text, tbContent.Text, this.p) == 0)
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
            if (this.like == 0)
            {
                if ((this.like = new PostBAL().UpdateLike(Session["User_ID"].ToString(), this.p, 1)) > 0)
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
                if ((this.like = new PostBAL().UpdateLike(Session["User_ID"].ToString(), this.p, 0)) > 0)
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
            if (this.flag == 0)
            {
                if ((this.flag = new PostBAL().UpdateFlag(Session["User_ID"].ToString(), this.p, 1)) > 0)
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
                if ((this.flag = new PostBAL().UpdateFlag(Session["User_ID"].ToString(), this.p, 0)) > 0)
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

        private void repMessages_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
            {
                Repeater repSubMessages = (Repeater)item.FindControl("repSubMessage");
                repSubMessages.DataSource = this.Submessages;
                repSubMessages.DataBind();
            }
        }
    }
}