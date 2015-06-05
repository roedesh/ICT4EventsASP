namespace BAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DAL;

    public class AccountBAL
    {
        public AccountBAL()
        {
        }

        public int CreateAccount(int rankID, string username, string password, int age, string interests, string signature)
        {
            return new AccountDAL().Insert(rankID, username, password, age, interests, signature);

        }

        public int UpdateAccount(int accountID, int rankID, string username, string password, int age, string interests, string signature)
        {
            return new AccountDAL().Update(accountID, rankID, username, password, age, interests, signature);

        }

        public int DeleteAccount(string username)
        {
            return new AccountDAL().Delete(username);

        }

        public DataTable GetAccount(string username)
        {
            return new AccountDAL().Load(username);

        }

        public DataTable GetAccountLogin(string username, string password)
        {
            return new AccountDAL().Load(username, password);

        }

        public DataTable GetAccount(string username, string password)
        {
            return new AccountDAL().Load(username, password);

        }

        public DataTable GetAllAccounts()
        {
            return new AccountDAL().LoadAll();

        }

        public int Login(string username, string password)
        {
            return new AccountDAL().Login(username, password);

        }

        public int CheckUsername(string username)
        {
            return new AccountDAL().CheckUsername(username);

        }

    }

}
