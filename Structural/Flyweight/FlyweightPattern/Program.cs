using System;
using System.Collections.Generic;

namespace FlyweightPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var drinkFactory = new DrinkFactory();
            var largeEspresso = drinkFactory.GetDrink("Espresso");
            largeEspresso.Serve("Large");

            var mediumSmoothie = drinkFactory.GetDrink("BananaSmothie");
            mediumSmoothie.Serve("Medium");


            var smallEspresso = drinkFactory.GetDrink("Espresso");
            smallEspresso.Serve("small");

            //UnsharedFlyweights(drinkFactory);

            drinkFactory.ListDrinks();
        }

        private static void UnsharedFlyweights(DrinkFactory drinkFactory)
        {
            var sizes = new List<string>() { "Small", "Medium", "Large" };
            sizes.ForEach(size =>
            {
                var giveaway = drinkFactory.CreateGiveaway();
                giveaway.Serve(size);
            });
        }
    }
}
