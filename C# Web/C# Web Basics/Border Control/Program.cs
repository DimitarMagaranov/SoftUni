using P05_BorderControl.Interfaces;
using P05_BorderControl.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_BorderControl
{
	public class Program
    {
        static void Main()
        {
			List<IIdentifiable> list = new List<IIdentifiable>();

			while (true)
			{
				string inputLine = Console.ReadLine();
				if (inputLine == "End")
				{
					break;
				}

				string[] inputArgs = inputLine.Split();

				if (inputArgs.Length == 3)
				{
					string name = inputArgs[0];
					int age = int.Parse(inputArgs[1]);
					string id = inputArgs[2];

					Citizen citizen = new Citizen(name, age, id);

					list.Add(citizen);
				}
				else if (inputArgs.Length == 2)
				{
					string model = inputArgs[0];
					string id = inputArgs[1];

					Robot robot = new Robot(model, id);

					list.Add(robot);
				}
			}

			string searchingId = Console.ReadLine();

			foreach (var participant in list.Where(x => x.Id.EndsWith(searchingId)))
			{
				Console.WriteLine(participant.Id);
			}
        }
    }
}
