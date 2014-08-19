//-----------------------------------------------------------------------
// <copyright file="IHangmanProvider.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.Core.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Hangman.Core.Models.StatisticModels;
    using Hangman.Core.Models.WordModels;
    
    public interface IHangmanProvider
    {
        int SaveResult(HangmanResult result);

        Word GetRandomWord(Func<Word, bool> filter = null);

        WordHelp GetHelpForWord(int wordID);

        IEnumerable<Language> GetAllLanguages();

        IEnumerable<Level> GetAllLevels();

        IEnumerable<Category> GetAllCategories();

        IEnumerable<ResultViewModel> GetPersonalStatistics(string email);
    }
}