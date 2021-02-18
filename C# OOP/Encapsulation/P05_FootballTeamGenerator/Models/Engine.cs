using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_FootballTeamGenerator.Models
{
    public class Engine
    {
        public void Run()
        {
            List<Team> teams = new List<Team>();

            while (true)
            {
                string[] inputLine = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                if (inputLine[0] == "END")
                {
                    break;
                }

                string teamName = inputLine[1];

                try
                {
                    switch (inputLine[0])
                    {
                        case "Team":
                            teams.Add(new Team(teamName));
                            break;
                        case "Add":
                            string playerName = inputLine[2];
                            int endurance = int.Parse(inputLine[3]);
                            int sprint = int.Parse(inputLine[4]);
                            int dribble = int.Parse(inputLine[5]);
                            int passing = int.Parse(inputLine[6]);
                            int shooting = int.Parse(inputLine[7]);

                            if (teams.Any(t => t.Name == teamName) == false)
                            {
                                throw new InvalidOperationException($"Team {teamName} does not exist.");
                            }
                            else
                            {
                                Team teamToAddPlayer = teams.First(t => t.Name == teamName);
                                teamToAddPlayer.AddPlayer(new Player(playerName, endurance, sprint, dribble, passing, shooting));
                            }
                            break;
                        case "Remove":
                            if (teams.Any(t => t.Name == teamName) == false)
                            {
                                throw new InvalidOperationException($"Team {teamName} does not exist.");
                            }
                            else
                            {
                                string playerNameToRemove = inputLine[2];
                                Team teamToRemovePlayer = teams.First(t => t.Name == teamName);
                                teamToRemovePlayer.RemovePlayer(playerNameToRemove);
                            }
                            break;
                        case "Rating":
                            if (teams.Any(t => t.Name == teamName) == false)
                            {
                                throw new InvalidOperationException($"Team {teamName} does not exist.");
                            }
                            else
                            {
                                Console.WriteLine($"{teamName} - {teams.First(t => t.Name == teamName).ShowRating()}");
                            }
                            break;
                        default:
                            break;
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
