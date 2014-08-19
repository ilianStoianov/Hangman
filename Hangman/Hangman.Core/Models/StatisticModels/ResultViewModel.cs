//-----------------------------------------------------------------------
// <copyright file="ResultViewModel.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.Core.Models.StatisticModels
{
    using System;

    public class ResultViewModel
    {
        public string Level { get; set; }

        public string Category { get; set; }

        public string Language { get; set; }

        public string WordName { get; set; }

        public int WrongAssumption { get; set; }

        public DateTime PlayDate { get; set; }

        public bool IsWinner { get; set; }
    }
}
