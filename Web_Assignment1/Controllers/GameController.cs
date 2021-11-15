using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Assignment1.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
          
            return View();
        }
        [HttpGet]
        public IActionResult NumberGuessingGame()
        {
            Random ranNumber = new Random();
            int genNumber = ranNumber.Next(1, 100);
            HttpContext.Session.SetInt32("num", genNumber);
            return View("NumberGuessingGame");
        }
        [HttpPost]
        public IActionResult NumberGuessingGame(int guess)
        {
            
            int rightGuess = (int)HttpContext.Session.GetInt32("num");
            
            if (guess >= 1 && guess <= 100)
            {
                if (guess == rightGuess)
                {
                    ViewBag.Message = guess + "...is Correct Congratulations to you";

                    NumberGuessingGame();
                }
                else if (guess > rightGuess)
                {
                    ViewBag.Message = guess + " is too high!!!";
                }
                else
                {
                    ViewBag.Message = guess + " is too low!!!";
                }
            }
            else
            {
                ViewBag.Message = "Invalid number Value must be between 1 and 100.!.";
            }

            
            return View("NumberGuessingGame");
        }

    }
}
