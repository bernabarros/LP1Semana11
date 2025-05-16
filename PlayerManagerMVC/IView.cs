using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerManagerMVC
{
    public interface IView
    {
        string MainMenu();
        void WaitForInput();
        void ShowGoodbye();
        void ShowErrorMessage();
        Player AskForPlayerInfo();
        void ShowPlayers(IEnumerable<Player> playersToList);
        int AskForMinScore();
        PlayerOrder AskForPlayerOrder();
    }
}