//-----------------------------------------------------------------------
// <copyright file="Account.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.Core.Models.AccountModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represent a structure of the accounts.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Gets or sets an identification number of the account.
        /// </summary>
        [Key]
        public int AccountID { get; set; }

        /// <summary>
        /// Gets or sets and identification number of the role.
        /// </summary>
        [Required]
        public int RoleID { get; set; }

        public virtual Role Role { get; set; }

        /// <summary>
        /// Gets or sets a first name of the account.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets a last name of the account.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets an email address of the account.
        /// </summary>
        [Required]
        [MaxLength(250)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a date and time of the account registration.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether account is locked or not.
        /// </summary>
        public bool IsLocked { get; set; }
    }
}