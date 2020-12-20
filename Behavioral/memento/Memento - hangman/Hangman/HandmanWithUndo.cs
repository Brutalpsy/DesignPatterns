namespace HangmanClassLibrary
{
    public class HandmanWithUndo : Hangman
    {
        public HandmanWithUndo(string secretWord = "secret") : base(secretWord)
        {

        }

        //Save
        public HangmanMemento CreateSetPoint()
        {
            var guesses = PreviousGuesses.ToArray();
            return new HangmanMemento()
            {
                Guesses = guesses
            };
        }

        //Restore
        public void ResumeFrom(HangmanMemento memento)
        {
            var guesses = memento.Guesses;
            PreviousGuesses.Clear();
            PreviousGuesses.AddRange(guesses);
        }
    }
}
