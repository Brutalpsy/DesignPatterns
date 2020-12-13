using System;

namespace Visitor_Pattern
{
    public class DiscountVisitor : IVisitor
    {
        private double _savings;

        public void VisitBook(Book book)
        {
            var discount = 0.0;
            if (book.Price < 20.00)
            {
                discount = book.GetDiscount(0.10) ;
                var newPrice = Math.Round(book.Price - discount, 2);
                Console.WriteLine($"DISCOUNTED: Book #{book.Id} is now ${newPrice}");
            }
            else { 
                Console.WriteLine($"FULL PRICE: Book #{book.Id} is ${book.Price}");
            }
            _savings += discount;
        }

        public void VisitVinyl(Vinyl vinyl)
        {
            var discount = vinyl.GetDiscount(0.15);
            var newPrice = Math.Round(vinyl.Price - discount, 2);
            Console.WriteLine($"SUPER SAVINGS: Vinyl #{vinyl.Id} is now ${newPrice}");
            _savings += discount;
        }
        public void Print()
        {
            Console.WriteLine($"\n You saved a total of ${_savings} on today's order.");
            Reset();
        }

        private void Reset()
        {
            _savings = 0;
        }
    }
}
