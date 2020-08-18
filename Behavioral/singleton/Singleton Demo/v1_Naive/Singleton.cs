namespace Singleton_Demo.v1_Naive
{
#nullable enable
    public sealed class Singleton
    {
        private static Singleton? _instance;

        public static Singleton Instance
        {
            get
            {
                Logger.Log("Instance called.");
                return _instance ??= new Singleton();
            }
        }

        private Singleton()
        {
            // Cannot be created except within this class
            Logger.Log("Constructor invoked.");
        }
    }
}
