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
            
            MenuController menuController = new MenuController();
            menuController.MainMenu();

            Console.Read();

        }

    }
}