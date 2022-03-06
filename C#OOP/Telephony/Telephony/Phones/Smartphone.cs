using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowserble
    {
        public string Browse(string url)
        {
            if (url.Any(x => Char.IsDigit(x)))
            {
                throw new ArgumentException(ExeptionMassage.UrlExeption);
            }
            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            if (!number.All(x=> Char.IsDigit(x)))
            {
                throw new ArgumentException(ExeptionMassage.NumberExeption);
            }
            return number.Length > 7 ? $"Calling... {number}" : $"Dialing... {number}";
        }
    }
}
