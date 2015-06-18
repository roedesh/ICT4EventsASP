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

        public int CreatePost(string username, string categoryID, string location, string size)
        {
            return new PostDAL().InsertFile(username, categoryID, location, size);
        }
        public DataTable GetMessages(string id)
        {
            return new PostDAL().LoadPostMessages(id);
        }
    }
}
