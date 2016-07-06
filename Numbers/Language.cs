using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Numbers
{
    abstract class Language
    {
        public List<string> Units { set; get; }
        public List<string> Decade { set; get; }
        public List<string> Hundreads { set; get; }
        public List<string> Big { set; get; }
        public List<string> Exceptions { set; get; }

        public string Translate(string bigInt)
        {
            string res = "";
            int digit = 0;
            while (bigInt.Length > 3)
            {
                int LastThree = Convert.ToInt32(bigInt.Substring(bigInt.Length - 3));
                res = String.Format("{0} {1}", Ending(LastThree, digit, Big[digit++]), res);
                bigInt = bigInt.Remove(bigInt.Length - 3);
            }
            res = String.Format("{0} {1}", Ending(Convert.ToInt32(bigInt), digit, Big[digit++]), res);
            return res;
        }
        public string ThirdDigit(int y, int digit)
        {
            string res = "";
            if (y < 3 && digit == 1)
                res = (y == 1) ? Exceptions[0] : Exceptions[1];
            else
                if (y % 100 > 9 && y % 100 < 20)
                res += Units[(y % 10) + 10];
            else
                res = (digit == 0 && y == 0) ? Exceptions[2] : String.Format("{0}{1} {2}", res, Decade[(y / 10) % 10], Units[y % 10]);
            return res = String.Format("{0} {1}", Hundreads[y / 100], res);
        }

        abstract public string Ending(int LastThree, int digit, string word);    
    }
}