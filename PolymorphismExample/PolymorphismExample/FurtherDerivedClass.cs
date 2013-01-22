using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolymorphismExample
{
    class FurtherDerivedClass : DerivedClass
    {
        /// <summary>
        /// A derived class can stop virtual inheritance by 
        /// declaring an override as sealed. This requires 
        /// putting the sealed keyword before the override 
        /// keyword in the class member declaration. 
        /// </summary>
        public sealed override void DoVirtualWork()
        {
            Console.WriteLine("I am the further derived class DoVirtualWork.");
        }

        public virtual void BaseVirtualWork()
        {
            Console.WriteLine("I am FurtherDerivedClass and I call DerivedClass.DoVirtualWork.");
            base.DoVirtualWork();
        }
    }
}
