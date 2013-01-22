using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolymorphismExample
{
    /// <summary>
    /// When a derived class inherits from a base class, it gains all the methods, 
    /// fields, properties and events of the base class. To change the data and 
    /// behavior of a base class, you have two choices: you can replace the base 
    /// member with a new derived member, or you can override a virtual base member.
    /// 
    /// Explanations and Example Code source: http://msdn.microsoft.com/en-us/library/ms173152(v=vs.80).aspx
    /// </summary>
    public class DerivedClass : BaseClass
    {
        public override void DoVirtualWork() { Console.WriteLine("I am the derived class DoVirtualWork."); }

        /* Replacing a member of a base class with a new derived member requires the new keyword. 
         * If a base class defines a method, field, or property, the new keyword is used to 
         * create a new definition of that method, field, or property on a derived class. 
         * The new keyword is placed before the return type of a class member that is being replaced. 
         */
        public new void DoWork() { Console.WriteLine("I am the derived class DoWork."); }
        public new int WorkField;
        public new int WorkProperty
        {
            get { return 0; }
        }
    }
}
