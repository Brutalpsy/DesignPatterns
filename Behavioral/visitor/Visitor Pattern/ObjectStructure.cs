using System;
using System.Collections.Generic;

namespace Visitor_Pattern
{
    public class ObjectStructure
    {
        private readonly List<IVisitableElement> _cart;
        public ObjectStructure(List<IVisitableElement> items)
        {
            _cart = items;
        }

        public void RemoveItem(IVisitableElement item)
        {
            _cart.Remove(item);
        }

        public void ApplyVisitor(IVisitor visitor)
        {
            Console.WriteLine("\n----------------------- Visitor Breakdown -----------------------");
            _cart.ForEach(Item => Item.Accept(visitor));
            visitor.Print();
        }
    }
}
