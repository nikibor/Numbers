using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

/// <summary>
/// Класс обеспечивающий работу с русским языком
/// </summary>
namespace Numbers
{
    class Russian : Language
    {
        public Russian()
        {
            this.Units = new List<string> { String.Empty, "один ", "два ", "три ", "четыре ", "пять ", "шесть ", "семь ", "восемь ","девять ", "десять ", "одиннадцать ", "двенадцать ", "тренадцать ", "четырнадцать ", "пятнадцать ", "шестнадцать ","семнадцать ", "восемнадцать ", "девятнадцать " };
            this.Decade = new List<string> { String.Empty, String.Empty, "двадцать ", "тридцать ", "сорок ", "пятьдесят ", "шестьдесят ","семьдесят ", "восемдесят ", "девяносто " };
            this.Hundreads = new List<string> { String.Empty, "сто " , "двести ", "триста ", "четыреста ", "пятьсот ", "шестьсот ","семьсот ", "восемьсот ", "девятьсот " };
            this.Big = new List<string> { String.Empty, "тысяч", "миллион", "миллиард", "триллион", "квадрилион", "квантиллион", "секстиллион",
            "септиллион", "октоллион", "нониллион", "дециллион", "андециллион", "дуодециллион", "тредециллион", "кваттордециллион",
            "квиндециллион", "сексдециллион", "септемдециллион", "октодециллион", "новемдециллион", "вигинтиллион", "анвигинтиллион",
            "дуовигинтиллион", "тревигинтиллион", "кватторвигинтиллион", "квинвгинтиллион", "сексвигинтиллион", "септимвигинтиллион",
            "октовигинтиллион", "новемвигинтиллион", "тригинтиллион", "антригинтиллион", "гугол" };
        }
        public override string ThirdDigit(int number, int digit)
        {
            string res = "";
            res = String.Join("", res, Hundreads[number / 100]);
            number %= 100;
            res = String.Join("", res, Decade[number / 10]);
            if (number >= 20)
            {
                number %= 10;
            }
            string one = (digit == 1) ? "одна " : Units[1];
            string two = (digit == 1) ? "две " : Units[2];
            if ((number % 10 == 1 || number % 10 == 2) && number / 10 != 1)
                res = (number == 1) ? String.Join("", res, one) : String.Join("", res, two);
            else
            res = String.Join("", res, Units[number]);
            return res;
        }

        /// <summary>
        /// Обработка окончаний на русском языке
        /// </summary>
        public override string Ending(int LastThree, int digit)
        {
            string result = String.Empty;
            if (LastThree == 0 || digit == 0) return "";
            else
            {
                if (digit == 1)
                    return EndingForThousands(LastThree);
                else
                    return EndingForBigNumbers(LastThree);
            }
        }

        /// <summary>
        /// Обработка окончаний для "тысяч"
        /// </summary>
        private string EndingForThousands(int LastThree)
        {
            if (LastThree % 10 == 1 && (LastThree % 100) / 10 != 1)
                return "а ";
            else
            {
                if (LastThree % 10 > 1 && LastThree % 10 < 5 && LastThree % 100 / 10 != 1)
                    return "и ";
                else return " ";
            }
        }

        /// <summary>
        /// Обработка окончаний для разрядов от миллиона и более
        /// </summary>
        private string EndingForBigNumbers(int LastThree)
        {
            if (LastThree % 10 == 1 && (LastThree % 100)/10 != 1)
                return " ";
            else
            {
                if (LastThree % 10 > 1 && LastThree % 10 < 5 && (LastThree % 100) / 10 != 1)
                    return "а ";
                else return "ов ";
            }
        }

    }
}
