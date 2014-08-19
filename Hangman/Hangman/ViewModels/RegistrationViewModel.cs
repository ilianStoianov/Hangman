//-----------------------------------------------------------------------
// <copyright file="RegistrationViewModel.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Въведете собственото си име")]
        [MaxLength(50, ErrorMessage = "Прекалено дълго име")]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Въведете фамилия")]
        [MaxLength(50, ErrorMessage = "Прекалено дълго име")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Въведете email адрес")]
        [MaxLength(250, ErrorMessage = "Прекалено дълъг email адрес")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Невалиден email адрес")]
        [Display(Name = "Е-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Въведете парола")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Паролата трябва да е поне 6 символа")]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Въведете повторно паролата си")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Въведените пароли не съвпадат")]
        [Display(Name = "Повторение на паролата")]
        public string ComparePassword { get; set; }

        public string Message { get; set; }
    }
}