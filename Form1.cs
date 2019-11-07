// UNN, IITMM
// © Roman Doronin, 2019
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetworkRecognitionNumbers
{
    public partial class Form1 : Form
    {
        private const string TRAIN_FILENAME_IMAGES = "train-images.idx3-ubyte";
        private const string TRAIN_FILENAME_LABELS = "train-labels.idx1-ubyte";
        private const string TEST_FILENAME_IMAGES = "t10k-images.idx3-ubyte";
        private const string TEST_FILENAME_LABELS = "t10k-labels.idx1-ubyte";
        private int numberRecognizableNumbers = 10;
        private int bitLen;
        private int imageSize = 28;

        private List<DigitImage> trainSet;
        private List<DigitImage> testSet;

        private TwoLayerNetwork network;

        public Form1()
        {
            InitializeComponent();
            bitLen = MyMath.Log2(numberRecognizableNumbers - 1) + 1;

            labelRecognizableNumbers.Text += numberRecognizableNumbers.ToString();
            labelBitLen.Text += bitLen.ToString();

            int nueronInHeddenLayerNum = 96;
            network = new TwoLayerNetwork(imageSize * imageSize, nueronInHeddenLayerNum, numberRecognizableNumbers);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            string filePath = textBoxPath.Text;
            trainSet = MNISTData.LoadData(filePath + TRAIN_FILENAME_IMAGES, filePath + TRAIN_FILENAME_LABELS,
                ref progressBar, numberRecognizableNumbers, 60000);
            labelTrainSize.Text += trainSet.Count.ToString();
            testSet = MNISTData.LoadData(filePath + TEST_FILENAME_IMAGES, filePath + TEST_FILENAME_LABELS,
                ref progressBar, numberRecognizableNumbers, 10000);
            labelTestSize.Text += testSet.Count.ToString();

            buttonTrain.Enabled = true;
        }

        private int NeuralRun(DigitImage digitImage)
        {
            List<float> inputSignal = CustomConversion.ByteMatrixToFloatList(digitImage.Pixels);
            List<float> realResult = CustomConversion.ByteToBinary(digitImage.Label, numberRecognizableNumbers);
            List<float> networkResult = network.Run(inputSignal, realResult);
            return CustomConversion.BinaryToByte(networkResult, numberRecognizableNumbers);
        }

        private float TestRun()
        {
            int allCount = 0;
            int rightCount = 0;

            foreach (DigitImage digitImage in testSet)
            {
                List<float> inputSignal = CustomConversion.ByteMatrixToFloatList(digitImage.Pixels);
                List<float> realResult = CustomConversion.ByteToBinary(digitImage.Label, bitLen);
                List<float> networkResult = network.Run(inputSignal);
                int result = CustomConversion.BinaryToByte(networkResult, numberRecognizableNumbers);

                if (result == digitImage.Label)
                {
                    rightCount++;
                }
                allCount++;
            }

            return (float)rightCount / allCount * 100;
        }

        private async void Training()
        {
            labelTestResult.Text = "Test result:";
            labelTraningResult.Text = "Train result:";
            progressBar.Maximum = trainSet.Count;
            progressBar.Value = 0;
            int allCount = 0;
            int rightCount = 0;

            int markNumPeriod = trainSet.Count / 20;

            foreach (DigitImage digitImage in trainSet)
            {
                int result = await Task.Run(()=>NeuralRun(digitImage));
                //int result = NeuralRun(digitImage);

                allCount++;
                if (result == digitImage.Label) rightCount++;

                if (allCount % markNumPeriod == 0)
                {
                    float procentTest = await Task.Run(()=>TestRun());
                    labelTestResult.Text += "\n" + procentTest.ToString() + "%";
                    float procentTrain = (float)rightCount / allCount * 100;
                    labelTraningResult.Text += "\n" + procentTrain.ToString() + "%";
                }

                progressBar.Value++;
            }
        }

        private void buttonTrain_Click(object sender, EventArgs e)
        {
            Training();
        }
    }
}
