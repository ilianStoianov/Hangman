//-----------------------------------------------------------------------
// <copyright file="HangmanProvider.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.Core.Services
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Hangman.Core.Interfaces;
    using Hangman.Core.Models;
    using Hangman.Core.Models.StatisticModels;
    using Hangman.Core.Models.WordModels;

    public class HangmanProvider : IHangmanProvider
    {
        public int SaveResult(HangmanResult result)
        {
            try
            {
                using (HangmanContext context = new HangmanContext())
                {
                    if (result.ResultID == 0)
                    {
                        result.PlayDate = DateTime.Now;

                        context.HangmanResults.Add(result);
                        context.SaveChanges();
                    }
                    else
                    {
                        HangmanResult updateResult = context.HangmanResults.FirstOrDefault(r => r.ResultID == result.ResultID);
                        updateResult.PlayDate = DateTime.Now;
                        updateResult.WrongAssumption = result.WrongAssumption;
                        updateResult.IsWinner = result.IsWinner;

                        if (result.WordID != 0)
                        {
                            updateResult.WordID = result.WordID;
                        }

                        context.SaveChanges();
                    }
                }

                return result.ResultID;
            }
            catch (Exception ex)
            {
                string path = HttpContext.Current.Server.MapPath("~/Logs");
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }

                System.IO.File.AppendAllText(System.IO.Path.Combine(path, "Hangman.txt"), "Error: " + DateTime.Now.ToString() + " " + ex.ToString() + Environment.NewLine);

                return 0;
            }
        }

        public Word GetRandomWord(Func<Word, bool> filter = null)
        {
            if (filter == null)
            {
                filter = w => true;
            }

            Word word = new Word();

            using (HangmanContext context = new HangmanContext())
            {
                IQueryable<Word> records = context.Words.Where(filter).OrderBy(w => Guid.NewGuid()).AsQueryable();

                // Random random = new Random();
                // int selectRow = random.Next(0, records.Count());
                word = records.FirstOrDefault();
            }

            return word;
        }

        public IEnumerable<WordHelp> GetHelpsForWord(int wordID)
        {
            IEnumerable<WordHelp> helps;

            using (HangmanContext context = new HangmanContext())
            {
                helps = context.WordHelps.Where(h => h.WordID == wordID).ToList();
            }

            return helps;
        }

        public IEnumerable<Language> GetAllLanguages()
        {
            IEnumerable<Language> allLanguages;

            using (HangmanContext context = new HangmanContext())
            {
                allLanguages = context.Languages.OrderBy(l => l.Name).ToList();
            }

            return allLanguages;
        }

        public IEnumerable<Level> GetAllLevels()
        {
            IEnumerable<Level> allLevels;

            using (HangmanContext context = new HangmanContext())
            {
                allLevels = context.Levels.OrderBy(l => l.Name).ToList();
            }

            return allLevels;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            IEnumerable<Category> allCategories;

            using (HangmanContext context = new HangmanContext())
            {
                allCategories = context.Categories.OrderBy(l => l.Name).ToList();
            }

            return allCategories;
        }

        public virtual IEnumerable<ResultViewModel> GetPersonalStatistics(string email)
        {
            IEnumerable<ResultViewModel> results;

            using (HangmanContext context = new HangmanContext())
            {
                results = context.HangmanResults.Where(w => w.Email.ToLower() == email.ToLower()).Select(r => new ResultViewModel
                {
                    Category = r.Word.Category.Name,
                    Language = r.Word.Language.Name,
                    Level = r.Word.Level.Name,
                    WordName = r.Word.Name,
                    WrongAssumption = r.WrongAssumption,
                    PlayDate = r.PlayDate,
                    IsWinner = r.IsWinner
                }).ToList();
            }

            return results;
        }
    }
}