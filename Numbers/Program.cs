using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число:");
            string num = Console.ReadLine();
            Console.WriteLine("Длинна введенной строки = {0}" , num.Length);
            BigInteger x = BigInteger.Parse(num);            
            try
            {
                Nums n = new Nums(x);
                Translate t = new Translate(x);
                string result = t.Russian().Normalize();
                Console.WriteLine("{0}в десятичной системе счисления", Clean.Cleaninig(Clean.Cleen(result)));
                Console.WriteLine(" ");
                t.x = BigInteger.Parse(n.ToEight(8));
                string Eight = t.Russian().Normalize();
                Console.WriteLine("{0}в восьмиричной системе счисления", Clean.Cleaninig(Clean.Cleen(Eight.Normalize())));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
