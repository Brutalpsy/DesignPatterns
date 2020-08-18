using System;
using System.Collections.Generic;
using System.Text;

#nullable enable
namespace Singleton_Demo.v2_locking
{
    public sealed class Singleton
    {
        private static Singleton? _instance = null;
        private static readonly object padlock = new object();

        public static Singleton Instance
        {
            get
            {
                Logger.Log("Instance called.");
                lock (padlock)
                {
                    return _instance ??= new Singleton();
                }
            }
        }

        private Singleton()
        {
            Logger.Log("Constructor invoked."); 
        }
    }
}
