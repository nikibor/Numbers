using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    /// <summary>
    /// Класс отвечающий за функционал английского языка
    /// </summary>
    class English : Language
    {
        public English()
        {
            this.Units = new List<string> { String.Empty, "one ", "two ", "three ", "four ", "five ", "six ", "seven ", "eight ", "nine ", "ten ",
                "eleven ", "twelve ", "thirteen ", "fourteen ", "fifteen ", "sixteen ", "seventeen ", "eighteen ", "nineteen " };
            this.Decade = new List<string> { String.Empty, String.Empty, "twenty ", "thirty ", "fourty ", "fifty ", "sixty ", "seventy ", "eighty ", "ninety " };
            this.Hundreads = new List<string> { String.Empty };
            this.Big = new List<string> { String.Empty, "thousand ", "million ", "billion ", "trillion ", "quadrillion ", "quintillion ", "sextillions ",
            "septillion ", "octillion ", "nonillion ", "decillion ", "undecillion ", "duodecillion ", "tredecillion ", "quattuordecillion ",
            "quintillion ", "seksdetsillion ", "septem detsillion ", "oktmo detsillion ", "basis detsillion ", "vigintillion ", "unvigintillion ",
            "uindecillion ", "sexdecillion ", "septendecillion ", "octodecillion ", "novemdecillion ", "vigintillion ",
            "unvigintillion ", "duovigintillion ", "tresvigintillion ", "quattuorvigintillion ", "quinquavigintillion " };
            for (int i = 1; i < 10; i++)
            {
                if (i == 1)
                    Hundreads.Add(String.Format("{0}{1}", Units[i], "hundred "));
                else
                    Hundreads.Add(String.Format("{0}{1}", Units[i], "hundreds "));
            }
        }

        /// <summary>
        /// Обработка окончаний в словах названий разрядов
        /// </summary>
        public override string Ending(int LastThree, int digit)
        {
            if (LastThree == 0) return "";
            else if (digit == 0 && LastThree == 0) return "zero";
            else
            {
                string result = String.Empty;
                int LastNum = LastThree % 10;
                return String.Join("", result);
            }
        }

        public override string ThirdDigit(int number, int digit)
        {
            int num = number;
            string res = "";
            res = String.Join("", Hundreads[num / 100], res);
            num %= 100;
            res = String.Join("", Decade[num / 10], res);
            if (num >= 20)
            {
                num %= 10;
            }
            res = String.Join("", Units[num], res);
            return res;
        }
    }
}