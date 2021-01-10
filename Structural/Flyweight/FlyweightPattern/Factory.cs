using System;
using System.Collections.Generic;

namespace FlyweightPattern
{
    public class DrinkFactory
    {
        private readonly Dictionary<string, IDrinkFlyweight> _drinkCache = new Dictionary<string, IDrinkFlyweight>();
        public int ObjectsCreated = 0;

        protected IDrinkFlyweight CreateDrink(string drinkKey)
        {
            return drinkKey switch
            {
                "Espresso" => new Espresso(),
                "BananaSmothie" => new BananaSmoothie(),
                _ => throw new Exception("This is not a flyweight drink object."),
            };
        }

        public IDrinkFlyweight GetDrink(string drinkKey)
        {
            if (_drinkCache.ContainsKey(drinkKey))
            {
                Console.WriteLine("Reusing exsisting flyweight object.");
                return  _drinkCache[drinkKey];
            }

            Console.WriteLine("Creating new flyweight object.");
            var drink = CreateDrink(drinkKey);
            _drinkCache.Add(drinkKey, drink);
            ObjectsCreated++;

            return drink;
        }

        public void ListDrinks() 
        {
            Console.WriteLine($"Factory has {_drinkCache.Count} drink objects ready to use.");
            Console.WriteLine($"Number of objects created: {ObjectsCreated}");
            
            foreach( var drink in _drinkCache)
            {
                Console.WriteLine($"\t {drink.Value.Name}");
            }

        }

        public IDrinkFlyweight CreateGiveaway() => new DrinkGiveaway();
    }
}
