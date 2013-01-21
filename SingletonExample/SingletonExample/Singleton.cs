using System;

/*
 * In software engineering, the singleton pattern is a design pattern that 
 * restricts the instantiation of a class to one object. 
 * This is useful when exactly one object is needed to coordinate actions 
 * across the system. The concept is sometimes generalized to systems that 
 * operate more efficiently when only one object exists, or that restrict the 
 * instantiation to a certain number of objects. 
 * 
 * Source: http://en.wikipedia.org/wiki/Singleton_pattern
 */

namespace SingletonExample
{
    /// <summary>
    /// Sample singleton object. Code Source: http://www.dotnetperls.com/singleton-static
    /// For more examples of how to implement this pattern, see these resources (or google 'C# Singleton Examples')
    /// http://msdn.microsoft.com/en-us/library/ff650316.aspx
    /// http://csharpindepth.com/Articles/General/Singleton.aspx
    /// </summary>
    public sealed class SingletonStatic
    {
        /// <summary>
        /// This is an expensive resource.
        /// We need to only store it in one place.
        /// </summary>
        public object[] _data = new object[10];

        /// <summary>
        /// Allocate ourselves.
        /// We have a private constructor, so no one else can.
        /// </summary>
        static readonly SingletonStatic _instance = new SingletonStatic();

        /// <summary>
        /// Access SingletonStatic.Instance to get the singleton object.
        /// Then call methods on that instance.
        /// </summary>
        public static SingletonStatic Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// This is a private constructor, meaning no outsiders have access.
        /// </summary>
        private SingletonStatic()
        {
            // Initialize members here.
        }

        public override string ToString()
        {
            return string.Format("[{0}]", String.Join(",", _data));
        }
    }
}
