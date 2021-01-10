using System;
using System.Collections.Generic;

namespace FlyweightPattern
{
    // Flyweight blueprint
    public interface IDrinkFlyweight
    {
        //Intrinsic state - shared/readonly
        string Name { get; }

        //Extrinsic state
        void Serve(string size);
    }

    public class Espresso : IDrinkFlyweight
    {
        public string Name => "espresso";
        public IEnumerable<string> _ingredients;

        public Espresso()
        {
            _ingredients = new List<string>
            {
                "Coffee Beans",
                "Hot Water"
            };
        }
        public void Serve(string size)
        {
            Console.WriteLine($"- {size} {Name} with {string.Join(", ",_ingredients)} coming up!\n");
        }
    }

    public class BananaSmoothie : IDrinkFlyweight
    {
        public string Name => "Banana Smoothie";
        public IEnumerable<string> _ingredients;
        public BananaSmoothie()
        {
            _ingredients = new List<string>
            {
                "Banana",
                "Whole Milk",
                "Vanilla Extract"
            };
        }
        public void Serve(string size)
        {
            Console.WriteLine($"- {size} {Name} with {string.Join(", ", _ingredients)} coming up!\n");
        }
    }

    //Unshared concrete flyweight
    public class DrinkGiveaway : IDrinkFlyweight
    {
        // All State
        public string Name => _randomDrink.Name;
        public string Size { get; set; }

        private readonly IDrinkFlyweight _randomDrink;
        private readonly IList<IDrinkFlyweight> _eligibleDrinks = new List<IDrinkFlyweight>
        {
            new Espresso(),
            new BananaSmoothie()
        };

        public DrinkGiveaway()
        {
            var radnomIndex = new Random().Next(0, 2);
            _randomDrink = _eligibleDrinks[radnomIndex];
        }

        //Extrinsic state
        public void Serve(string size)
        {
            Size = size;
            Console.WriteLine($"Free giveaway!");
            Console.WriteLine($"- {Size} {Name} coming up!\n");
        }
    }
}
