//-----------------------------------------------------------------------
// <copyright file="WordHelp.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.Core.Models.WordModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represent a structure of the helps.
    /// </summary>
    public class WordHelp
    {
        /// <summary>
        /// Gets or sets an identification number of the help.
        /// </summary>
        [Key]
        public int HelpID { get; set; }

        [Required]
        public int WordID { get; set; }

        public virtual Word Word { get; set; }

        /// <summary>
        /// Gets or sets a content of the help.
        /// </summary>
        [Required(ErrorMessage = "Въведете помощен текст")]
        [Display(Name = "Помощ")]
        public string Content { get; set; }
    }
}