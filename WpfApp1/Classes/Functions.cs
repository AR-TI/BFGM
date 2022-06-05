using System;
using System.Globalization;

namespace BFGM.Classes
{
    internal static class Functions
    {
        public static bool IsRightDate(string date, out DateTime dateTime)
        {
            return DateTime.TryParse(date, out dateTime) && dateTime.Year >= DateTime.Now.Year;
        }

        public static string ToTitleCaseAllWords(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
        }

        public static string ToTitleCaseFirstWord(string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }
    }
}
