using PerceptronWorkout.DTOs.SimplePerceptronOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronWorkout.Gateways.Context
{
    public class Gate_And_Context
    {

        private readonly int[,] input = new int[,] { { 1, 1 }, { 1, -1 }, { -1, 1 }, { -1, -1 } };
        private readonly int[] expectedOutput = { 1, -1, -1, -1 };

        private static Gate_And_Context _instance;

        private Gate_And_Context() { }

        public static Gate_And_Context GetInstance()
        {
            return _instance == null ? _instance = new Gate_And_Context() : _instance;
        }

        public GateDataDTO gateData()
        {

            return new GateDataDTO()
            {
                expectedOutput = expectedOutput,
                input = input
            };

        }

    }
}
