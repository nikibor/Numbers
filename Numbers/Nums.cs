using System.Numerics;

namespace Numbers
{
    /// <summary>
    /// Класс для работы с числами
    /// </summary>
    class Nums
    {
        public BigInteger bigInt { set; get; }
        /// <summary>
        /// Функция по переводу числа в 8сс
        /// </summary>
        public static string ToEight(string bigInt, int parametr)
        {
            string result = "";
            BigInteger ostAfterDivide = BigInteger.Parse(bigInt);
            while (ostAfterDivide > parametr)
            {
                result = (ostAfterDivide % parametr).ToString() + result;
                ostAfterDivide = ostAfterDivide / parametr;
            }
            result = ostAfterDivide.ToString() + result;
            return result;
        }
    }
}
