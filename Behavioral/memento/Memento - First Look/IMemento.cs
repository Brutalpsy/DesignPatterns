using System;

namespace Memento___First_Look
{
    // The Memento interface provides a way to retrieve the memento's metadata,
    // such as creation date or name. However, it doesn't expose the
    // Originator's state.
    public interface IMemento
    {
        string GetState();
        string GetName();
        DateTime GetDate();
    }
}