using System;
using System.Collections.Generic;
using Visitor___First_Look;


var components = new List<IComponent>
{
    new ComponentA(),
    new ComponentB()
};

Console.WriteLine("The client code works with all visitors via the base Visitor interface:");
var visitor1 = new ConcreateVisitor1();
Client.ClientCode(components, visitor1);

Console.WriteLine("It allows the same client code to work with different types of visitors:");
var visitor2 = new ConcreateVisitor2();
Client.ClientCode(components, visitor2);

Console.ReadLine();




public class Client
{
    public static void ClientCode (List<Visitor___First_Look.IComponent> components, IVisitor visitor)
     => components.ForEach(c => c.Accept(visitor));
} 