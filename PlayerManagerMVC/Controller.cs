using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManagerMVC
{
    public class Controller
    {
        /// The list of all players
        private readonly  PlayersList playerList;

        // Comparer for comparing player by name (alphabetical order)
        private readonly IComparer<Player> compareByName;

        // Comparer for comparing player by name (reverse alphabetical order)
        private readonly IComparer<Player> compareByNameReverse;

        private readonly IView view;
        public Controller(IView view,
        PlayersList playerList,
        IComparer<Player> compareByName,
        IComparer<Player> compareByNameReverse)
        {
            this.view = view;
            this.playerList = playerList;
            this.compareByName = compareByName;
            this.compareByNameReverse = compareByNameReverse;
        }
        public void Run(IView view)
        {
            // We keep the user's option here
            // Show menu and get user option
            string option;

            // Main program loop
            do
            {
                option =  view.MainMenu();

                // Determine the option specified by the user and act on it
                switch (option)
                {
                    case "1":
                        // Insert player
                        InsertPlayer();
                        break;
                    case "2":
                        view.ShowPlayers(playerList);
                        break;
                    case "3":
                        ListPlayersWithScoreGreaterThan();
                        break;
                    case "4":
                        SortPlayerList();
                        break;
                    case "0":
                        view.ShowGoodbye();
                        break;
                    default:
                        view.ShowErrorMessage();
                        break;
                }

                view.WaitForInput();

                // Loop keeps going until players choses to quit (option 4)
            } while (option != "0");
        }

        /// <summary>
        ///  Sort player list by the order specified by the user.
        /// </summary>
        private void SortPlayerList()
        {
            PlayerOrder playerOrder = view.AskForPlayerOrder();

            switch (playerOrder)
            {
                case PlayerOrder.ByScore:
                    playerList.Sort();
                    break;
                case PlayerOrder.ByName:
                    playerList.Sort(compareByName);
                    break;
                case PlayerOrder.ByNameReverse:
                    playerList.Sort(compareByNameReverse);
                    break;
                default:
                    view.ShowErrorMessage();
                    break;
            }
        }
        private void InsertPlayer()
        {
            Player newPlayer = view.AskForPlayerInfo();
            playerList.Add(newPlayer);
        }
        

        /// <summary>
        /// Show all players with a score higher than a user-specified value.
        /// </summary>
        private void ListPlayersWithScoreGreaterThan()
        {
            // Enumerable of players with score higher than the minimum score
            IEnumerable<Player> playersWithScoreGreaterThan;
            // Minimum score user should have in order to be shown
            int minScore = view.AskForMinScore();

            // Get players with score higher than the user-specified value
            playersWithScoreGreaterThan =
                playerList.GetPlayersWithScoreGreaterThan(minScore);

            // List all players with score higher than the user-specified value
            view.ShowPlayers(playersWithScoreGreaterThan);
        }
    }
}