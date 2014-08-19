//-----------------------------------------------------------------------
// <copyright file="AdministrationController.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Hangman.Core.Interfaces;
    using Hangman.Core.Models.AccountModels;
    using Hangman.Core.Models.ReviewModels;
    using Hangman.Core.Models.WordModels;
    using Hangman.Core.Services;
    using Hangman.ViewModels;
    
    [Authorize]
    public class AdministrationController : Controller
    {
        #region Fields
        private readonly IAdministrationProvider administrationProvider;
        #endregion

        #region Constructors
        public AdministrationController()
        {
            this.administrationProvider = new AdministrationProvider();
        }
        #endregion

        // GET: Administration
        public ActionResult Index()
        {
            AdministrationViewModel adminViewModel = new AdministrationViewModel();
            adminViewModel.Accounts = new AdminAccountsViewModel();
            adminViewModel.Accounts.Accounts = this.administrationProvider.GetAllAccounts();
            adminViewModel.Reviews = new AdminReviewsViewModel();
            adminViewModel.Reviews.Reviews = this.administrationProvider.GetAllReviews();
            adminViewModel.Words = new AdminWordsViewModel();
            adminViewModel.Words.Words = this.administrationProvider.GetAllWords();

            return this.View(adminViewModel);
        }

        public ActionResult GetAccounts(string filter)
        {
            Func<Account, bool> searchFor = null;

            if (!string.IsNullOrEmpty(filter))
            {
                searchFor = w => w.FirstName.ToLower().Contains(filter.ToLower()) || w.LastName.Contains(filter.ToLower()) || w.Email.Contains(filter.ToLower());
            }
            else
            {
                searchFor = w => true;
            }

            AdminAccountsViewModel accounts = new AdminAccountsViewModel();
            accounts.Accounts = this.administrationProvider.GetAllAccounts(searchFor);
            accounts.Filter = filter;

            return this.PartialView("Partial/Accounts", accounts);
        }

        public ActionResult GetWords(string filter)
        {
            Func<Word, bool> searchFor = null;

            if (!string.IsNullOrEmpty(filter))
            {
                searchFor = w => w.Name.ToLower().Contains(filter.ToLower()) || w.Description.Contains(filter.ToLower());
            }
            else
            {
                searchFor = w => true;
            }

            AdminWordsViewModel words = new AdminWordsViewModel();
            words.Words = this.administrationProvider.GetAllWords(searchFor);
            words.Filter = filter;

            return this.PartialView("Partial/Words", words);
        }

        public ActionResult GetReviews(string filter)
        {
            Func<Review, bool> searchFor = null;

            if (!string.IsNullOrEmpty(filter))
            {
                searchFor = w => w.Names.ToLower().Contains(filter.ToLower()) || w.Email.Contains(filter.ToLower()) || w.Message.Contains(filter.ToLower());
            }
            else
            {
                searchFor = w => true;
            }

            AdminReviewsViewModel reviews = new AdminReviewsViewModel();
            reviews.Reviews = this.administrationProvider.GetAllReviews(searchFor);
            reviews.Filter = filter;

            return this.PartialView("Partial/Reviews", reviews);
        }
    }
}