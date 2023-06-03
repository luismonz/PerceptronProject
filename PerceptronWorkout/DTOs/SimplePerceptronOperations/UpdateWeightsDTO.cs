using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronWorkout.DTOs.SimplePerceptronOperations
{
    public class UpdateWeightsDTO
    {

        public double[] weights { get; set; }
        public double learningRate { get; set; }
        public int[] positions { get; set; }
        public int[,] inputDB { get; set; }
        public int[] actualOutput { get; set; }

    }
}
