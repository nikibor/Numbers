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
        public Translate(BigInteger num)
        {
            this.x = num;
        }
        static string[] nums1 = { "", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
        static string[] nums2 = { "десять", "одиннадцать", "двенадцать", "тренадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" };
        static string[] nums3 = { "", "", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемдесят", "девяносто" };
        static string[] nums4 = { "", "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };
        static string[] nums5 = { "", "тысяч(а/и)", "миллион", "миллиард", "триллион", "квадрилион", "квантиллион", "секстиллион", "септиллион", "октоллион", "нониллион", "дециллион", "андециллион", "дуодециллион", "тредециллион", "кваттордециллион", "квиндециллион", "сексдециллион", "септемдециллион", "октодециллион", "новемдециллион", "вигинтиллион", "анвигинтиллион", "дуовигинтиллион", "тревигинтиллион", "кватторвигинтиллион", "квинвгинтиллион", "сексвигинтиллион", "септимвигинтиллион", "октовигинтиллион", "новемвигинтиллион", "тригинтиллион", "антригинтиллион" };
        /// <summary>
        /// Перевод на русский язык введенного числа
        /// </summary>
        /// <returns></returns>
        public List<string> Russian()
        {
            List<string> lst = new List<string>();
            string res = "";
            string res2 = "";            
            string num = x.ToString();
            int digit = 0;
            while( (num.Length)>=3 )
            {
                int LastThree = Convert.ToInt32(num.Substring(num.Length-3));
                if (digit < 30)
                {
                    if (LastThree%10 == 0 && digit !=0)
                    {
                        res = String.Format("{0} {1}(ов) {2}", ThirdDigit(LastThree), nums5[digit], res);
                    }
                    else if (LastThree%10 == 1 && digit != 0)
                    {
                        res = String.Format("{0} {1}(а/ов) {2}", ThirdDigit(LastThree), nums5[digit], res);
                    }
                    else if(LastThree%10 == 2 || LastThree % 10 == 3|| LastThree % 10 == 4 || LastThree % 10 == 5 && digit != 0)
                    {
                        res = String.Format("{0} {1}(а/ов) {2}", ThirdDigit(LastThree), nums5[digit], res);
                    }
                    else res = String.Format("{0} {1} {2}", ThirdDigit(LastThree), nums5[digit], res);
                }
                else
                {
                    if (LastThree % 10 == 0 && digit != 0)
                    {
                        res2 = String.Format("{0} {1}(ов) {2}", ThirdDigit(LastThree), nums5[digit], res2);
                    }
                    if (LastThree % 10 == 1 && digit != 0)
                    {
                        res2 = String.Format("{0} {1}(а) {2}", ThirdDigit(LastThree), nums5[digit], res2);
                    }
                    else if (LastThree % 10 == 2 || LastThree % 10 == 3 || LastThree % 10 == 4 && digit != 0)
                    {
                        res2 = String.Format("{0} {1}(и) {2}", ThirdDigit(LastThree), nums5[digit], res2);
                    }
                    else res2 = String.Format("{0} {1} {2}", ThirdDigit(LastThree), nums5[digit], res2);
                }
                num = num.Remove(num.Length - 3);
                digit++;
                x = BigInteger.Divide(x, 1000);
            }
            if (digit < 20)
            {
                res = String.Format("{0}{1} {2}", ThirdDigit(Convert.ToInt32(x.ToString())), nums5[digit++], res);
            }
            else
            {
                res2 = String.Format("{0}{1} {2}", ThirdDigit(Convert.ToInt32(x.ToString())), nums5[digit++], res2);
            }
            lst.Add(res);
            lst.Add(res2);
            return lst;
        }
        /// <summary>
        /// Перевод последних трех чисел на русский
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public string ThirdDigit(int y)
        {
            string res = "";
            if(y%100>9 && y%100<20)
            {
                switch(y%100)
                {
                    case (10): res += nums2[0];break;
                    case (11): res += nums2[1]; break;
                    case (12): res += nums2[2]; break;
                    case (13): res += nums2[3]; break;
                    case (14): res += nums2[4]; break;
                    case (15): res += nums2[5]; break;
                    case (16): res += nums2[6]; break;
                    case (17): res += nums2[7]; break;
                    case (18): res += nums2[8]; break;
                    case (19): res += nums2[9]; break;
                }
            }
            else
            {
                res = String.Format("{0} {1} {2}", res, nums3[(y / 10) % 10], nums1[y % 10]);
            }
            return res = String.Format("{0} {1} ", nums4[y / 100], res);
        }
    }
    
}
