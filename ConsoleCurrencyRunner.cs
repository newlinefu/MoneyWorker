using System;
using System.Collections.Generic;
using System.Text;
using static MoneyWorker.Enums;

namespace MoneyWorker
{
    internal class ConsoleCurrencyRunner
    {
        private static Dictionary<string, Currencies> curStrings;
        private CurrencyRate generalCurRate;
        private static string annotation = @"Enter:
    1 for get sum of two currencies
    2 for get difference of two currencies
    3 for get comparison result of two currencies
    4 or other symbol to exit
    (Please enter currency value in format like <10,2 e> where last symbol - currency type 
    (e - euro, d - dollar, r - ruble))";


        public ConsoleCurrencyRunner()
        {
            bool isRateInitialized = false;
            while(!isRateInitialized)
            {
                try
                {
                    generalCurRate = GetCurrencyRateFromConsole();
                    isRateInitialized = true;
                }
                catch(Exception e)
                {
                    Console.WriteLine("Invalid value, try again");
                }
            }

            curStrings = new Dictionary<string, Currencies>()
            {
                {"e", Currencies.EURO},
                {"r", Currencies.RUBLE},
                {"d", Currencies.DOLLAR}
            };
        }

        public void Run()
        {
            bool isRunning = true;
            while(isRunning)
            {
                Console.WriteLine(annotation);
                string step = Console.ReadLine().Trim();
                switch (step)
                {
                    case "1":
                        {
                            Console.Write("First money value: ");
                            Currency curOne = ReadCurrencyFromConsole();
                            Console.Write("Second money value: ");
                            Currency curTwo = ReadCurrencyFromConsole();
                            if (curOne == null || curTwo == null)
                            {
                                Console.WriteLine("Entered invalid value(s). Try again");
                                continue;
                            }
                            else
                            {
                                Currency curSum = curOne + curTwo;
                                Console.Write("Result: " + curSum.ToString());
                                curSum.ChangeCurrencyType(Currencies.DOLLAR);
                                Console.Write(" | " + curSum.ToString());
                                curSum.ChangeCurrencyType(Currencies.EURO);
                                Console.WriteLine(" | " + curSum.ToString());
                            }
                            break;
                        }
                        
                    case "2":
                        {
                            Console.Write("First money value: ");
                            Currency curOne = ReadCurrencyFromConsole();
                            Console.Write("Second money value: ");
                            Currency curTwo = ReadCurrencyFromConsole();
                            if (curOne == null || curTwo == null)
                            {
                                Console.WriteLine("Entered invalid value(s). Try again");
                            }
                            else
                            {
                                Currency curDiff = curOne - curTwo;
                                Console.Write("Result: " + curDiff.ToString());
                                curDiff.ChangeCurrencyType(Currencies.DOLLAR);
                                Console.Write(" | " + curDiff.ToString());
                                curDiff.ChangeCurrencyType(Currencies.EURO);
                                Console.WriteLine(" | " + curDiff.ToString());
                            }
                            break;
                        }
                    case "3":
                        {
                            Console.Write("First money value: ");
                            Currency curOne = ReadCurrencyFromConsole();
                            Console.Write("Second money value: ");
                            Currency curTwo = ReadCurrencyFromConsole();
                            if (curOne == null || curTwo == null)
                            {
                                Console.WriteLine("Entered invalid value(s). Try again");
                            }
                            else
                            {
                                if(curOne > curTwo)
                                {
                                        Console.WriteLine("First value more than second");
                                }
                                else if (curTwo > curOne)
                                {
                                    Console.WriteLine("Second value more than first");
                                }
                                else
                                {
                                    Console.WriteLine("Values are equals");
                                }
                            }
                            break;
                    }

                    default:
                        isRunning = false;
                        break;
                }
            }
            
        }

        public Currency ReadCurrencyFromConsole()
        {
            string line = Console.ReadLine();
            string[] lineValues = line.Split(" ");

            if(lineValues.Length == 2 
                && decimal.TryParse(lineValues[0], out decimal curValue) 
                && curStrings.TryGetValue(lineValues[1], out Currencies curType))
            {
                return new Currency(curValue, curType, generalCurRate);
            }

            return null;
        }

        public CurrencyRate GetCurrencyRateFromConsole()
        {
            Console.Write("Enter ruble value: ");
            decimal rubbleValue = decimal.Parse(Console.ReadLine());
            Console.Write("Enter dollar value: ");
            decimal dollarValue = decimal.Parse(Console.ReadLine());
            Console.Write("Enter euro value: ");
            decimal euroValue = decimal.Parse(Console.ReadLine());

            return new CurrencyRate(rubbleValue, dollarValue, euroValue);
        }
    }
}
