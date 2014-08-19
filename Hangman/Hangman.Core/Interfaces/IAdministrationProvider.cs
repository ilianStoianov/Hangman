//-----------------------------------------------------------------------
// <copyright file="IAdministrationProvider.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.Core.Interfaces
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Hangman.Core.Models;
    using Hangman.Core.Models.AccountModels;
    using Hangman.Core.Models.ReviewModels;
    using Hangman.Core.Models.WordModels;

    public interface IAdministrationProvider
    {
        bool AddWord(Word newWord);

        bool RemoveWord(int wordID);

        bool UpdateWord(Word updatedWord);

        IEnumerable<Word> GetAllWords(Func<Word, bool> filter = null);

        IEnumerable<Review> GetAllReviews(Func<Review, bool> filter = null);

        bool UpdateReview(int reviewID);

        Account GetAccount();

        IEnumerable<Account> GetAllAccounts(Func<Account, bool> filter = null);
    }
}