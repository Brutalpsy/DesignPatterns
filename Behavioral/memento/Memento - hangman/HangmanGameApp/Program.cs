#define SupportUndo


using HangmanClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace HangmanGameApp
{
    class Program
    {
        static void Main(string[] args)
        {
#if SupportUndo
            //MEMENTO NOTES:
            // HangmanGameWithUndo == ORIGINATOR
            // This Main Program   == CARETAKER
            // HangmanMemento      == MEMENTO
            var game = new HandmanWithUndo();
            var gameHistory = new Stack<HangmanMemento>();
            gameHistory.Push(game.CreateSetPoint());

#else
            var game = new Hangman();
#endif

            while (!game.IsOver)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Welcome to Hangman");

                Console.WriteLine(game.CurrentMaskedWord);
                Console.WriteLine($"Previous Guesses: {string.Join(',',game.PreviousGuesses.ToArray())}");
                Console.WriteLine($"Guesses Left: {game.GuessesRemaining}");

#if SupportUndo
                Console.WriteLine("Guess (a-z or '-' to undo last guess)");
#else

                Console.WriteLine("Guess (a-z): ");
#endif
                var entry = char.ToUpperInvariant(Console.ReadKey().KeyChar);

#if SupportUndo
                if (entry == '-')
                {
                    if(gameHistory.Count > 1)
                    {
                        gameHistory.Pop();
                        game.ResumeFrom(gameHistory.Peek());
                        Console.WriteLine();
                    }
                }
#endif
                try
                {
                    game.Guess(entry);
                    Console.WriteLine();

                    gameHistory.Push(game.CreateSetPoint());


                }
                catch (DoubleGuessException)
                {
                    OutputError("You already guessed that letter");
                }
                catch(InvalidGuessException ex)
                {
                    OutputError(ex.Message);
                }
            }

            if (game.Result == GameResult.Won)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Congrats! You won!");
            }

            if (game.Result == GameResult.Lost)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry! You lost this time. Try again!");
            }

        }

        private static void OutputError(string message)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            Thread.Sleep(3000);
        }
    }
}
