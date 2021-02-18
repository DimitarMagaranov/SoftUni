using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.IsChipped == true)
            {
                throw new ArgumentException($"{robot.Name} is already chipped");
            }

            robot.Happiness -= 5;
            robot.IsChipped = true;
            base.DoService(robot, procedureTime);
        }
    }
}
