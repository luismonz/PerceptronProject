using PerceptronWorkout.DTOs.SimplePerceptronOperations;
using PerceptronWorkout.Gateways;
using PerceptronWorkout.UseCases.SimplestPerceptron;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronWorkout.Controllers
{
    public class SimplePerceptronController
    {

        public BinaryStepFunctionAlgorithm learningAlgorithm;
        private UnitOfWork _unitOfWork = UnitOfWork.GetInstance();
        readonly IDictionary<string, GateDataDTO> supportedGates;

        public SimplePerceptronController()
        {
            learningAlgorithm = new BinaryStepFunctionAlgorithm();
            supportedGates = new Dictionary<string, GateDataDTO>();
            AddSupportedGates();
        }

        public void LearnGate(SimplePerceptronConfiguration config)
        {

            GateDataDTO gateData = supportedGates[config.logicalGate];

            SimplePerceptronLearnAlgorithmDTO algorithmDTO = new SimplePerceptronLearnAlgorithmDTO()
            {
                expectedOutput = gateData.expectedOutput,
                input = gateData.input,
                learningRate = config.learningRate,
                weights_threshold = config.weights_threshold,
                maxIterations = config.MaxIterations
            };

            learningAlgorithm.Learn(algorithmDTO);
        }

        private void AddSupportedGates()
        {
            supportedGates.Add("OR", GetORData());
            supportedGates.Add("AND", GetANDData());
        }

        private GateDataDTO GetORData()
        {
            return _unitOfWork.gate_Or_Repository.gateData();
        }

        private GateDataDTO GetANDData()
        {
            return _unitOfWork.gate_And_Repository.gateData();
        }

    }
}
