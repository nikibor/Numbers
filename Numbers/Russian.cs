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
            this.Units = new List<string> { String.Empty, "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
            this.Tens = new List<string> { "десять", "одиннадцать", "двенадцать", "тренадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" };
            this.Decade = new List<string> { String.Empty, String.Empty, "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемдесят", "девяносто" };
            this.Hundreads = new List<string> { String.Empty, "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };
            this.Big = new List<string> { String.Empty, "тысяч", "миллион", "миллиард", "триллион", "квадрилион", "квантиллион", "секстиллион",
            "септиллион", "октоллион", "нониллион", "дециллион", "андециллион", "дуодециллион", "тредециллион", "кваттордециллион",
            "квиндециллион", "сексдециллион", "септемдециллион", "октодециллион", "новемдециллион", "вигинтиллион", "анвигинтиллион",
            "дуовигинтиллион", "тревигинтиллион", "кватторвигинтиллион", "квинвгинтиллион", "сексвигинтиллион", "септимвигинтиллион",
            "октовигинтиллион", "новемвигинтиллион", "тригинтиллион", "антригинтиллион", "гугол" };
        }
        public override string Ending(int LastThree, int digit, string word)
        {
            if (digit == 0 && LastThree == 0) return "ноль";
            else if (LastThree == 0) return "";
            else
            {
                string res = String.Empty;
                int LastNum = LastThree % 10;
                if (digit == 1)
                {
                    if (LastNum == 1 && LastThree % 100 != 11) res = "а";
                    else if ((LastNum > 2 && LastNum < 5) && LastThree % 100 > 15)
                        res = "и";
                    else res = String.Empty;
                }
                else if (digit != 0 && LastThree > 0)
                {
                    if (LastNum == 1 && LastThree % 100 != 11) res = String.Empty;
                    else if ((LastNum > 2 && LastNum < 5) && LastThree % 100 > 15)
                        res = "а";
                    else res = "ов";
                }
                string ThirdDigit = "";
                if (LastThree < 3 && digit == 1)
                    ThirdDigit = (LastThree == 1) ? "одна" : "две";
                else
                    ThirdDigit = (LastThree % 100 > 9 && LastThree % 100 < 20) ? ThirdDigit + Tens[LastThree % 10] : String.Format("{0}{1} {2}", ThirdDigit, Decade[(LastThree / 10) % 10], Units[LastThree % 10]);
                ThirdDigit = String.Format("{0} {1}", Hundreads[LastThree / 100], ThirdDigit);
                if (LastThree != 0)
                    return String.Format("{0} {1}{2}", ThirdDigit, word, res);
                else
                    return res;
            }
        }
    }
}
