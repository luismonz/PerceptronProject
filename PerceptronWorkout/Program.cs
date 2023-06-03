using PerceptronWorkout.Controllers;
using PerceptronWorkout.DTOs.SimplePerceptronOperations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace test
{

    class Program
    {
        static void Main(string[] args)
        {
            double[] weights_threshold = { 1.2, -1.2, -0.4 };

            SimplePerceptronController simplePerceptronController = new SimplePerceptronController();

            SimplePerceptronConfiguration configuration = new SimplePerceptronConfiguration()
            {
                learningRate = 0.5,
                logicalGate = "OR",
                weights_threshold = weights_threshold
            };

            simplePerceptronController.LearnGate(configuration);
        }


    }

}