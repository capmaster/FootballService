using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Service
{
    public interface IMathService
    {
        int RomanToArabic(string roman);
    }

    public class MathService : IMathService
    {
        private static Dictionary<char, int> RomanArabicTranlations
        {
            get
            {
                return new Dictionary<char, int> {
                { 'M', 1000 },
                { 'D', 500 },
                { 'C', 100 },
                { 'L', 50 },
                { 'X', 10 },
                { 'V', 5 },
                { 'I', 1 }
            };
            }
        }

        public int RomanToArabic(string romanNumber)
        {
            romanNumber = romanNumber.Trim();

            if (!IsValidRomanNumber(romanNumber))
            {
                return -1;
            }

            bool skipNext = true;
            int total = 0;

            var arabicTranslations = romanNumber.Select(s => Convert.ToInt32(RomanArabicTranlations[s])).ToArray();

            for (int i = 0; i < arabicTranslations.Length; i++)
            {
                if (skipNext)
                {
                    skipNext = false;
                    continue;
                }

                if (arabicTranslations[i] <= arabicTranslations[i - 1])
                {
                    total += arabicTranslations[i - 1];
                }
                else
                {
                    total += arabicTranslations[i] - arabicTranslations[i - 1];
                    skipNext = true;
                }
            }

            if (!skipNext) total += arabicTranslations[arabicTranslations.Length - 1];

            return total;
        }
 
        private static bool IsValidRomanNumber(string romanNumber)
        {
            return new Regex(@"^(?=[MDCLXVI])M*(C[MD]|D?C{0,3})(X[CL]|L?X{0,3})(I[XV]|V?I{0,3})$").IsMatch(romanNumber);
        }
    }

    
}