using System;

namespace Visitor_Pattern
{
    public class SalesVisitor : IVisitor
    {
        private int _bookCount;
        private int _vinylCount;

        public void Print()
        {
            Console.WriteLine($"Book sold: {_bookCount}");
            Console.WriteLine($"Vinyl sold: {_vinylCount}");
            Console.WriteLine($"Store sold : {_bookCount + _vinylCount} units today!");
        }

        public void VisitBook(Book book)
        {
            _bookCount++;
        }

        public void VisitVinyl(Vinyl vinyl)
        {
            _vinylCount++;
        }
    }
}
