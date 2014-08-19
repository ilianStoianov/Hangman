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
        /// <summary>
        /// Gets or sets an entered email address from the user.
        /// </summary>
        [Required(ErrorMessage = "Въведете email адрес")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Невалиден email адрес")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets an entered password from the user.
        /// </summary>
        [Required(ErrorMessage = "Въведете парола")]
        [DataType(DataType.Password, ErrorMessage = "Невалидна парола")]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets an information message.
        /// </summary>
        public string Message { get; set; }
    }
}