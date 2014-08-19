//-----------------------------------------------------------------------
// <copyright file="LoginAsGuestViewModel.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class LoginAsGuestViewModel
    {
        /// <summary>
        /// Gets or sets an email address, using for login.
        /// </summary>
        [Required(ErrorMessage = "Веведете email адрес")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Невалиден емаил адрес")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets an information message for login.
        /// </summary>
        public string Message { get; set; }
    }
}