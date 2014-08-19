//-----------------------------------------------------------------------
// <copyright file="StatisticController.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.Controllers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Security;
    using Hangman.Core.Interfaces;
    using Hangman.Core.Models.StatisticModels;
    using Hangman.Core.Services;
    using Hangman.ViewModels;

    public class StatisticController : Controller
    {
        #region Fields
        private readonly IHangmanProvider hangamnProvider;
        #endregion

        #region Constructors
        public StatisticController()
        {
            this.hangamnProvider = new HangmanProvider();
        }
        #endregion

        // GET: Statistic
        public ActionResult Index(string sortOrder, string search)
        {
            StatisticViewModel statisticModel = new StatisticViewModel();

            if (User.Identity.IsAuthenticated || HttpContext.Session["Email"] != null)
            {
                string email = string.Empty;
                if (User.Identity.IsAuthenticated)
                {
                    MembershipUser user = Membership.GetUser();
                    email = user.Email;
                }
                else if (HttpContext.Session["Email"] != null)
                {
                    email = HttpContext.Session["Email"].ToString();
                }

                statisticModel.Results = this.hangamnProvider.GetPersonalStatistics(email);
            }
            else
            {
                statisticModel.Message = "За да видите личната си статистика е нужно да влезете в акаунта си.";
            }

            return this.View(statisticModel);
        }
    }
}