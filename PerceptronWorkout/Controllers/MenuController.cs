using PerceptronWorkout.Clients.ExecutionModes;
using PerceptronWorkout.DTOs.SimplePerceptronOperations;
using PerceptronWorkout.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronWorkout.Controllers
{
    public class MenuController
    {

        private readonly IDictionary<int, Action> AllowedModes;
        private UserInputValidator validator = new UserInputValidator();

        public MenuController()
        {
            AllowedModes = new Dictionary<int, Action>();
            AllowedModes.Add(1, AutomaticMode);
            AllowedModes.Add(2, ManualMode);
        }

        public void MainMenu()
        {

            Console.WriteLine("\nBIENVENIDO!\n Ingrese el NUMERO del modo a ejecutar de la app");
            Console.WriteLine("Modo 1. Automatico (con Numeros Aleatorios y compuerta logica aleatoria)");
            Console.WriteLine("Modo 2. Manual (todos los parametros deben ser ingresados)\n\n");

            int modo = validator.modoMainMenuValidator(AllowedModes);
            AllowedModes[modo].Invoke();

            string response = validator.validarSiEjecutarNuevamente();

            if(response.Equals("y"))
            {
                MainMenu();
                return;
            }

            Console.WriteLine("ADIOS!");
        }

        public void ManualMode()
        {
            ManualModeClient manualModeClient = new ManualModeClient();
            SimplePerceptronConfiguration configuration = manualModeClient.SetConfig();

            SimplePerceptronController simplePerceptronController = new SimplePerceptronController();
            simplePerceptronController.LearnGate(configuration);

        }

        public void AutomaticMode()
        {

            Random randomNumberGenerator = new Random();

            double[] weights_threshold = new double[3];

            for (int i = 0; i < weights_threshold.Length; i++)
            {
                double randomNumber = Math.Round(randomNumberGenerator.NextDouble() * 10, 2);
                weights_threshold[i] = randomNumber;
            }

            SimplePerceptronConfiguration configuration = new SimplePerceptronConfiguration()
            {
                learningRate = Math.Round(randomNumberGenerator.NextDouble() * 10, 2),
                logicalGate = randomNumberGenerator.Next(0, 2) == 0 ? "OR" : "AND",
                weights_threshold = weights_threshold,
                MaxIterations = randomNumberGenerator.Next(0, 11)
            };

            SimplePerceptronController simplePerceptronController = new SimplePerceptronController();
            simplePerceptronController.LearnGate(configuration);
        }

        public void DeveloperTestingMode()
        {
            double[] weights_threshold = { 1.2, -1.2, -0.4 };

            SimplePerceptronConfiguration configuration = new SimplePerceptronConfiguration()
            {
                learningRate = 0.5,
                logicalGate = "OR",
                weights_threshold = weights_threshold,
                MaxIterations = 10
            };

            SimplePerceptronController simplePerceptronController = new SimplePerceptronController();
            simplePerceptronController.LearnGate(configuration);
        }

    }
}
