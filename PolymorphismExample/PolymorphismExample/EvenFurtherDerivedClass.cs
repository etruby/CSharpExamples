using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolymorphismExample
{
    class EvenFurtherDerivedClass : FurtherDerivedClass
    {
        /// <summary>
        /// Sealed methods can be replaced by derived classes using the new keyword.
        /// </summary>
        public new void DoVirtualWork()
        {
            Console.WriteLine("I am the even further derived class DoVirtualWork.");
        }

        public override void BaseVirtualWork()
        {
            Console.WriteLine("I am EvenFurtherDerivedClass and I call FurtherDerivedClass.DoVirtualWork.");
            base.DoVirtualWork();
        }
    }
}
