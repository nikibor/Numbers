using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Numbers
{
    class CommandLine
    {
        public static string rus = "-rus";
        public static string eight = "-eight";
        public static string eng = "-eng";
        public static string num = "-num";
        /// <summary>
        /// Работа с переводом в 8сс
        /// </summary>
        /// <param name="n">Первоначальное число</param>
        public static void Eight(BigInteger n)
        {
            Console.WriteLine(" ");
            string Eight = Translate.Russian(BigInteger.Parse(Nums.ToEight(n))).Normalize();
            Console.WriteLine("{0}в восьмиричной системе счисления", Eight.Normalize());
        }
        /// <summary>
        /// Проверка параметров и выдача результата
        /// </summary>
        /// <param name="args">параметры</param>
        /// <param name="x"></param>
        public static void Check(string[] args, ref BigInteger bigInt)
        {
            if(args.Length!=0)
            {
                for(int i=0;i<args.Length-1;i++)
                {
                    if(args[i]==num)
                    {
                        bigInt = Num(args[i + 1]);
                        WorkWirh10(bigInt);
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Введите число:");
                bigInt = BigInteger.Parse(Console.ReadLine());
            }
        }
        /// <summary>
        /// Поиск и преобразование аргумента в число
        /// </summary>
        /// <param name="args">параметр</param>
        /// <returns>Начальное число для дальнейшей работы</returns>
        public static BigInteger Num(string args)
        {
            BigInteger bigInt = new BigInteger();
            BigInteger.TryParse(args,out bigInt);
            return bigInt;
        }
        /// <summary>
        /// Финальный этап работы с 10сс
        /// </summary>
        /// <param name="x">Первоначальное большое число</param>
        public static void WorkWirh10(BigInteger x)
        {
            string result = Translate.Russian(x).Normalize();
            Console.WriteLine("Длинна введенной строки = {0}", x.ToString().Length);
            Console.WriteLine("{0}в десятичной системе счисления", result.Normalize());
        }
    }
}
