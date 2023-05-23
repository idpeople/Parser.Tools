using System.Linq;
using System.Text;

namespace Parser.Tools.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNumeric(this string val)
        {
            return val.All(char.IsDigit);
        }

        public static string PadZerosLeft(this string val, int length)
        {
            return val.PadLeft(length, '0');
        }

        public static string PadZerosRight(this string val, int length)
        {
            return val.PadRight(length, '0');
        }

        public static long HexToDec(this string val)
        {
            return long.Parse(val, System.Globalization.NumberStyles.HexNumber);
        }

        public static string Reverse(this string val)
        {
            string retVal = "";
            for (int i = 0; i < val.Length; i++)
                retVal = val.Substring(i, 1) + retVal;
            return retVal;
        }

        public static string ConvertFormat(this string val, Encoding origEncoding, Encoding toEncoding)
        {
            byte[] orig = origEncoding.GetBytes(val);
            byte[] newEnc = Encoding.Convert(origEncoding, toEncoding, orig);
            return toEncoding.GetString(newEnc);
        }

        public static string ConvertUTF8to1252(this string val)
        {
            return ConvertFormat(val, Encoding.UTF8, Encoding.GetEncoding(1252));
        }
    
        public static bool IsEmpty(this string val)
        {
            return val.Trim().Length== 0;
        }
    }
}
