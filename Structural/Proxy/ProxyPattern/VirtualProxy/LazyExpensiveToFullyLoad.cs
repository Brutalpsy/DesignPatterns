using System;
using System.Collections.Generic;

namespace ProxyPattern.VirtualProxy
{
    public class LazyExpensiveToFullyLoad : BaseClassWithHistory
    {
        private readonly Lazy<IEnumerable<ExpensiveEntity>> _homeEntities;
        public IEnumerable<ExpensiveEntity> HomeEntities 
        { 
            get => _homeEntities.Value; 
        }

        private readonly Lazy<IEnumerable<ExpensiveEntity>> _awayEntities;
        public IEnumerable<ExpensiveEntity> AwayEntities
        {
            get => _awayEntities.Value;
        }

        public LazyExpensiveToFullyLoad()
        {
            History.Add("Constructor called.");
            _homeEntities = new Lazy<IEnumerable<ExpensiveEntity>>(() => ExpensiveDataSource.GetEntities(this));
            _awayEntities = new Lazy<IEnumerable<ExpensiveEntity>>(() => ExpensiveDataSource.GetEntities(this));

        }
    }
}
