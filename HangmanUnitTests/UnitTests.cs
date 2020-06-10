using Microsoft.VisualStudio.TestTools.UnitTesting;
using HangmanLibrary;
using System;

namespace HangmanUnitTests
{
    [TestClass]
    public class BaseTests
    {
        [TestMethod]
        public void CheckWordGeneration() //Simply checks if a word was correctly generated
        { 
            Hangman game = new Hangman();
            bool result = false;

            if (Array.IndexOf(game.words, game.GenerateWord()) >= 0)
            {
                result = true;
            }

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckLetter()
        {
            Hangman game = new Hangman();
            Assert.AreEqual(1, game.CheckLetter("test", "e"));
        }

        [TestMethod]
        public void GuessWord()
        {
            Hangman game = new Hangman();
            Assert.IsTrue(game.GuessWord(game.words[0], "Hello World"));
        }

    }

    [TestClass]
    public class InvalidInputs
    {
        [TestMethod]
        public void InvalidCheckLetter()
        {
            Hangman game = new Hangman();
            Assert.AreEqual(-1, game.CheckLetter("test", "-"));
        }

        [TestMethod]
        public void InvalidGuessWord()
        {
            Hangman game = new Hangman();
            Assert.IsFalse(game.GuessWord(game.words[0], "Test!"));
        }
    }
}
