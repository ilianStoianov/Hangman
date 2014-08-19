//-----------------------------------------------------------------------
// <copyright file="IReviewProvider.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.Core.Interfaces
{
    using System.Collections.Generic;
    using Hangman.Core.Models;
    using Hangman.Core.Models.ReviewModels;

    public interface IReviewProvider
    {
        bool AddEntry(Review entry);

        IEnumerable<Review> GetAllEntries();
    }
}