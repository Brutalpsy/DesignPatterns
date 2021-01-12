using System.Collections.Generic;

namespace ProxyPattern

{
    public abstract class BaseClassWithHistory
    {
        public List<string> History { get; } = new List<string>();
    }
}
