using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    class English : Language
    {
        public English()
        {
            this.Exceptions = new List<string> { "", "", "" };
            this.Units = new List<string> { String.Empty, "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            this.Decade = new List<string> { String.Empty, String.Empty, "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            this.Hundreads = new List<string> { String.Empty };
            this.Big = new List<string> { String.Empty, "thousand", "million", "billion", "trillion", "quadrillion", "quintillion", "sextillions",
            "septillion", "octillion", "nonillion", "decillion", "undecillion", "duodecillion", "tredecillion", "quattuordecillion",
            "quintillion", "seksdetsillion", "septem detsillion", "oktmo detsillion", "basis detsillion", "vigintillion", "unvigintillion",
            "uindecillion", "sexdecillion", "septendecillion", "octodecillion", "novemdecillion", "vigintillion",
            "unvigintillion", "duovigintillion", "tresvigintillion", "quattuorvigintillion", "quinquavigintillion" };
            for (int i = 1; i < 10; i++)
            {
                if (i == 2)
                    Hundreads.Add(String.Format("{0} {1}s", Units[i], "hundred"));
                else
                    Hundreads.Add(String.Format("{0} {1}", Units[i], "hundred"));
            }
        }
        /// <summary>
        /// Функция преписывающая окончания к названию класса числа
        /// </summary>
        /// <param name="LastThree">Последние 3 числа</param>
        /// <param name="digit">Номер разряда</param>
        /// <param name="word">Название разряда</param>
        /// <returns></returns>
        public override string Ending(int LastThree, int digit, string word)
        {
            if (LastThree == 0) return "";
            else if (digit == 0 && LastThree == 0) return Exceptions[2];
            else
            {
                string res = String.Empty;
                int LastNum = LastThree % 10;
                string ThirdDigit = "";
                ThirdDigit = (LastThree % 100 > 9 && LastThree % 100 < 20) ? ThirdDigit + Units[(LastThree % 10) + 10] : String.Format("{0}{1} {2}", ThirdDigit, Decade[(LastThree / 10) % 10], Units[LastThree % 10]);
                ThirdDigit = String.Format("{0} {1}", Hundreads[LastThree / 100], ThirdDigit);
                if (LastThree != 0)
                    return String.Format("{0} {1}{2}", ThirdDigit, word, res);
                else
                    return res;
            }
        }
    }
}