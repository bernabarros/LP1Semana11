using System;
using System.Collections.Generic;
using PlayerManagerMVC;

namespace PlayerManagerMVC
{
    /// <summary>
    /// The player listing program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Program begins here.
        /// </summary>
        /// <param name="args">Not used.</param>
        private static void Main(string[] args)
        {
            // Initialize player comparers
            IComparer<Player> compareByName = new CompareByName(true);
            IComparer<Player> compareByNameReverse = new CompareByName(false);

            // Initialize the player list with two players using collection
            // initialization syntax
            PlayersList playerList = new PlayersList() {
                new Player("Best player ever", 100),
                new Player("An even better player", 500)
            };

            IView view = new UglyView();

            Controller controller = new Controller(view,playerList,
            compareByName, compareByNameReverse);

            controller.Run(view);
        }
    }
}
