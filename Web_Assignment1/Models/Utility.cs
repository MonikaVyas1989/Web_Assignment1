using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Assignment1.Models
{
    public class Utility
    {
        public static float Number { get; set; }

        public static string CheckFever()
        {
            return "Please Enter Value to check You have fever or not";
        }
        public static string CheckFever(float num)
        {
            string message; 
            if (num >= 105) // Value of num  is checked as per fever temperature..
            {
                message = "You have a high Fever";
            }
            else if (num >= 100 && num < 105)
            {
                message = "You have a Fever";
            }
            else if (num >= 1 && num < 100)
            {
                message = "You do not have a Fever";

            }
            else
            {
                message = "";
            }


            return message;
        }
    }
}
