//-----------------------------------------------------------------------
// <copyright file="Level.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.Core.Models.WordModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represent a structure of the levels.
    /// </summary>
    public class Level
    {
        /// <summary>
        /// Gets or sets an identification number of the level.
        /// </summary>
        [Key]
        public int LevelID { get; set; }

        /// <summary>
        /// Gets or sets a name of the level.
        /// </summary>
        [Required(ErrorMessage = "Въведете наименование на нивото")]
        [MaxLength(50, ErrorMessage = "Прекалено дълго име")]
        [Display(Name = "Ниво")]
        public string Name { get; set; }
    }
}