// UNN, IITMM
// © Roman Doronin, 2019
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkRecognitionNumbers
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
                    list.Add((float)matrix[i][j] / 255);
                }
            }

            return list;
        }

        static public List<float> ByteToBinary(byte input, int len)
        {
            List<float> bin = new List<float>();

            for (int i = 0; i < len; i++)
            {
                if (i == input)
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

        static public int BinaryToByte(List<float> bin, int len)
        {
            float max = 0;
            int result = -1;

            for (int i = 0; i < len; i++)
            {
                if (max < bin[i])
                {
                    max = bin[i];
                    result = i;
                }
            }

            return result;
        }
    }
}
