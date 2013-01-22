using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolymorphismExample
{
    /// <summary>
    /// Example source: http://msdn.microsoft.com/en-us/library/ms173152(v=vs.80).aspx
    /// </summary>
    public class BaseClass
    {
        /* In order for an instance of a derived class to completely take over a class member
         * from a base class, the base class has to declare that member as virtual. 
         * This is accomplished by adding the virtual keyword before the return type of the member.
         * A derived class then has the option of using the override keyword, instead of new, 
         * to replace the base class implementation with its own. 
         */
        public virtual void DoVirtualWork() { Console.WriteLine("I am the base class DoVirtualWork."); }
        
        public void DoWork() { Console.WriteLine("I am the base class DoWork."); }
        public int WorkField;
        public int WorkProperty
        {
            get { return 0; }
        }
    }
}
