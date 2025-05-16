using System;
using System.Collections.Generic;
using System.IO;

namespace PlayerManagerMVC2
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
            if (args[0] == null)
            {
                Console.WriteLine("No file found");
            }
            // Initialize player comparers
            IComparer<Player> compareByName = new CompareByName(true);
            IComparer<Player> compareByNameReverse = new CompareByName(false);

            // Initialize the player list with two players using collection
            // initialization syntax
            string s;
            PlayersList playerList = new PlayersList();
            List<string> lstp = new List<string>();
            string file_path = args[0];
            using StreamReader sr = new StreamReader(file_path);

            while ((s = sr.ReadLine()) != null)
            {
                lstp.Add(s);
            }
            foreach (string line in lstp)
            {
                string[] playerinfo = line.Split(",");
                playerList.Add(new Player(playerinfo[0], int.Parse(playerinfo[1])));
            }
            IView view = new UglyView();

            Controller controller = new Controller(view,playerList,
            compareByName, compareByNameReverse);

            controller.Run(view);
        }
    }
}
