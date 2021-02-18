using System;

namespace testingSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ReturnBool("oistmiahf", "halves"));
        }

        static bool ReturnBool(string setOfLetters, string word)
        {
            int currIndex = 0;

            while (currIndex <= word.Length - 1)
            {
                char currLetterOfWord = word[currIndex];

                if (setOfLetters.Contains(currLetterOfWord) == false)
                {
                    return false;
                }

                currIndex++;
            }

            return true;
        }
    }
}
