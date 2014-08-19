//-----------------------------------------------------------------------
// <copyright file="ResultViewModel.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.Core.Models.StatisticModels
{
    using System;

    public class ResultViewModel
    {
        /// <summary>
        /// Gets or sets a full name of the level.
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// Gets or sets a full name of the category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets of set a full name of the language.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets a name of the word.
        /// </summary>
        public string WordName { get; set; }

        /// <summary>
        /// Gets or sets a count of the wrong assumptions.
        /// </summary>
        public int WrongAssumption { get; set; }

        /// <summary>
        /// Gets or sets date and time whenever the player has been playing
        /// </summary>
        public DateTime PlayDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the player is winner or not.
        /// </summary>
        public bool IsWinner { get; set; }
    }
}
