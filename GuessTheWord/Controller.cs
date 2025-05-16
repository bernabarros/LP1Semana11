using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuessTheWord
{
    public class Controller
    {
        private readonly IView view;
        private readonly WordDictionary worddictionary;

        public Controller(IView view, WordDictionary worddictionary)
        {
            this.view = view;
            this.worddictionary = worddictionary;
        }

        public string ChooseRandomWord()
        {
            // Select a random word
            Random rand = new Random();
            List<string> words = new List<string>(worddictionary.Keys);
            string chosenWord = words[rand.Next(words.Count)];
            return chosenWord;
        }
        public string GetWordHint()
        {
            string hint = worddictionary[ChooseRandomWord()];
            return hint;
        }
        public void PlayerGuess(string chosenWord)
        {
            string guess;
            do
            {
                Console.Write("Your guess: ");
                guess = Console.ReadLine().Trim().ToLower();

                if (guess != chosenWord)
                    Console.WriteLine("Incorrect. Try again.");
            } while (guess != chosenWord);

            Console.WriteLine("Correct! Well done!");
            Console.WriteLine($"The word was \"{chosenWord}\".");
        }

        public void Run(IView view)
        {
            Word chosenword = new Word(ChooseRandomWord(), GetWordHint());
        }
    }
}