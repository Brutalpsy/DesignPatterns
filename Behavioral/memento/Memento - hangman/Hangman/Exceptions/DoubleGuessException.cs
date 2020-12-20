using System;

namespace HangmanClassLibrary
{
    public class DoubleGuessException : Exception
    {
        public DoubleGuessException(string message="") : base(message)
        {
        }
    }
}
