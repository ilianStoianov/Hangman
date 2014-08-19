//-----------------------------------------------------------------------
// <copyright file="LoginModel.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.Core.Models.AccountModels
{
    using System.ComponentModel.DataAnnotations;

    public class LoginModel
    {
        [Required(ErrorMessage = "Въведете email адрес")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Невалиден email адрес")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Въведете парола")]
        [DataType(DataType.Password, ErrorMessage = "Невалидна парола")]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        public string Message { get; set; }
    }
}