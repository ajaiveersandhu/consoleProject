using System;
using System.Threading;

namespace consoleProject
{
    class MainScreen
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        public static void Loading(int timer)
        {
            Console.Write("\n  ");

            for (int x = 0; x < 3; x++)
            {
                Thread.Sleep(timer);
                Console.Write("+");
                Thread.Sleep(timer);
                Console.Write("\b");
                Thread.Sleep(timer);
                Console.Write("x");
                Thread.Sleep(timer);
                Console.Write("\b");
                Thread.Sleep(timer);
                Console.Write(".");
            }

            Console.WriteLine();
        }

        public static void TryAgain()
        {
            Thread.Sleep(1000);
            ChangeColorToWhite();
            Console.WriteLine("\n  TRY AGAIN !!!");
            Thread.Sleep(1250);
        }

        public static void CenterText(String text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }

        public static void ChangeColorToDarkYellow()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }

        public static void ChangeColorToRed()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        public static void ChangeColorToBlue()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        public static void ChangeColorToCyan()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        public static void ChangeColorToDarkCyan()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }

        public static void ChangeColorToWhite()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ChangeColorToDarkGray()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }

        public static void ChangeColorToGray()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }


        public static void MainHeading()
        {
            Console.Clear();

            Console.WriteLine();
            ChangeColorToDarkYellow();
            //Console.WriteLine(new String('*', Console.WindowWidth));
            CenterText("****************************************");
            CenterText("*********  Welcome to MoviePlex Theatre  *********");
            CenterText("****************************************");
            ChangeColorToWhite();
            Console.WriteLine();
        }

        public static void MainMenu()
        {
            MainHeading();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("  Please Select From The Following Options:");
            ChangeColorToBlue();
            Console.WriteLine("\t1. Administrator");
            ChangeColorToRed();
            Console.WriteLine("\t2. Guest");
            ChangeColorToDarkGray();
            Console.WriteLine("\n  *You can enter 0 whenever you want to come back here!");

            ChangeColorToDarkYellow();
            Console.Write("\n  > ");
            int menuType = 0;
            Console.ForegroundColor = ConsoleColor.Gray;
            string userInput = Console.ReadLine().ToLower();

            switch (userInput)
            {
                case "1":
                case "admin":
                case "administrator":
                    {
                        ChangeColorToDarkYellow();
                        Loading(150);
                        Admin adminObj = new Admin();
                        ChangeColorToGray();
                        Admin.AdminMenu();
                        break;
                    }
                case "2":
                case "guest":
                    {
                        ChangeColorToDarkYellow();
                        Loading(150);
                        ChangeColorToGray();
                        Guests.GuestsMenu();
                        break;
                    }
                default:
                    {
                        if (userInput.Equals(""))
                        {
                            CustomException.NoInputDetected();
                            MainMenu();
                        }
                        else if (userInput.Contains("ad") || userInput.Contains("adm") || userInput.Contains("gu") || userInput.Contains("gue"))
                        {
                            ChangeColorToDarkYellow();
                            Console.WriteLine("  You made a mistake in spelling.");
                            TryAgain();
                        }
                        else
                        {
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
                            }
                            catch (FormatException)
                            {
                                CustomException.FormatErrorMessage();
                            }
                        }
                        MainMenu();
                        break;
                    }
            }
        }
    }
}
