using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkRecognitionNumbers
{
    class Layer
    {
        private List<Neuron> nueronList;
        private List<float> activeList;

        public Layer(int inputSignalNum, int nueronNum, Random rnd)
        {
            nueronList = new List<Neuron>();

            for (int count = 0; count < nueronNum; count++)
            {
                nueronList.Add(new Neuron(inputSignalNum, rnd));
            }
        }

        public List<float> DoIteration(List<float> inputSignal)
        {
            List<float> sumList = new List<float>();

            foreach (var neuron in nueronList)
            {
                sumList.Add(neuron.CulcSum(inputSignal));
            }

            activeList = new List<float>();

            for (int count = 0; count < nueronList.Count; count++)
            {
                activeList.Add(nueronList[count].ActivationFunc(sumList[count]));
            }

            return activeList;
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

            for (int count = 0; count < nueronList.Count; count++)
            {
                nueronList[count].CulcDelta(deltaList[count], deltaNextList);
            }

            return deltaNextList;
        }

        public void RecalculationWeights(List<float> inputSignal, List<float> deltaList, List<float> outputSignal)
        {
            for (int count = 0; count < nueronList.Count; count++)
            {
                nueronList[count].RecalculationWeights(deltaList[count], inputSignal, outputSignal[count]);
            }
        }
    }
}
