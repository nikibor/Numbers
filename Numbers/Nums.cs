using System.Numerics;

namespace Numbers
{
    class Nums
    {
        public BigInteger x { set; get; }        
        /// <summary>
        /// Перевод в 8сс
        /// </summary>
        /// <returns>Строка с переведенным числом</returns>
        public static string ToEight(BigInteger x)
        {
            string res = "";
            BigInteger ost = new BigInteger();
            while(x>8)
            {
                ost = x % 8;
                x = x / 8;
                res = ost.ToString() + res;
            }
            res = x.ToString() + res;
            return res;
        }
    }
}
