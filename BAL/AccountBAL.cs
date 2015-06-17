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

        public int CreateAccount(string username, string password, string email)
        {
            return new AccountDAL().Insert(username, password, email);
        }

        public int UpdateAccount(int accountID, string username, string password, string role)
        {
            return new AccountDAL().Update(accountID, username, password, role);
        }

        public int UpdateAccount(int accountID, string username, string password, string role,
            string email, int activated, string firstname,
            string lastname, string street, int streetNum, string zip, string bankNum)
        {
            return new AccountDAL().Update(accountID, username, password, 
            role, email, activated, firstname,
            lastname, street, streetNum, zip, bankNum);

        }

        public int DeleteAccount(string username)
        {
            return new AccountDAL().Delete(username);
        }

        public DataTable GetAccount(string username)
        {
            return new AccountDAL().Load(username);
        }

        public int GetAccountLogin(string username, string password)
        {
            return new AccountDAL().Login(username, password);
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
