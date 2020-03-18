using System;
using System.Collections.Generic;
using System.Threading;

namespace consoleProject
{
    class Guests
    {
        public static int movieChoice;
        public static string guestAge;
        public static void GuestHeading()
        {
            Console.Clear();
            MainScreen.ChangeColorToRed();
            Console.WriteLine();
            MainScreen.CenterText("************************************");
            MainScreen.CenterText("**************  Guests Menu  *************");
            MainScreen.CenterText("************************************");
            MainScreen.ChangeColorToWhite();
            Console.WriteLine();
        }

        public static void GuestsMenu()
        {
            GuestHeading();

            if (Admin.moviesList.Count == 0)
            {
                MainScreen.ChangeColorToDarkYellow();
                Console.WriteLine("  Sorry, there are no movies playing today.");
                Thread.Sleep(1000);
                MainScreen.ChangeColorToDarkGray();
                Console.WriteLine("\n  Taking you back to Main Screen.");
                MainScreen.ChangeColorToRed();
                Thread.Sleep(1000);
                MainScreen.Loading(150);
                MainScreen.MainMenu();
            }
            else
            {
                MainScreen.ChangeColorToBlue();
                Console.WriteLine("  Welcome!! Movies to be Played Today:");
                int count = 1;
                MainScreen.ChangeColorToDarkGray();
                Console.WriteLine("\t<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                Console.Write("\t|  ");
                MainScreen.ChangeColorToRed();
                Console.Write("Sr.  ");
                MainScreen.ChangeColorToDarkGray();
                Console.Write("|                     ");
                MainScreen.ChangeColorToRed();
                Console.Write("Title                       ");
                MainScreen.ChangeColorToDarkGray();
                Console.Write("|     ");
                MainScreen.ChangeColorToRed();
                Console.Write("Rating");
                MainScreen.ChangeColorToDarkGray();
                Console.WriteLine("      |");
                foreach (KeyValuePair<string, string> movie in Admin.moviesList)
                {
                    Console.WriteLine("\t-----------------------------------------------------------------------------");
                    Console.Write("\t|   ");
                    MainScreen.ChangeColorToBlue();
                    Console.Write("{0}", count++);
                    MainScreen.ChangeColorToDarkGray();
                    Console.Write("   |");
                    MainScreen.ChangeColorToRed();
                    Console.Write("  {0}", movie.Key);
                    MainScreen.ChangeColorToDarkGray();
                    Console.Write(new String(' ', (47 - movie.Key.Length)));
                    Console.Write("|");
                    Console.Write(new String(' ', (17 - movie.Value.Length) / 2));
                    MainScreen.ChangeColorToRed();
                    Console.Write("{0}", movie.Value);
                    Console.Write(new String(' ', (18 - movie.Value.Length) / 2));
                    MainScreen.ChangeColorToDarkGray();
                    Console.Write("|\n");
                }
                Console.WriteLine("\t>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

                MainScreen.ChangeColorToBlue();
                Console.WriteLine("\n\n  Which movie would you like to watch?");
                MainScreen.ChangeColorToRed();
                Console.Write("  > ");
                Console.ForegroundColor = ConsoleColor.Gray;
                string userInput = Console.ReadLine();

                if (userInput == "")
                {
                    CustomException.NoInputDetected();
                    GuestsMenu();
                }

                try
                {
                    CustomException.ValidateMovieChoice(Convert.ToInt32(userInput));
                }
                catch (CustomException)
                {
                    GuestsMenu();
                }
                catch (OverflowException)
                {
                    CustomException.OverflowErrorMessage();
                    GuestsMenu();
                }
                catch (FormatException)
                {
                    CustomException.FormatErrorMessage();
                    GuestsMenu();
                }
                switch (userInput)
                {
                    default:
                        movieChoice = Convert.ToInt32(userInput);
                        GuestsMenuVerifyAge();
                        break;
                }
            }
        }

        private static bool GuestsMenuVerifyAge()
        {
            GuestHeading();

            MainScreen.ChangeColorToRed();
            Console.Write("\n  You have chosen to watch :");
            MainScreen.ChangeColorToDarkYellow();
            Console.WriteLine(" {0}", Admin.moviesList[movieChoice - 1].Key);
            MainScreen.ChangeColorToRed();
            Console.Write("  It has the rating of :");
            MainScreen.ChangeColorToDarkYellow();
            Console.WriteLine(" {0}", Admin.moviesList[movieChoice - 1].Value);

            MainScreen.ChangeColorToBlue();
            Console.WriteLine("\n\n  What is your age?");
            MainScreen.ChangeColorToRed();
            Console.Write("  > ");
            Console.ForegroundColor = ConsoleColor.Gray;
            guestAge = Console.ReadLine();

            int ageLimit = 0;
            if (Admin.moviesList[movieChoice - 1].Value == "G")
                ageLimit = 0;
            else if (Admin.moviesList[movieChoice - 1].Value == "PG")
                ageLimit = 10;
            else if (Admin.moviesList[movieChoice - 1].Value == "PG-13")
                ageLimit = 13;
            else if (Admin.moviesList[movieChoice - 1].Value == "R")
                ageLimit = 15;
            else if (Admin.moviesList[movieChoice - 1].Value == "NC-17")
                ageLimit = 17;
            else
                ageLimit = Convert.ToInt32(Admin.moviesList[movieChoice - 1].Value);
            try
            {
                CustomException.ValidateGuestAge(Convert.ToInt32(guestAge), ageLimit);
            }
            catch (CustomException)
            {
                GuestsMenuVerifyAge();
            }
            catch (OverflowException)
            {
                CustomException.OverflowErrorMessage();
                GuestsMenuVerifyAge();
            }
            catch (FormatException)
            {
                CustomException.FormatErrorMessage();
                GuestsMenuVerifyAge();
            }
            switch (guestAge)
            {
                default:
                    LoadingMovie();
                    return true;
            }
        }

        public static void LoadingMovie()
        {
            GuestHeading();

            MainScreen.ChangeColorToRed();
            Console.WriteLine("  Playing {0}\n\n", Admin.moviesList[movieChoice - 1].Key);
            MainScreen.ChangeColorToDarkYellow();
            int timer = 150;

            Console.WriteLine();
            Console.Write("  ");
            for (int x = 0; x < 5; x++)
            {
                Thread.Sleep(timer);
                Console.Write("+");
                Thread.Sleep(timer);
                Console.Write("\b");
                Thread.Sleep(timer);
                Console.Write("x");
            }
            Console.WriteLine("\n  ");
            MainScreen.ChangeColorToBlue();
            for (int x = 0; x < 3; x++)
            {
                //Console.Write("/");
                //Thread.Sleep(timer);
                //Console.Write("\b");
                //Thread.Sleep(timer);
                //Console.Write("-");
                //Thread.Sleep(timer);
                //Console.Write("\b");
                //Thread.Sleep(timer);
                //Console.Write("|");
                //Thread.Sleep(timer);
                //Console.Write("\b");
                //Thread.Sleep(timer);
                //Console.Write("-");
                //Thread.Sleep(timer);
                //Console.Write("\b");
                //Thread.Sleep(timer);
                //Console.Write("\\");
                //Thread.Sleep(timer);
                //Console.Write("\b");
                //Thread.Sleep(timer);
                Console.WriteLine(
                    " ---------- __o     \n" +
                    "--------  _ \\<,_   \n" +
                    "------ - (*) / (*)    ");
                Thread.Sleep(1500);
            }

            Console.Clear();
            GuestsMenuEnjoy();
        }

        private static bool GuestsMenuEnjoy()
        {
            GuestHeading();

            MainScreen.ChangeColorToBlue();
            Console.WriteLine("  What would you like to do now?\n");
            Thread.Sleep(500);
            MainScreen.ChangeColorToRed();
            Console.WriteLine("\t1. Choose another movie\n" +
                 "\t2. Go back to the main menu");
            Console.Write("  > ");
            int menuType = 0;
            Console.ForegroundColor = ConsoleColor.Gray;
            string userInput = Console.ReadLine();
            try
            {
                CustomException.ValidateInput(Convert.ToInt32(userInput), menuType);
            }
            catch (CustomException)
            {
            }
            catch (OverflowException)
            {
                CustomException.OverflowErrorMessage();
                GuestsMenuEnjoy();
            }
            catch (FormatException)
            {
                CustomException.FormatErrorMessage();
                GuestsMenuEnjoy();
            }
            switch (userInput)
            {
                case "1":
                    Console.Clear();
                    GuestsMenu();
                    return true;
                case "2":
                    MainScreen.ChangeColorToDarkGray();
                    Console.WriteLine("\n  Taking you back to Main Screen.");
                    MainScreen.ChangeColorToRed();
                    Thread.Sleep(1000);
                    MainScreen.Loading(150);
                    MainScreen.MainMenu();
                    return true;
                default:
                    return true;
            }
        }
    }
}
