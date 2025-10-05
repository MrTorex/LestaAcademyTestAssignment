using System.Collections.Generic;

namespace LT_Game._Core.Utilities
{
    public static class RomanNumerals
    {
        private static readonly Dictionary<int, string> ArabicToRomanNumerals = new()
        {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" }
        };
    
        public static string ToRoman(this int value)
        {
            var roman = string.Empty;

            foreach (var item in ArabicToRomanNumerals)
            {
                var n =  value / item.Key;
                for (var i = 0; i < n; i++)
                    roman += item.Value;
                value -= n * item.Key;
            }
        
            return roman;
        }
    }
}