//-----------------------------------------------------------------------
// <copyright file="AdminAccountsViewModel.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.ViewModels
{
    using System.Collections.Generic;
    using Hangman.Core.Models.AccountModels;

    public class AdminAccountsViewModel
    {
        /// <summary>
        /// Gets or sets a collection of existing accounts, as type IEnumerable.
        /// </summary>
        public IEnumerable<Account> Accounts { get; set; }

        /// <summary>
        /// Gets or sets a criteria for filtering the results.
        /// </summary>
        public string Filter { get; set; }
    }
}