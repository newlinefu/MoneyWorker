using System;
using System.Collections.Generic;
using static MoneyWorker.Enums;

namespace MoneyWorker
{
    internal class Currency
    {
        private static Dictionary<Currencies, decimal> exchangeRates;

        public decimal Value { get; set; }
        public Currencies CurType { get; set; }

        static Currency()
        {
            exchangeRates = new Dictionary<Currencies, decimal>() 
            { 
                { Currencies.RUBLE, 1M }, 
                { Currencies.DOLLAR, 30.5M }, 
                { Currencies.EURO, 40.64M } 
            };
        }

        public Currency(decimal value, Currencies curType)
        {
            Value = value;
            CurType = curType;
        }

        public decimal ChangeCurrencyType(Currencies newCurType)
        {
            Value = exchangeRates[CurType] * Value / exchangeRates[newCurType];
            CurType = newCurType;

            return Value;
        }

        public static bool operator <(Currency curOne, Currency curTwo)
        {
            return curOne.ChangeCurrencyType(Currencies.RUBLE) < curTwo.ChangeCurrencyType(Currencies.RUBLE);
        }

        public static bool operator >(Currency curOne, Currency curTwo)
        {
            return curOne.IsMoreThan(curTwo);
        }

        public static Currency operator +(Currency curOne, Currency curTwo)
        {
            return curOne.Add(curTwo);
        }

        public static Currency operator -(Currency curOne, Currency curTwo)
        {
            return new Currency(curOne.ChangeCurrencyType(Currencies.RUBLE) - curTwo.ChangeCurrencyType(Currencies.RUBLE), Currencies.RUBLE);
        }

        public override string ToString()
        {
            return $"{Value.ToString("0.##")} ({CurType})";
        }
    }
}
