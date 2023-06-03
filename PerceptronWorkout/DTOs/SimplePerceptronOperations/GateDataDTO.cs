using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronWorkout.DTOs.SimplePerceptronOperations
{
    public class GateDataDTO
    {

        public int[,] input { get; set; }
        public int[] expectedOutput { get; set; }

    }
}
