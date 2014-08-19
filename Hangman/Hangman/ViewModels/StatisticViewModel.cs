//-----------------------------------------------------------------------
// <copyright file="StatisticViewModel.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.ViewModels
{
    using System.Collections.Generic;
    using Hangman.Core.Models.StatisticModels;

    public class StatisticViewModel
    {
        public IEnumerable<ResultViewModel> Results { get; set; }

        public string Message { get; set; }
    }
}