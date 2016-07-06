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
        English Eng = new English();
        Russian Rus = new Russian();
        BigInteger bigInt { set; get; }
        string[] args;
        /// <summary>
        /// Конструктор класса для описания поведения программы
        /// </summary>
        /// <param name="bigInt">Начальное число</param>
        /// <param name="args">Параметры командной строки</param>
        public CommandLine(BigInteger bigInt, string[] args)
        {
            //this.bigInt = bigInt;
            this.args = args;
        }
        /// <summary>
        /// Функция преобразующая в 8сс
        /// </summary>
        public void Eight()
        {
            foreach (string a in args)
                if (a == eight)
                {
                    Console.WriteLine();
                    string Eight = (args.Contains(eng)) ? Eng.Translate(Nums.ToEight(bigInt)).Normalize() : Rus.Translate(Nums.ToEight(bigInt)).Normalize();
                    Console.WriteLine("{0}в восьмиричной системе счисления", Eight.Remove(Eight.Length - 1, 1));
                }
        }
        /// <summary>
        /// Проверка всех аргументов, выбор языка, написание основного числа
        /// </summary>
        public void Check()
        {
            if (args.Length != 0)
            {
                for (int i = 0; i < args.Length - 1; i++)
                {
                    if (args[i] == num)
                    {
                        bigInt = Num(args[i + 1]);
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Введите число:");
                bigInt = BigInteger.Parse(Console.ReadLine());
                if (bigInt < 0) Console.WriteLine("Число отрицательное");
            }
            string result = (args.Contains(eng)) ? Eng.Translate(bigInt.ToString()).Normalize() : Rus.Translate(bigInt.ToString()).Normalize();
            Console.WriteLine("Длинна введенной строки = {0}", bigInt.ToString().Length);
            if (bigInt < 0) Console.WriteLine("Число отрицательное");
            else Console.WriteLine("{0}в десятичной системе счисления", result.Remove(result.Length - 1, 1));
        }
        /// <summary>
        /// Преобразование аргумента числа
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public BigInteger Num(string args)
        {
            BigInteger bigInt = new BigInteger();
            BigInteger.TryParse(args, out bigInt);
            return bigInt;
        }
    }
}