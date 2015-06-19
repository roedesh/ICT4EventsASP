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

    /// <summary>
    /// WebForm used to display Post and messages.
    /// </summary>
    public partial class Post : System.Web.UI.Page
    {
        /// <summary>
        /// p is used for holding the PostID parameter
        /// </summary>
        private string p = string.Empty;

        /// <summary>
        /// like is used to keep track if a post id has already been
        /// liked by a user
        /// </summary>
        private int like = 0;

        /// <summary>
        /// flag is used to keep track if a post id has already been flagged by a user
        /// </summary>
        private int flag = 0;

        /// <summary>
        /// A data table made to keep all the values of the child messages of a message
        /// </summary>
        private DataTable submessages = new DataTable();

        /// <summary>
        /// Gets or sets a value indicating whether IsLoggedInAsAdmin is true or false
        /// </summary>
        public bool IsLoggedInAsAdmin
        {
            get;
            set;
        }

        /// <summary>
        /// On page load this method will be triggered, everything inside this
        /// method will be executed.
        /// This builds the website content.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.p = Request.QueryString["postid"];
            if (!this.IsPostBack)
            {
                this.p = Request.QueryString["postid"];
                if (this.p != null)
                {
                    DataTable post = new PostBAL().GetPost(this.p);
                    this.repPost.DataSource = post;
                    this.repPost.DataBind();
                    DataTable messages = new PostBAL().GetMessages(this.p);
                    this.repMessages.DataSource = messages;
                    this.repMessages.DataBind();
                    
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
                    this.btnLike.Text = "Unlike";
                    this.like = 1;
                }
                else
                {
                    this.btnLike.Text = "like";
                    this.like = 0;
                }

                if ((this.flag = new PostBAL().CheckFlag(Session["User_ID"].ToString(), this.p)) > 0)
                {
                    this.btnFlag.Text = "Gewenst";
                    this.flag = 1;
                }
                else
                {
                    this.btnFlag.Text = "Ongewenst";
                    this.flag = 0;
                }

                if (this.Session["USER_ROLE"].ToString() == "ADMIN")
                {
                    this.IsLoggedInAsAdmin = true;
                }
            }
        }

        /// <summary>
        /// Creates a button click event, which will trigger
        /// when at the http side of the application Buttons use OnCommand.
        /// By using Command we can send extra arguments to this method.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Upon clicking of the button Send, this method will be triggered.
        /// Which will create a message containing the information send with the Create Message method.
        /// Will return message depending on result.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnSend_Click(object sender, EventArgs e)
        {
            if (new PostBAL().CreateMessage(Session["User_ID"].ToString(), this.tbTitle.Text, this.tbContent.Text, this.p) == 0)
            {
                Response.Write("<script language=javascript>alert('Er ging wat fout met het toevoegen van het bericht');</script>");
            }
            else
            {
                Response.Write("<script language=javascript>alert('Bericht is toegevoegd');</script>");
            }
        }

        /// <summary>
        /// This method uses the like integer to check if a user has already liked said post.
        /// If the user hasn't liked this post, it will call the Update Like Method from POST BAL.
        /// Will return message depending on result.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnLike_Click(object sender, EventArgs e)
        {
            if (this.like == 0)
            {
                if ((this.like = new PostBAL().UpdateLike(Session["User_ID"].ToString(), this.p, 1)) > 0)
                {
                    Response.Write("<script language=javascript>alert('Bijdrage is geliked');</script>");
                    this.btnLike.Text = "Unlike";
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
                    this.btnLike.Text = "Like";
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Er ging wat fout met het disliken');</script>");
                }
            }
        }

        /// <summary>
        /// This method uses the flag integer to check if a user has already flagged said post.
        /// If the user hasn't flag this post, it will call the Update Like flag from POST BAL.
        /// Will return message depending on result.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnFlag_Click(object sender, EventArgs e)
        {
            if (this.flag == 0)
            {
                if ((this.flag = new PostBAL().UpdateFlag(Session["User_ID"].ToString(), this.p, 1)) > 0)
                {
                    Response.Write("<script language=javascript>alert('De bijdrage is ongewenst gemarkeerd');</script>");
                    this.btnFlag.Text = "Unflag";
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
                    this.btnFlag.Text = "Flag";
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Er ging wat fout met het gewenst markeren');</script>");
                }
            }
        }

        /// <summary>
        /// This method builds the data source of the nested repeater
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Web.UI.WebControls.RepeaterItemEventArgs"/> instance containing the event data.</param>
        private void RepMessages_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
            {
                Repeater repsubmessages = (Repeater)item.FindControl("repSubMessage");
                repsubmessages.DataSource = this.submessages;
                repsubmessages.DataBind();
            }
        }
    }
}