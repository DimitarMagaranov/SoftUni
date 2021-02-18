﻿using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private const int Capacity = 10;

        private Dictionary<string, IRobot> robots;

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots => this.robots;

        public void Manufacture(IRobot robot)
        {
            if (this.robots.Count >= Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (this.robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException($"Robot {robot.Name} already exist");
            }

            this.robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (this.robots.ContainsKey(robotName) == false)
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }

            this.robots[robotName].Owner = ownerName;
            this.robots[robotName].IsBought = true;

            this.robots.Remove(robotName);
        }
    }
}
