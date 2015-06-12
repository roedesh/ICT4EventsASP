using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BAL
{
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
        #endregion
    }
}
