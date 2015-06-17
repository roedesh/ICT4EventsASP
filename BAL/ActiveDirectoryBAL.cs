﻿// <copyright file="ActiveDirectoryHandling.cs" company="ICT4EventsASP">
//     Copyright (c) ADonderzoek. All rights reserved.
// </copyright>
// <author>Berry Verschueren</author>
namespace BAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.DirectoryServices;
    using System.DirectoryServices.ActiveDirectory;
    
    /// <summary>
    /// Class to handle active directory.
    /// </summary>
    class ActiveDirectoryBAL
    {  
        /// <summary>
        /// The path to use when working with active directory for our domain.
        /// </summary>
        const string url = "LDAP://CN=Users,DC=ICT4EVENTS,DC=PARENT";

        /// <summary>
        /// Integer value to work with.
        /// </summary>
        int counter;

        /// <summary>
        /// Array value to work with.
        /// Usually containing all data returned and at the end a counter (1 or 0)
        /// if counter equals 1 then an error occured.
        /// </summary>
        string[] returnValues;


        /// <summary>
        /// Initializes an instance of the ActiveDirectoryBAL class.
        /// </summary>
        public ActiveDirectoryBAL()
        {
            this.counter = 0;
        }

        /// <summary>
        /// Method to create a user within the active directory, by default the account is disabled.
        /// Do not forget to add the user to a certain group, using the AddToGroup method.
        /// </summary>
        /// <param name="username">username value</param>
        /// <param name="password">password value</param>
        /// <param name="email">email address value</param>
        /// <returns>array with username, password, email and (1/0) errorOccurance index</returns>
        public string[] CreateUser(string username, string password, string email)
        {
            try
            {
                using (DirectoryEntry localMachine = new DirectoryEntry(url, "Administrator", "FONTYSPTS-23", AuthenticationTypes.Secure))
                using (DirectoryEntry newUser = localMachine.Children.Add("CN=" + username, "user"))
                {
                    newUser.Properties["samAccountName"].Value = username;
                    newUser.CommitChanges();
                    newUser.Invoke("SetPassword", new object[] { password });
                    newUser.CommitChanges();
                    newUser.Invoke("EmailAddress", new object[] { email });
                    newUser.CommitChanges();
                    newUser.Close();
                    localMachine.Close();
                }
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                this.counter++;
            }
            finally
            {
                this.returnValues = new string[] { username, password, email, this.counter.ToString() };
            }

            return this.returnValues;
        }

        /// <summary>
        /// Method to delete a user from the active directory, only use if something went wrong, otherwise just disable the account.
        /// </summary>
        /// <param name="username">username value</param>
        /// <returns>array with username and (1/0) errorOccurance index</returns>
        public string[] DeleteUser(string username)
        {
            try
            {
                using (DirectoryEntry localMachine = new DirectoryEntry(url, "Administrator", "FONTYSPTS-23", AuthenticationTypes.Secure))
                using (DirectoryEntry newUser = localMachine.Children.Add("CN=" + username, "user"))
                {
                    newUser.DeleteTree();
                    newUser.Close();
                    localMachine.Close();
                }
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                this.counter++;
            }
            finally
            {
                this.returnValues = new string[] { username, this.counter.ToString() };
            }

            return this.returnValues;
        }

        /// <summary>
        /// Method to see if the credentials are correct and recognized by the active directory server.
        /// </summary>
        /// <param name="username">username value</param>
        /// <param name="password">password value</param>
        /// <returns>array with username, password and (1/0) errorOccurance index</returns>
        public string[] Authenticate(string username, string password)
        {
            try
            {
                DirectoryEntry entry = new DirectoryEntry(url, username, password);
                object nativeObject = entry.NativeObject;
                entry.Close();
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                this.counter++;
            }
            finally
            {
                this.returnValues = new string[] { username, password, this.counter.ToString() };
            }

            return this.returnValues;
        }

        /// <summary>
        /// Method to enable a disabled account within the active directory. Enables for instance authentication.
        /// </summary>
        /// <param name="username">username value</param>
        /// <returns>array with username and (1/0) errorOccurance index</returns>
        public string[] EnableAccount(string username)
        {
            try
            {
                using (DirectoryEntry localMachine = new DirectoryEntry(url, "Administrator", "FONTYSPTS-23", AuthenticationTypes.Secure))
                using (DirectoryEntry user = localMachine.Children.Find("CN=" + username, "user"))
                {
                    int val = (int)user.Properties["userAccountControl"].Value;
                    user.Properties["userAccountControl"].Value = val & ~0x2;
                    user.CommitChanges();
                    user.Close();
                    localMachine.Close();
                }
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                this.counter++;
            }
            finally
            {
                this.returnValues = new string[] { username, this.counter.ToString() };
            }

            return this.returnValues;
        }

        /// <summary>
        /// Method to disnable an enabled account within the active directory. Disables for instance authentication.
        /// </summary>
        /// <param name="username">username value</param>
        /// <returns>array with username and (1/0) errorOccurance index</returns>
        public string[] DisableAccount(string username)
        {
            try
            {
                using (DirectoryEntry localMachine = new DirectoryEntry(url, "Administrator", "FONTYSPTS-23", AuthenticationTypes.Secure))
                using (DirectoryEntry user = localMachine.Children.Find("CN=" + username, "user"))
                {
                    int val = (int)user.Properties["userAccountControl"].Value;
                    user.Properties["userAccountControl"].Value = val | 0x2;
                    user.CommitChanges();
                    user.Close();
                    localMachine.Close();
                }
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                this.counter++;
            }
            finally
            {
                this.returnValues = new string[] { username, this.counter.ToString() };
            }

            return this.returnValues;
        }

        /// <summary>
        /// Method to add a user to a group within active directory.
        /// </summary>
        /// <param name="username">username value</param>
        /// <param name="groupname">groupname value</param>
        /// <returns>array with username, groupname and (1/0) errorOccurance index</returns>
        public string[] AddToGroup(string username, string groupname)
        {
            try
            {
                using (DirectoryEntry localMachine = new DirectoryEntry(url, "Administrator", "FONTYSPTS-23", AuthenticationTypes.Secure))
                using (DirectoryEntry group = localMachine.Children.Find("CN=" + groupname, "group"))
                {
                    string userDN = "LDAP://ICT4EVENTS.PARENT/CN=" + username + ",CN=Users,DC=ICT4EVENTS,DC=PARENT";
                    group.Invoke("Add", new object[] { userDN });
                    group.CommitChanges();
                    group.Close();
                    localMachine.Close();
                }
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                this.counter++;
            }
            finally
            {
                this.returnValues = new string[] { username, groupname, this.counter.ToString() };
            }

            return this.returnValues;
        }
    }
}
