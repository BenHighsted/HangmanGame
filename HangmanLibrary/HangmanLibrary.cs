using System;

namespace HangmanLibrary
{
    public class Hangman
    {
        public readonly String[] words = { "Hello World", "Developer", "C Sharp", "Coder" };

        /// <summary>
        /// Generates a random word that the user will have to try and guess.
        /// This should be called during initiation of the GUI.
        /// </summary>
        /// <returns>Returns the generated word.</returns>
        public String GenerateWord()
        {
            Random rand = new Random();
            return words[rand.Next(words.Length)];
        }

        /// <summary>
        /// Checks if the letter guessed is contained in the answer.
        /// </summary>
        /// <param name="word">The word the user is trying to guess</param>
        /// <param name="letter">The letter the user has guessed</param>
        /// <returns>If the letter is contained, the index of the letter is returned</returns>
        public int CheckLetter(String word, char letter)
        {
            int i = 0;

            foreach (char c in word)
            {
                if (c.CompareTo(letter) == 0)
                    return i;
                else
                    i++;
            }
            return -1; //if not contained in word, return -1 to indicate it wasnt found
        }

        /// <summary>
        /// Checks if the word guessed matches the answer.
        /// </summary>
        /// <param name="word">The word the user is trying to guess</param>
        /// <param name="guess">The word the user has entered as their guess</param>
        /// <returns>Returns true if the guess was correct, otherwise it returns else</returns>
        public bool GuessWord(String word, String guess)
        {
            if (word.Equals(guess))
                return true;
            else
                return false;
        }

    }
}