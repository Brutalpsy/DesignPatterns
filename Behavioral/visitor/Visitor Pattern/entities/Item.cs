using System;

namespace Visitor_Pattern
{
    public class Item 
    {
        public int Id;
        public double Price;
        public Item(int id, double price)
        {
            Id = id;
            Price = price;
        }

        public double GetDiscount(double percentage) => Math.Round(Price * percentage, 2);
    }
}
