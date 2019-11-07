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
    class Neuron
    {
        private const float EDUCATION_SPEED = 0.2f;

        private List<float> _weight;

        public Neuron(int weightNum, Random rnd)
        {
            _weight = new List<float>();

            for (int i = 0; i < weightNum; i++)
            {
                float num = 0;
                while (num == 0)
                {
                    num = (float)rnd.Next(-50, 50) / 100;
                }
                _weight.Add(num);
            }
        }

        /*public Neuron(Neuron neuron)
        {
            _weight = new List<float>(neuron._weight);
        }*/

        public void SetWeight(List<float> weight)
        {
            _weight = new List<float>(weight);
        }

        public float CulcSum(List<float> inputSignal)
        {
            float sum = 0;

            for (int count = 0; count < _weight.Count; count++)
            {
                sum += _weight[count] * inputSignal[count];
            }

            return sum;
        }

        public float ActivationFunc(float sum)
        {
            double x = sum;
            float actFunc = (float)(1 / (1 + Math.Exp(-x)));
            return actFunc;
        }

        public void CulcDelta(float delta, List<float> deltaNextList)
        {
            for (int count = 0; count < _weight.Count; count++)
            {
                deltaNextList[count] += delta * _weight[count];
            }
        }

        public void RecalculationWeights(float delta, List<float> x, float fA)
        {
            for (int count = 0; count < _weight.Count; count++)
            {
                float fDeriv = fA * (1 - fA);
                _weight[count] = _weight[count] + delta * fDeriv * x[count] * EDUCATION_SPEED;
            }
        }
    }
}
