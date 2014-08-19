//-----------------------------------------------------------------------
// <copyright file="Review.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.Core.Models.ReviewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represent a structure of the guest book.
    /// </summary>
    public class Review
    {
        /// <summary>
        /// Gets or sets an identification number of the record.
        /// </summary>
        [Key]
        public int ReviewID { get; set; }

        [Required(ErrorMessage = "Въведете вашите имена")]
        [Display(Name = "Имена")]
        public string Names { get; set; }

        /// <summary>
        /// Gets or sets an email address of the account.
        /// </summary>
        [Required(ErrorMessage = "Въведете email адрес")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a message.
        /// </summary>
        [Required(ErrorMessage = "Въведете текст")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Съобщение")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets a date and time, when the record was created.
        /// </summary>
        [Required]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the record is approved or not.
        /// </summary>
        public bool IsApproved { get; set; }
    }
}