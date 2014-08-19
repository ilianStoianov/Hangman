//-----------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman
{
    using System.Data.Entity;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Hangman.Core.Models;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<HangmanContext>());
        }
    }
}