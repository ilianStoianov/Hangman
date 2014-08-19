//-----------------------------------------------------------------------
// <copyright file="WordDetails.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.ViewModels
{
    using System.Collections.Generic;
    using Hangman.Core.Models.WordModels;

    public class WordDetails
    {
        public int WordID { get; set; }

        public List<char> WordName { get; set; }

        public IEnumerable<char> Alphabet { get; set; }

        public List<char> SpellingWords { get; set; }

        public string WordDescription { get; set; }

        public List<WordHelp> WordHelps { get; set; }

        public List<char> WrongLetters { get; set; }

        public int MissedLettersCount { get; set; }

        public int WrongLettersCount { get; set; }

        public string Message { get; set; }
    }
}
