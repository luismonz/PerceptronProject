using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronWorkout.DTOs.SimplePerceptronOperations
{
    public class SimplePerceptronLearnAlgorithmDTO
    {

        public int[,] input { get; set; }
        public int[] expectedOutput { get; set; }
        public double[] weights_threshold { get; set; }
        public double learningRate { get; set; }

    }
}
