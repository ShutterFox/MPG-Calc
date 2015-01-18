using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MPGCalc
{
    class Program
    {
        static void Main()
        {
            int selection;
            string menuString;

            Console.WriteLine(@"
MPG Calculator Main Menu
========================

1. Instructions

2. Calculator

3. History

4. Quit


Please type the number of your selection and press ENTER:");

            try
            {
                menuString = Console.ReadLine();
                selection = int.Parse(menuString);


                switch (selection)
                {
                    case 1:
                        Console.Clear();
                        Instructions();
                        break;
                    case 2:
                        Console.Clear();
                        Caluculator();
                        break;
                    case 3:
                        Console.Clear();
                        History();
                        break;
                    case 4:
                        Console.Clear();
                        Quit();
                        break;
                    default:
                        Console.WriteLine("Invalid Number Entered");
                        Main();
                        break;
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine(@"

ERROR
=====

Invalid value entered. Enter 1, 2, 3 or 4 then press ENTER

");
                Main();
            }






        }
        static void Caluculator()
        {
            decimal miles, fuelCost, fuelPumped, mpg, litresPumped, gallonsPumped;
            const decimal LIT_GAL_CONV = 4.54m;
            const decimal MIN_FUEL_COST = 0.10m;
            const decimal MAX_FUEL_COST = 50;
            const decimal MIN_FUEL_PUMPED = 1;
            const decimal MAX_FUEL_PUMPED = 100;
            const decimal MIN_TRAVEL = 1;
            const decimal MAX_TRAVEL = 1000;
            string milesString, fuelCostString, fuelPumpedString;

            {
                do
                {
                    try
                    {
                        Console.WriteLine("Enter Fuel Cost per litre in £/p (e.g: 1.20)");
                        fuelCostString = Console.ReadLine();
                        fuelCost = decimal.Parse(fuelCostString);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(@"Invalid number entered.
 
Please enter the data in numerical format, to 2 decimal places if needed.
");
                        fuelCost = 0m;
                    }
                } while (fuelCost < MIN_FUEL_COST || fuelCost > MAX_FUEL_COST);

                do
                {
                    try
                    {


                        Console.WriteLine("Enter cost of fuel pumped in £/p (E.g: 1.20)");
                        fuelPumpedString = Console.ReadLine();
                        fuelPumped = decimal.Parse(fuelPumpedString);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(@"Invalid number entered.
 
Please enter the data in numerical format, to 2 decimal places if needed.
");
                        fuelPumped = 0m;
                    }
                }
                while (fuelPumped < MIN_FUEL_PUMPED || fuelPumped > MAX_FUEL_PUMPED);

                do
                {
                    try
                    {
                        Console.WriteLine("Enter miles travelled until next refuelling in whole miles");
                        milesString = Console.ReadLine();
                        miles = decimal.Parse(milesString);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(@"Invalid number entered.
Please enter the data in numerical format, in whole numbers.
");
                        miles = 0m;
                    }
                }
                while (miles < MIN_TRAVEL || miles > MAX_TRAVEL);


                litresPumped = fuelPumped / fuelCost;

                gallonsPumped = litresPumped / LIT_GAL_CONV;

                mpg = miles / gallonsPumped;

                Console.WriteLine("The MPG is: {0:00.00}", mpg);

                StreamWriter writer;
                writer = File.AppendText("History.txt");

                writer.WriteLine(DateTime.Now);
                writer.WriteLine("{0:00.00}", mpg);

                writer.Close();

                int select;
                string menuString2;
                try
                {
                    Console.WriteLine(@"

MENU
====

1. Reset Calculator

2. Main Menu


Please type the number of your selection and press ENTER:");
                    menuString2 = Console.ReadLine();
                    select = int.Parse(menuString2);


                    switch (select)
                    {
                        case 1:
                            Console.Clear();
                            Caluculator();
                            break;
                        case 2:
                            Console.Clear();
                            Main();
                            break;
                        default:
                            Console.WriteLine("Invalid Number Entered, returning to Main Menu");
                            Main();
                            break;
                    }
                }

                catch
                {
                    Console.Clear();
                    Console.WriteLine(@"

ERROR
=====

Invalid value entered. Returning to Main Menu

");
                    Main();
                }
            }
        }

        static void History()
        {
            Console.WriteLine(@"History

");
            StreamReader reader = new StreamReader("History.txt");
            while (reader.EndOfStream == false)
            {
                string line = reader.ReadLine();
                Console.WriteLine(line);
            }
            reader.Close();

            int select;
            string menuString2;
            try
            {
                Console.WriteLine(@"

MENU
====

1. Main Menu

2. Clear History

3. Quit


Please type the number of your selection and press ENTER:");
                menuString2 = Console.ReadLine();
                select = int.Parse(menuString2);


                switch (select)
                {
                    case 1:
                        Console.Clear();
                        Main();
                        break;
                    case 2:
                        Console.Clear();
                        HistoryConfirm();
                        break;
                    case 3:
                        Console.Clear();
                        Quit();
                        break;
                    default:
                        Console.WriteLine("Invalid Number Entered");
                            History();
                        break;
                }
            }

            catch
            {
                Console.Clear();
                Console.WriteLine(@"

ERROR
=====

Invalid value entered. Enter 1, 2 or 3 then press ENTER

");
                History();
            }
        }
        static void Quit()
        {
            Console.WriteLine("Quitting...");

        }


        static void Instructions()
        {
            int select;
            string menuString2;
            try
            {
                Console.WriteLine(@"
MILES PER GALLON CALCULATOR FOR CARS
====================================
 
This simple program will calculate your MPG for most cars 
without an MPG calulator built into it.
 
To use this program, you will need wait until your Low
Fuel warning light comes on, refuel, reset your Trip
Counter and make a note of the cost of the fuel per
litre and how much the total fuel cost you so you can
enter these values into the program, along with the
miles travelled between refuelling from your trip
counter.
 
MENU
====

1. Main Menu

2. Quit


Please type the number of your selection and press ENTER:");
                menuString2 = Console.ReadLine();
                select = int.Parse(menuString2);


                switch (select)
                {
                    case 1:
                        Console.Clear();
                        Main();
                        break;
                    case 2:
                        Console.Clear();
                        Quit();
                        break;
                    default:
                        Console.WriteLine("Invalid Number Entered");
                        Instructions();
                        break;

                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine(@"

ERROR
=====

Invalid value entered. Enter 1 or 2 then press ENTER

");
                Instructions();
            }
        }
        static void HistoryClear()
        {
            Console.WriteLine(@"!!HISTORY CLEARED!!

");
            StreamWriter writer;
            writer = new StreamWriter("History.txt");
            writer.WriteLine(DateTime.Now);
            writer.WriteLine("HISTORY CLEARED");

            writer.Close();

            int select;
            string menuString2;
            try
            {
                Console.WriteLine(@"

MENU
====

1. Main Menu

2. Quit


Please type the number of your selection and press ENTER:");
                menuString2 = Console.ReadLine();
                select = int.Parse(menuString2);


                switch (select)
                {
                    case 1:
                        Console.Clear();
                        Main();
                        break;
                    case 2:
                        Console.Clear();
                        Quit();
                        break;
                    default:
                        Console.WriteLine("Invalid Number Entered, returning to Main Menu");
                        Main();
                        break;


                }
            }


            catch
            {
                Console.Clear();
                Console.WriteLine(@"

ERROR
=====

Invalid value entered. Enter 1 or 2 then press ENTER

");
                HistoryClear();


            }
        }
        static void HistoryConfirm()
        {
            int select;
            string menuString2;
            try
            {
                Console.WriteLine(@"WARNING!!
=========

ONCE HISTORY HAS BEEN CLEARED IT CANNOT BE UNDONE!!

MENU
====

1. Clear History

2. Main Menu


Please type the number of your selection and press ENTER:");
                menuString2 = Console.ReadLine();
                select = int.Parse(menuString2);


                switch (select)
                {
                    case 1:
                        Console.Clear();
                        HistoryClear();
                        break;
                    case 2:
                        Console.Clear();
                        Main();
                        break;
                    default:
                        Console.WriteLine("Invalid Number Entered");
                        HistoryConfirm();
                        break;
                }

            }
            catch
            {
                Console.Clear();
                Console.WriteLine(@"

ERROR
=====

Invalid value entered. Enter 1 or 2 then press ENTER

");
                HistoryConfirm();
            }
        }
    }
}

