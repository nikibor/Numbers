using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Numbers
{
    class Translate
    {
        public BigInteger x { set; get; }
        static string[] nums1 = { String.Empty, "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
        static string[] nums2 = { "десять", "одиннадцать", "двенадцать", "тренадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" };
        static string[] nums3 = { String.Empty, String.Empty, "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемдесят", "девяносто" };
        static string[] nums4 = { String.Empty, "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };
        static string[] nums5 = { String.Empty, "тысяч", "миллион", "миллиард", "триллион", "квадрилион", "квантиллион", "секстиллион", "септиллион", "октоллион", "нониллион", "дециллион", "андециллион", "дуодециллион", "тредециллион", "кваттордециллион", "квиндециллион", "сексдециллион", "септемдециллион", "октодециллион", "новемдециллион", "вигинтиллион", "анвигинтиллион", "дуовигинтиллион", "тревигинтиллион", "кватторвигинтиллион", "квинвгинтиллион", "сексвигинтиллион", "септимвигинтиллион", "октовигинтиллион", "новемвигинтиллион", "тригинтиллион", "антригинтиллион", "гугол" };
        /// <summary>
        /// Перевод на русский язык
        /// </summary>
        /// <param name="x">Число</param>
        /// <returns>Число на русском языке</returns>
        public static string Russian(BigInteger x)
        {
            string res = "";
            string num = x.ToString();
            int digit = 0;
            while (num.Length > 3)
            {
                int LastThree = Convert.ToInt32(num.Substring(num.Length - 3));
                res = String.Format("{0} {1}", Ending(LastThree, digit, nums5[digit++]), res);
                num = num.Remove(num.Length - 3);
            }
            res = String.Format("{0} {1}", Ending(Convert.ToInt32(num), digit, nums5[digit++]), res);
            if (res[0] == ' ')
                res.Remove(0, 1);
            return res;
        }
        /// <summary>
        /// Перевод последних трех чисел на русский
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public static string ThirdDigit(int y, int digit)
        {
            string res = "";
            if (y < 3 && digit == 1) res = (y == 1) ? "одна" : "две";
            else res = (y % 100 > 9 && y % 100 < 20) ? res + nums2[y % 10] : String.Format("{0}{1} {2}", res, nums3[(y / 10) % 10], nums1[y % 10]);            
            return res = String.Format("{0} {1}", nums4[y / 100], res);
        }
        /// <summary>
        /// Добавление названия разряда и его окончания
        /// </summary>
        /// <param name="LastThree">Последние 3 знака числа</param>
        /// <param name="digit">Разряд</param>
        /// <param name="word">Название разряда</param>
        /// <returns></returns>
        public static string Ending(int LastThree, int digit,string word)
        {
            if (LastThree == 0) return "";
            else if (digit == 0 && LastThree == 0) return "ноль";
            else
            {
                string res = String.Empty;
                int LastNum = LastThree % 10;
                if (digit == 1)
                    res = (LastNum > 1 || LastNum == 0) ? (LastNum < 5) ? String.Format("и") : String.Empty : String.Format("а");
                else if 
                    (digit != 0) res = (LastNum > 1 || LastNum == 0) ? (LastNum < 5) ? String.Format("а") : String.Format("ов") : String.Empty;
                string ThirdDigit = "";
                if (LastThree < 3 && digit == 1) ThirdDigit = (LastThree == 1) ? "одна" : "две";
                else ThirdDigit = (LastThree % 100 > 9 && LastThree % 100 < 20) ? ThirdDigit + nums2[LastThree % 10] : String.Format("{0}{1} {2}", ThirdDigit, nums3[(LastThree / 10) % 10], nums1[LastThree % 10]);
                ThirdDigit = String.Format("{0} {1}", nums4[LastThree / 100], ThirdDigit);
                if (LastThree != 0) return String.Format("{0} {1}{2}", ThirdDigit, word, res);
                else return res;
            }
        }
    }
}
