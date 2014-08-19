//-----------------------------------------------------------------------
// <copyright file="Word.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.Core.Models.WordModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represent a structure of the words.
    /// </summary>
    public class Word
    {
        /// <summary>
        /// Gets or sets a identification number of the word.
        /// </summary>
        [Key]
        public int WordID { get; set; }

        /// <summary>
        /// Gets or sets an identification number of the level for the word.
        /// </summary>
        [Required(ErrorMessage = "Изберете ниво на трудност")]
        [Display(Name = "Ниво")]
        public int LevelID { get; set; }

        public virtual Level Level { get; set; }

        /// <summary>
        /// Gets or sets an identification number of the category for the word.
        /// </summary>
        [Required(ErrorMessage = "Изберете категория")]
        [Display(Name = "Категория")]
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }

        /// <summary>
        /// Gets or sets a identification number of the language.
        /// </summary>
        [Required(ErrorMessage = "Изберете езика")]
        [Display(Name = "Език")]
        public int LanguageID { get; set; }

        public virtual Language Language { get; set; }

        /// <summary>
        /// Gets or sets a name of the word.
        /// </summary>
        [Required(ErrorMessage = "Въведете дума")]
        [MinLength(5, ErrorMessage = "Думата трябва да бъде поне 4 символа")]
        [Display(Name = "Дума")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a description of the word.
        /// </summary>
        [Required(ErrorMessage = "Въведете описание на думата")]
        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}