using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoLayerNeuralNetwork
{
    class Layer
    {
        private List<Neuron> _layer;
        private List<float> _activeList;

        public Layer(int inputSignalNum, int nueronNum, Random rnd)
        {
            _layer = new List<Neuron>();

            for (int count = 0; count < nueronNum; count++)
            {
                _layer.Add(new Neuron(inputSignalNum, rnd));
            }
        }

        public List<float> DoIteration(List<float> inputSignal)
        {
            List<float> sumList = new List<float>();

            foreach (var neuron in _layer)
            {
                sumList.Add(neuron.CulcSum(inputSignal));
            }

            _activeList = new List<float>();

            for (int count = 0; count < _layer.Count; count++)
            {
                _activeList.Add(_layer[count].ActivationFunc(sumList[count]));
            }

            return _activeList;
        }

        private void InitByZeroList(List<float> list, int size)
        {
            for (int count = 0; count < size; count++)
            {
                list.Add(0);
            }
        }

        public List<float> CulcDelta(List<float> deltaList, int nueronNextNum)
        {
            List<float> deltaNextList = new List<float>();
            InitByZeroList(deltaNextList, nueronNextNum);

            for (int count = 0; count < _layer.Count; count++)
            {
                _layer[count].CulcDelta(deltaList[count], deltaNextList);
            }

            return deltaNextList;
        }

        public void RecalculationWeights(List<float> inputSignal, List<float> deltaList, List<float> outputSignal)
        {
            for (int count = 0; count < _layer.Count; count++)
            {
                _layer[count].RecalculationWeights(deltaList[count], inputSignal, outputSignal[count]);
            }
        }
    }
}
