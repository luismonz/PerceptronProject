using PerceptronWorkout.DTOs.SimplePerceptronOperations;
using PerceptronWorkout.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronWorkout.Clients.ExecutionModes
{
    public class ManualModeClient
    {

        private UserInputValidator validator = new UserInputValidator();

        private double[] FullFillWeights()
        {
            double[] weights_threshold = new double[3];
            string askMessage;

            for (int i = 0; i < weights_threshold.Length; i++)
            {
                if (i < 2)
                {
                    askMessage = "Ingrese valor para w" + (i + 1) + ": ";
                    Console.Write(askMessage);
                    weights_threshold[i] = validator.ForceGetDoubleNumberLoop("VALOR INVALIDO PARA PESO w" + (i + 1), askMessage);
                    continue;
                }
                askMessage = "Ingrese valor para umbral U: ";
                Console.Write(askMessage);
                weights_threshold[i] = validator.ForceGetDoubleNumberLoop("VALOR INVALIDO PARA Umbral U", askMessage);
            }

            return weights_threshold;
        }

        public SimplePerceptronConfiguration SetConfig()
        {
            string askMessage;

            SimplePerceptronConfiguration configuration = new SimplePerceptronConfiguration();
            configuration.weights_threshold = FullFillWeights();

            askMessage = "Ingrese un valor para factor de aprendizaje: ";
            Console.Write(askMessage);
            double learningRate = validator.ForceGetDoubleNumberLoop("Factor de aprendizaje invalido!", askMessage);
            configuration.learningRate = learningRate;

            askMessage = "Ingrese la compuerta logica a utilizar (AND/OR): ";
            string logicalGate = validator.validarGate(askMessage);
            configuration.logicalGate = logicalGate;

            askMessage = "Ingrese un valor para Numero maximo de iteraciones: ";
            Console.Write(askMessage);
            int maxIterations = validator.ForceGetIntNumberLoop("Factor de aprendizaje invalido!", askMessage);
            configuration.MaxIterations = maxIterations;

            return configuration;
        }

    }
}
