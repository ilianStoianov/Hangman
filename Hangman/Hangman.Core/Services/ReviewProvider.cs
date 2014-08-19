//-----------------------------------------------------------------------
// <copyright file="ReviewProvider.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Hangman.Core.Interfaces;
    using Hangman.Core.Models;
    using Hangman.Core.Models.ReviewModels;

    public class ReviewProvider : IReviewProvider
    {
        public bool AddEntry(Review entry)
        {
            try
            {
                using (HangmanContext context = new HangmanContext())
                {
                    entry.DateCreated = DateTime.Now;
                    entry.IsApproved = true;

                    context.Reviews.Add(entry);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                string path = HttpContext.Current.Server.MapPath("~/Logs");
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }

                System.IO.File.AppendAllText(System.IO.Path.Combine(path, "Review.txt"), "Error: " + DateTime.Now.ToString() + " " + ex.ToString() + Environment.NewLine);

                return false;
            }
        }

        public IEnumerable<Review> GetAllEntries()
        {
            IEnumerable<Review> guestBookEntries = new List<Review>();

            using (HangmanContext context = new HangmanContext())
            {
                guestBookEntries = context.Reviews.ToList();
            }

            return guestBookEntries;
        }
    }
}