using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronWorkout.UI.SimplePerceptronUI
{
    public class SimplePerceptronPresentation
    {

        public void PrintWeights(double[] newWeights)
        {
            Console.WriteLine("\n|---------------------|");
            Console.WriteLine("|  VAR  |  NEW VALUE  |");
            Console.WriteLine("|-------|-------------|");

            for (int i = 0; i < newWeights.Length; i++)
            {
                if (i < 2)
                {
                    Console.WriteLine("| {0,5} | {1, 11} |", "w" + Convert.ToString(i + 1), newWeights[i]);
                    continue;
                }
                Console.WriteLine("| {0,5} | {1, 11} |", "U", newWeights[i]);
            }
            Console.WriteLine("|---------------------|\n");
        }

        public void PrintNewOutput(int[] output)
        {
            Console.WriteLine("|--------|");
            Console.WriteLine("| VALUES |");
            Console.WriteLine("|--------|");

            for (int i = 0; i < output.Length; i++)
            {
                Console.WriteLine("| {0,6} |", output[i]);
            }
            Console.WriteLine("|--------|");
        }

    }
}
