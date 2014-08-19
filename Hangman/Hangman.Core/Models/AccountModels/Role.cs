//-----------------------------------------------------------------------
// <copyright file="Role.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.Core.Models.AccountModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represent a structure of the roles.
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Gets or sets an identification number of the role.
        /// </summary>
        [Key]
        public int RoleID { get; set; }

        /// <summary>
        /// Gets or sets a name of the role.
        /// </summary>
        [Required]
        [MaxLength(50, ErrorMessage = "Прекалено дълго наименование")]
        public string Name { get; set; }
    }
}