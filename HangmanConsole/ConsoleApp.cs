using System;
using HangmanLibrary;
using System.Collections.Generic;

namespace HangmanConsole
{
    class HangmanConsole
    {
        //according to the internet, 6 is the number of guesses for a standard game

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
            int totalGuesses = 6;

            Console.WriteLine("The generated puzzle: " + puzzle);

            Console.WriteLine("Enter a single letter, or try guess the word.");

            bool word_not_guessed = false;
            bool invalid = false;

            int guesses = 0;

            List<String> guessedLetters = new List<String>();

            while (!word_not_guessed)
            {
                string input = Console.ReadLine();

                // Console.Clear(); (Clears the contents on the screen, might be useful later)

                if (input.Length == 1)
                {
                    Console.WriteLine("You entered the letter: " + input);
                    if (!guessedLetters.Contains(input.ToUpper()))
                    {
                        if (game.CheckLetter(word, input) != -1)
                        {
                            puzzle = UpdatePuzzle(word, puzzle, input);
                            guessedLetters.Add(input.ToUpper());

                        }
                        else
                        {
                            guessedLetters.Add(input.ToUpper());
                            guesses++;
                        }
                    }
                    else {
                        Console.WriteLine("You already guessed that letter. Try again.");
                        invalid = true;
                    }

                }
                else if (input.Length > 1)
                {
                    Console.WriteLine("You guessed the word: " + input.ToUpper());

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
                    invalid = true;
                }

                if (!word_not_guessed && !invalid)
                {
                    Console.WriteLine(puzzle.ToUpper());

                    Console.WriteLine("Incorrect guesses so far: " + guesses + "\n");

                    Console.Write("Guessed letters: ");
                    foreach (String letter in guessedLetters) {
                        Console.Write(letter + ", ");
                    }
                    Console.WriteLine();
                }

                invalid = false;

                if (guesses == totalGuesses) {
                    Console.WriteLine("You Lose!");
                    break;
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