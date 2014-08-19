//-----------------------------------------------------------------------
// <copyright file="AccountProvider.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.Core.CustomMembershipProvider
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using Hangman.Core.Models;
    using Hangman.Core.Models.AccountModels;

    public class AccountProvider
    {
        public static bool ValidateAccount(string email, string password)
        {
            bool isSuccess = false;

            using (HangmanContext context = new HangmanContext())
            {
                isSuccess = context.Accounts.FirstOrDefault(a => a.Email.ToLower() == email.ToLower() && (string.Compare(a.Password, password, false) == 0)) != null;
            }

            return isSuccess;
        }

        public static Account GetUserObjByEmail(string email, string passWord)
        {
            Account account = new Account();

            using (HangmanContext context = new HangmanContext())
            {
                account = context.Accounts.SingleOrDefault(a => a.Email == email && a.Password == passWord);
            }

            return account;
        }

        public static Account GetUserObjByEmail(string email)
        {
            Account account = new Account();
            using (HangmanContext context = new HangmanContext())
            {
                account = context.Accounts.SingleOrDefault(u => u.Email == email);
            }

            return account;
        }

        public static IEnumerable<Account> GetAllAccounts()
        {
            IEnumerable<Account> accounts;

            using (HangmanContext context = new HangmanContext())
            {
                accounts = context.Accounts.AsEnumerable().ToList();
            }

            return accounts;
        }

        public static string GetMD5Hash(string value)
        {
            MD5 md5Hasher = MD5.Create();

            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                stringBuilder.Append(data[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }

        public static int GetRoleID(string roleName)
        {
            int roleID = 0;

            using (HangmanContext context = new HangmanContext())
            {
                roleID = context.Roles.FirstOrDefault(r => r.Name.ToLower() == roleName.ToLower()).RoleID;
            }

            return roleID;
        }

        public static int RegisterAccount(Account account)
        {
            using (HangmanContext context = new HangmanContext())
            {
                context.Accounts.Add(account);
                context.SaveChanges();
            }

            return account.AccountID;
        }
    }
}