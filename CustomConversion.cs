using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkWithMNISTData
{
    public class CustomConversion
    {
        static public List<float> ByteMatrixToFloatList(List<List<byte>> matrix)
        {
            List<float> list = new List<float>();

            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix.Count; j++)
                {
                    list.Add(matrix[i][j]);
                }
            }

            return list;
        }

        static public List<float> ByteToBinary(byte input, int len)
        {
            List<float> bin = new List<float>();

            for (int i = 0; i < len; i++)
            {
                if ((input & (1 << i)) > 0)
                {
                    bin.Add(1);
                }
                else
                {
                    bin.Add(0);
                }
            }

            return bin;
        }

        static public byte BinaryToByte(List<float> bin, int len)
        {
            byte result = 0;

            for (int i = 0; i < len; i++)
            {
                if (Math.Round(bin[i]) == 1)
                {
                    result += (byte)Math.Pow(2, i);
                }
            }

            return result;
        }
    }
}
