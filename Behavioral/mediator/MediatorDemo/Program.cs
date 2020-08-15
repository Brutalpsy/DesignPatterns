using MediatorDemo.ChatApp;
using MediatorDemo.Structural;
using System;

namespace MediatorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var teamChat = new TeamChatroom();

            var pera = new Developer("Para");
            var mita = new Developer("Mita");
            var steva = new Developer("Steva");

            var milunka = new Tester("Milunka");
            var draginja = new Tester("Draginja");

            teamChat.RegisterMembers(pera, mita, steva, milunka, draginja);
            steva.Send("Deploying at 2 pm today");
            milunka.Send("Ok, tnanks for letting us know.");
            Console.WriteLine();
            steva.SendTo<Developer>("make sure to execute your unit tests before checking in!");

        }


        private static void StructuralExample()
        {
            var mediator = new ConcreteMediator();

            var c1 = mediator.CreateColleague<Colleague1>();
            var c2 = mediator.CreateColleague<Colleague2>();


            c1.Send("Yo madafaka (from c1)");
            c2.Send("hey c1 (from c2)");
        }
    }

}
