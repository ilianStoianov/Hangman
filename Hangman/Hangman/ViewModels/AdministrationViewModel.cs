//-----------------------------------------------------------------------
// <copyright file="AdministrationViewModel.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.ViewModels
{
    public class AdministrationViewModel
    {
        public AdminAccountsViewModel Accounts { get; set; }

        public AdminWordsViewModel Words { get; set; }

        public AdminReviewsViewModel Reviews { get; set; }
    }
}