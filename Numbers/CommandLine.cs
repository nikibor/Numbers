using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Numbers
{
    /// <summary>
    /// Класс работающий с состояниями программы
    /// </summary>
    class CommandLine
    {
        private static BigInteger bigInt { set; get; }
        private string[] args { set; get; }
        private Dictionary<string, Language> langDict = new Dictionary<string, Language>
        {
            { "--rus", new Russian()},
            { "--eng", new English()},
        };
        private Dictionary<string, ITransference> SystemsOfCounting = new Dictionary<string, ITransference>
        {
            { "--eight",new Eight() },
            {"--decimal",new Decimal() }
        };

        public CommandLine(string[] args)
        {
            this.args = args;
            HaveArguments();
            ParameterCheck();
            ManySameLanguagesCheck();
        }

        public void AnotherSystemsOfCounting()
        {
            foreach (string tag in args)
            {
                if (SystemsOfCounting.ContainsKey(tag))
                {
                    SystemsOfCounting[tag].number = bigInt.ToString();
                    Translate(SystemsOfCounting[tag].number);
                }
            }
        }

        public void Decimal()
        {
            if (args.Contains("--decimal"))
                Translate(bigInt.ToString());
            else
                throw new Exception("Неправильно переданы параметры командной строки");
        }

        private void HaveArguments()
        {
            bool result = true;
            foreach (string tag in args)
            {
                if (IsNumber(tag))
                {
                    if (tag != "-0")
                        TakeNumber(tag);
                    else throw new Exception("Неправильный ввод числа");
                }
                else
                    result = CheckParametrs(result, tag);
            }
            if (!result) throw new Exception("Недостаточно аргументов для работы программы");
        }

        private bool CheckParametrs(bool result, string tag)
        {
            if (!langDict.ContainsKey(tag) && !SystemsOfCounting.ContainsKey(tag))
            {
                throw new Exception("Введенные параметры содержат ошибку");
            }
            return result;
        }

        private void TakeNumber(string tag)
        {
            if (IsNumber(tag))
            {
                CommandLine.bigInt = BigInteger.Parse(tag);
                if (bigInt < 0)
                    throw new Exception("Число отрицательное");
            }
        }

        public void Translate(string number)
        {
            foreach (string tag in args)
            {
                if (langDict.ContainsKey(tag))
                    SelectLanguage(tag, number);
            }
        }

        private void SelectLanguage(string tag, string number)
        {
            string result = langDict[tag].Translate(number);
            Console.WriteLine(result);
        }

        private bool IsNumber(string tag)
        {
            BigInteger bigInt = new BigInteger();
            return BigInteger.TryParse(tag, out bigInt);
        }

        private void ParameterCheck()
        {
            int quantityOfNumbers = 0;
            int Languages = 0;
            foreach (string tag in args)
            {
                if (IsNumber(tag))
                    quantityOfNumbers++;
                if (langDict.ContainsKey(tag))
                    Languages++;
            }
            if (Languages == 0)
                throw new Exception("Язык не выбран");
            if (quantityOfNumbers == 0)
                throw new Exception("Число не введено");
        }

        private void ManySameLanguagesCheck()
        {
            Dictionary<string, int> quantity = new Dictionary<string, int>();
            foreach(string tag in args)
            {
                if (!quantity.ContainsKey(tag))
                    quantity.Add(tag, 0);
                quantity[tag]++;
                if (quantity[tag] > 1)
                    throw new Exception(String.Format("Параметры переданы неправильно: язык {0} передан более одного раза", tag));
            }
        }
    }   
}