#nullable enable
namespace Singleton_Demo.v3_BetterLocking
{
    public sealed class Singleton
    {
        private static Singleton? _instance = null;
        private static readonly object padlock = new object();
        public static Singleton Instance
        {
            get
            {
                // double check locking pattern - better performance - it's not checking the lock as often
                Logger.Log("Instance called.");
                if (_instance == null)
                {
                    lock (padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Singleton();
                        }
                    }
                }
                return _instance;
            }
        }

        private Singleton()
        {
            Logger.Log("Constructor invoked.");
        }
    }
}
