using System;

namespace Memento___First_Look
{
    class Program
    {
        static void Main(string[] args)
        {
            var originator = new Originator("Super duper originator");
            var caretaker = new Caretaker(originator);
            caretaker.Backup();

            originator.DoSomething();
            caretaker.Backup();

            originator.DoSomething();
            caretaker.Backup();

            caretaker.ShowHistory();

            Console.WriteLine("\n Client: Now, let's  rollback! \n");
            caretaker.Undo();

            Console.WriteLine("\n\n Client: Once more! \n");
            caretaker.Undo();

            Console.WriteLine("\n\n Client: To unitial state! \n");
            caretaker.Undo();

            Console.ReadLine();
        }
    }
}
