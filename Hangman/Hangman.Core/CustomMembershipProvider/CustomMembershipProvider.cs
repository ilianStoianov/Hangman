//-----------------------------------------------------------------------
// <copyright file="CustomMembershipProvider.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.Core.CustomMembershipProvider
{
    using System;
    using System.Web.Security;
    using Hangman.Core.Models.AccountModels;

    /// <summary>
    /// Represents a custom membership provider properties and methods.
    /// </summary>
    public class CustomMembershipProvider : MembershipProvider
    {
        #region Properties
        /// <summary>
        /// Gets a value indicating whether reset password functionality is enabled.
        /// </summary>
        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets a boolean variable, whether is enabled password retrieve.
        /// </summary>
        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets a boolean variable whether question and answer are requires.
        /// </summary>
        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets a boolean value whether requires unique email.
        /// </summary>
        public override bool RequiresUniqueEmail
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a count of maximum invalid password attempts.
        /// </summary>
        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets a count of  minimum required non alphanumeric characters.
        /// </summary>
        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets a minimum required password length.
        /// </summary>
        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets a password attempt window.
        /// </summary>
        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets an application name.
        /// </summary>
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets a description.
        /// </summary>
        public override string Description
        {
            get
            {
                return base.Description;
            }
        }

        /// <summary>
        /// Gets a name.
        /// </summary>
        public override string Name
        {
            get
            {
                return base.Name;
            }
        }

        /// <summary>
        /// Gets a regular expression for checking password strength.
        /// </summary>
        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets a password format.
        /// </summary>
        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }
        #endregion

        #region Methods
        public override bool ValidateUser(string loginEmail, string loginPassword)
        {
            return AccountProvider.ValidateAccount(loginEmail, AccountProvider.GetMD5Hash(loginPassword));
        }

        public override bool DeleteUser(string a, bool b)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string a)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string a, string b, string c)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a count of online users.
        /// </summary>
        /// <returns>A integer variable, contains count of online users.</returns>
        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="username">An username of the new user.</param>
        /// <param name="password">A password of the new user.</param>
        /// <param name="email">An email address of the new user.</param>
        /// <param name="firstName">A first name of the new user.</param>
        /// <param name="lastName">A last name of the new user.</param>
        /// <param name="isLocked">A value indicating whether the new user account is locked or not.</param>
        /// <param name="providerUserKey">A user key of the new user, as object.</param>
        /// <param name="status">A value of type object. Indicate whether the new user is added successfully or not.</param>
        /// <returns>An object of type "MembershipUser", contains the new user details.</returns>
        public override MembershipUser CreateUser(string username, string password, string email, string firstName, string lastName, bool isLocked, object providerUserKey, out MembershipCreateStatus status)
        {
            ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(username, password, true);
            this.OnValidatingPassword(args);

            if (args.Cancel)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }

            if (this.RequiresUniqueEmail && !string.IsNullOrEmpty(this.GetUserNameByEmail(email)))
            {
                status = MembershipCreateStatus.DuplicateEmail;

                return null;
            }

            Account account = new Account();
            account.RoleID = AccountProvider.GetRoleID("потребител");
            account.Password = AccountProvider.GetMD5Hash(password);
            account.FirstName = firstName;
            account.LastName = lastName;
            account.Email = email;
            account.CreateDate = DateTime.Now;
            account.IsLocked = isLocked;

            AccountProvider.RegisterAccount(account);

            status = MembershipCreateStatus.Success;

            return this.GetUser(email, true);
        }

        /// <summary>
        /// Getting a user details based on user key provider.
        /// </summary>
        /// <param name="providerUserKey">User key as object.</param>
        /// <param name="userIsOnline">A value indicating whether user must be online at the moment or not.</param>
        /// <returns>An object of type "MembershipUser", contains user details.</returns>
        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Getting an account details based on email address.
        /// </summary>
        /// <param name="email">Username as string.</param>
        /// <param name="userIsOnline">A value indicating whether user must be online at the moment or not.</param>
        /// <returns>An object of type "MembershipUser", contains user details.</returns>
        public override MembershipUser GetUser(string email, bool userIsOnline)
        {
            Account account = AccountProvider.GetUserObjByEmail(email);

            if (account != null)
            {
                MembershipUser memUAccount = new MembershipUser("CustomMembershipProvider", string.Empty, account.AccountID, account.Email, account.FirstName, account.LastName, true, false, account.CreateDate, DateTime.MinValue, DateTime.MinValue, DateTime.Now, DateTime.Now);

                return memUAccount;
            }

            return null;
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Getting a collection of all users.
        /// </summary>
        /// <param name="pageIndex">The number of page.</param>
        /// <param name="pageSize">The count for total records on page.</param>
        /// <param name="totalRecords">The count for total number of users as integer.</param>
        /// <returns>An object of type "MembershipUserCollection", contains users.</returns>
        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Getting a current password of user via username and answer of security question.
        /// </summary>
        /// <param name="username">The user's username as string.</param>
        /// <param name="answer">The answer of security question as string.</param>
        /// <returns>A string contains the current password of user.</returns>
        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a user's username by email address.
        /// </summary>
        /// <param name="email">An email address as string.</param>
        /// <returns>A user's username as string.</returns>
        public override string GetUserNameByEmail(string email)
        {
            MembershipUser user = this.GetUser(email, false);

            if (user != null)
            {
                email = user.Email;
            }
            else
            {
                email = string.Empty;
            }

            return email;
        }

        /// <summary>
        /// Password reset functionality.
        /// </summary>
        /// <param name="username">The user's username as string.</param>
        /// <param name="answer">The answer of security question as string.</param>
        /// <returns>A string contains the new password.</returns>
        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Change user details.
        /// </summary>
        /// <param name="user">An object of type "MembershipUser", contains current user details.</param>
        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Password validation.
        /// </summary>
        /// <param name="e">An event for password validation.</param>
        protected override void OnValidatingPassword(ValidatePasswordEventArgs e)
        {
            base.OnValidatingPassword(e);
        }

        #endregion
    }
}