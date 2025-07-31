using System;
using System.Linq;
using System.Collections.Generic;

namespace Game
{
    class miniWordleFuncs
    {



        //prints the grid
        public static void printGrid(char[] grid)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(grid[(i * 5) + j] + " ");
                }
                Console.WriteLine();
            }
        }


        //checks in the guess length is 5 letters only and that characters are A-Z
        public static bool validGuess(string guess)
        {
            if (!(guess.All(char.IsLetter))) { return false; }
            int guessLen = guess.Length;
            if (guessLen != 5) { return false; } else { return true; }
        }


        //checks if the guess is correct
        public static void checkCorrect(char[] guessSplit, char[] randWordSplit, List<char> recordedCorrectGuesses)
        {
            for (int i = 0; i < 5; i++)
            {
                if (guessSplit[i] == randWordSplit[i])
                {
                    Console.WriteLine($"The letter {guessSplit[i]} is in the correct position!");
                    recordedCorrectGuesses.Add(guessSplit[i]);
                }
                else if (Array.Exists(randWordSplit, c => c == guessSplit[i]))
                {
                    Console.WriteLine($"The letter {guessSplit[i]} is somewhere in the word!");
                }
                else
                {
                    Console.WriteLine($"The letter {guessSplit[i]} is not in the word. Try a different one!");
                }
            }
        }



    }
}
