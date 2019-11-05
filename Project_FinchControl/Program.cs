using System;
using System.Collections.Generic;
using FinchAPI;
using System.Windows.Input;
using System.Windows;
using System.Runtime.InteropServices;
using System.IO;
using System.Linq;

namespace Project_FinchControl
{
    // **************************************************
    //
    // Title: Finch Control
    // Description: This program enables the Finch to perform different tasks.
    // Application Type: Console
    // Author: Leachman, River William
    // Dated Created: 10/9/2019
    // Last Modified: 11/5/2019
    //
    // **************************************************
    class Program
    {
        public enum Command
        {
            NONE,
            DONE,
            MOVEFORWARD,
            MOVEBACKWARD,
            STOPMOTORS,
            WAIT,
            TURNRIGHT,
            TURNLEFT,
            LEDON,
            LEDOFF
        }
        static void Main(string[] args)
        {
            SetTheme();
            DisplayWelcomeScreen();
            DisplayMenu();
            DisplayClosingScreen();
        }
        static void SetTheme()
        {
            string dataPathForeground = @"Data\Foreground.txt";
            string foregroundColorString;
            ConsoleColor foregroundColor;
            foregroundColorString = File.ReadAllText(dataPathForeground);
            Enum.TryParse(foregroundColorString, out foregroundColor);
            Console.ForegroundColor = foregroundColor;

            string dataPathBackground = @"Data\Background.txt";
            string backgroundColorString;
            ConsoleColor backgroundColor;
            backgroundColorString = File.ReadAllText(dataPathBackground);
            Enum.TryParse(backgroundColorString, out backgroundColor);
            Console.BackgroundColor = backgroundColor;

        }
        static void GetTheme()
        {
            string dataPathForeground = @"Data\Foreground.txt";
            string dataPathBackground = @"Data\Background.txt";
            ConsoleColor backgroundColor;
            Console.WriteLine("Please enter background color.");
            Console.WriteLine();
            string BGinput = Console.ReadLine();
            bool BGresult = Enum.TryParse<ConsoleColor>(BGinput, out backgroundColor);
            if (BGresult == false)
            {
                while (BGresult == false)
                {
                    Console.WriteLine("Please enter a valid ConsoleColor.");
                    BGinput = Console.ReadLine();
                    BGresult = Enum.TryParse<ConsoleColor>(BGinput, out backgroundColor);

                }
            }

            ConsoleColor foregroundColor;
            Console.WriteLine("Please enter foreground color.");
            Console.WriteLine();
            string FGinput = Console.ReadLine();
            bool FGresult = Enum.TryParse<ConsoleColor>(FGinput, out foregroundColor);
            if (FGresult == false)
            {
                while (FGresult == false)
                {
                    Console.WriteLine("Please enter a valid ConsoleColor.");
                    FGinput = Console.ReadLine();
                    FGresult = Enum.TryParse<ConsoleColor>(FGinput, out foregroundColor);

                }
            }

            File.WriteAllText(dataPathBackground, backgroundColor.ToString());
            File.WriteAllText(dataPathForeground, foregroundColor.ToString());

            SetTheme();
        }
        /// <summary>
        /// module: Talent Show
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void TalentShow(Finch finchRobot)
        {
            // define vars
            int Red;
            int Green;
            int Blue;
            bool quit = false;

            do
            {
                TalentShowIntro();
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Song();
                }
                else if (input == "2")
                {
                    Dance();
                }
                else if (input == "3")
                {
                    LightShow();
                }
                else if (input == "4")
                {
                    Console.WriteLine("Enter Red Value 0-255");
                    string RedInput = Console.ReadLine();
                    bool redResult = int.TryParse(RedInput, out Red);
                    if (redResult == false)
                    {
                        while (redResult == false)
                        {
                            Console.WriteLine("Please enter a valid integer between 0-255.");
                            RedInput = Console.ReadLine();
                            redResult = int.TryParse(RedInput, out Red);
                        }
                    }

                    Console.WriteLine("Enter Green Value 0-255");
                    string GreenInput = Console.ReadLine();
                    bool GreenResult = int.TryParse(GreenInput, out Green);
                    if (GreenResult == false)
                    {
                        while (GreenResult == false)
                        {
                            Console.WriteLine("Please enter a valid integer between 0-255.");
                            GreenInput = Console.ReadLine();
                            GreenResult = int.TryParse(GreenInput, out Green);
                        }
                    }

                    Console.WriteLine("Enter Blue Value 0-255");
                    string BlueInput = Console.ReadLine();
                    bool BlueResult = int.TryParse(BlueInput, out Blue);
                    if (BlueResult == false)
                    {
                        while (BlueResult == false)
                        {
                            Console.WriteLine("Please enter a valid integer between 0-255.");
                            BlueInput = Console.ReadLine();
                            BlueResult = int.TryParse(BlueInput, out Blue);
                        }
                    }
                    finchRobot.setLED(Red, Green, Blue);
                }
                else if (input == "5")
                {
                    quit = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid intger 1-5.");
                    DisplayContinuePrompt();
                }
                void RGB()
                {
                    finchRobot.setLED(255, 255, 255);
                    finchRobot.wait(250);
                    finchRobot.setLED(255, 0, 0);
                    finchRobot.wait(250);
                    finchRobot.setLED(0, 255, 0);
                    finchRobot.wait(250);
                    finchRobot.setLED(0, 0, 255);
                    finchRobot.wait(250);
                }
                void E5()
                {
                    finchRobot.noteOn(659);
                    finchRobot.wait(500);
                    finchRobot.noteOff();
                }
                void C5()
                {
                    finchRobot.noteOn(523);
                    finchRobot.wait(500);
                    finchRobot.noteOff();
                }
                void G5()
                {
                    finchRobot.noteOn(784);
                    finchRobot.wait(500);
                    finchRobot.noteOff();
                }
                void G4()
                {
                    finchRobot.noteOn(392);
                    finchRobot.wait(500);
                    finchRobot.noteOff();
                }
                void Dance()
                {
                    finchRobot.setMotors(255, 255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                    finchRobot.setMotors(-255, 255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                    finchRobot.setMotors(255, -255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                    finchRobot.setMotors(-255, 255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                    finchRobot.setMotors(255, -255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                    finchRobot.setMotors(-255, 255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                    finchRobot.setMotors(255, -255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                    finchRobot.setMotors(-255, 255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                    finchRobot.setMotors(255, -255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                    finchRobot.setMotors(-255, 255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                    finchRobot.setMotors(255, -255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                    finchRobot.setMotors(-255, 255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                    finchRobot.setMotors(255, -255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                    finchRobot.setMotors(-255, 255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                    finchRobot.setMotors(255, -255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                    finchRobot.setMotors(-255, 255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                    finchRobot.setMotors(255, -255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                    finchRobot.setMotors(-255, 255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                    finchRobot.setMotors(255, -255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                    finchRobot.setMotors(-255, 255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                    finchRobot.setMotors(255, -255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                    finchRobot.setMotors(-255, 255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                    finchRobot.setMotors(255, -255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                    finchRobot.setMotors(-255, 255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                    finchRobot.setMotors(255, -255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                    finchRobot.setMotors(-255, 255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                    finchRobot.setMotors(255, -255);
                    finchRobot.wait(1000);
                    finchRobot.setMotors(0, 0);
                }
                void Song()
                {
                    E5();
                    E5();
                    E5();
                    C5();
                    E5();
                    G5();
                    G4();
                }
                void LightShow()
                {
                    RGB();
                    RGB();
                    RGB();
                    RGB();
                    RGB();
                    RGB();
                    RGB();
                    RGB();
                    RGB();
                    RGB();
                    RGB();
                    RGB();
                    RGB();
                    RGB();
                    RGB();
                    RGB();
                    RGB();
                    RGB();
                    RGB();
                    RGB();
                    RGB();
                    RGB();
                }
            } while (!quit);
            void TalentShowIntro()
            {
                DisplayScreenHeader("Talent Show");
                Console.WriteLine("The Finch robot will now show its talent.");
                DisplayContinuePrompt();
                Console.WriteLine("Type 1 for a song.");
                Console.WriteLine("Type 2 for a dance.");
                Console.WriteLine("Type 3 for a light show.");
                Console.WriteLine("Type 4 to set specific LED RGB values.");
                Console.WriteLine("Type 5 to quit.");
            }
            DisplayContinuePrompt();
        }
        /// <summary>
        /// module: Alarm System
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void AlarmSystem(Finch finchRobot)
        {
            string alarmType;
            int maxTime;
            double max;
            double min;
            bool IsWithinLimits;

            DisplayScreenHeader("Alarm System");

            alarmType = DisplayGetAlarmType();
            maxTime = DisplayGetMaxTime();
            max = DisplayGetMax(alarmType);
            min = DisplayGetMin(alarmType);
            IsWithinLimits = DisplayCheckLevels(finchRobot, alarmType, maxTime, max, min);

            if (IsWithinLimits == true)
            {
                Console.WriteLine("It is within limits.");
            }
            else if (IsWithinLimits == false)
            {
                Console.WriteLine("ALERT!");
            }

            DisplayContinuePrompt();
        }

        static bool DisplayCheckLevels(Finch finchRobot, string alarmType, int maxTime, double max, double min)
        {
            bool IsWithinLimits = true;
            int time = 0;
            if (alarmType == "light")
            {
                int currentLight;
                int maxLight = (int)max;
                int minLight = (int)min;
                do
                {
                    currentLight = finchRobot.getLeftLightSensor();
                    if (minLight > currentLight || currentLight > maxLight)
                    {
                        IsWithinLimits = false;
                    }
                    finchRobot.wait(500);
                    time = time + 500;
                } while (time < maxTime && IsWithinLimits == true);
            }
            else if (alarmType == "temp")
            {
                double currentTemp;
                do
                {
                    currentTemp = finchRobot.getTemperature();
                    if (min > currentTemp || currentTemp > max)
                    {
                        IsWithinLimits = false;
                    }
                    finchRobot.wait(500);
                    time = time + 500;
                } while (time < maxTime && IsWithinLimits == true);
            }
            return IsWithinLimits;
        }
        static string DisplayGetAlarmType()
        {
            string alarmType = "Unknown";
            Console.Write("Alarm Type (light or temp?):");
            bool alarmTypeIsValid = false;

            do
            {
                alarmType = Console.ReadLine();
                if (alarmType == "light")
                {
                    alarmTypeIsValid = true;
                }
                else if (alarmType == "temp")
                {
                    alarmTypeIsValid = true;
                }
                else
                {
                    Console.WriteLine("Please enter either light or temp.");
                }
            } while (!alarmTypeIsValid);

            return alarmType;
        }

        static int DisplayGetMaxTime()
        {
            int maxTime = 0;
            Console.Write("How many milliseconds?");
            bool maxTimeResult = int.TryParse(Console.ReadLine(), out maxTime);

            if (maxTimeResult == false)
            {
                while (maxTimeResult == false)
                {
                    Console.WriteLine("Please enter a valid integer describing milliseconds.");
                    maxTimeResult = int.TryParse(Console.ReadLine(), out maxTime);
                }
            }

            return maxTime;
        }
        static double DisplayGetMax(string alarmType)
        {
            double max = 0;
            Console.Write($"Please enter max {alarmType}.");
            bool maxResult = double.TryParse(Console.ReadLine(), out max);

            if (maxResult == false)
            {
                while (maxResult == false)
                {
                    Console.WriteLine($"Please enter a valid number describing max {alarmType}.");
                    maxResult = double.TryParse(Console.ReadLine(), out max);
                }
            }

            return max;
        }
        static double DisplayGetMin(string alarmType)
        {
            double min = 0;
            Console.Write($"Please enter min {alarmType}.");
            bool minResult = double.TryParse(Console.ReadLine(), out min);

            if (minResult == false)
            {
                while (minResult == false)
                {
                    Console.WriteLine($"Please enter a valid number describing min {alarmType}.");
                    minResult = double.TryParse(Console.ReadLine(), out min);
                }
            }
            Console.WriteLine("PREPARE FOR ALARM SYSTEM");
            Console.ReadKey();
            return min;
        }

        /// <summary>
        /// module: Data Recorder
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DataRecorder(Finch finchRobot)
        {
            double frequency;
            int numberOfDataPoints;

            DisplayScreenHeader("Data Recorder");

            frequency = DisplayGetDataRecorderFrequency(finchRobot);

            numberOfDataPoints = DisplayGetNumberOfDataPoints(finchRobot);

            double[] temps = new double[numberOfDataPoints];

            DisplayGetData(numberOfDataPoints, frequency, temps, finchRobot);

            DisplayData(temps);

            DisplayMainMenuPrompt();
        }

        static void DisplayData(double[] temps)
        {
            DisplayScreenHeader("Temperatures");

            Console.WriteLine("Data Set");

            for (int index = 0; index < temps.Length; index++)
            {
                Console.WriteLine($"Temp {index + 1}: {temps[index]}");
            }

            DisplayContinuePrompt();
        }
        static void DisplayGetData(int numberOfDataPoints, double frequency, double[] temps, Finch finchRobot)
        {
            DisplayScreenHeader("Get Temperatures");

            Console.WriteLine("PRESS ANY KEY TO BEGIN RECORDING");
            Console.ReadKey();

            for (int index = 0; index < numberOfDataPoints; index++)
            {
                temps[index] = finchRobot.getTemperature();
                int ms = (int)(frequency);
                finchRobot.wait(ms);
                Console.WriteLine($"Temp {index + 1}: {temps[index]}");
            }

            DisplayContinuePrompt();
        }
        static double DisplayGetDataRecorderFrequency(Finch finchRobot)
        {
            double frequency;

            DisplayScreenHeader("Get Frequency of Recording");

            Console.Write("Enter frequency [milliseconds]");

            bool freqResult = double.TryParse(Console.ReadLine(), out frequency);

            if (freqResult == false)
            {
                while (freqResult == false)
                {
                    Console.WriteLine("Please enter a valid integer describing milliseconds");

                    freqResult = double.TryParse(Console.ReadLine(), out frequency);
                }
            }

            DisplayContinuePrompt();

            return frequency;
        }

        static int DisplayGetNumberOfDataPoints(Finch finchRobot)
        {
            int numberOfDataPoints;
            DisplayScreenHeader("Get Numbers of Recordings");
            Console.Write("Enter number of recrodings [integer]");
            bool numResult = int.TryParse(Console.ReadLine(), out numberOfDataPoints);
            if (numResult == false)
            {
                while (numResult == false)
                {
                    Console.WriteLine("Please enter a valid integer describing number of data points");

                    numResult = int.TryParse(Console.ReadLine(), out numberOfDataPoints);
                }
            }

            DisplayContinuePrompt();

            return numberOfDataPoints;
        }

        static void DisplayMenu()
        {
            //
            // instantiate a Finch object
            //
            Finch finchRobot = new Finch();
            bool finchRobotConnected = false;
            bool quitApplication = false;
            bool invalidResponse = false;
            ConsoleKeyInfo menuChoiceKey;
            char menuChoice;

            do
            {
                DisplayScreenHeader("Main Menu");

                Console.WriteLine("a) Connect Finch Robot");
                Console.WriteLine("b) Talent Show");
                Console.WriteLine("c) Data Recorder");
                Console.WriteLine("d) Alarm System");
                Console.WriteLine("e) User Programming");
                Console.WriteLine("f) Disconnect Finch Robot");
                Console.WriteLine("g) Set Theme");
                Console.WriteLine("q) Quit");
                Console.CursorVisible = false;
                menuChoiceKey = Console.ReadKey();
                menuChoice = menuChoiceKey.KeyChar;

                switch (menuChoice)
                {
                    case 'a':
                        finchRobotConnected = DisplayConnectFinchRobot(finchRobot);
                        break;
                    case 'b':
                        if (finchRobotConnected) TalentShow(finchRobot);
                        else DisplayConnectionIssueInformation();
                        break;
                    case 'c':
                        if (finchRobotConnected) DataRecorder(finchRobot);
                        else DisplayConnectionIssueInformation();
                        break;
                    case 'd':
                        if (finchRobotConnected) AlarmSystem(finchRobot);
                        else DisplayConnectionIssueInformation();
                        break;
                    case 'e':
                        if (finchRobotConnected) UserProgramming(finchRobot);
                        else DisplayConnectionIssueInformation();
                        break;
                    case 'f':
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;
                    case 'g':
                        GetTheme();
                        break;
                    case 'q':
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please provide a proper menu choice.");
                        DisplayContinuePrompt();
                        break;
                }
            } while (!quitApplication);

        }

        /// <summary>
        /// display disconnecting from the Finch robot
        /// </summary>
        /// <param name="finchRobot"></param>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            DisplayScreenHeader("Disconnect the Finch Robot");

            Console.WriteLine("The Finch robot is about to be disconnected.");
            DisplayContinuePrompt();

            finchRobot.disConnect();
            Console.WriteLine("The Finch robot is now disconnected.");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// displayed when a module is called and the Finch robot is not connected
        /// </summary>
        static void DisplayConnectionIssueInformation()
        {
            DisplayScreenHeader("Connection Information");
            Console.WriteLine("The Finch robot is not connected. Please confirm that the USB cables are fully connected and choose \"a\" from the menu to connect the Finch robot.");
            DisplayContinuePrompt();
        }


        /// <summary>
        /// connect the Finch robot to the application
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            const int MAX_ATTEMPTS = 3;
            int attempts = 1;
            bool finchRobotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tConnecting to the Finch robot. Be sure the USB cord is plugged into both the robot and the computer.");
            Console.WriteLine();
            DisplayContinuePrompt();

            //
            // loop until the Finch robot is connected or the maximum number of attempts is exceeded
            //
            while (!finchRobot.connect() && attempts <= MAX_ATTEMPTS)
            {
                Console.WriteLine();
                Console.WriteLine("\tUnable to connect to the Finch robot. Please confirm all USB cords are plugged in.");
                Console.WriteLine();
                DisplayContinuePrompt();
                attempts++;
            }

            //
            // notify the user if the maximum attempts is exceeded
            //
            if (attempts <= MAX_ATTEMPTS)
            {
                Console.WriteLine();
                Console.WriteLine("\tFinch robot is now connected.");
                Console.WriteLine();
                finchRobotConnected = true;
                finchRobot.setLED(0, 255, 0); // set nose to green
                finchRobot.noteOn(500);
                finchRobot.wait(2000);
                finchRobot.noteOff();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("\tUnable to connect to the Finch robot. Please check the Finch robot or try a different one.");
                Console.WriteLine();
                finchRobotConnected = false;
            }

            DisplayContinuePrompt();

            return finchRobotConnected;
        }

        /// <summary>
        /// display welcome screen
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display closing screen
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        static void DisplayGetDataReadings(int numberOfDataPoints, double frequencyOfDataPoints, double[] temperatures, Finch finchRobot)
        {
            DisplayScreenHeader("Get Temperature Recordings");

            // prompt the user

            for (int index = 0; index < numberOfDataPoints; index++)
            {
                temperatures[index] = finchRobot.getTemperature();
                int milliseconds = (int)(frequencyOfDataPoints * 1000);
                finchRobot.wait(milliseconds);
                Console.WriteLine($"Temperature {index + 1}: {temperatures[index]}");
            }

            DisplayContinuePrompt();

        }

        #region HELPER METHODS

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }






        /// <summary>
        /// display main menu prompt
        /// </summary>
        static void DisplayMainMenuPrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }









        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }



        #endregion
        #region USER PROGRAMMING

        static void DisplayFinchCommands(List<Command> commands)
        {
            DisplayScreenHeader("Finch Commands");



            Console.WriteLine("Commands:");
            Console.WriteLine();

            foreach (Command command in commands)
            {
                Console.WriteLine(command);
            }



            DisplayContinuePrompt();
        }

        static void DisplayGetFinchCommands(List<Command> commands)
        {
            DisplayScreenHeader("Finch Robot Commands");

            Command command = Command.NONE;

            while (command != Command.DONE)
            {
                Console.Write("Enter Command:");


                bool commandResult = Enum.TryParse(Console.ReadLine(), out command);

                if (commandResult == false)
                {
                    while (commandResult == false)
                    {
                        Console.WriteLine("Please enter a valid command.");

                        commandResult = Enum.TryParse(Console.ReadLine(), out command);
                    }
                }


                commands.Add(command);
            }


            DisplayContinuePrompt();
        }

        static void DisplayExecuteFinchCommands(Finch finchRobot, List<Command> commands, (int motorSpeed, int ledBrightness, int waitSeconds) commandParameter)
        {
            DisplayScreenHeader("Execute Finch Commands");

            DisplayContinuePrompt();

            foreach (Command command in commands)
            {
                switch (command)
                {
                    case Command.NONE:
                        break;
                    case Command.DONE:
                        break;
                    case Command.MOVEFORWARD:
                        finchRobot.setMotors(commandParameter.motorSpeed, commandParameter.motorSpeed);
                        finchRobot.wait(commandParameter.waitSeconds);
                        finchRobot.setMotors(0, 0);
                        break;
                    case Command.MOVEBACKWARD:
                        finchRobot.setMotors(-(commandParameter.motorSpeed), -(commandParameter.motorSpeed));
                        finchRobot.wait(commandParameter.waitSeconds);
                        finchRobot.setMotors(0, 0);
                        break;
                    case Command.STOPMOTORS:
                        finchRobot.setMotors(0, 0);
                        break;
                    case Command.WAIT:
                        finchRobot.wait(commandParameter.waitSeconds);
                        break;
                    case Command.TURNRIGHT:
                        finchRobot.setMotors((commandParameter.motorSpeed), -(commandParameter.motorSpeed));
                        break;
                    case Command.TURNLEFT:
                        finchRobot.setMotors(-(commandParameter.motorSpeed), (commandParameter.motorSpeed));
                        break;
                    case Command.LEDON:
                        finchRobot.setLED(commandParameter.ledBrightness, commandParameter.ledBrightness, commandParameter.ledBrightness);
                        break;
                    case Command.LEDOFF:
                        finchRobot.setLED(0, 0, 0);
                        break;
                    default:
                        break;
                }
            }



        }

        static (int motorSpeed, int ledBrightness, int waitSeconds) DisplayGetCommandParameters()
        {
            (int motorSpeed, int ledBrightness, int waitSeconds) commandParameters;

            Console.WriteLine();
            Console.WriteLine("Enter Motor Speed (0-255)");
            bool speedResult = int.TryParse(Console.ReadLine(), out commandParameters.motorSpeed);

            if (speedResult == false || ((commandParameters.motorSpeed < 0) || (commandParameters.motorSpeed > 255)))
            {
                while (speedResult == false || ((commandParameters.motorSpeed < 0) || (commandParameters.motorSpeed > 255)))
                {
                    Console.WriteLine("Please enter a valid motor speed between 0-255.");

                    speedResult = int.TryParse(Console.ReadLine(), out commandParameters.motorSpeed);
                }
            }
            Console.WriteLine();
            Console.WriteLine("Enter LED Brightness (0-255)");
            bool ledResult = int.TryParse(Console.ReadLine(), out commandParameters.ledBrightness);

            if (ledResult == false || ((commandParameters.ledBrightness < 0) || (commandParameters.ledBrightness > 255)))
            {
                while (ledResult == false || ((commandParameters.ledBrightness < 0) || (commandParameters.ledBrightness > 255)))
                {
                    Console.WriteLine("Please enter a valid led brightness between 0-255.");

                    ledResult = int.TryParse(Console.ReadLine(), out commandParameters.ledBrightness);
                }
            }
            Console.WriteLine();
            Console.WriteLine("Enter Wait Command In milliseconds");
            bool waitResult = int.TryParse(Console.ReadLine(), out commandParameters.waitSeconds);

            if (waitResult == false)
            {
                while (waitResult == false)
                {
                    Console.WriteLine("Please enter a valid integer.");

                    waitResult = int.TryParse(Console.ReadLine(), out commandParameters.waitSeconds);
                }
            }

            return commandParameters;

        }

        /// <summary>
        /// module: User Programming
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void UserProgramming(Finch finchRobot)
        {
            DisplayScreenHeader("User Programming");
            (int motorSpeed, int ledBrightness, int waitSeconds) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;

            List<Command> commands = new List<Command>();
            bool quitApplication = false;
            ConsoleKeyInfo menuChoiceKey;
            char menuChoice;
            do
            {
                DisplayScreenHeader("User Programming");

                Console.WriteLine("a) Set Command Parameters");
                Console.WriteLine("b) Add Commands");
                Console.WriteLine("c) View Commands");
                Console.WriteLine("d) Execute Commands");
                Console.WriteLine("q) Return to main menu");
                Console.WriteLine("NONE,DONE,MOVEFORWARD,MOVEBACKWARD,STOPMOTORS WAIT,TURNRIGHT,TURNLEFT,LEDON,LEDOFF");
                Console.CursorVisible = false;
                menuChoiceKey = Console.ReadKey();
                menuChoice = menuChoiceKey.KeyChar;

                switch (menuChoice)
                {
                    case 'a':
                        commandParameters = DisplayGetCommandParameters();
                        break;
                    case 'b':
                        DisplayGetFinchCommands(commands);
                        break;
                    case 'c':
                        DisplayFinchCommands(commands);
                        break;
                    case 'd':
                        DisplayExecuteFinchCommands(finchRobot, commands, commandParameters);
                        break;
                    case 'q':
                        quitApplication = true;
                        break;
                    default:

                        break;
                }
            } while (!quitApplication);


            DisplayContinuePrompt();
        }



        #endregion
    }
}
