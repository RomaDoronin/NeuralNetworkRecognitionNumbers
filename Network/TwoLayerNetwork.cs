using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkRecognitionNumbers
{
    class TwoLayerNetwork
    {
        private Layer layer1;
        private Layer layer2;
        private int nueronInLayer1;
        private int nueronInLayer2;

        public TwoLayerNetwork(int inputSignalNum, int nueronInHeddenLayerNum, int outputSignalNum)
        {
            nueronInLayer1 = nueronInHeddenLayerNum;
            nueronInLayer2 = outputSignalNum;

            Random rnd = new Random(DateTime.Now.Millisecond);

            layer1 = new Layer(inputSignalNum, nueronInLayer1, rnd);
            layer2 = new Layer(nueronInLayer1, nueronInLayer2, rnd);
        }

        public List<float> Run(List<float> inputSignal, List<float> etalon)
        {
            // Прямой ход, подсчет значений на нейронах
            List<float> outputFromLayer1 = layer1.DoIteration(inputSignal);
            List<float> outputFromLayer2 = layer2.DoIteration(outputFromLayer1);

            List<float> result = new List<float>(outputFromLayer2);
            List<float> delta = DivisionLists(etalon, result);

            // Обратный ход, подсчет ошибок на нейронах
            List<float> deltaFromLayer2 = delta;
            List<float> deltaFromLayer1 = layer2.CulcDelta(deltaFromLayer2, nueronInLayer1);

            // Пересчет весов в нейронах
            layer1.RecalculationWeights(inputSignal, deltaFromLayer1, outputFromLayer1);
            layer2.RecalculationWeights(outputFromLayer1, deltaFromLayer2, outputFromLayer2);

            return result;
        }

        public List<float> Run(List<float> inputSignal)
        {
            List<float> outputFromLayer1 = layer1.DoIteration(inputSignal);
            return layer2.DoIteration(outputFromLayer1);
        }

        private List<float> DivisionLists(List<float> firstList, List<float> secondList)
        {
            List<float> resultList = new List<float>();

            for (int count = 0; count < firstList.Count; count++)
            {
                resultList.Add(firstList[count] - secondList[count]);
            }

            return resultList;
        }
    }
}
