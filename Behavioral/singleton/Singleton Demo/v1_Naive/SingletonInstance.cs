using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
[assembly: CollectionBehavior(CollectionBehavior.CollectionPerClass, DisableTestParallelization = true)]

namespace Singleton_Demo.v1_Naive
{
    public class SingletonInstance
    {
        private readonly ITestOutputHelper _output;
        public SingletonInstance(ITestOutputHelper output)
        {
            _output = output;
            SingletonTestHelpers.Reset(typeof(Singleton));
            Logger.Clear();
        }

        [Fact]
        public void ReturnsNonNullSingletonInstance()
        {
            Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<Singleton>());

            var result = Singleton.Instance;
            Assert.NotNull(result);
            Assert.IsType<Singleton>(result);

            Logger.Output().ToList().ForEach(o => _output.WriteLine(o));
        }

        [Fact]
        public void OnlyCallsConstructorOnceGivenThreeInstanceCalls()
        {
            Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<Singleton>());

            var one = Singleton.Instance;
            var two = Singleton.Instance;
            var three = Singleton.Instance;

            var log = Logger.Output();
            Assert.Equal(1, log.Count(x => x.Contains("Constructor")));
            Assert.Equal(3, log.Count(x => x.Contains("Instance")));
            Logger.Output().ToList().ForEach(x => _output.WriteLine(x));

        }

        [Fact]
        public void CallsConstrucotMultipleTImesGivenThreeParallelInstanceCalls()
        {
            Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<Singleton>());
            // configure logger to slow donw the creation long enough to cause problems
            Logger.DelayMilliseconds = 50;

            var strings = new List<string>() { "1", "2", "3" };
            var instances = new List<Singleton>();
            var options = new ParallelOptions() { MaxDegreeOfParallelism = 3 };

            Parallel.ForEach(strings, options, instance =>
            {
                instances.Add(Singleton.Instance);
            });

            var log = Logger.Output();

            try
            {
                Assert.True(log.Count(l => l.Contains("Constructor")) > 1);
                Assert.Equal(3, log.Count(l => l.Contains("Instance")));
            }
            finally
            {
                Logger.Output().ToList().ForEach(o => _output.WriteLine(o));
            }
        }
    }
}
