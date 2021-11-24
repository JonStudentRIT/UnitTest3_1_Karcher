using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // a reference to store the users input
            string input = "";
            // a reference that is used to store the formated input
            string palandromeCheck = "";
            // a bool used when outputing the results
            bool isAPalandrome = false;
            // prompt the user for input
            Console.WriteLine("Enter a string");
            // store the input
            input = Console.ReadLine();
            // reverse the input
            Console.WriteLine(Reverse(input));
            // output the letter count
            LetterCount(input.ToUpper());
            // is the input a palandrome
            //remove punctuation and spacing
            palandromeCheck = RemoveUnwantedChars(input.ToLower());
            // is it even
            if (input.Length % 2 == 0)
            {
                // fast check for an even string, split it in half and flip one side to see if they are the same string
                int half = palandromeCheck.Length / 2;
                string tempFirstHalf = palandromeCheck.Substring(0,half);
                string tempSecondHalf = palandromeCheck.Substring(half);
                tempSecondHalf = Reverse(tempSecondHalf);
                if(tempFirstHalf.Equals(tempSecondHalf))
                {
                    isAPalandrome = true;
                }
                Console.WriteLine(isAPalandrome);
            }
            // is it odd
            else
            {
                // split the string in half
                // integer division should result in a unballenced pair
                int half = palandromeCheck.Length / 2;
                string tempFirstHalf = palandromeCheck.Substring(0, half);
                // store all but the first char of the second half
                // skip the middle
                string tempSecondHalf = palandromeCheck.Substring(half + 1);
                // check if two stored strings are the same
                tempSecondHalf = Reverse(tempSecondHalf);
                if (tempFirstHalf.Equals(tempSecondHalf))
                {
                    isAPalandrome = true;
                }
                Console.WriteLine(isAPalandrome);
            }
        }
        /* Method: LetterCount
         * Purpose: Output the number of letters in a string case insensitive
         * Restrictions: None
         */
        static void LetterCount(string input)
        {
            // an array to store the number of letters in the input
            int[] letterCount = new int[26];
            for(int i = 0; i < input.Length; i++)
            {
                // use the decimal value of a char as the index of the letter being incramented
                letterCount[(int)input[i]-65]++;
            }
            // output the number of letters found
            for(int i = 0; i < letterCount.Length; i++)
            {
                // im assuming that the user is interested in the letters that they entered
                if (letterCount[i] != 0)
                {
                    Console.WriteLine((char)(65 + i) + " : " + letterCount[i]);
                }
            }
        }
        /* Method: Reverse
         * Purpose: Reverse any string entered
         * Restrictions: None
         */
        static string Reverse(string s)
        {
            string reverse = "";
            // start at the end incrament toward the first letter
            for (int i = s.Length - 1; i > -1; i--)
            {
                reverse = reverse + s[i];
            }
            return reverse;
        }
        /* Method: Reverse
         * Purpose: Remove chars that can interfere with later processing of the string
         * Restrictions: None
         */
        static string RemoveUnwantedChars(string s)
        {
            string temp = "";
            for (int i = 0; i < s.Length; i++)
            {
                // look specifically for space and punctuation
                if (s[i] != ' ' && !Char.IsPunctuation(s[i]))
                {
                    temp = temp + s[i];
                }
            }
            return temp;
        }
    }
}
