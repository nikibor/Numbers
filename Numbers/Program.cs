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
                BigInteger x = new BigInteger();
                CommandLine.Check(args, ref x);
                foreach (string a in args)
                    if (a == CommandLine.eight) CommandLine.Eight(x);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
