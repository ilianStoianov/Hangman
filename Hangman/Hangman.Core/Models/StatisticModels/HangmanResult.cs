//-----------------------------------------------------------------------
// <copyright file="HangmanResult.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.Core.Models.StatisticModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Hangman.Core.Models.WordModels;

    public class HangmanResult
    {
        /// <summary>
        /// Gets or sets an identification number of the record.
        /// </summary>
        [Key]
        public int ResultID { get; set; }

        /// <summary>
        /// Gets or sets a identification number of the word.
        /// </summary>
        public int WordID { get; set; }

        public virtual Word Word { get; set; }

        /// <summary>
        /// Gets or sets an email address of the player.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a wrong assumption count.
        /// </summary>
        [Required]
        public int WrongAssumption { get; set; }

        /// <summary>
        /// Gets or sets a date and time of the finished game.
        /// </summary>
        public DateTime PlayDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether player is winner or not.
        /// </summary>
        [Required]
        public bool IsWinner { get; set; }
    }
}
