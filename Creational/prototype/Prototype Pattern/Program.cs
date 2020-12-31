using System;
using static Prototype_Pattern.FoodOrder;

namespace Prototype_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Original order: ");

            var savedOrder = new FoodOrder(
                customerName: "Danijel",
                isDelivery: true,
                orderContents: new string[] { "Pizza", "Jagger" },
                orderInfo: new OrderInfo(21));

            savedOrder.Debug();

            Console.WriteLine("Cloned order:");
            var clonedOrder = savedOrder.DeepCopy();
            clonedOrder.Debug();

            Console.WriteLine("Order changes");
            Console.WriteLine("--------------------------------------------------");
            savedOrder.CustomerName = "Nemanja";
            savedOrder.OrderInfo.Id = 555;
            Console.WriteLine("Original:");
            savedOrder.Debug();
            Console.WriteLine("Cloned:");

            clonedOrder.Debug();
            Console.WriteLine("--------------------------------------------------");
            */

            var manager = new PrototypeManager();
            manager["12/31/2020"] = new FoodOrder(
                customerName: "Milica",
                isDelivery: true,
                orderContents: new string[] { "Chicken Parm", "Lemonade" },
                orderInfo: new OrderInfo(71)); 


            Console.WriteLine("Manager clone");
            var managerOrder = (FoodOrder)manager["12/31/2020"].DeepCopy();
            managerOrder.Debug();

        }
    }
}
