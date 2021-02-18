namespace P07_MilitaryElite
{
    using P07_MilitaryElite.Models;
    using P07_MilitaryElite.Models.Privates;
    using P07_MilitaryElite.Models.Privates.SpecialisedSoldiers;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<Soldier> soldiers = new List<Soldier>();

            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == "End")
                {
                    break;
                }

                string[] soldierArgs = inputLine.Split();

                string soldierType = soldierArgs[0];
                string id = soldierArgs[1];
                string firstName = soldierArgs[2];
                string lastName = soldierArgs[3];

                if (soldierType == "Private")
                {
                    decimal salary = decimal.Parse(soldierArgs[4]);

                    Private @private = new Private(id, firstName, lastName, salary);

                    soldiers.Add(@private);
                }
                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(soldierArgs[4]);

                    Spy spy = new Spy(id, firstName, lastName, codeNumber);

                    soldiers.Add(spy);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(soldierArgs[4]);

                    List<string> ids = soldierArgs.Skip(5).ToList();

                    List<Private> privates = GetPrivates(ids, soldiers);

                    LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary, privates);

                    soldiers.Add(lieutenantGeneral);
                }
                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(soldierArgs[4]);
                    string corps = soldierArgs[5];

                    List<string> repairArgs = soldierArgs.Skip(6).ToList();

                    List<Repair> repairs = GetRepairs(repairArgs);

                    try
                    {
                        Engineer engineer = new Engineer(id, firstName, lastName, salary, corps, repairs);

                        soldiers.Add(engineer);
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(soldierArgs[4]);
                    string corps = soldierArgs[5];

                    List<string> missionArgs = soldierArgs.Skip(6).ToList();

                    List<Mission> missions = GetMissions(missionArgs);

                    try
                    {
                        Commando commando = new Commando(id, firstName, lastName, salary, corps, missions);

                        soldiers.Add(commando);
                    }
                    catch (Exception)
                    {
                    }

                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private static List<Mission> GetMissions(List<string> missionArgs)
        {
            List<Mission> missions = new List<Mission>();

            for (int i = 0; i < missionArgs.Count; i += 2)
            {
                string codeName = missionArgs[i];
                string state = missionArgs[i + 1];

                try
                {
                    Mission mission = new Mission(codeName, state);

                    missions.Add(mission);
                }
                catch (Exception)
                {
                }
            }

            return missions;
        }

        private static List<Repair> GetRepairs(List<string> repairArgs)
        {
            List<Repair> repairs = new List<Repair>();

            for (int i = 0; i < repairArgs.Count; i += 2)
            {
                string repairName = repairArgs[i];
                int hoursWorked = int.Parse(repairArgs[i + 1]);

                Repair repair = new Repair(repairName, hoursWorked);

                repairs.Add(repair);
            }

            return repairs;
        }

        private static List<Private> GetPrivates(List<string> ids, List<Soldier> soldiers)
        {
            List<Private> privates = new List<Private>();

            foreach (var id in ids)
            {
                if (soldiers.Select(x => x.Id).Contains(id))
                {
                    Private @private = (Private)soldiers.FirstOrDefault(x => x.Id == id);
                    privates.Add(@private);
                }
            }

            return privates;
        }
    }
}
