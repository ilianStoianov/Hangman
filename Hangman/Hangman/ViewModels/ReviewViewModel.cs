//-----------------------------------------------------------------------
// <copyright file="ReviewViewModel.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.ViewModels
{
    using System.Collections.Generic;
    using Hangman.Core.Models;
    using Hangman.Core.Models.ReviewModels;

    public class ReviewViewModel
    {
        public Review NewEntry { get; set; }

        public IEnumerable<Review> PreviousEntries { get; set; }

        public string Message { get; set; }
    }
}