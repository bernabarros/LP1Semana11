using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuessTheWord
{
    public interface IView
    {
        void AskForGuess();
        void PlayerGuess();
    }
}