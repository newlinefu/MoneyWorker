using System;
using static MoneyWorker.Enums;

namespace MoneyWorker
{
    internal static class CurrencyExtension
    {
        public static Currency Add(this Currency curOne, Currency curTwo)
        {
            return new Currency(curOne.ChangeCurrencyType(Currencies.RUBLE) + curTwo.ChangeCurrencyType(Currencies.RUBLE), Currencies.RUBLE);
        }

        public static bool IsMoreThan(this Currency curOne, Currency curTwo)
        {
            return curOne.ChangeCurrencyType(Currencies.RUBLE) > curTwo.ChangeCurrencyType(Currencies.RUBLE);
        }
    }
}
