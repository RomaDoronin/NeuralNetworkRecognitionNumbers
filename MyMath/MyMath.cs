using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkRecognitionNumbers
{
    public class MyMath
    {
        public static int Log2(int val)
        {
            int res = 0;
            while (val / 2 > 0)
            {
                val /= 2;
                res++;
            }
            return res;
        }
    }
}
