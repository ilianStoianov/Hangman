//-----------------------------------------------------------------------
// <copyright file="HangmanContext.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.Core.Models
{
    using System.Data.Entity;
    using Hangman.Core.Models.AccountModels;
    using Hangman.Core.Models.ReviewModels;
    using Hangman.Core.Models.StatisticModels;
    using Hangman.Core.Models.WordModels;
    
    public class HangmanContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Word> Words { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Level> Levels { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<WordHelp> WordHelps { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<HangmanResult> HangmanResults { get; set; }
    }
}