using System;
using System.Linq;
using System.Collections.Generic;

namespace Game
{

    class miniWordleMain
    {
        static void Main(string[] args)
        {
            //all words
            string[] wordList = { "apple", "crane", "ghost", "lemon", "storm", "chair", "bread", "tiger", "ocean", "plant",
            "magic", "globe", "house", "drive", "beach", "smile", "clock", "sound", "flame", "cloud",
            "space", "dance", "water", "quick", "blank", "earth", "light", "music", "power", "dream",
            "stone", "river", "grape", "round", "block", "shine", "brown", "green", "wheel", "peace",
            "heart", "voice", "knife", "sword", "seven", "night", "truck", "glass", "paper", "phone",
            "black", "white", "horse", "snake", "world", "flute", "piano", "radio", "coral", "field",
            "table", "shelf", "grass", "roses", "sugar", "honey", "money", "solar", "super", "royal",
            "trade", "fresh", "birth", "metal", "cabin" };

            //30 chars
            char[] wordleGrid = { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*',
            '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*'};

            Random rand = new Random();
            int randPick = rand.Next(0, 74);
            string randWord = wordList[randPick]; //picks random word to be guessed
            char[] randWordSplit = randWord.ToCharArray();
            int guessAttempts = 0;
            int offset = 0;
            var rCG = new List<char>();

            Console.WriteLine("Welcome to Mini Wordle! You get 6 tries to guess the word!");

            //attempts begin
            while (guessAttempts < 6 && rCG.Distinct().Count() != 5)
            {
                Game.miniWordleFuncs.printGrid(wordleGrid);
                Console.Write("Input guess here: ");
                string guess = Console.ReadLine();

                bool checkGuess = Game.miniWordleFuncs.validGuess(guess);
                if (checkGuess)
                {
                    char[] guessSplit = guess.ToCharArray();

                    for (int i = 0; i < 5; i++)
                    {
                        wordleGrid[i + offset] = guessSplit[i];
                    }

                    //checks for any letters in the word or in the correct position
                    Game.miniWordleFuncs.checkCorrect(guessSplit, randWordSplit, rCG);

                    offset += 5;
                    guessAttempts++;
                }
                else
                { //condition only met when the guess isn't 5 characters, attempts are not counted
                    Console.WriteLine("Invalid guess. Word must only contain letters A-Z and be 5 characters long. Try again!");
                    continue;
                }
            }

            if (rCG.Distinct().Count() == 5)
            {
                Game.miniWordleFuncs.printGrid(wordleGrid);
                Console.WriteLine($"You guessed the correct word, {randWord}, in {guessAttempts} attempts! Nice job!");
            }
            else
            {
                Game.miniWordleFuncs.printGrid(wordleGrid);
                Console.WriteLine($"The correct word was: {randWord}. Good try!");
            }
        }
    }

}