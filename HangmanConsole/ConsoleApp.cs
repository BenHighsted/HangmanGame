using System;
using HangmanLibrary;
using System.Collections.Generic;

namespace HangmanConsole
{
    class HangmanConsole
    {
        //according to the internet, 6 is the number of guesses for a standard game
        private readonly int totalGuesses = 6;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Ben Highsted's Hangman Console Game.");
            SetupGame();
        }

        private static void SetupGame()
        {
            Hangman game = new Hangman();
            string word = game.GenerateWord();

            string puzzle = GeneratePuzzle(word);

            RunGame(game, word, puzzle);
        }

        private static void RunGame(Hangman game, string word, string puzzle)
        {
            Console.WriteLine("The generated puzzle: " + puzzle);

            Console.WriteLine("Enter a single letter, or try guess the word.");

            bool word_not_guessed = false;
            int guesses = 0;

            while (!word_not_guessed)
            {
                string input = Console.ReadLine();

                // Console.Clear(); (Clears the contents on the screen, might be useful later)

                if (input.Length == 1)
                {
                    Console.WriteLine("You entered the letter: " + input);
                    if (game.CheckLetter(word, input) != -1)
                    {
                        puzzle = UpdatePuzzle(word, puzzle, input);
                    }
                    else {
                        guesses++;
                    }

                }
                else if (input.Length > 1)
                {
                    Console.WriteLine("You guessed the word: " + input);

                    if (game.GuessWord(word, input))
                    { //if the word was the correct guess
                        word_not_guessed = true;
                        Console.WriteLine("You win!");
                    }
                    else
                        guesses++;
                }
                else {
                    Console.WriteLine("Invalid Input.");
                }

                if (!word_not_guessed)
                {
                    Console.WriteLine(puzzle);
                    Console.WriteLine("Guesses so far: " + guesses + "\n");
                }
            }
        }

        private static string GeneratePuzzle(string word)
        {
            string puzzle = "";

            foreach (char letter in word)
            {
                if (letter.Equals(char.Parse(" ")))
                    puzzle += " ";
                else
                    puzzle += "_";
            }

            return puzzle;
        }

        private static string UpdatePuzzle(string word, string puzzle, string letter)
        {
            List<int> indexes = new List<int>();
            int count = 0;

            foreach (char character in word)
            {

                if (Char.ToUpper(character).Equals(char.Parse(letter.ToUpper())))
                {
                    indexes.Add(count);
                }

                count++;
            }

            char[] charsPuzzle = puzzle.ToCharArray();

            foreach (int index in indexes)
            {
                charsPuzzle[index] = char.Parse(letter.ToUpper());
            }

            return new string(charsPuzzle);
        }

    }
}


/*

    Could do something like this for a visual aspect?
    ______
    |    |
    o    |
    |    |
    /\   |
        ---

    Also thinking rather than just having an array of words, use a file to read
    in a list of words to pick from.

*/