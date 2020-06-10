using System;
using HangmanLibrary;

namespace HangmanConsole
{
    class HangmanConsole
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Ben Highsted's Hangman Console Game.");
            SetupGame();
            
        }

        private static void SetupGame()
        {
            Hangman game = new Hangman();
            String word = game.GenerateWord();

            RunGame(game, word);
        }

        private static void RunGame(Hangman game, String word)
        {
            Console.WriteLine("Enter a single letter, or guess the word.");

            bool word_not_guessed = false;

            while (!word_not_guessed)
            {
                String input = Console.ReadLine();
                if (input.Length == 1)
                {
                    Console.WriteLine("You entered the letter: " + input);
                }
                else if (input.Length > 1)
                {
                    Console.WriteLine("You guessed the word: " + input);

                    if (word.Equals(input)) //if the word was the correct guess
                        word_not_guessed = true;
                }
                else {
                    Console.WriteLine("Invalid Input.");
                }
            }
        }

    }
}
