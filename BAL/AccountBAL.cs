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

        public int DeleteAccount(string username)
        {
            return new AccountDAL().Delete(username);
        }

        public DataTable GetAccount(string username)
        {
            return new AccountDAL().Load(username);
        }

        public DataTable GetAccountByBarcode(string barcode)
        {
            return new AccountDAL().LoadPerson(barcode);
        }

        public DataTable GetPersonByAanwezig(int aanwezig)
        {
            if (aanwezig == 1 || aanwezig == 0)
            {
                return new AccountDAL().LoadAllPersons(aanwezig);
            }
            else
            {
                return null;
            }
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

        public int UpdatePresence(int personID, int aanwezig)
        {
            return new AccountDAL().UpdatePresence(personID, aanwezig);
        }
    }

}
