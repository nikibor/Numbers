using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Numbers
{
    class Russian : Language
    {
        public Russian()
        {
            this.Units = new List<string> { String.Empty, "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять", "десять", "одиннадцать", "двенадцать", "тренадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" };
            this.Decade = new List<string> { String.Empty, String.Empty, "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемдесят", "девяносто" };
            this.Hundreads = new List<string> { String.Empty, "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };
            this.Big = new List<string> { String.Empty, "тысяч", "миллион", "миллиард", "триллион", "квадрилион", "квантиллион", "секстиллион",
            "септиллион", "октоллион", "нониллион", "дециллион", "андециллион", "дуодециллион", "тредециллион", "кваттордециллион",
            "квиндециллион", "сексдециллион", "септемдециллион", "октодециллион", "новемдециллион", "вигинтиллион", "анвигинтиллион",
            "дуовигинтиллион", "тревигинтиллион", "кватторвигинтиллион", "квинвгинтиллион", "сексвигинтиллион", "септимвигинтиллион",
            "октовигинтиллион", "новемвигинтиллион", "тригинтиллион", "антригинтиллион", "гугол" };
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
            string res = String.Empty;
            switch (digit)
            {
                case (0):
                    res = (LastThree == 0) ? "ноль" : "";
                    break;
                case (1):
                    if (LastThree % 10 == 1 && (LastThree % 100) / 10 != 1)
                        res = "а";
                    else if (LastThree % 10 > 1 && LastThree % 10 < 5 && (LastThree % 100) / 10 > 1 && (LastThree % 100) / 10 < 5)
                        res = "и";
                    else
                        res = "";
                    break;
                default:
                    if (LastThree % 10 == 1 && (LastThree % 100) / 10 != 1)
                        res = "";
                    else if (LastThree % 10 > 1 && LastThree % 10 < 5 && (LastThree % 100) / 10 > 1 && (LastThree % 100) / 10 < 5)
                        res = "а";
                    else
                        res = "ов";
                    break;
            }
            string thirdDigit = "";
            thirdDigit = (LastThree % 100 > 9 && LastThree % 100 < 20) ? thirdDigit + Units[(LastThree % 10) + 10] : String.Format("{0}{1} {2}", thirdDigit, Decade[(LastThree / 10) % 10], Units[LastThree % 10]);
            thirdDigit = String.Format("{0} {1}", Hundreads[LastThree / 100], thirdDigit);
            if (LastThree != 0)
                return String.Format("{0} {1}{2}", thirdDigit, word, res);
            else
                return res;
        }
    }
}
