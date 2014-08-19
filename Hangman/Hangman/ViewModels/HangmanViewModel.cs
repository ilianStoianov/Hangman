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
        [Display(Name = "Език")]
        public int SelectedLanguageID { get; set; }

        [Display(Name = "Ниво")]
        public int SelectedLevelID { get; set; }

        [Display(Name = "Категория")]
        public int SelectedCategoryID { get; set; }

        public IEnumerable<Language> Languages { get; set; }

        public IEnumerable<Level> Levels { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public WordDetails WordDetails { get; set; }

        public int HangmanResultID { get; set; }
    }
}