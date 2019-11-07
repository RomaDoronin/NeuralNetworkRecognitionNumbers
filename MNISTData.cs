// UNN, IITMM
// © Roman Doronin, 2019
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace NeuralNetworkRecognitionNumbers
{
    public class MNISTData
    {
        private static int ReverseBytes(int v)
        {
            byte[] byteAsBytes = BitConverter.GetBytes(v);
            Array.Reverse(byteAsBytes);
            return BitConverter.ToInt32(byteAsBytes, 0);
        }

        public static List<DigitImage> LoadData(string pixelFile, string labelFile, ref ProgressBar progressBar, int numberRecognizableNumbers, int numImages)
        {
            // Читаем потоки из файлов
            FileStream ifsPixels = new FileStream(pixelFile, FileMode.Open);
            FileStream ifsLabels = new FileStream(labelFile, FileMode.Open);
            // Читаем бинарки из потоков
            BinaryReader brImages = new BinaryReader(ifsPixels);
            BinaryReader brLabels = new BinaryReader(ifsLabels);

            int magic1 = brImages.ReadInt32(); // обратный порядок байтов
            magic1 = ReverseBytes(magic1); // преобразуем в формат Intel
            int imageCount = brImages.ReadInt32();
            imageCount = ReverseBytes(imageCount);
            int numRows = brImages.ReadInt32();
            numRows = ReverseBytes(numRows);
            int numCols = brImages.ReadInt32();
            numCols = ReverseBytes(numCols);

            int magic2 = brLabels.ReadInt32();
            magic2 = ReverseBytes(magic2);
            int numLabels = brLabels.ReadInt32();
            numLabels = ReverseBytes(numLabels);

            int imageSize = 28;
            List<DigitImage> result = new List<DigitImage>();

            progressBar.Maximum = numImages;
            progressBar.Value = 0;

            for (int di = 0; di < numImages; ++di)
            {
                List<List<byte>> pixels = new List<List<byte>>();
                for (int i = 0; i < imageSize; ++i) // получаем пиксельные
                {
                    List<byte> pixel = new List<byte>();
                    for (int j = 0; j < imageSize; ++j)
                    {
                        byte b = brImages.ReadByte();
                        pixel.Add(b);
                    }
                    pixels.Add(pixel);
                }
                byte lbl = brLabels.ReadByte();
                if (lbl < numberRecognizableNumbers)
                {
                    DigitImage dImage = new DigitImage(pixels, lbl);
                    result.Add(dImage);
                }
                progressBar.Value++;
            }

            ifsPixels.Close();
            brImages.Close();
            ifsLabels.Close();
            brLabels.Close();

            return result;
        }
    }
}
