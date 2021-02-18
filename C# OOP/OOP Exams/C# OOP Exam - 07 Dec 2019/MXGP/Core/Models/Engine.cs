using MXGP.Core.Contracts;
using MXGP.IO;
using MXGP.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Core.Models
{
    public class Engine : IEngine
    {
        private IChampionshipController championshipController;
        private IReader consoleReader;
        private IWriter consoleWriter;

        public Engine()
        {
            this.championshipController = new ChampionshipController();
            this.consoleReader = new ConsoleReader();
            this.consoleWriter = new ConsoleWriter();
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string[] inputArgs = consoleReader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string command = inputArgs[0];

                    if (command == "End")
                    {
                        break;
                    }
                    else if (command == "CreateRider")
                    {
                        string name = inputArgs[1];

                        consoleWriter.WriteLine(this.championshipController.CreateRider(name));
                    }
                    else if (command == "CreateMotorcycle")
                    {
                        string type = inputArgs[1];
                        string model = inputArgs[2];
                        int horsePower = int.Parse(inputArgs[3]);

                        consoleWriter.WriteLine(this.championshipController.CreateMotorcycle(type, model, horsePower));
                    }
                    else if (command == "AddMotorcycleToRider")
                    {
                        string riderName = inputArgs[1];
                        string motorcycleModel = inputArgs[2];

                        consoleWriter.WriteLine(this.championshipController.AddMotorcycleToRider(riderName, motorcycleModel));
                    }
                    else if (command == "AddRiderToRace")
                    {
                        string raceName = inputArgs[1];
                        string riderName = inputArgs[2];

                        consoleWriter.WriteLine(this.championshipController.AddRiderToRace(raceName, riderName));
                    }
                    else if (command == "CreateRace")
                    {
                        string name = inputArgs[1];
                        int laps = int.Parse(inputArgs[2]);

                        consoleWriter.WriteLine(this.championshipController.CreateRace(name, laps));
                    }
                    else if (command == "StartRace")
                    {
                        string name = inputArgs[1];

                        consoleWriter.WriteLine(this.championshipController.StartRace(name));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
