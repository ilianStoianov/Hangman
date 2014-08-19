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
        /// <summary>
        /// Gets or sets an identification number of the word.
        /// </summary>
        public int WordID { get; set; }

        public List<char> WordName { get; set; }

        public IEnumerable<char> Alphabet { get; set; }

        public List<char> SpellingWords { get; set; }

        /// <summary>
        /// Gets or sets a description of the word.
        /// </summary>
        public string WordDescription { get; set; }

        public WordHelp WordHelp { get; set; }

        public List<char> WrongLetters { get; set; }

        public int MissedLettersCount { get; set; }

        public int WrongLettersCount { get; set; }

        public string Message { get; set; }
    }
}
