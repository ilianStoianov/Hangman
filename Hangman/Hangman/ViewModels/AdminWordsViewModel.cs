//-----------------------------------------------------------------------
// <copyright file="AdminWordsViewModel.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.ViewModels
{
    using System.Collections.Generic;
    using Hangman.Core.Models.WordModels;

    public class AdminWordsViewModel
    {
        public IEnumerable<Word> Words { get; set; }

        public string Filter { get; set; }
    }
}