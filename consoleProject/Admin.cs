using System;
using System.Collections.Generic;
using System.Threading;


namespace consoleProject
{
    static class Admin
    {


        public static List<KeyValuePair<string, string>> moviesList = new List<KeyValuePair<string, string>>();
        private static int playingToday;

        static Admin()
        {
            Admin.WrongPassWordCount = 5;
            Admin.CorrectPassword = "pc";
        }

        static int WrongPassWordCount { get; set; }

        static string CorrectPassword { get; set; }

        public static void AdminHeading()
        {
            Console.Clear();
            MainScreen.ChangeColorToBlue();
            Console.WriteLine();
            MainScreen.CenterText("****************************************");
            MainScreen.CenterText("****************  Admin Menu  ****************");
            MainScreen.CenterText("****************************************");
            MainScreen.ChangeColorToWhite();
            Console.WriteLine();
        }

        public static void AdminMenu()
        {
            AdminHeading();

            while (WrongPassWordCount != 0)
            {
                WrongPassWordCount--;
                MainScreen.ChangeColorToBlue();
                Console.Write("\n  Please Enter the Admin Password: ");
                MainScreen.ChangeColorToDarkGray();

                //https://stackoverflow.com/questions/3404421/password-masking-console-application
                string enteredPassword = "";
                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    // Backspace Should Not Work
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        enteredPassword += key.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && enteredPassword.Length > 0)
                        {
                            enteredPassword = enteredPassword.Substring(0, (enteredPassword.Length - 1));
                            Console.Write("\b \b");
                        }
                        else if (key.Key == ConsoleKey.Enter)
                        {
                            break;
                        }
                    }
                } while (true);
                MainScreen.ChangeColorToWhite();


                if (String.Equals(CorrectPassword, enteredPassword))
                {
                    MainScreen.ChangeColorToBlue();
                    Console.WriteLine();
                    MainScreen.Loading(150);
                    Console.WriteLine("\n  Logging you in.");
                    MainScreen.ChangeColorToWhite();
                    Thread.Sleep(400);
                    Console.Clear();
                    AdminMenuMoviesPlayingToday();
                    break;
                }
                else if (enteredPassword == "0")
                {
                    Console.Clear();
                    MainScreen.MainMenu();
                    break;
                }
                else if (WrongPassWordCount == 0)
                {
                    AdminHeading();
                    Console.Beep();
                    MainScreen.ChangeColorToRed();
                    Console.WriteLine("  Invalid password.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("  You have");
                    MainScreen.ChangeColorToBlue();
                    Console.Write(" {0} ", WrongPassWordCount);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("more attempts to enter the correct password.");
                    Thread.Sleep(2000);
                    MainScreen.ChangeColorToDarkGray();
                    Console.WriteLine("\n\nGoing back to Main Screen.");
                    MainScreen.Loading(150);

                    MainScreen.MainMenu();

                }
                else
                {
                    AdminHeading();
                    Console.Beep();
                    MainScreen.ChangeColorToRed();
                    Console.WriteLine("  Invalid password.\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("  You have");
                    MainScreen.ChangeColorToBlue();
                    Console.Write(" {0} ", WrongPassWordCount);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("more attempts to enter the correct password" +
                        "\n\t\t\tOR");
                    MainScreen.ChangeColorToDarkGray();
                    Console.WriteLine("\n  Press '0' to go back to the previous screen.\n");
                }
            }
        }

        private static void AdminMenuMoviesPlayingToday()
        {
            AdminHeading();

            MainScreen.ChangeColorToDarkYellow();
            Console.WriteLine("  Welcome MoviePlex Administrator.\n\n");
            MainScreen.ChangeColorToBlue();
            Console.Write("  How many movies are playing today?");
            MainScreen.ChangeColorToDarkGray();
            Console.WriteLine(" (Maximum 10)");
            MainScreen.ChangeColorToBlue();
            Console.Write("  > ");
            int menuType = 2;
            Console.ForegroundColor = ConsoleColor.Gray;
            string userInput = Console.ReadLine();
            if (userInput == "")
            {
                CustomException.NoInputDetected();
                AdminMenuMoviesPlayingToday();
            }

            try
            {
                CustomException.ValidateInput(Convert.ToInt32(userInput), menuType);
            }
            catch (CustomException)
            {
                AdminMenuMoviesPlayingToday();
            }
            catch (OverflowException)
            {
                CustomException.OverflowErrorMessage();
                AdminMenuMoviesPlayingToday();
            }
            catch (FormatException)
            {
                CustomException.FormatErrorMessage();
                AdminMenuMoviesPlayingToday();
            }
            switch (userInput)
            {
                default:
                    playingToday = Convert.ToInt32(userInput);
                    AdminMenuAddMovies();
                    break;
            }
        }

        public static void AdminMenuAddMovies()
        {
            AdminHeading();
            int moviesPlayingToday = playingToday;
            string movieName;
            string ratingOrAge;
            Dictionary<int, string> numbers = new Dictionary<int, string>(){
                    {1, "First" },
                    {2, "Second" },
                    {3, "Third" },
                    {4, "Fourth" },
                    {5, "Fifth" },
                    {6, "Sixth" },
                    {7, "Seventh" },
                    {8, "Eighth" },
                    {9, "Ninth" },
                    {10, "Tenth" },
                };

            bool flag = false;

            for (int x = moviesList.Count + 1; x <= moviesPlayingToday; x++)
            {
                Console.WriteLine();
                getMovieName(numbers[x]);
                getMovieRating(numbers[x]);
            }

            void getMovieName(string serialOrder)
            {
                if (moviesList.Count > 0 && flag == true)
                {
                    AdminHeading();
                    flag = false;
                    for (int x = 0; x < moviesList.Count; x++)
                    {
                        MainScreen.ChangeColorToDarkYellow();
                        Console.Write("  Please Enter {0} Movie's Name >", numbers[x + 1]);
                        MainScreen.ChangeColorToDarkCyan();
                        Console.WriteLine(" {0}", moviesList[x].Key);
                        MainScreen.ChangeColorToDarkYellow();
                        Console.Write("  Please Enter the Age Limit OR Rating For the {0} Movie >", numbers[x + 1]);
                        MainScreen.ChangeColorToDarkCyan();
                        Console.WriteLine(" {0}", moviesList[x].Value);
                        Console.WriteLine("");
                    }
                }

                MainScreen.ChangeColorToDarkYellow();
                Console.Write("  Please Enter {0} Movie's Name > ", serialOrder);
                MainScreen.ChangeColorToDarkCyan();
                movieName = Console.ReadLine();
                if (movieName == "0")
                {
                    MainScreen.MainMenu();
                }
                if (movieName == "")
                {
                    CustomException.NoInputDetected();
                    if (moviesList.Count != 0)
                    {
                        flag = true;
                    }
                    else
                    {
                        AdminHeading();
                    }
                    getMovieName(serialOrder);
                }
                movieName = char.ToUpper(movieName[0]) + movieName.Substring(1);
                if ((movieName.Length) % 2 != 0)
                {
                    movieName += " ";
                }
            }
            void getMovieRating(string serialOrder)
            {
                if (flag == false)
                {
                    MainScreen.ChangeColorToDarkYellow();
                    Console.Write("  Please Enter the Age Limit OR Rating For the {0} Movie > ", serialOrder);
                    MainScreen.ChangeColorToDarkCyan();
                    ratingOrAge = Console.ReadLine().ToUpper();

                    switch (ratingOrAge)
                    {
                        case "G":
                            {
                                ratingOrAge = "G";
                                moviesList.Add(new KeyValuePair<string, string>(movieName, ratingOrAge));
                                break;
                            }
                        case "PG":
                        case "10":
                            {
                                ratingOrAge = "PG";
                                moviesList.Add(new KeyValuePair<string, string>(movieName, ratingOrAge));
                                break;
                            }
                        case "PG-13":
                        case "PG 13":
                        case "PG13":
                        case "13":
                            {
                                ratingOrAge = "PG-13";
                                moviesList.Add(new KeyValuePair<string, string>(movieName, ratingOrAge));
                                break;
                            }
                        case "R":
                        case "15":
                            {
                                ratingOrAge = "R";
                                moviesList.Add(new KeyValuePair<string, string>(movieName, ratingOrAge));
                                break;
                            }
                        case "NC-17":
                        case "NC 17":
                        case "NC17":
                        case "17":
                            {
                                ratingOrAge = "NC-17";
                                moviesList.Add(new KeyValuePair<string, string>(movieName, ratingOrAge));
                                break;
                            }
                        default:
                            {
                                try
                                {
                                    CustomException.ValidateMovieEntry(ratingOrAge);
                                }
                                catch (CustomException)
                                {
                                    flag = true;
                                    getMovieRating(serialOrder);
                                }
                                break;
                            }
                    }

                }
                else if (moviesList.Count > 0 && flag == true)
                {
                    flag = false;
                    for (int x = 0; x < moviesList.Count; x++)
                    {
                        MainScreen.ChangeColorToDarkYellow();
                        Console.Write("  Please Enter {0} Movie's Name >", numbers[x + 1]);
                        MainScreen.ChangeColorToDarkCyan();
                        Console.WriteLine(" {0}", moviesList[x].Key);
                        MainScreen.ChangeColorToDarkYellow();
                        Console.Write("  Please Enter the Age Limit OR Rating For the {0} Movie >", numbers[x + 1]);
                        MainScreen.ChangeColorToDarkCyan();
                        Console.WriteLine(" {0}", moviesList[x].Value);
                        Console.WriteLine("");
                    }
                    getMovieName(serialOrder);
                    getMovieRating(serialOrder);
                }
                else if (moviesList.Count == 0 && flag == true)
                {
                    flag = false;
                    getMovieName(serialOrder);
                    getMovieRating(serialOrder);
                }
                else if (numbers[moviesList.Count] == serialOrder && flag == true)
                {
                    flag = false;
                    getMovieName(serialOrder);
                    getMovieRating(serialOrder);
                }
            }
            AdminMenuSatisfied();
        }

        private static void AdminMenuSatisfied()
        {
            AdminHeading();
            MainScreen.ChangeColorToDarkYellow();
            Console.WriteLine("  Movies to be Played Today:");
            int count = 1;
            MainScreen.ChangeColorToDarkGray();
            Console.WriteLine("\t<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
            Console.Write("\t|  ");
            MainScreen.ChangeColorToBlue();
            Console.Write("Sr.  ");
            MainScreen.ChangeColorToDarkGray();
            Console.Write("|                     ");
            MainScreen.ChangeColorToBlue();
            Console.Write("Title                       ");
            MainScreen.ChangeColorToDarkGray();
            Console.Write("|     ");
            MainScreen.ChangeColorToBlue();
            Console.Write("Rating");
            MainScreen.ChangeColorToDarkGray();
            Console.WriteLine("      |");
            foreach (KeyValuePair<string, string> movie in moviesList)
            {
                Console.WriteLine("\t-----------------------------------------------------------------------------");
                Console.Write("\t|   ");
                MainScreen.ChangeColorToDarkYellow();
                Console.Write("{0}", count++);
                MainScreen.ChangeColorToDarkGray();
                Console.Write("   |");
                MainScreen.ChangeColorToBlue();
                Console.Write("  {0}", movie.Key);
                MainScreen.ChangeColorToDarkGray();
                Console.Write(new String(' ', (47 - movie.Key.Length)));
                Console.Write("|");
                Console.Write(new String(' ', (17 - movie.Value.Length) / 2));
                MainScreen.ChangeColorToBlue();
                Console.Write("{0}", movie.Value);
                Console.Write(new String(' ', (18 - movie.Value.Length) / 2));
                MainScreen.ChangeColorToDarkGray();
                Console.Write("|\n");
            }
            Console.WriteLine("\t>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

            MainScreen.ChangeColorToBlue();
            Console.Write("\n\n  Your Movies Playing Today Are Listed Above. Are you satisfied");
            MainScreen.ChangeColorToDarkYellow();
            Console.WriteLine(" Y / N ?");
            MainScreen.ChangeColorToBlue();
            Console.Write("  > ");
            Console.ForegroundColor = ConsoleColor.Gray;
            string userInput = Console.ReadLine().ToLower();
            if (userInput == "y" || userInput == "yes" || userInput == "0")
            {
                MainScreen.ChangeColorToDarkYellow();
                Console.WriteLine("\n\n  We will play these movies.   :)");
                Thread.Sleep(1000);
                Console.WriteLine("\n  Taking you back to Main Screen.");
                Thread.Sleep(1000);
                MainScreen.ChangeColorToBlue();
                MainScreen.Loading(150);
                Console.Clear();
                MainScreen.MainMenu();
            }
            else if (userInput == "n" || userInput == "no")
            {
                moviesList.Clear();
                AdminMenuMoviesPlayingToday();
            }
            else if (userInput == "")
            {
                CustomException.NoInputDetected();
                AdminMenuSatisfied();
            }
            else
            {
                Console.Clear();
                MainScreen.ChangeColorToRed();
                Console.WriteLine("  That was not a valid option.");
                MainScreen.TryAgain();
                AdminMenuSatisfied();
            }
        }
    }
}
