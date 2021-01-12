using ProxyPattern.VirtualProxy;
using System.Collections.Generic;

namespace ProxyPattern
{
    public class ExpensiveToFullyLoad : BaseClassWithHistory
    {
        protected ExpensiveToFullyLoad()
        {
            History.Add("Constructor called.");
        }
        public static ExpensiveToFullyLoad Create()
        {
            return new VirtualExpensiveToFullyLoad();
        }

        public virtual IEnumerable<ExpensiveEntity> HomeEntities { get; protected set; }
        public virtual IEnumerable<ExpensiveEntity> AwayEntities { get; protected set; }
    }
}
