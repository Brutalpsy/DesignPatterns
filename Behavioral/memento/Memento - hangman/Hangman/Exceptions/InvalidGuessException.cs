using System;

namespace HangmanClassLibrary
{
    public class InvalidGuessException: Exception
    {
        public InvalidGuessException(string message) : base(message)
        {

        }
    }
}
