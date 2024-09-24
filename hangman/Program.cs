using System;
using System.Collections.Generic;

namespace hangman
{
    class Program
    {
        class Settings
        {
            private List<string> animals = new List<string> { "dog", "cat", "bird", "rhino", "tiger", "lion", "giraffe", "dolphin", "hamster" };
            private List<string> cars = new List<string> { "sedan", "coupe", "convertible", "hatchback", "SUV", "truck", "van", "wagon", "sports car" };
            private List<string> fruits = new List<string> { "apple", "banana", "cherry", "date", "elderberry", "fig", "grape", "kiwi", "lemon" };

            private static readonly Random getrandom = new Random();
            private int lindex;
            private string chosenword;
            private List<string> currentList;
            private string underscores;  
            private int incorrectGuesses;  
            public const int MaxIncorrectGuesses = 6; 
            private HashSet<char> guessedLetters;  

            public Settings()
            {
                currentList = animals;
                underscores = ""; 
                incorrectGuesses = 0; 
                guessedLetters = new HashSet<char>(); 
            }

            public void SetList(string listType)
            {
                switch (listType.ToLower())
                {
                    case "animals":
                        currentList = animals;
                        break;
                    case "cars":
                        currentList = cars;
                        break;
                    case "fruits":
                        currentList = fruits;
                        break;
                    default:
                        Console.WriteLine("Invalid list type. Defaulting to animals.");
                        currentList = animals;
                        break;
                }
                GetWord();
            }

            private void GetWord()
            {
                lindex = getrandom.Next(currentList.Count-1);
                chosenword = currentList[lindex];
                int chosenWordLength = chosenword.Length;
                underscores = new string('_', chosenWordLength);  
            }

            public string GetChosenWord()
            {
                return chosenword;
            }

            public string GetUnderScores()
            {
                return underscores;  
            }

            public void UpdateUnderscores(char guess)
            {
                bool correctGuess = false;
                char[] underscoresArray = underscores.ToCharArray();

                for (int i = 0; i < chosenword.Length; i++)
                {
                    if (chosenword[i] == guess)
                    {
                        underscoresArray[i] = guess;
                        correctGuess = true;
                    }
                }

                underscores = new string(underscoresArray);

                if (!correctGuess)
                {
                    incorrectGuesses++;
                }
            }

            public bool HasGuessedAllLetters()
            {
                return underscores.Equals(chosenword);
            }

            public bool IsGameOver()
            {
                return incorrectGuesses >= MaxIncorrectGuesses;
            }

            public int GetIncorrectGuesses()
            {
                return incorrectGuesses;
            }

            public void ResetIncorrectGuesses()
            {
                incorrectGuesses = 0;
            }

            public void AddGuessedLetter(char letter)
            {
                guessedLetters.Add(letter);
            }

            public HashSet<char> GetGuessedLetters()
            {
                return guessedLetters;
            }
        }

        static void Main(string[] args)
        {
            Settings settings = new Settings();
            bool continueRunning = true;

            while (continueRunning)
            {
                settings.ResetIncorrectGuesses();
                settings.GetGuessedLetters().Clear(); 
                Console.WriteLine("Choose a list to get a word from (animals, cars, fruits) or type 'exit' to quit:");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    continueRunning = false;
                }
                else
                {
                    settings.SetList(input);
                    
                    bool guessing = true;
                    while (guessing)
                    {
                        Console.WriteLine($"Current word status: {settings.GetUnderScores()}");
                        Console.WriteLine($"Incorrect guesses: {settings.GetIncorrectGuesses()} / {Settings.MaxIncorrectGuesses}");
                        Console.WriteLine($"Guessed letters: {string.Join(", ", settings.GetGuessedLetters())}");
                        Console.Write("Guess a letter: ");
                        string userInput = Console.ReadLine();

                        if (!string.IsNullOrEmpty(userInput) && userInput.Length == 1)
                        {
                            char userGuess = userInput[0];  

                            if (char.IsLetter(userGuess))
                            {
                                if (!settings.GetGuessedLetters().Contains(userGuess))
                                {
                                    settings.AddGuessedLetter(userGuess);
                                    settings.UpdateUnderscores(userGuess);

                                    if (settings.IsGameOver())
                                    {
                                        Console.WriteLine("Game over! You've made too many incorrect guesses.");
                                        Console.WriteLine($"The word was: {settings.GetChosenWord()}");
                                        guessing = false;
                                    }
                                    else if (settings.HasGuessedAllLetters())
                                    {
                                        Console.WriteLine("Congratulations! You've guessed the word.");
                                        guessing = false;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You've already guessed that letter. Try another.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a letter.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter a single letter.");
                        }
                    }
                }
            }
        }
    }
}
