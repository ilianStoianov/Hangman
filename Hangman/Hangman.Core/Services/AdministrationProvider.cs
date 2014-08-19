//-----------------------------------------------------------------------
// <copyright file="AdministrationProvider.cs" company="None">
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
    using Hangman.Core.Models.AccountModels;
    using Hangman.Core.Models.ReviewModels;
    using Hangman.Core.Models.WordModels;

    public class AdministrationProvider : IAdministrationProvider
    {
        public bool AddWord(Word newWord)
        {
            try
            {
                using (HangmanContext context = new HangmanContext())
                {
                    context.Words.Add(newWord);
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

                System.IO.File.AppendAllText(System.IO.Path.Combine(path, "Words.txt"), "Error: " + DateTime.Now.ToString() + " " + ex.ToString() + Environment.NewLine);

                return false;
            }
        }

        public bool RemoveWord(int wordID)
        {
            try
            {
                using (HangmanContext context = new HangmanContext())
                {
                    Word word = context.Words.FirstOrDefault(w => w.WordID == wordID);

                    context.Words.Remove(word);
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

                System.IO.File.AppendAllText(System.IO.Path.Combine(path, "Words.txt"), "Error: " + DateTime.Now.ToString() + " " + ex.ToString() + Environment.NewLine);

                return false;
            }
        }

        public bool UpdateWord(Word updatedWord)
        {
            try
            {
                using (HangmanContext context = new HangmanContext())
                {
                    Word word = context.Words.FirstOrDefault(w => w.WordID == updatedWord.WordID);

                    word = updatedWord;
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

                System.IO.File.AppendAllText(System.IO.Path.Combine(path, "Words.txt"), "Error: " + DateTime.Now.ToString() + " " + ex.ToString() + Environment.NewLine);

                return false;
            }
        }

        public IEnumerable<Word> GetAllWords(Func<Word, bool> filter = null)
        {
            IEnumerable<Word> words;
            using (HangmanContext context = new HangmanContext())
            {
                if (filter == null)
                {
                    filter = w => true;
                }

                words = context.Words.Where(filter).ToList();
            }

            return words;
        }

        public IEnumerable<Review> GetAllReviews(Func<Review, bool> filter = null)
        {
            IEnumerable<Review> reviews;
            using (HangmanContext context = new HangmanContext())
            {
                if (filter == null)
                {
                    filter = r => true;
                }

                reviews = context.Reviews.Where(filter).ToList();
            }

            return reviews;
        }

        public bool UpdateReview(int reviewID)
        {
            return false;
        }

        public Account GetAccount()
        {
            return null;
        }

        public IEnumerable<Account> GetAllAccounts(Func<Account, bool> filter = null)
        {
            IEnumerable<Account> accounts;
            using (HangmanContext context = new HangmanContext())
            {
                if (filter == null)
                {
                    filter = r => true;
                }

                accounts = context.Accounts.Where(filter).ToList();
            }

            return accounts;
        }
    }
}