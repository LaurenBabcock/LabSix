using System;

namespace LabSix
{
    class Program
    {
        static void Main(string[] args)
        {
            string userText;
            string pigLatinWord = null;
            string lettersBeforeVowel;
            string lettersFromVowelOn;
            int vowelPosition;
            bool run = true;
            

            Console.WriteLine("Welcome to the Pig Latin Translator!");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();

            while (run == true)
            {
                string translatedSentence = null;

                bool enteredWord = false;

                while (enteredWord == false)
                {
                    //Prompt the user for a word or phrase to translate
                    Console.Write("Please enter something to translate into Pig Latin: ");
                    userText = Console.ReadLine();

                    //Confirm that the user did actually enter something to translate. If they didn't enter anything, prompt them again.
                    if (userText.Length == 0)
                    {
                        Console.WriteLine("I'm sorry, you forgot to type a word.");
                        enteredWord = false;
                    }
                    //If they did enter something, convert it to pig latin
                    else
                    {                     
                        enteredWord = true;

                        string[] wordsArray = userText.Split(' ');

                        foreach (string word in wordsArray)
                        {
                            vowelPosition = FindVowel(word);

                            //If the word starts with a vowel, just add "way" on to the ending
                            if (vowelPosition == 0)
                            {
                                pigLatinWord = word + "way";
                            }
                            //If the word starts with a consonant, move all of the consonants that appear before the first vowel to the end of the word and add "ay" to the end
                            else if (vowelPosition > 0)
                            {
                                //Create a substring of the consonants before the first vowel & a substring of the first vowel + all letters after it
                                lettersBeforeVowel = word.Substring(0, vowelPosition);
                                lettersFromVowelOn = word.Substring(vowelPosition);

                                //Combine the substrings into a new pig latin string: firstVowelString + consonantsBeforeVowelString + ay
                                pigLatinWord = lettersFromVowelOn + lettersBeforeVowel + "ay";

                            }
                            //If there are no vowels, let the user know they may have mis-typed.
                            else if (vowelPosition == -1)
                            {
                                pigLatinWord = word;
                            }

                            //Add the translated word on to the current sentence
                            translatedSentence = translatedSentence + " " + pigLatinWord;                          
                        }

                        //Out put their translated text
                        Console.WriteLine("Your translated text is: " + translatedSentence);

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
            int vowelIndex = -1;
            aString = aString.ToLower();

            //Change your string into an array of characters
            char[] individualChars = aString.ToCharArray();

            //Check each character to see if it is a vowel. As soon as the first vowel is found, return the index of that vowel.
            for (int i = 0; i <= individualChars.Length - 1; i++)
            {
                if (individualChars[i] == 'a' || individualChars[i] == 'e' || individualChars[i] == 'i' || individualChars[i] == 'o' || individualChars[i] == 'u')
                {
                    vowelIndex = i;
                    break;
                }                           
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
