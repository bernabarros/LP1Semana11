using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuessTheWord
{
    public class View
    {
        public void AskForGuess()
        {
            Console.WriteLine("Guess the full word!");
        Console.WriteLine($"Hint: It's a {hint}.");
        Console.WriteLine($"Word: {new string(display)}");
        }
        public void PlayerGuess()
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
    }
}