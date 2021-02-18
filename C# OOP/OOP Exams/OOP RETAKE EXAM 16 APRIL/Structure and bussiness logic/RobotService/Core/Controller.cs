using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IGarage garage;
        private ICollection<IProcedure> procedures;

        public Controller()
        {
            this.garage = new Garage();
            this.procedures = new List<IProcedure>();
            this.procedures.Add(new Charge());
            this.procedures.Add(new Chip());
            this.procedures.Add(new Polish());
            this.procedures.Add(new Rest());
            this.procedures.Add(new TechCheck());
            this.procedures.Add(new Work());
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = null;

            if (robotType == "HouseholdRobot")
            {
                robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "PetRobot")
            {
                robot = new PetRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "WalkerRobot")
            {
                robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }

            if (robot == null)
            {
                throw new ArgumentException($"{robotType} type doesn't exist");
            }

            if (this.garage.Robots.ContainsKey(name))
            {
                throw new ArgumentException($"Robot {name} already exist");
            }

            this.garage.Manufacture(robot);

            return $"Robot {name} registered successfully";
        }

        public string Chip(string robotName, int procedureTime)
        {
            IProcedure procedure = (IProcedure)this.procedures.First(x => x.GetType().Name == "Chip");

            if (this.garage.Robots.ContainsKey(robotName) == false)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }

            KeyValuePair<string, IRobot> robot = this.garage.Robots.First(x => x.Key == robotName);

            IRobot robotToChip = robot.Value;

            procedure.DoService(robotToChip, procedureTime);

            return $"{robotName} had chip procedure";
        }

        public string Charge(string robotName, int procedureTime)
        {
            IProcedure procedure = (IProcedure)this.procedures.First(x => x.GetType().Name == "Charge");

            if (this.garage.Robots.ContainsKey(robotName) == false)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }

            KeyValuePair<string, IRobot> robot = this.garage.Robots.First(x => x.Key == robotName);

            IRobot robotToCharge = robot.Value;

            procedure.DoService(robotToCharge, procedureTime);

            return $"{robotName} had charge procedure";
        }


        public string Polish(string robotName, int procedureTime)
        {
            IProcedure procedure = (IProcedure)this.procedures.First(x => x.GetType().Name == "Polish");

            if (this.garage.Robots.ContainsKey(robotName) == false)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }

            KeyValuePair<string, IRobot> robot = this.garage.Robots.First(x => x.Key == robotName);

            IRobot robotToPolish = robot.Value;

            procedure.DoService(robotToPolish, procedureTime);

            return $"{robotName} had polish procedure";
        }

        public string Rest(string robotName, int procedureTime)
        {
            IProcedure procedure = (IProcedure)this.procedures.First(x => x.GetType().Name == "Rest");

            if (this.garage.Robots.ContainsKey(robotName) == false)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }

            KeyValuePair<string, IRobot> robot = this.garage.Robots.First(x => x.Key == robotName);

            IRobot robotToRest = robot.Value;

            procedure.DoService(robotToRest, procedureTime);

            return $"{robotName} had rest procedure";
        }

        public string Work(string robotName, int procedureTime)
        {
            IProcedure procedure = (IProcedure)this.procedures.First(x => x.GetType().Name == "Work");

            if (this.garage.Robots.ContainsKey(robotName) == false)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }

            KeyValuePair<string, IRobot> robot = this.garage.Robots.First(x => x.Key == robotName);

            IRobot robotToWork = robot.Value;

            procedure.DoService(robotToWork, procedureTime);

            return $"{robotName} was working for {procedureTime} hours";
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            IProcedure procedure = (IProcedure)this.procedures.First(x => x.GetType().Name == "TechCheck");

            if (this.garage.Robots.ContainsKey(robotName) == false)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }

            KeyValuePair<string, IRobot> robot = this.garage.Robots.First(x => x.Key == robotName);

            IRobot robotToTechCheck = robot.Value;

            procedure.DoService(robotToTechCheck, procedureTime);

            return $"{robotName} had tech chech procedure";
        }

        public string Sell(string robotName, string ownerName)
        {
            if (this.garage.Robots.ContainsKey(robotName) == false)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }

            KeyValuePair<string, IRobot> robot = this.garage.Robots.First(x => x.Key == robotName);

            IRobot robotToSell = robot.Value;

            this.garage.Sell(robotName, ownerName);

            if (robotToSell.IsChipped == true)
            {
                return $"{ownerName} bought robot with chip";
            }
            else
            {
                return $"{ownerName} bought robot without chip";
            }
        }

        public string History(string procedureType)
        {
            IProcedure procedure = (IProcedure)this.procedures.First(x => x.GetType().Name == procedureType);

            return procedure.History();
        }

    }
}
