using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MorseCodeChallengeMVC.Models;

namespace MorseCodeChallengeMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // instantiate the model to prevent null object reference when there is no data in the model
            HomeViewModel model = new HomeViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HomeViewModel model)
        {
           Dictionary<char, string> codes = new Dictionary<char, string>();

           var characters = model.Characters;

            model.Result = TranslateTextToMorse(characters); 
          
           return View(model); 
        }

        private static string TranslateTextToMorse(string textInput)
        {
            var morseDictionary = new Dictionary<char, string>()
            {
                {'a', ".-"},{'b', "-..."},{'c', "-.-."},{'d', "-.."},{'e', "."},{'f', "..-."},{'g', "--."},{'h', "...."}, {'i', ".."}, {'j', ".---"},{'k', "-.-"}, {'l', ".-.."}, {'m', "--"}, {'n', "-."},{'o', "---"},
                {'p', ".--."},{'q', "--.-"},{'r', ".-."},{'s', "..."},{'t', "-"},{'u', "..-"}, {'v', "...-"},{'w', ".--"},{'x', "-..-"}, {'y', "-.--"}, {'z', "--.."}
            };

            StringBuilder morseStringBuilder = new StringBuilder();
            if (!string.IsNullOrEmpty(textInput))
            {
                foreach (char character in textInput)
                {
                    if (morseDictionary.ContainsKey(character))
                    {
                        morseStringBuilder.Append(morseDictionary[character] + " ");
                    }
                    else if (character == ' ')
                    {
                        morseStringBuilder.Append(" / ");
                    }
                }
            }
            return morseStringBuilder.ToString();
        }
    }
}