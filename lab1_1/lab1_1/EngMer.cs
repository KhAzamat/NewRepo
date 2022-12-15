using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_1
{
    public class EngMer
    {
        
        public int a;
        public int b;
        static public int EngMer_func(int a, int radio)
        {

            if (radio == 0)
            {
                a = a * 12;
                return a;

            }
            else if (radio == 1)
            {
                a = a / 12;
                return a;
            }
            else
            {
                return 0;
            }


        }


    }
    
}
