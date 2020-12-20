using System;
using System.Collections.Generic;
using System.Linq;

namespace Memento___First_Look
{
    public class Caretaker
    {
        private  List<IMemento> _mementos = new List<IMemento>();
        private  Originator _originator = null;

        public Caretaker(Originator originator)
        {
            _originator = originator;
        }

        public void Backup() 
        {
            Console.WriteLine($"\nCaretaker: Saving Originator's state....");
            _mementos.Add(_originator.Save());
        }

        public void Undo()
        {
            if (!_mementos.Any()) 
            {
                return;
            }

            var memento = _mementos.Last();
            _mementos.Remove(memento);

            Console.WriteLine($"Caretaker: Restoring state to: {memento.GetName()}");

            try
            {
                _originator.Restore(memento);
            }
            catch (Exception)
            {
                Undo();
            }
        }

        public void ShowHistory() 
        {
            Console.WriteLine("Caretaker: Here's the list of mementos");
            _mementos.ForEach(memento => Console.WriteLine(memento.GetName()));
        }

    }
}
