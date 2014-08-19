//-----------------------------------------------------------------------
// <copyright file="ReviewController.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;
    using Hangman.Core.Interfaces;
    using Hangman.Core.Models;
    using Hangman.Core.Models.ReviewModels;
    using Hangman.Core.Services;
    using Hangman.ViewModels;

    public class ReviewController : Controller
    {
        #region Fields
        private readonly IReviewProvider reviewProvider;
        #endregion

        #region Constructors
        public ReviewController()
        {
            this.reviewProvider = new ReviewProvider();
        }
        #endregion

        // GET: GuestBook
        public ActionResult Index()
        {
            string email = string.Empty;

            MembershipUser user = Membership.GetUser();

            ReviewViewModel reviewModel = new ReviewViewModel();
            reviewModel.PreviousEntries = this.reviewProvider.GetAllEntries();

            Review review = new Review();

            if (user != null)
            {
                review.Email = user.Email;
            }
            else if (HttpContext.Session["Email"] != null)
            {
                review.Email = HttpContext.Session["Email"].ToString();
            }

            reviewModel.NewEntry = review;

            return this.View(reviewModel);
        }

        [HttpPost]
        public ActionResult Index(ReviewViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (this.reviewProvider.AddEntry(model.NewEntry))
                {
                    model.Message = "Благодарим! Вашето мнение е важно за нас.";
                }
                else
                {
                    model.Message = "Възникна проблем, моля опитайте по-късно.";
                }
            }

            model.PreviousEntries = this.reviewProvider.GetAllEntries();

            return this.View(model);
        }
    }
}