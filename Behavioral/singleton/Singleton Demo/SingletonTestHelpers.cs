﻿using System;
using System.Reflection;

namespace Singleton_Demo
{
    public class SingletonTestHelpers
    {
        public static void Reset(Type type)
        {
            FieldInfo info = type.GetField("_instance", BindingFlags.NonPublic | BindingFlags.Static);
            info.SetValue(null, null);
        }

        public static T GetPrivateStaticInstance<T>() where T: class
        {
            Type type = typeof(T);
            FieldInfo info = type.GetField("_instance", BindingFlags.NonPublic | BindingFlags.Static);
            return info.GetValue(null) as T;
        }
    }
}
