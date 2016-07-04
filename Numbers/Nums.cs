using System.Numerics;

namespace Numbers
{
    class Nums
    {
        public BigInteger x { set; get; }
        public Nums(BigInteger x)
        {
            this.x = x;
        }
        /// <summary>
        /// Перевод в 8сс
        /// </summary>
        /// <returns>Строка с переведенным числом</returns>
        public string ToEight(int param)
        {
            string res = "";
            BigInteger ost = new BigInteger();
            while(x>param)
            {
                ost = x % param;
                x = x / param;
                res = ost.ToString() + res;
            }
            res = x.ToString() + res;
            return res;
        }
    }
}
