//-----------------------------------------------------------------------
// <copyright file="HangmanController.cs" company="None">
// Copyright (c) Ilian Stoyanov. All rights reserved.
// </copyright>
// <author>Ilian Stoyanov</author>
//-----------------------------------------------------------------------

namespace Hangman.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;
    using Hangman.Core.Interfaces;
    using Hangman.Core.Models.StatisticModels;
    using Hangman.Core.Models.WordModels;
    using Hangman.Core.Services;
    using Hangman.ViewModels;

    public class HangmanController : Controller
    {
        #region Fields
        private readonly IHangmanProvider hangamnProvider;
        #endregion

        #region Constructions
        public HangmanController()
        {
            this.hangamnProvider = new HangmanProvider();
        }
        #endregion

        // GET: Hangman
        [HttpGet]
        public async Task<ActionResult> Index()
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
            else
            {
                return this.RedirectToAction("Index", "Home", new { auth = false });
            }

            HangmanViewModel hangmanModel = new HangmanViewModel();
            Word word = this.hangamnProvider.GetRandomWord();

            if (word == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            hangmanModel = await this.GetAllFilters(hangmanModel);
            hangmanModel = await this.LoadWordDetailsIntoModel(hangmanModel, word);

            HangmanResult result = new HangmanResult();
            result.WordID = word.WordID;
            result.Email = email;
            result.WrongAssumption = 0;
            result.IsWinner = false;

            int resultID = this.hangamnProvider.SaveResult(result);

            if (resultID > 0)
            {
                hangmanModel.HangmanResultID = resultID;
                HttpContext.Session["HangmanData"] = hangmanModel;

                return this.View(hangmanModel);
            }

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Index(HangmanViewModel model)
        {
            if (HttpContext.Session["HangmanData"] != null)
            {
                Word word = this.hangamnProvider.GetRandomWord(w => ((model.SelectedLanguageID == 0) || w.LanguageID == model.SelectedLanguageID) &&
                    ((model.SelectedLevelID == 0) || w.LevelID == model.SelectedLevelID) && ((model.SelectedCategoryID == 0) || w.CategoryID == model.SelectedCategoryID));

                HangmanViewModel hangmanModel = (HangmanViewModel)HttpContext.Session["HangmanData"];

                model.Languages = hangmanModel.Languages;
                model.Levels = hangmanModel.Levels;
                model.Categories = hangmanModel.Categories;

                if (word != null)
                {
                    model.HangmanResultID = hangmanModel.HangmanResultID;
                    model = await this.LoadWordDetailsIntoModel(model, word);

                    HangmanResult result = new HangmanResult();
                    result.ResultID = hangmanModel.HangmanResultID;
                    result.WordID = word.WordID;
                    result.WrongAssumption = 0;
                    result.IsWinner = false;

                    this.hangamnProvider.SaveResult(result);

                    HttpContext.Session["HangmanData"] = model;
                }
            }

            // If session is destroyed, redirect to index page.
            return this.View(model);
        }

        public ActionResult CheckLetter(string letters, string word)
        {
            // If session is destroyed, redirect to index page.
            if (HttpContext.Session["HangmanData"] == null)
            {
                return this.RedirectToAction("Index");
            }

            HangmanViewModel hangmanModel = (HangmanViewModel)HttpContext.Session["HangmanData"];
            HttpContext.Session["HangmanData"] = null;

            // Check whether is entered the full word
            if (word != null)
            {
                char[] spellingEteredWord = word.ToLower().ToCharArray();
                hangmanModel = this.CheckEnteredWord(hangmanModel, spellingEteredWord);

                if (hangmanModel == null)
                {
                    return this.RedirectToAction("Index");
                }
            }
            else
            {
                hangmanModel = this.CheckWordContainsLetter(hangmanModel, letters[0]);
            }

            // Check for end of the game.
            if (hangmanModel.WordDetails.MissedLettersCount == 0 || hangmanModel.WordDetails.WrongLettersCount >= 5)
            {
                hangmanModel.WordDetails.SpellingWords = hangmanModel.WordDetails.WordName;

                HangmanResult result = new HangmanResult();
                result.ResultID = hangmanModel.HangmanResultID;
                result.WrongAssumption = hangmanModel.WordDetails.WrongLettersCount;
                result.IsWinner = hangmanModel.WordDetails.MissedLettersCount == 0 ? true : false;

                this.hangamnProvider.SaveResult(result);
            }
            else
            {
                HttpContext.Session["HangmanData"] = hangmanModel;
            }

            return this.PartialView("Partial/Hangman", hangmanModel.WordDetails);
        }

        public ActionResult GetHelpForWord()
        {
            // If session is destroyed, redirect to index page.
            if (HttpContext.Session["HangmanData"] == null)
            {
                return this.RedirectToAction("Index");
            }

            HangmanViewModel hangmanModel = (HangmanViewModel)HttpContext.Session["HangmanData"];

            if (hangmanModel.WordDetails.WrongLettersCount <= 3)
            {
                List<WordHelp> helps = this.hangamnProvider.GetHelpsForWord(hangmanModel.WordDetails.WordID).ToList();

                if (helps.Count() > 0)
                {
                    hangmanModel.WordDetails.WordHelps = this.hangamnProvider.GetHelpsForWord(hangmanModel.WordDetails.WordID).ToList();
                    hangmanModel.WordDetails.WrongLettersCount += 1;
                }
                else
                {
                    hangmanModel.WordDetails.WordHelps = new List<WordHelp> { new WordHelp() { Content = "Съжаляваме, но няма налична помощ за тази дума." } };
                }

                HttpContext.Session["HangmanData"] = hangmanModel;
            }
            else
            {
                hangmanModel.WordDetails.Message = "В този момент от играта, не може да използвате помощ";
            }

            return this.PartialView("Partial/Hangman", hangmanModel.WordDetails);
        }

        #region Helpers Methods
        private HangmanViewModel CheckWordContainsLetter(HangmanViewModel hangmanModel, char selectedLetter)
        {
            int containsCount = 0;

            List<char> onlyMissedLetters = hangmanModel.WordDetails.SpellingWords.Where(l => l == ' ').ToList();

            for (int i = 0; i < hangmanModel.WordDetails.SpellingWords.Count(); i++)
            {
                if ((hangmanModel.WordDetails.SpellingWords[i] == '_') && (selectedLetter == hangmanModel.WordDetails.WordName[i]))
                {
                    hangmanModel.WordDetails.SpellingWords[i] = selectedLetter;
                    containsCount++;
                }
            }

            if (containsCount > 0)
            {
                hangmanModel.WordDetails.MissedLettersCount -= containsCount;
            }
            else
            {
                hangmanModel.WordDetails.WrongLetters.Add(selectedLetter);
                hangmanModel.WordDetails.WrongLettersCount += 1;
            }

            return hangmanModel;
        }

        private HangmanViewModel CheckEnteredWord(HangmanViewModel hangmanModel, char[] enteredWord)
        {
            int elementIndex = 0;
            for (int i = 0; i < hangmanModel.WordDetails.SpellingWords.Count(); i++)
            {
                if ((hangmanModel.WordDetails.SpellingWords[i] == '_') && (hangmanModel.WordDetails.WordName[i] == enteredWord[elementIndex]))
                {
                    hangmanModel.WordDetails.MissedLettersCount -= 1;
                    elementIndex++;
                }
            }

            if (hangmanModel.WordDetails.MissedLettersCount > 0)
            {
                // Game over, sets maximum count of errors.
                hangmanModel.WordDetails.WrongLettersCount = 5;
                hangmanModel.WordDetails.SpellingWords = hangmanModel.WordDetails.WordName;
            }

            return hangmanModel;
        }

        private async Task<HangmanViewModel> GetAllFilters(HangmanViewModel hangmanModel)
        {
            hangmanModel.Languages = this.hangamnProvider.GetAllLanguages();
            hangmanModel.Levels = this.hangamnProvider.GetAllLevels();
            hangmanModel.Categories = this.hangamnProvider.GetAllCategories();

            return hangmanModel;
        }

        private async Task<HangmanViewModel> LoadWordDetailsIntoModel(HangmanViewModel hangmanModel, Word word)
        {
            if (hangmanModel.Languages == null)
            {
                hangmanModel.Languages = this.hangamnProvider.GetAllLanguages();
            }

            int missedLettersCount = 0;
            int whiteSpacesCount = 1;
            List<char> spellingWords = new List<char>();
            List<string> splitWords = word.Name.Trim().Split(' ').ToList();

            foreach (string splitWord in splitWords)
            {
                char[] splitWordChars = splitWord.ToCharArray();
                for (int i = 0; i < splitWordChars.Count(); i++)
                {
                    if ((i == 0) || (i == splitWordChars.Count() - 1))
                    {
                        spellingWords.Add(splitWordChars[i]);
                    }
                    else
                    {
                        spellingWords.Add('_');
                        missedLettersCount++;
                    }
                }

                if (splitWords.Count() > whiteSpacesCount && (whiteSpacesCount <= splitWords.Count() - 1))
                {
                    spellingWords.Add(' ');
                    whiteSpacesCount++;
                }
            }

            hangmanModel.WordDetails = new WordDetails();
            hangmanModel.WordDetails.WordID = word.WordID;
            hangmanModel.WordDetails.Alphabet = hangmanModel.Languages.FirstOrDefault(l => l.LanguageID == word.LanguageID).Alphabet.ToCharArray();
            hangmanModel.WordDetails.SpellingWords = spellingWords;
            hangmanModel.WordDetails.WordName = word.Name.Trim().ToCharArray().ToList();
            hangmanModel.WordDetails.WrongLetters = new List<char>();
            hangmanModel.WordDetails.MissedLettersCount = missedLettersCount;
            hangmanModel.WordDetails.WrongLettersCount = 0;
            hangmanModel.WordDetails.WordDescription = word.Description;
            hangmanModel.SelectedCategoryID = word.CategoryID;
            hangmanModel.SelectedLanguageID = word.LanguageID;
            hangmanModel.SelectedLevelID = word.LevelID;

            return hangmanModel;
        }
        #endregion
    }
}