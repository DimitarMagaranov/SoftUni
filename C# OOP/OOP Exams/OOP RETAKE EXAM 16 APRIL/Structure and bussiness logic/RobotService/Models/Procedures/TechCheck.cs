using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public class TechCheck : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.IsChecked == false)
            {
                robot.Energy -= 8;
                robot.IsChecked = true;
            }
            else
            {
                robot.Energy -= 8;
            }

            base.DoService(robot, procedureTime);
        }
    }
}
