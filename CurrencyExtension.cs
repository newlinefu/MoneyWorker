using System;
using static MoneyWorker.Enums;

namespace MoneyWorker
{
    internal static class CurrencyExtension
    {
        public static Currency Add(this Currency curOne, Currency curTwo)
        {
            if (curOne.ActualRate != curTwo.ActualRate)
            {
                throw new Exception("The currencies being stacked have different rates");
            }

            return new Currency(curOne.ChangeCurrencyType(Currencies.RUBLE) + curTwo.ChangeCurrencyType(Currencies.RUBLE), Currencies.RUBLE, curOne.ActualRate);
        }

        public static bool IsMoreThan(this Currency curOne, Currency curTwo)
        {
            return curOne.ChangeCurrencyType(Currencies.RUBLE) > curTwo.ChangeCurrencyType(Currencies.RUBLE);
        }
    }
}
