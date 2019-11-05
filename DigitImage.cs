using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkWithMNISTData
{
    public class DigitImage
    {
        public int width;
        public int height;
        public List<List<byte>> _pixels; // 0 (белый) – 255 (черный)
        public byte _label; // '0' - '9'

        public DigitImage(List<List<byte>> pixels, byte label)
        {
            width = 28;
            height = 28;

            _pixels = new List<List<byte>>();
            for (int i = 0; i < height; ++i)
            {
                List<byte> pixel = new List<byte>();
                for (int j = 0; j < width; ++j)
                {
                    pixel.Add(pixels[i][j]);
                }
                _pixels.Add(pixel);
            }

            _label = label;
        }
    }
}
