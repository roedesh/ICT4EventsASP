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
    using System.Net;

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
        /// String is used to store filepath
        /// </summary>
        private string filelocation = string.Empty;

        /// <summary>
        /// String is used to store filename
        /// </summary>
        public string filename = string.Empty;

        private int count = 0;
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

        private DataTable post = new DataTable();
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
            post = new PostBAL().GetPost(this.p);
            filelocation = post.Rows[0].Field<string>("BESTANDSLOCATIE");
            filename = filelocation.Split('\\').Last();
            if (!this.IsPostBack)
            {
                this.p = Request.QueryString["postid"];
                if (this.p != null)
                {
                    litFile.Text = "Bestand - " + filename;
                    img_Preview.ImageUrl = filelocation;
                   // ImageUrl="~/Media/78/Koala.jpg"

                    int uploaderID = Convert.ToInt32(post.Rows[0].Field<long>("ACCOUNT_ID"));
                    string[] accountData = new AccountBAL().SelectAccount(uploaderID);
                    lbl_Uploader.Text = accountData[0];
                    lbl_Date.Text = post.Rows[0].Field<DateTime>("DATUM").ToString();
                    lbl_Size.Text = this.BytesToString(post.Rows[0].Field<long>("GROOTTE"));

                    List<int> likeFlagcount = new PostBAL().GetLikeFlagCount(post.Rows[0].Field<long>("ID").ToString());
                    lbl_Likes.Text = likeFlagcount[0].ToString();
                    lbl_Flags.Text = likeFlagcount[1].ToString();

                    DataTable messages = new PostBAL().GetMessages(this.p);
                    messages.Columns.Add("Author");
                    messages.Columns.Add("Likes");
                    messages.Columns.Add("Flags");

                    foreach (DataRow row in messages.Rows)
                    {
                        int authorID = Convert.ToInt32(row.Field<long>("ACCOUNT_ID"));
                        string[] authorData = new AccountBAL().SelectAccount(authorID);
                        row["Author"] = authorData[0];

                        List<int> messageLikeFlags = new PostBAL().GetLikeFlagCount(row.Field<long>("ID").ToString());
                        row["Likes"] = messageLikeFlags[0];
                        row["Flags"] = messageLikeFlags[1];
                    }

                    //foreach (DataRow Row in post.Rows)
                    //{
                    //    filename = Row.Field<string>("BESTANDSLOCATIE").Split('\\').Last();
                    //    Row["NAAM"] = filename;

                    //    int uploaderID = Convert.ToInt32(Row.Field<long>("ACCOUNT_ID"));
                    //    string[] accountData = new AccountBAL().SelectAccount(uploaderID);
                    //    Row["UPLOADER"] = accountData[0];

                    //    List<int> likeFlagcount = new PostBAL().GetLikeFlagCount(Row.Field<long>("ID").ToString());
                    //    Row["LIKES"] = likeFlagcount[0];
                    //    Row["FLAGS"] = likeFlagcount[1];
                    //}

                    this.repMessages.DataSource = messages;
                    this.repMessages.DataBind();

                    foreach (RepeaterItem item in repMessages.Items)
                    {
                        Repeater repsubmessages = (Repeater)item.FindControl("repsubmessages");
                        try
                        {
                            DataTable tablesub = new PostBAL().GetMessages(messages.Rows[count].Field<Int64>("ID").ToString());
                            tablesub.Columns.Add("Author");
                            tablesub.Columns.Add("Likes");
                            tablesub.Columns.Add("Flags");

                            foreach (DataRow row in tablesub.Rows)
                            {
                                int authorID = Convert.ToInt32(row.Field<long>("ACCOUNT_ID"));
                                string[] authorData = new AccountBAL().SelectAccount(authorID);
                                row["Author"] = authorData[0];

                                List<int> messageLikeFlags = new PostBAL().GetLikeFlagCount(row.Field<long>("ID").ToString());
                                row["Likes"] = messageLikeFlags[0];
                                row["Flags"] = messageLikeFlags[1];

                            }

                            repsubmessages.DataSource = tablesub;
                            repsubmessages.DataBind();
                            count++;

                        }
                        catch
                        {
                            count++;
                        }
                    }
                }

                if (this.p == null)
                {
                    Response.Redirect("~/category.aspx");
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
                    this.btnLike.Text = "Like";
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

                //DataTable messages = new PostBAL().GetMessages(this.p);
                //DataTable tablesub = new PostBAL().GetMessages(messages.Rows[count].Field<Int64>("ID").ToString());
                //int subLike = 0;
                //int subFlag = 0;

                //foreach (DataRow row in tablesub.Rows)
                //{

                //    if (subLike == new PostBAL().CheckLike(Session["User_ID"].ToString(), row.Field<long>("BIJDRAGE_ID").ToString())) ;
                //    {
                        
                //    }


                //}


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
                        Response.Write("<script language=javascript>alert('Er is geen reactie om te liken.');</script>");
                    }
                    else
                    {
                        int mlike = new PostBAL().CheckLike(Session["User_ID"].ToString(), e.CommandArgument.ToString());
                        if (mlike == 0)
                        {
                            if ((mlike = new PostBAL().UpdateLike(Session["User_ID"].ToString(), e.CommandArgument.ToString(), 1)) > 0)
                            {
                                Response.Write("<script language=javascript>alert('De reactie is geliked.');</script>");
                                btnLike.Text = "Unlike";

                                Response.Redirect("../Post/Post.aspx?postid=" + post.Rows[0].Field<long>("ID").ToString());
                            }
                            else
                            {
                                Response.Write("<script language=javascript>alert('Er ging wat fout tijdens het liken.');</script>");
                            }
                        }
                        else
                        {
                            if ((mlike = new PostBAL().UpdateLike(Session["User_ID"].ToString(), e.CommandArgument.ToString(), 0)) > 0)
                            {
                                Response.Write("<script language=javascript>alert('De like op de reactie is verwijderd.');</script>");
                                btnLike.Text = "Like";

                                Response.Redirect("../Post/Post.aspx?postid=" + post.Rows[0].Field<long>("ID").ToString());
                            }
                            else
                            {
                                Response.Write("<script language=javascript>alert('Er ging wat fout tijdens het verwijderen van de dislike.');</script>");
                            }
                        }
                    }

                    break;
                case "Flag":
                    if ((string)e.CommandArgument == string.Empty)
                    {
                        Response.Write("<script language=javascript>alert('Er is geen reactie om als ongewenst te markeren.');</script>");
                    }
                    else
                    {
                        int mflag = new PostBAL().CheckFlag(Session["User_ID"].ToString(), e.CommandArgument.ToString());
                        if (mflag == 0)
                        {
                            if ((flag = new PostBAL().UpdateFlag(Session["User_ID"].ToString(), e.CommandArgument.ToString(), 1)) > 0)
                            {
                                Response.Write("<script language=javascript>alert('De reactie is als ongewenst gemarkeerd.');</script>");
                                btnFlag.Text = "Gewenst";

                                Response.Redirect("../Post/Post.aspx?postid=" + post.Rows[0].Field<long>("ID").ToString());
                            }
                            else
                            {
                                Response.Write("<script language=javascript>alert('Er ging wat fout tijdens het markeren als ongewenst.');</script>");
                            }
                        }
                        else
                        {
                            if ((flag = new PostBAL().UpdateFlag(Session["User_ID"].ToString(), e.CommandArgument.ToString(), 0)) > 0)
                            {
                                Response.Write("<script language=javascript>alert('De reactie is als gewenst gemarkeerd.');</script>");
                                btnFlag.Text = "Ongewenst";

                                Response.Redirect("../Post/Post.aspx?postid=" + post.Rows[0].Field<long>("ID").ToString());
                            }
                            else
                            {
                                Response.Write("<script language=javascript>alert('Er ging wat fout tijdens het markeren als gewenst.');</script>");
                            }
                        }
                    }

                    break;
                case "Delete":
                    if ((string)e.CommandArgument == string.Empty)
                    {
                        Response.Write("<script language=javascript>alert('Reactie is niet bekend in database.');</script>");
                    }
                    else
                    {
                        if (new PostBAL().DeletePost(e.CommandArgument.ToString()) > 0)
                        {
                            Response.Write("<script language=javascript>alert('De reactie is verwijderd.');</script>");

                            Response.Redirect("../Post/Post.aspx?postid=" + post.Rows[0].Field<long>("ID").ToString());
                        }
                        else
                        {
                            Response.Write("<script language=javascript>alert('Er ging wat fout tijdens het verwijderen.');</script>");
                        }
                    }

                    break;
                case "Reply":
                    {
                        Response.Redirect("~/Post/Reply.aspx?id=" + e.CommandArgument.ToString());
                    }
                    break;
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
                    Response.Write(string.Format("<script language=javascript>alert('Bestand {0} is geliked.');</script>", filename));
                    this.btnLike.Text = "Unlike";

                    Response.Redirect("../Post/Post.aspx?postid=" + post.Rows[0].Field<long>("ID").ToString());
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Er ging wat fout tijdens het liken.');</script>");
                }
            }
            else
            {
                if ((this.like = new PostBAL().UpdateLike(Session["User_ID"].ToString(), this.p, 0)) > 0)
                {
                    Response.Write(string.Format("<script language=javascript>alert('Like op bestand {0} is verwijderd.');</script>", filename));
                    this.btnLike.Text = "Like";

                    Response.Redirect("../Post/Post.aspx?postid=" + post.Rows[0].Field<long>("ID").ToString());
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Er ging wat fout tijdens het verwijderen van de like.');</script>");
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
                    Response.Write(string.Format("<script language=javascript>alert('Bestand {0} is als ongewenst gemarkeerd.');</script>", filename));
                    this.btnFlag.Text = "Gewenst";

                    Response.Redirect("../Post/Post.aspx?postid=" + post.Rows[0].Field<long>("ID").ToString());
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Er ging wat fout tijdens het markeren als ongewenst.');</script>");
                }
            }
            else
            {
                if ((this.flag = new PostBAL().UpdateFlag(Session["User_ID"].ToString(), this.p, 0)) > 0)
                {
                    Response.Write(string.Format("<script language=javascript>alert('Bestand {0} is als gewenst gemarkeerd.');</script>", filename));
                    this.btnFlag.Text = "Ongewenst";

                    Response.Redirect("../Post/Post.aspx?postid=" + post.Rows[0].Field<long>("ID").ToString());
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Er ging wat fout tijdens het markeren als gewenst.');</script>");
                }
            }
        }

        /// <summary>
        /// Method sends user to reply page
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnReply_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Post/Reply.aspx?id=" + p);
        }

        /// <summary>
        /// Method for handling download upon button click
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                WebClient req = new WebClient();
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.ClearContent();
                response.ClearHeaders();
                response.Buffer = true;
                response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");
                byte[] data = req.DownloadData(filelocation);
                response.BinaryWrite(data);
                response.End();
            }
            catch (Exception ex)
            {
                Response.Write(string.Format("<script language=javascript>alert('Er is een fout opgetreden: {0}');</script>", ex.ToString()));
            }
        }

        /// <summary>
        /// Event for handling deletion of post
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void BtnDel_Click(object sender, EventArgs e)
        {
            if (new PostBAL().DeletePost(p) > 0)
            {
                Response.Write(string.Format("<script language=javascript>alert('Bestand {0} is verwijderd.');</script>", filename));

                Response.Redirect("../Post/Category.aspx?catid=" + post.Rows[0].Field<long>("CATEGORIE_ID").ToString());
            }
            else
            {
                Response.Write(string.Format("<script language=javascript>alert('Bestand {0} is niet verwijderd.');</script>", filename));
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Post/Category.aspx?catid=" + post.Rows[0].Field<long>("CATEGORIE_ID").ToString());
        }

        private string BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
            if (byteCount == 0)
            {
                return "0" + suf[0];
            }

            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);

            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }
    }
}