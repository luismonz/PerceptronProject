using PerceptronWorkout.DTOs.SimplePerceptronOperations;
using PerceptronWorkout.UI.SimplePerceptronUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronWorkout.UseCases.SimplestPerceptron
{
    public class BinaryStepFunctionAlgorithm
    {

        private readonly SimplePerceptronPresentation presentation = new SimplePerceptronPresentation();

        public void Learn(SimplePerceptronLearnAlgorithmDTO algorithmDTO)
        {
            double[] solutionWeights;

            Console.WriteLine("\nPesos Iniciales: ");
            presentation.PrintWeights(algorithmDTO.weights_threshold);
            Console.WriteLine("\nNumero Iteraciones Maxima: " + algorithmDTO.maxIterations + "\n");

            bool foundSolution = hasSolution(algorithmDTO, out solutionWeights);


            if (foundSolution)
            {
                Console.WriteLine("\nSOLUCION");
                presentation.PrintWeights(solutionWeights);
                return;
            }

            Console.WriteLine("\nNO TIENE SOLUCION");
        }

        private bool hasSolution(SimplePerceptronLearnAlgorithmDTO algorithmDTO, out double[] responseWeight)
        {
            int iterationCounter = 0;
            int[] actualOutput;
            bool foundSolution = false;

            responseWeight = algorithmDTO.weights_threshold;

            while (algorithmDTO.maxIterations > 0)
            {
                iterationCounter++;
                Console.WriteLine("ITERATION {0}\n", iterationCounter);
                algorithmDTO.maxIterations--;

                actualOutput = calculateNewOutput(algorithmDTO.input, algorithmDTO.weights_threshold);

                if (algorithmDTO.expectedOutput.SequenceEqual(actualOutput))
                {
                    foundSolution = true;
                    break;
                }

                int[] positions = GetPositionsWhereArraysDiffer(algorithmDTO.expectedOutput, actualOutput);

                algorithmDTO.weights_threshold = getNewWeight(algorithmDTO, positions, actualOutput);

                responseWeight = algorithmDTO.weights_threshold;

                Console.WriteLine("-------------------------------------------------");
            }

            return foundSolution;
        }

        private double[] getNewWeight(SimplePerceptronLearnAlgorithmDTO algorithmDTO, int[] positions, int[] actualOutput)
        {
            UpdateWeightsDTO updateWeightsDTO = new UpdateWeightsDTO()
            {
                weights = algorithmDTO.weights_threshold,
                learningRate = algorithmDTO.learningRate,
                positions = positions,
                inputDB = algorithmDTO.input,
                actualOutput = actualOutput
            };
            algorithmDTO.weights_threshold = UpdateWeightsThreshold(updateWeightsDTO);
            return algorithmDTO.weights_threshold;
        }


        private int[] calculateNewOutput(int[,] input, double[] weights_threshold)
        {
            int[] output = new int[input.GetLength(0)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                double sum = 0;

                for (int j = 0; j < weights_threshold.Length; j++)
                {
                    
                    if(j<2)
                    {
                        Console.Write("{0:+0;-0}({1}) ", input[i,j], weights_threshold[j]);
                        sum += input[i, j] * weights_threshold[j];
                        continue;
                    }

                    Console.Write("{0}({1})", -1, weights_threshold[j]);
                    sum += -1* weights_threshold[j];
                }

                Console.Write(" = " + sum);
                Console.WriteLine("");

                int outputSum = (sum >= weights_threshold[2]) ? 1 : -1;

                output[i] = outputSum;

            }

            presentation.PrintNewOutput(output);

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


        private double[] UpdateWeightsThreshold(UpdateWeightsDTO updateWeightsDTO)
        {

            double[] newWeights = new double[updateWeightsDTO.weights.Length];

            double actualOutput = updateWeightsDTO.actualOutput[updateWeightsDTO.positions[0]] * -1;

            double commonTerm = 2 * updateWeightsDTO.learningRate * actualOutput;

            for (int i = 0; i < updateWeightsDTO.weights.Length; i++)
            {
                if (i < 2)
                {
                    newWeights[i] = updateWeightsDTO.weights[i] + updateWeightsDTO.inputDB[updateWeightsDTO.positions[0], i] * commonTerm;
                    Console.WriteLine("w{0} = {1} + 2({2})({3})({4}) = {5}", i, updateWeightsDTO.weights[i], updateWeightsDTO.learningRate, actualOutput, updateWeightsDTO.inputDB[updateWeightsDTO.positions[0], i], newWeights[i]);
                    continue;
                }
                newWeights[i] = updateWeightsDTO.weights[i] +  commonTerm * -1;
                Console.WriteLine("U = {1} + 2({2})({3})(-1) = {4}", i, updateWeightsDTO.weights[i], updateWeightsDTO.learningRate, updateWeightsDTO.actualOutput[updateWeightsDTO.positions[0]], newWeights[i]);
            }

            presentation.PrintWeights(newWeights);

            return newWeights;
        }

    }
}
