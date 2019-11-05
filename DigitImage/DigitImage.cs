using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkRecognitionNumbers
{
    public class DigitImage
    {
        public int Size { set; get; }
        public List<List<byte>> Pixels { set; get; }
        public byte Label { set; get; }

        public DigitImage(List<List<byte>> pixels, byte label)
        {
            Size = 28;
            Pixels = new List<List<byte>>(pixels);
            Label = label;
        }
    }
}
