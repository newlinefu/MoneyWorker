using System;
using System.Collections.Generic;
using System.Text;
using static MoneyWorker.Enums;

namespace MoneyWorker
{
    internal class CurrencyRate
    {
        private static Dictionary<Currencies, decimal> exchangeRates;

        public decimal this[Currencies curType]
        {
            get => exchangeRates[curType];
        }

        public CurrencyRate(decimal rubleValue, decimal dollarValue, decimal euroValue)
        {
            exchangeRates = new Dictionary<Currencies, decimal>()
            {
                { Currencies.RUBLE, rubleValue },
                { Currencies.DOLLAR, dollarValue },
                { Currencies.EURO, euroValue }
            };
        }

        public static bool operator ==(CurrencyRate curRateOne, CurrencyRate curRateTwo)
        {
            return curRateOne[Currencies.RUBLE] == curRateTwo[Currencies.RUBLE]
                && curRateOne[Currencies.DOLLAR] == curRateTwo[Currencies.DOLLAR]
                && curRateOne[Currencies.EURO] == curRateTwo[Currencies.EURO];
        }

        public static bool operator !=(CurrencyRate curRateOne, CurrencyRate curRateTwo)
        {
            return curRateOne[Currencies.RUBLE] != curRateTwo[Currencies.RUBLE]
                || curRateOne[Currencies.DOLLAR] != curRateTwo[Currencies.DOLLAR]
                || curRateOne[Currencies.EURO] != curRateTwo[Currencies.EURO];
        }
    }
}
