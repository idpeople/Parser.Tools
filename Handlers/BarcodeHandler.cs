using System;
using System.Linq;
using Parser.Tools.Extensions;

namespace Parser.Tools.Handlers
{
    public sealed class BarcodeHandler
    {
        /// <summary>
        /// Calculate and add an EAN check digit.
        /// It will not check for EAN8 or 13 length is correct
        /// </summary>
        /// <param name="ean">ean value</param>
        /// <returns>Ean value with check digit</returns>
        public static string AddEanCheckDigit(string ean)
        {
            if (!ean.IsNumeric())
                throw new ArgumentException($"{ean} is not numeric");
            var s = ean.Reverse();

            int calc = 0;
            for(int pos = 0; pos < s.Length; pos++)
            {
                var tmp = Convert.ToInt16(s[pos]);
                calc += (pos % 2) == 0 ? tmp * 3 : tmp;
            }

            var x1 = calc % 10;
            var chkDigit = (x1 > 0) ? (10 - x1) : 0;

            return ean + chkDigit.ToString();
        }

        public static string AddUpcCheckDigit(string upc)
        {
            if(!upc.IsNumeric())
                throw new ArgumentException($"{upc} is not numeric");

            var s = upc.Reverse();

            var odd = 0;
            var even = 0;
            for(int pos = 0; pos < s.Length; pos++)
            {
                var val = Convert.ToInt16(s[pos]);
                if (pos % 2 == 0)
                    odd += val;
                else
                    even += val;
            }

            odd *= 3;
            var result = even + odd;
            var digit = 10 - (result % 10);
            if(digit == 10) digit = 0;
            return upc + digit.ToString();
        }

        public static string AddIsbn10CheckDigit(string isbn)
        {
            if (!isbn.IsNumeric())
                throw new ArgumentException($"{isbn} is not numeric");

            var s = isbn.PadLeft(10, '0');
            if (s.Length > 10)
                throw new ArgumentException($"{isbn} is too long");

            s = s.Reverse();

            var val = 0;
            for(int pos = 0; pos < s.Length; pos++)
            {
                val += (pos * 2) * Convert.ToInt16(s[pos]);
            }

            return isbn + (11 - (val % 11)).ToString();
        }
    }
}
