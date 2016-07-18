using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Numbers
{
    /// <summary>
    /// Класс обеспечивающий преобразование числа в слова
    /// </summary>
    abstract class Language
    {
        protected List<string> Units { set; get; }
        protected List<string> Decade { get; set; }
        protected List<string> Hundreads { get; set; }
        protected List<string> Big { get; set; }

        /// <summary>
        /// Перевод численного впредставления в словестный
        /// </summary>
        public string Translate(string bigInt)
        {
            string ending = "";
            int digit = 0;
            if (bigInt == "0")
                return "ноль";

            while (bigInt.Length > 3)
            {
                int LastThree = Convert.ToInt32(bigInt.Substring(bigInt.Length - 3));
                if (LastThree != 0)
                    ending = String.Join("", CombineWord(LastThree, Ending(LastThree, digit), digit), ending);
                bigInt = bigInt.Remove(bigInt.Length - 3);
                digit++;
            }
            ending = String.Join("", CombineWord(Convert.ToInt32(bigInt), Ending(Convert.ToInt32(bigInt), digit), digit), ending);
            return ending;
        }

        public abstract string ThirdDigit(int number, int digit);
        
        public abstract string Ending(int LastThree, int digit);

        private string CombineWord(int LastThree, string endingOfWord, int digit)
        {
            string result = "";
            string LastNumsTranslated = ThirdDigit(LastThree, digit);
            try
            {
                result = String.Join("", Big[digit], endingOfWord);
            }
            catch (Exception)
            {
                throw new Exception("Введенное число слишком большое");
            }
            return String.Format("{0}{1}", LastNumsTranslated, result);
        }
    }
}