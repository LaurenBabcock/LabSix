using System;

namespace LabSix
{
    class Program
    {
        static void Main(string[] args)
        {
            string userWord;
            string pigLatinWord;
            string lettersBeforeVowel;
            string lettersFromVowelOn;
            int vowelPosition;
            bool run = true;
         
            Console.WriteLine("Welcome to the Pig Latin Translator!");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();

            while (run == true)
            {

                bool enteredWord = false;

                while (enteredWord == false)
                {
                    //Prompt the user for a word to translate
                    Console.Write("Please enter a word to translate into Pig Latin: ");
                    userWord = Console.ReadLine();

                    //Confirm that the user did actually enter a word to translate. If they didn't enter a word, prompt them again.
                    if (userWord.Length == 0)
                    {
                        Console.WriteLine("I'm sorry, you forgot to type a word.");
                        enteredWord = false;
                    }
                    //If they did enter a word, convert it to pig latin
                    else
                    {                     
                        enteredWord = true;
                        //Convert to lowercase
                        userWord = userWord.ToLower();

                        //If the word starts with a vowel, just add "way" on to the ending
                        if (userWord.IndexOf("a") == 0 || userWord.IndexOf("e") == 0 || userWord.IndexOf("i") == 0 || userWord.IndexOf("o") == 0 || userWord.IndexOf("u") == 0)
                        {
                            pigLatinWord = userWord + "way";

                            Console.WriteLine("Your pig latin word is: " + pigLatinWord);
                        }
                        //If the word starts with a consonant, move all of the consonants that appear before the first vowel to the end of the word and add "ay" to the end
                        else
                        {
                            //Determine the location of the first vowel using the FindVowel method
                            vowelPosition = FindVowel(userWord);

                            //Create a substring of the consonants before the first vowel & a substring of the first vowel + all letters after it
                            lettersBeforeVowel = userWord.Substring(0, vowelPosition);
                            lettersFromVowelOn = userWord.Substring(vowelPosition);

                            //Combine the substrings into a new pig latin string: firstVowelString + consonantsBeforeVowelString + ay
                            pigLatinWord = lettersFromVowelOn + lettersBeforeVowel + "ay";

                            //Display the pig latin word to the user
                            Console.WriteLine("Your pig latin word is: " + pigLatinWord);

                        }
                        //See if they would like to translate another word
                        Console.WriteLine();
                        run = Continue();
                        Console.WriteLine();
                    }
                }

                
            }
        }

        static int FindVowel(string aString)
        {
            int vowelIndex = 0;

            //Change your string into an array of characters
            char[] individualChars = aString.ToCharArray();

            //Check each character to see if it is a vowel. As soon as the first vowel is found, return the index of that vowel.
            for (int i = 0; i < individualChars.Length - 1; i++)
            {
                if (individualChars[i] == 'a' || individualChars[i] == 'e' || individualChars[i] == 'i' || individualChars[i] == 'o' || individualChars[i] == 'u')
                {
                    vowelIndex = i;
                    break;
                }                           
            }
            //If there are no vowels, let the user know they may have mis-typed.
            if (vowelIndex == 0)
            {
                Console.WriteLine("You may have misspelled your word. Your word does not have any vowels in it.");
            }
            return vowelIndex;
        }

        static bool Continue()
        {
            Console.Write("Would you like to translate another word (Y/N)? ");
            string input = Console.ReadLine().ToUpper();
            bool doAgain;
            if (input == "Y")
            {
                doAgain = true;
            }
            else if (input == "N")
            {
                doAgain = false;
            }
            else
            {
                Console.WriteLine("That is not a valid response. Please try again.");
                doAgain = Continue();
            }

            return doAgain;
        }
    }
}
