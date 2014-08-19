//-----------------------------------------------------------------------
// <copyright file="HomeController.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.Controllers
{
    using System.Web.Mvc;
    using System.Web.Security;
    using Hangman.Core.Models.AccountModels;
    using Hangman.ViewModels;

    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string auth)
        {
            LoginAsGuestViewModel loginModel = new LoginAsGuestViewModel();

            if (!string.IsNullOrEmpty(auth))
            {
                loginModel.Message = "За да играете е нужно да се впишете в системата или да въведете email адреса.";
            }

            return this.View(loginModel);
        }

        [HttpPost]
        public ActionResult Index(LoginAsGuestViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(Membership.GetUserNameByEmail(model.Email)))
                {
                    LoginModel loginModel = new LoginModel();
                    loginModel.Email = model.Email;
                    loginModel.Message = "Въведеният email адрес е регистриран. Моля въведете парола";

                    this.TempData["LoginModel"] = loginModel;

                    return this.RedirectToAction("Login", "Account");
                }
                else
                {
                    if (!string.IsNullOrEmpty(model.Email))
                    {
                        HttpContext.Session["Email"] = model.Email;
                    }

                    return this.RedirectToAction("Index", "Hangman");
                }
            }
            else if (!string.IsNullOrEmpty((string)HttpContext.Session["Email"]))
            {
                return this.RedirectToAction("Index", "Hangman");
            }

            return this.View(model);
        }
    }
}