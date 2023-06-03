using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronWorkout.DTOs.SimplePerceptronOperations
{
    public class SimplePerceptronConfiguration
    {
        public string logicalGate { get; set; }
        public double learningRate { get; set; }
        public double[] weights_threshold { get; set; }
    }
}
