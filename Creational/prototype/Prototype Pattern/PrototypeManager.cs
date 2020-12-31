using System.Collections.Generic;

namespace Prototype_Pattern
{
    public partial class FoodOrder
    {
        public class PrototypeManager
        {
            private readonly Dictionary<string, Prototype> _prototypeLibrary = new Dictionary<string, Prototype>();

            public Prototype this[string key]
            {
                get { return _prototypeLibrary[key]; }
                set { _prototypeLibrary.Add(key, value); }
            }
        }
    }
}
