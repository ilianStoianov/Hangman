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
        [Required(ErrorMessage = "Веведете email адрес")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Невалиден емаил адрес")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string Message { get; set; }
    }
}