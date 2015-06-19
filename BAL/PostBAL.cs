namespace BAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using DAL;

    public class PostBAL
    {
        #region Categorie

        public DataTable GetCategories()
        {
            return new PostDAL().LoadRootCategories();
        }

        public DataTable GetCategories(string id)
        {
            return new PostDAL().LoadChildCategories(id);
        }

        public DataTable GetAllCategories()
        {
            return new PostDAL().LoadAllCategories();
        }

        public int CreateCategory(string username, string categoryid, string name)
        {
            return new PostDAL().InsertCategory(username, categoryid, name);
        }

        #endregion

        public DataTable GetAllPosts(string id)
        {
            return new PostDAL().LoadCategoryFiles(id);
        }
        
        public DataTable GetPost(string id)
        {
            return new PostDAL().LoadFile(id);
        }

        public int CreateFile(string username, string categoryID, string location, string size)
        {
            return new PostDAL().InsertFile(username, categoryID, location, size);
        }
        public DataTable GetMessages(string id)
        {
            return new PostDAL().LoadPostMessages(id);
        }

        public int CreateMessage(string username, string title, string content, string targetid)
        {
            return new PostDAL().InsertMessage(username, title, content, targetid);
        }

        public int CreateLikeFlag(string username, string postid, int like, int flag)
        {
            return new PostDAL().InsertLikeFlag(username, postid, like, flag);
        }
        public int UpdateLike(string username, string postid, int like)
        {
            if(new PostDAL().CheckLikeFlag(username, postid) > 0)
            {
                return new PostDAL().UpdateLike(username, postid, like);
            }
            else
            {
                return new PostDAL().InsertLikeFlag(username, postid, like, 0);
            }
            
        }

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

        public int CheckLike(string username, string postid)
        {
            int like = 1;
            return new PostDAL().CheckLike(username, postid, like);
        }

        public int CheckFlag(string username, string postid)
        {
            int flag = 1;
            return new PostDAL().CheckFlag(username, postid, flag);
        }

        public int DeletePost(string postid)
        {
            return new PostDAL().DeletePost(postid);
        }
    }
}
