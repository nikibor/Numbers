using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    class Clean
    {
        public static string Cleaninig(string s)
        {
            for (int i = 0; i < 1; i++)
            {
                if (s.Contains("   "))
                {
                    s.Replace(" ", String.Empty);
                    s.Remove(s.IndexOf(' '), 1);
                    s.Trim(' ').Replace(" ", String.Empty);
                }
                s.Normalize();
                if (s.Contains("  "))
                {
                    s.Replace("  ", " ");
                    s.Remove(s.IndexOf(' '), 1);
                    s.Trim(' ').Replace("  ", String.Empty);
                }
                s.Normalize();
                if (s.Contains(" "))
                {
                    s.Replace(" ", String.Empty);
                    s.Remove(s.IndexOf(' '), 1);
                    s.Trim(' ').Replace(" ", String.Empty);
                }

                s.Normalize();
            }
            return s;
        }
        public static string Cleen(string s)
        {
            for(int i=0;i<s.Length-1;i++)
            {
                if (s[i] == ' ' && s[i + 1] == ' ')
                    s.Trim(s[i]);
            }
            return s;
        }
    }
}
