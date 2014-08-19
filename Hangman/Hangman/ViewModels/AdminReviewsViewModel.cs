//-----------------------------------------------------------------------
// <copyright file="AdminReviewsViewModel.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.ViewModels
{
    using System.Collections.Generic;
    using Hangman.Core.Models;
    using Hangman.Core.Models.ReviewModels;

    public class AdminReviewsViewModel
    {
        public IEnumerable<Review> Reviews { get; set; }

        public string Filter { get; set; }
    }
}