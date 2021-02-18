using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Core.Factories.Models;
using PlayersAndMonsters.IO;
using PlayersAndMonsters.IO.Contracts;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.BattleFields.Models;
using PlayersAndMonsters.Repositories;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();
            IPlayerRepository playerRepository = new PlayerRepository();
            ICardRepository cardRepository = new CardRepository();
            IBattleField battleField = new BattleField();
            ICardFactory cardFactory = new CardFactory();
            IPlayerFactory playerFactory = new PlayerFactory();
            IManagerController managerController = new ManagerController(cardRepository, playerRepository, battleField, cardFactory, playerFactory);


            while (true)
            {
                string[] args = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = args[0];

                if (command == "Exit")
                {
                    break;
                }

                try
                {
                    if (command == "AddPlayer")
                    {
                        string[] playerArgs = args.Skip(1).ToArray();
                        string playerType = playerArgs[0];
                        string playerName = playerArgs[1];

                        writer.WriteLine(managerController.AddPlayer(playerType, playerName));
                    }
                    else if (command == "AddCard")
                    {
                        string[] cardArgs = args.Skip(1).ToArray();
                        string cardType = cardArgs[0];
                        string cardName = cardArgs[1];

                        writer.WriteLine(managerController.AddCard(cardType, cardName));
                    }
                    else if (command == "AddPlayerCard")
                    {
                        string[] playerCardArgs = args.Skip(1).ToArray();
                        string username = playerCardArgs[0];
                        string cardName = playerCardArgs[1];

                        writer.WriteLine(managerController.AddPlayerCard(username, cardName));
                    }
                    else if (command == "Fight")
                    {
                        string[] fightArgs = args.Skip(1).ToArray();
                        string attacker = fightArgs[0];
                        string enemy = fightArgs[1];

                        writer.WriteLine(managerController.Fight(attacker, enemy));
                    }
                    else if (command == "Report")
                    {
                        writer.WriteLine(managerController.Report());
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
