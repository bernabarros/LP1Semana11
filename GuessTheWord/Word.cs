using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuessTheWord
{
    public class Word
    {
        public string RandomWord { get; }
        public string Hint { get; }

        public Word(string randomword, string hint)
        {
            RandomWord = randomword;
            Hint = hint;
        }
    }
}