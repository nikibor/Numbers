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
                Console.WriteLine(n.ToEight(8));
                Console.WriteLine("{0}в десятичной системе счисления", t.Russian()[0]);
                if (t.Russian()[1].Length >0)
                {
                    Console.Write("{0}в десятичной системе счисления", t.Russian()[1]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
