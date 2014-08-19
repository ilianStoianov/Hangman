//-----------------------------------------------------------------------
// <copyright file="Category.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.Core.Models.WordModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represent a structure of the categories.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets an identification number of the category.
        /// </summary>
        [Key]
        public int CategoryID { get; set; }

        /// <summary>
        /// Gets or sets a name of the category.
        /// </summary>
        [Required(ErrorMessage = "Въведете наименование на категорията")]
        [MaxLength(50, ErrorMessage = "Прекалено дълго име")]
        [Display(Name = "Категория")]
        public string Name { get; set; }
    }
}