using PerceptronWorkout.DTOs.SimplePerceptronOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronWorkout.UseCases.SimplestPerceptron
{
    public class LearningAlgorithm
    {

        public void Learn(SimplePerceptronLearnAlgorithmDTO algorithmDTO)
        {

            while (true)
            {
                int[] actualOutput = new int[algorithmDTO.input.GetLength(0)];

                actualOutput = calculateOutput(algorithmDTO.input, algorithmDTO.weights_threshold);

                if (algorithmDTO.expectedOutput.SequenceEqual(actualOutput)) break;

                int[] positions = GetPositionsWhereArraysDiffer(algorithmDTO.expectedOutput, actualOutput);

                UpdateWeightsDTO updateWeightsDTO = new UpdateWeightsDTO()
                {
                    weights = algorithmDTO.weights_threshold,
                    learningRate = algorithmDTO.learningRate,
                    positions = positions,
                    inputDB = algorithmDTO.input,
                    actualOutput = actualOutput
                };

                algorithmDTO.weights_threshold = UpdateWeights(updateWeightsDTO);
            }

            Console.Read();
        }


        private int[] calculateOutput(int[,] input, double[] weights_threshold)
        {
            int[] output = new int[input.GetLength(0)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                double sum = 0;
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    sum += input[i, j] * weights_threshold[j];
                }

                int outputSum = (sum >= weights_threshold[2]) ? 1 : -1;

                output[i] = outputSum;

                Console.WriteLine("Resultado para input {0}: {1}", i, outputSum);
            }

            return output;
        }

        private int[] GetPositionsWhereArraysDiffer(int[] arr1, int[] arr2)
        {
            List<int> differentPositions = new List<int>();

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    differentPositions.Add(i);
                }
            }

            int[] positions = differentPositions.ToArray();
            return positions;
        }


        private double[] UpdateWeights(UpdateWeightsDTO updateWeightsDTO)
        {

            double[] newWeights = new double[updateWeightsDTO.weights.Length];

            for (int i = 0; i < updateWeightsDTO.weights.Length; i++)
            {
                if (i < 2)
                {
                    newWeights[i] = updateWeightsDTO.weights[i] + 2 * updateWeightsDTO.learningRate * updateWeightsDTO.inputDB[updateWeightsDTO.positions[0], i] * updateWeightsDTO.actualOutput[updateWeightsDTO.positions[0]] * -1;
                    continue;
                }
                newWeights[i] = updateWeightsDTO.weights[i] + 2 * updateWeightsDTO.learningRate * -1 * updateWeightsDTO.actualOutput[updateWeightsDTO.positions[0]] * -1;
            }

            newWeights.ToList().ForEach(num =>
            {
                Console.WriteLine(num);
            });

            return newWeights;
        }

    }
}
