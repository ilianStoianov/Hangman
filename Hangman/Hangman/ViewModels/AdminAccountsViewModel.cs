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
        public IEnumerable<Account> Accounts { get; set; }

        public string Filter { get; set; }
    }
}