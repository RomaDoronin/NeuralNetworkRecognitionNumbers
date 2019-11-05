using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoLayerNeuralNetwork
{
    class TwoLayerNetwork
    {
        private List<Layer> _network;

        private const int NEURON_IN_LAYER_1 = 96;
        private int NEURON_IN_LAYER_2;
        //private const int NEURON_IN_LAYER_3 = 1;

        public TwoLayerNetwork(int inputSignalNum, byte numberRecognizableNumbers)
        {
            NEURON_IN_LAYER_2 = numberRecognizableNumbers;

            _network = new List<Layer>();
            Random rnd = new Random(DateTime.Now.Millisecond);

            _network.Add(new Layer(inputSignalNum, NEURON_IN_LAYER_1, rnd));
            _network.Add(new Layer(NEURON_IN_LAYER_1, NEURON_IN_LAYER_2, rnd));
            //_network.Add(new Layer(NEURON_IN_LAYER_2, NEURON_IN_LAYER_3));
        }

        public List<float> Run(List<float> inputSignal, List<float> etalon)
        {
            // Прямой ход, подсчет значений на нейронах
            List<float> outputFromLayer1 = _network[0].DoIteration(inputSignal);
            List<float> outputFromLayer2 = _network[1].DoIteration(outputFromLayer1);
            //List<float> outputFromLayer3 = _network[2].DoIteration(outputFromLayer2);

            List<float> result = new List<float>(outputFromLayer2); //outputFromLayer3[0];
            List <float> delta = DivisionLists(etalon, result);

            // Обратный ход, подсчет ошибок на нейронах
            //List<float> deltaFromLayer3 = new List<float>() { delta };
            List<float> deltaFromLayer2 = delta; //_network[2].CulcDelta(deltaFromLayer3, NEURON_IN_LAYER_2);
            List<float> deltaFromLayer1 = _network[1].CulcDelta(deltaFromLayer2, NEURON_IN_LAYER_1);

            // Пересчет весов в нейронах
            _network[0].RecalculationWeights(inputSignal, deltaFromLayer1, outputFromLayer1);
            _network[1].RecalculationWeights(outputFromLayer1, deltaFromLayer2, outputFromLayer2);
            //_network[2].RecalculationWeights(outputFromLayer2, deltaFromLayer3, outputFromLayer3);

            return result;
        }

        public List<float> Run(List<float> inputSignal)
        {
            List<float> outputFromLayer1 = _network[0].DoIteration(inputSignal);
            return _network[1].DoIteration(outputFromLayer1);
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
