using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronWorkout.Validators
{
    public class UserInputValidator
    {

        public int modoMainMenuValidator(IDictionary<int, Action> dict)
        {
            string getModoErrorMessage = "Ingrese un modo valido";
            Console.Write("Modo: ");

            int modo = ForceGetIntNumberLoop(getModoErrorMessage);

            while(!dict.ContainsKey(modo))
            {
                Console.WriteLine("MODO INVALIDO!");
                Console.Write("Modo: ");
                modo = ForceGetIntNumberLoop(getModoErrorMessage);
            }

            return modo;
        }

        public int ForceGetIntNumberLoop(string errorMessage)
        {

            int number;

            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine(errorMessage);
            }

            return number;

        }

        public int ForceGetIntNumberLoop(string errorMessage, string askNumberAgain_Message)
        {

            int number;

            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine(errorMessage);
                Console.Write(askNumberAgain_Message);
            }

            return number;

        }

        public double ForceGetDoubleNumberLoop(string errorMessage, string askNumberAgain_Message)
        {

            double number;

            while (!double.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine(errorMessage);
                Console.Write(askNumberAgain_Message);
            }

            return number;

        }

        public string validarSiEjecutarNuevamente()
        {
            
            Console.WriteLine("Desea realizar otro calculo? y / n");
            string response = Console.ReadLine().Trim().ToLower();

            while(!response.Equals("y") && !response.Equals("n"))
            {
                Console.WriteLine("OPCION INVALIDA! Seleccionar \"y\" o \"n\"");
                Console.WriteLine("Desea realizar otro calculo? y / n");
                response = Console.ReadLine().Trim().ToLower();
            }

            return response;
        }

        public string validarGate(string askMessage)
        {
            Console.Write(askMessage);
            string response = Console.ReadLine().Trim().ToUpper();

            while (!response.Equals("AND") && !response.Equals("OR"))
            {
                Console.WriteLine("GATE INVALIDA! Seleccionar \"OR\" o \"AND\"");
                Console.Write(askMessage);
                response = Console.ReadLine().Trim().ToUpper();
            }

            return response;
        }

    }
}
