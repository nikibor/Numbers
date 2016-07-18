using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Numbers
{
    class Eight : ITransference
    {
        private string Number = String.Empty;

        public string number
        {
            get
            {
                return Number;
            }
            set
            {
                Number = Nums.ToEight(value, 8);
            }
        }
    }
}
