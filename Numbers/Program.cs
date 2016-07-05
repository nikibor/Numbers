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
            try
            {
                Console.WriteLine("Введите число:");
                string num = Console.ReadLine();
                Console.WriteLine("Длинна введенной строки = {0}", num.Length);
                BigInteger x = BigInteger.Parse(num);
                Nums n = new Nums(x);
                string result = Translate.Russian(x).Normalize();
                Console.WriteLine("{0}в десятичной системе счисления", result.Normalize());
                if (args[0].Contains("-eight"))
                {
                    Console.WriteLine(" ");
                    string Eight = Translate.Russian(BigInteger.Parse(n.ToEight(8))).Normalize();
                    Console.WriteLine("{0}в восьмиричной системе счисления", Eight.Normalize());
                }                                
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
