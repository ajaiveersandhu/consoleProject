using System;
using System.Threading;

namespace consoleProject
{
    class CustomException : Exception
    {

        public CustomException(string errorType)
        {
            if (errorType == "back to main menu")
            {
                MainScreen.ChangeColorToDarkGray();
                Console.WriteLine("\n  Taking you back to Main Screen.");
                Thread.Sleep(1500);
                MainScreen.MainMenu();
            }

            if (errorType == "out of scope")
            {
                Console.Clear();
                MainScreen.ChangeColorToRed();
                Console.Beep();
                Console.WriteLine("\n\n  That is not an option.");
                MainScreen.TryAgain();
            }

            else if (errorType == "negative")
            {
                Console.Clear();
                MainScreen.ChangeColorToRed();
                Console.Beep();
                Console.WriteLine("\n\n  Do not write negative numbers");
                MainScreen.TryAgain();
            }

            else if (errorType == "movies>10")
            {
                Console.Clear();
                Console.WriteLine("  A maximum of 10 movies can be played.");
                MainScreen.TryAgain();
            }

            else if (errorType == "invalid movie rating")
            {
                Admin.AdminHeading();

                MainScreen.ChangeColorToDarkCyan();

                Console.WriteLine("  The rating inserted is not valid, please choose one of these options:");
                Console.WriteLine("\tG     -   Any age");
                Console.WriteLine("\tPG    -   10 years or older");
                Console.WriteLine("\tPG-13 -   13 years or older");
                Console.WriteLine("\tR     -   15 years or older");
                Console.WriteLine("\tNC-17 -   17 years or older\n");
                Console.WriteLine("  Press Enter to input Rating again.");
                Console.ReadLine();
            }

            else if (errorType == "must be mortal")
            {
                Console.WriteLine("  You are too OLD! We don't want you to die, while watching movie.");
                MainScreen.TryAgain();
            }

            else if (errorType == "too young")
            {
                Console.WriteLine(
                    "  You are '{0}' years old...\n" +
                    "  The movie '{1}' you chose has the rating of '{2}'.\n" +
                    "  Unfortunately, you cannot watch this movie\n",
                    Guests.guestAge,
                    Admin.moviesList[Guests.movieChoice - 1].Key,
                    Admin.moviesList[Guests.movieChoice - 1].Value
                    );
                Thread.Sleep(2000);
                MainScreen.TryAgain();
            }
        }

        public static void ValidateMovieEntry(string value)
        {
            int age;
            bool isInt = int.TryParse(value, out age);
            if (value == "0")
                throw new CustomException("back to main menu");
            else if (isInt)
            {
                if (Convert.ToInt32(value) < 0)
                {
                    throw new CustomException("negative");
                }
                else if (!(age == 10 || age == 13 || age == 15 || age == 17))
                {
                    throw new CustomException("invalid movie rating");
                }
            }
            else if (!isInt)
                if (
                value != "G" &&
                value != "PG" &&
                value != "PG-13" &&
                value != "R" &&
                value != "NC-17")
                    throw new CustomException("invalid movie rating");
        }

        public static void ValidateMovieChoice(int value)
        {
            if (value == 0)
                throw new CustomException("back to main menu");
            else if (value < 0)
                throw new CustomException("negative");
            else if (value > Admin.moviesList.Count)
                throw new CustomException("out of scope");
        }

        public static void ValidateGuestAge(int guestAge, int ageLimit)
        {
            if (guestAge == 0)
                throw new CustomException("back to main menu");
            else if (guestAge < 0)
                throw new CustomException("negative");
            else if (guestAge < ageLimit)
                throw new CustomException("too young");
            else if (guestAge > 120)
                throw new CustomException("must be mortal");
        }

        public static void ValidateInput(int value, int menuType)
        {
            if (value == 0)
                throw new CustomException("back to main menu");
            else if (value > 2 && menuType == 0 || value > 1 && menuType == 1 || value > 5 && menuType == 3)
                throw new CustomException("out of scope");
            else if (value < 0)
                throw new CustomException("negative");
            else if (value > 10 && menuType == 2)
                throw new CustomException("movies>10");
        }

        public static void OverflowErrorMessage()
        {
            Console.Clear();
            MainScreen.ChangeColorToRed();
            Console.Beep();
            Console.WriteLine("\n\n  The inserted value was too big.");
            MainScreen.TryAgain();
        }
        public static void FormatErrorMessage()
        {
            Console.Clear();
            MainScreen.ChangeColorToRed();
            Console.Beep();
            Console.WriteLine("\n\n  The inserted value was not a number.");
            MainScreen.TryAgain();
        }

        public static void NoInputDetected()
        {
            Console.Clear();
            MainScreen.ChangeColorToRed();
            Console.Beep();
            Console.WriteLine("\n\n  NO! Input Detected.");
            MainScreen.TryAgain();
        }
    }
}
