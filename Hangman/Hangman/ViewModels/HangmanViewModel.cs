//-----------------------------------------------------------------------
// <copyright file="HangmanViewModel.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Hangman.Core.Models.WordModels;

    public class HangmanViewModel
    {
        /// <summary>
        /// Gets or sets an identification number of the selected language.
        /// </summary>
        [Display(Name = "Език")]
        public int SelectedLanguageID { get; set; }

        /// <summary>
        /// Gets or sets an identification number of the selected level.
        /// </summary>
        [Display(Name = "Ниво")]
        public int SelectedLevelID { get; set; }

        /// <summary>
        /// Gets or sets an identification number of the selected category.
        /// </summary>
        [Display(Name = "Категория")]
        public int SelectedCategoryID { get; set; }

        /// <summary>
        /// Gets or sets a collection for all existing languages into database, as type IEnumerable.
        /// </summary>
        public IEnumerable<Language> Languages { get; set; }

        /// <summary>
        /// Gets or sets a collection for all existing levels into database, as type IEnumerable.
        /// </summary>
        public IEnumerable<Level> Levels { get; set; }

        /// <summary>
        /// Gets or sets a collection for all existing categories into database, as type IEnumerable.
        /// </summary>
        public IEnumerable<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets details of the word.
        /// </summary>
        public WordDetails WordDetails { get; set; }

        /// <summary>
        /// Gets or sets an identification number of the created record.
        /// </summary>
        public int HangmanResultID { get; set; }
    }
}