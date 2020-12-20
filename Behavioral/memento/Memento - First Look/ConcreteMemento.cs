using System;

namespace Memento___First_Look
{
    // The Concrete Memento contains the infrastructure for storing the
    // Originator's state.
    public class ConcreteMemento : IMemento
    {
        private readonly string _state;

        private readonly DateTime _date;

        public ConcreteMemento(string state)
        {
            _state = state;
            _date = DateTime.UtcNow;
        }
        // The Originator uses this method when restoring its state.
        public string GetState() => _state;

        // The rest of the methods are used by the Caretaker to display
        // metadata.
        public DateTime GetDate() => _date;

        public string GetName() => $"{_date} / {_state.Substring(0, 9)}";
    }
}