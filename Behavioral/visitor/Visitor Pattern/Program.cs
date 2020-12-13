using System;
using System.Collections.Generic;
using Visitor_Pattern;

var items = new List<IVisitableElement>()
{
    new Book(12345,11.99),
    new Book(12321,22.22),
    new Book(6744,17.12),
    new Vinyl(4333434,8.79)
};

#region Without ObjectStructure layer
//var discountVisitor = new DiscountVisitor();

//items.ForEach(item => item.Accept(discountVisitor));
//discountVisitor.Print();

//var salesVisitor = new SalesVisitor();
//items.ForEach(item => item.Accept(salesVisitor));
//salesVisitor.Print();
#endregion

var cart = new ObjectStructure(items);

var discountVisitor = new DiscountVisitor();
var salesVisitor = new SalesVisitor();

cart.ApplyVisitor(discountVisitor);
cart.ApplyVisitor(salesVisitor);

// update the cart and get a new total savings
cart.RemoveItem(items[3]);
cart.ApplyVisitor(discountVisitor);

Console.ReadLine();