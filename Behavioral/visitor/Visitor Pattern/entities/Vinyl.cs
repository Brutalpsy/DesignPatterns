﻿namespace Visitor_Pattern
{
    public class Vinyl : Item, IVisitableElement
    {
        public Vinyl(int id, double price): base(id,price)
        {

        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitVinyl(this);
        }
    }
}
