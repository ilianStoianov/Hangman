//-----------------------------------------------------------------------
// <copyright file="Language.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.Core.Models.WordModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represent a structure of the languages.
    /// </summary>
    public class Language
    {
        /// <summary>
        /// Gets or sets an identification number of the language.
        /// </summary>
        [Key]
        public int LanguageID { get; set; }

        /// <summary>
        /// Gets or sets a name of the language.
        /// </summary>
        [Required(ErrorMessage = "Въведете името на езика")]
        [MaxLength(50, ErrorMessage = "Прекалено дълго име")]
        [Display(Name = "Език")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets an alphabet of the language.
        /// </summary>
        [Required(ErrorMessage = "Въведете азбука")]
        [MinLength(15, ErrorMessage = "Въведете цялата азбука")]
        [MaxLength(50, ErrorMessage = "Въведете еднократно азбуката")]
        [Display(Name = "Азбука")]
        public string Alphabet { get; set; }
    }
}