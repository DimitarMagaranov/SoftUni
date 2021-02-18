using ViceCity.Core.Contracts;
using System;
using ViceCity.IO.Contracts;
using ViceCity.IO;
using System.Linq;

namespace ViceCity.Core.Models
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IController controller;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                string[] commandArgs = reader.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = commandArgs[0];

                if (commandArgs[0] == "Exit")
                {
                    Environment.Exit(0);
                }

                try
                {
                    if (command == "AddPlayer")
                    {
                        string username = commandArgs[1];

                        this.writer.WriteLine(this.controller.AddPlayer(username));
                    }
                    else if (command == "AddGun")
                    {
                        string type = commandArgs[1];
                        string name = commandArgs[2];

                        this.writer.WriteLine(this.controller.AddGun(type, name));
                    }
                    else if (command == "AddGunToPlayer")
                    {
                        string playerName = commandArgs[1];

                        this.writer.WriteLine(this.controller.AddGunToPlayer(playerName));
                    }
                    else if (command == "Fight")
                    {
                        this.writer.WriteLine(this.controller.Fight());
                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
