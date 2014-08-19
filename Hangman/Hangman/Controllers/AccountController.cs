//-----------------------------------------------------------------------
// <copyright file="AccountController.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Web.Security;
    using Hangman.Core.Models.AccountModels;
    using Hangman.ViewModels;

    [Authorize]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return this.View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            LoginModel loginModel = new LoginModel();

            if (TempData["LoginModel"] != null)
            {
                loginModel = (LoginModel)TempData["LoginModel"];
            }

            return this.View(loginModel);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Email, model.Password))
                {
                    FormsAuthentication.RedirectFromLoginPage(model.Email, false);

                    return this.RedirectToAction("Index", "Account");
                }

                model.Message = "Невалиден email и/или парола.";
            }

            return this.View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            HttpContext.Session.Clear();

            return this.RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult Registration()
        {
            RegistrationViewModel model = new RegistrationViewModel();

            return this.View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                MembershipCreateStatus status;
                MembershipUser user = Membership.CreateUser(DateTime.Now.ToString("ddhhmmssfff"), model.Password, model.Email.Trim().ToLower(), model.FirstName.Trim(), model.LastName.Trim(), false, out status);

                if (status == MembershipCreateStatus.Success)
                {
                    return this.RedirectToAction("Index");
                }
                else
                {
                    switch (status)
                    {
                        case MembershipCreateStatus.DuplicateEmail:
                            model.Message = "Въведеният Email адрес е зает.";
                            break;
                        default:
                            break;
                    }
                }
            }

            return this.View(model);
        }
    }
}