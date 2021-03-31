using System;
using System.Collections.Generic;
using static MoneyWorker.Enums;

namespace MoneyWorker
{
    internal class Currency
    {
        public CurrencyRate ActualRate { get; set; }
        public decimal Value { get; set; }
        public Currencies CurType { get; set; }


        public Currency(decimal value, Currencies curType, CurrencyRate actualRate)
        {
            Value = value;
            CurType = curType;
            ActualRate = actualRate;
        }

        public decimal ChangeCurrencyType(Currencies newCurType)
        {
            Value = ActualRate[CurType] * Value / ActualRate[newCurType];
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
            if(curOne.ActualRate != curTwo.ActualRate)
            {
                throw new Exception("The deductible currencies have different rates");
            }

            return new Currency(curOne.ChangeCurrencyType(Currencies.RUBLE) - curTwo.ChangeCurrencyType(Currencies.RUBLE),              Currencies.RUBLE, curOne.ActualRate);
        }

        public override string ToString()
        {
            return $"{Value.ToString("0.##")} ({CurType})";
        }
    }
}
