// <copyright file="AccountBAL.cs" company="JonneIT">
//      Copyright (c) ICT4Events. All rights reserved.
// </copyright>
// <author>Jonne van Dreven</author>
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
    /// business class for all account related code
    /// </summary>
    public class AccountBAL
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountBAL"/> class.
        /// </summary>
        public AccountBAL()
        {
        }

        /// <summary>
        /// A method to create an account
        /// </summary>
        /// <param name="username">Name of the user</param>
        /// <param name="password">Password of the user</param>
        /// <param name="email">Email of the user</param>
        /// <returns>1 or 0</returns>
        public int CreateAccount(string username, string password, string email)
        {
            return new AccountDAL().Insert(username, password, email);
        }

        /// <summary>
        /// A method to update an account
        /// </summary>
        /// <param name="accountID">account of a user</param>
        /// <param name="username">name of a user</param>
        /// <param name="password">password of a user</param>
        /// <param name="role">what role he or she has</param>
        /// <returns>1 or 0</returns>
        public int UpdateAccount(int accountID, string username, string password, string role)
        {
            return new AccountDAL().Update(accountID, username, password, role);
        }

        /// <summary>
        /// A method to update an account
        /// </summary>
        /// <param name="accountID">ID of the account</param>
        /// <param name="username">username of the account</param>
        /// <param name="password">password of the account</param>
        /// <param name="role">role of the account</param>
        /// <param name="email">email of the account</param>
        /// <param name="activated">Whether the account is activated or not</param>
        /// <returns>1 or 0</returns>
        public int UpdateAccount(int accountID, string username, string password, string role, string email, int activated)
        {
            return new AccountDAL().Update(accountID, username, password, role, email, activated);
        }

        /// <summary>
        /// A method to update an account
        /// </summary>
        /// <param name="accountID">ID of the account</param>
        /// <param name="password">password of the account</param>
        /// <returns>1 or 0</returns>
        public int UpdateAccount(int accountID, string password)
        {
            return new AccountDAL().Update(accountID, password);
        }

        /// <summary>
        ///  A method to delete an account
        /// </summary>
        /// <param name="username">username of the account</param>
        /// <returns>1 or 0</returns>
        public int DeleteAccount(string username)
        {
            return new AccountDAL().Delete(username);
        }

        /// <summary>
        /// A method to get an account
        /// </summary>
        /// <param name="username">Username of the account</param>
        /// <returns>an account</returns>
        public DataTable GetAccount(string username)
        {
            return new AccountDAL().Load(username);
        }

        /// <summary>
        /// A method to get an account
        /// </summary>
        /// <param name="username">username of the account</param>
        /// <param name="password">password of the account</param>
        /// <returns>an account</returns>
        public DataTable GetAccount(string username, string password)
        {
            return new AccountDAL().Load(username, password);
        }

        /// <summary>
        /// A method to get the login of an account
        /// </summary>
        /// <param name="username">username of the account</param>
        /// <param name="password">password of the account</param>
        /// <returns>1 or 0</returns>
        public int GetAccountLogin(string username, string password)
        {
            return new AccountDAL().Login(username, password);
        }

        /// <summary>
        /// A method to get all accounts
        /// </summary>
        /// <returns>All accounts</returns>
        public DataTable GetAllAccounts()
        {
            return new AccountDAL().LoadAll();
        }

        /// <summary>
        /// A method to login an account
        /// </summary>
        /// <param name="username">username of the account</param>
        /// <param name="password">password of the account</param>
        /// <returns>1 or 0</returns>
        public int Login(string username, string password)
        {
            return new AccountDAL().Login(username, password);
        }

        /// <summary>
        /// A method to check a username
        /// </summary>
        /// <param name="username">username of the account</param>
        /// <returns>1 or 0</returns>
        public int CheckUsername(string username)
        {
            return new AccountDAL().CheckUsername(username);
        }

        /// <summary>
        /// A method to check an email address
        /// </summary>
        /// <param name="email">email of the account</param>
        /// <returns>1 or 0</returns>
        public int CheckEmail(string email)
        {
            return new AccountDAL().CheckEmail(email);
        }
    }
}
