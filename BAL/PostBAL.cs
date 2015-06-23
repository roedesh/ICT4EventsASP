// <copyright file="PostBAL.cs" company="ICT4EventsASP">
//     Copyright (c) ICT4EventsASP. All rights reserved.
// </copyright>
// <author>Jeroen Pullich</author>
namespace BAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DAL;

    /// <summary>
    /// Class with the business layer for media sharing.
    /// </summary>
    public class PostBAL
    {
        #region Categorie

        /// <summary>
        /// Method for getting root categories.
        /// </summary>
        /// <returns>Returns a table with the data of root categories</returns>
        public DataTable GetCategories()
        {
            return new PostDAL().LoadRootCategories();
        }

        /// <summary>
        /// Method for getting child categories
        /// </summary>
        /// <param name="id">Identifier of parent category</param>
        /// <returns>Returns a table with the data of parent categories</returns>
        public DataTable GetCategories(string id)
        {
            return new PostDAL().LoadChildCategories(id);
        }

        /// <summary>
        /// Method for getting all categories
        /// </summary>
        /// <returns>Returns a table with data of all the categories</returns>
        public DataTable GetAllCategories()
        {
            return new PostDAL().LoadAllCategories();
        }

        /// <summary>
        /// Method for creating a category
        /// </summary>
        /// <param name="username">Username of the creator</param>
        /// <param name="categoryid">Identifier of potential parent category</param>
        /// <param name="name">Name of the category</param>
        /// <returns>Returns a "1" if the insert was successful, otherwise "0"</returns>
        public int CreateCategory(string username, string categoryid, string name)
        {
            return new PostDAL().InsertCategory(username, categoryid, name);
        }

        #endregion

        /// <summary>
        /// Method for getting all categories in a category
        /// </summary>
        /// <param name="id">Identifier of target category</param>
        /// <returns>Returns a table containing all file data</returns>
        public DataTable GetAllPosts(string id)
        {
            return new PostDAL().LoadCategoryFiles(id);
        }
        
        /// <summary>
        /// Method for getting target file
        /// </summary>
        /// <param name="id">Identifier of the file</param>
        /// <returns>Return a table containing the file data</returns>
        public DataTable GetPost(string id)
        {
            return new PostDAL().LoadFile(id);
        }

        /// <summary>
        /// Method for creating a file
        /// </summary>
        /// <param name="username">Username of the uploader</param>
        /// <param name="categoryID">Identifier of the category</param>
        /// <param name="location">Full path of the file on the server</param>
        /// <param name="size">Size of the file in bytes</param>
        /// <returns>Returns a "1" if the insert was successful, otherwise "0".</returns>
        public int CreateFile(string username, string categoryID, string location, string size)
        {
            return new PostDAL().InsertFile(username, categoryID, location, size);
        }

        /// <summary>
        /// Method for getting all messages on a post
        /// </summary>
        /// <param name="id">Identifier of target post</param>
        /// <returns>Returns a table with all message data</returns>
        public DataTable GetMessages(string id)
        {
            return new PostDAL().LoadPostMessages(id);
        }

        /// <summary>
        /// Method for creating a message
        /// </summary>
        /// <param name="username">Username of the author</param>
        /// <param name="title">Title of the message</param>
        /// <param name="content">Content of the message</param>
        /// <param name="targetid">Identifier of target post</param>
        /// <returns>Returns a "1" if the insert was successful, otherwise "0".</returns>
        public int CreateMessage(string username, string title, string content, string targetid)
        {
            return new PostDAL().InsertMessage(username, title, content, targetid);
        }

        /// <summary>
        /// Method for creating a like or flag
        /// </summary>
        /// <param name="username">Username of the creator</param>
        /// <param name="postid">Identifier of target post</param>
        /// <param name="like">State of the like, either "1" or "0"</param>
        /// <param name="flag">State of the flag, either "1" or "0"</param>
        /// <returns>Returns a "1" if the insert was successful, otherwise "0".</returns>
        public int CreateLikeFlag(string username, string postid, int like, int flag)
        {
            return new PostDAL().InsertLikeFlag(username, postid, like, flag);
        }

        /// <summary>
        /// Method for updating a like
        /// </summary>
        /// <param name="username">Username of the creator</param>
        /// <param name="postid">Identifier of target post</param>
        /// <param name="like">State of the like, either "1" or "0"</param>
        /// <returns>Returns a "1" if the insert was successful, otherwise "0".></returns>
        public int UpdateLike(string username, string postid, int like)
        {
            if (new PostDAL().CheckLikeFlag(username, postid) > 0)
            {
                return new PostDAL().UpdateLike(username, postid, like);
            }
            else
            {
                return new PostDAL().InsertLikeFlag(username, postid, like, 0);
            }         
        }

        /// <summary>
        /// Method for updating a flag
        /// </summary>
        /// <param name="username">Username of the creator</param>
        /// <param name="postid">Identifier of target post</param>
        /// <param name="flag">State of the like, either "1" or "0"</param>
        /// <returns>Returns a "1" if the insert was successful, otherwise "0".></returns>
        public int UpdateFlag(string username, string postid, int flag)
        {
            if (new PostDAL().CheckLikeFlag(username, postid) > 0)
            {
                return new PostDAL().UpdateFlag(username, postid, flag);
            }
            else
            {
                return new PostDAL().InsertLikeFlag(username, postid, 0, flag);
            }
        }

        /// <summary>
        /// Method used for checking the like of a user on a post
        /// </summary>
        /// <param name="username">Username of the liker</param>
        /// <param name="postid">Identifier of target post</param>
        /// <returns>Returns a "1" if the insert was successful, otherwise "0".</returns>
        public int CheckLike(string username, string postid)
        {
            int like = 1;
            return new PostDAL().CheckLike(username, postid, like);
        }

        /// <summary>
        /// Method used for checking the flag of a user on a post
        /// </summary>
        /// <param name="username">Username of the flagger</param>
        /// <param name="postid">Identifier of target post</param>
        /// <returns>Returns a "1" if the insert was successful, otherwise "0".</returns>
        public int CheckFlag(string username, string postid)
        {
            int flag = 1;
            return new PostDAL().CheckFlag(username, postid, flag);
        }

        /// <summary>
        /// Method used for deleting a post
        /// </summary>
        /// <param name="postid">Identifier of target post</param>
        /// <returns>Returns a "1" if the insert was successful, otherwise "0".</returns>
        public int DeletePost(string postid)
        {
            return new PostDAL().DeletePost(postid);
        }

        public int DeleteCategory(string id)
        {
            PostDAL postdal = new PostDAL();
            int result = 0;

            DataTable childs =postdal.LoadChildCategories(id);
            foreach (DataRow child in childs.Rows)
            {
                result = postdal.DeletePost(child.Field<long>("BIJDRAGE_ID").ToString());
            }

            result = postdal.DeletePost(id);

            return result;
        }

        public string GetCategoryName(string id)
        {
            return new PostDAL().GetCategoryName(id);
        }

        public int GetParentCategoryID(string childID)
        {
            return new PostDAL().GetParentCategoryID(childID);
        }

        public List<int> GetLikeFlagCount(string id)
        {
            return new PostDAL().GetLikeFlagCount(id);

        }
    }
}
