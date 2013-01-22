using System;


/*
 * The intention of project is to provide a working example of the OOP concept of Polymorphism. 
 * 
 * As always, this project is a work-in-progress. Comments and improvements are welcome.
 */
namespace PolymorphismExample
{
    /// <summary>
    /// Through inheritance, a class can be used as more than one type; 
    /// it can be used as its own type, any base types, or any interface 
    /// type if it implements interfaces. This is called polymorphism. 
    /// 
    /// In C#, every type is polymorphic. Types can be used as their own type 
    /// or as a Object instance, because any type automatically treats Object
    /// as a base type.
    /// 
    /// Polymorphism is important not only to the derived classes, but to the
    /// base classes as well. Anyone using the base class could, in fact, be using 
    /// an object of the derived class that has been cast to the base class type. 
    /// Designers of a base class can anticipate the aspects of their base class that
    /// are likely to change for a derived type. For example, a base class for cars 
    /// might contain behavior that is subject to change when the car in question is
    /// a minivan or a convertible. A base class can mark those class members as virtual, 
    /// allowing derived classes representing convertibles and minivans to override that behavior.
    /// 
    /// Explanation, Comments, and most Source Code taken from: http://msdn.microsoft.com/en-us/library/ms173152(v=vs.80).aspx
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            DerivedClass Derived = new DerivedClass();
            BaseClass DerivedCastToBase = (BaseClass)Derived;
            BaseClass TrueBase = new BaseClass();

            Console.WriteLine("Hiding Examples ");
            Console.WriteLine("----------------\n");

            /* When the new keyword is used, the new class members are called instead of
             * the base class members that have been replaced. Those base class members 
             * are called hidden members. Hidden class members can still be called if an 
             * instance of the derived class is cast to an instance of the base class. 
             * 
             * For example:
             */

            Console.WriteLine("First Derived.DoWork() ");
            Derived.DoWork();
            Console.WriteLine("\nThen DerivedCastToBase.DoWork() ");
            DerivedCastToBase.DoWork();
            Console.WriteLine("\nThen TrueBase.DoWork() ");
            TrueBase.DoWork();

            Console.WriteLine("\nVirtual Examples ");
            Console.WriteLine("-----------------\n");

            /* Fields cannot be virtual; only methods, properties, events and indexers
             * can be virtual. When a derived class overrides a virtual member, that 
             * member is called even when an instance of that class is being accessed 
             * as an instance of the base class. 
             * 
             * For Example:
             */

            Console.WriteLine("First Derived.DoVirtualWork() ");
            Derived.DoVirtualWork();
            Console.WriteLine("\nThen DerivedCastToBase.DoVirtualWork() ");
            DerivedCastToBase.DoVirtualWork();
            Console.WriteLine("\nThen TrueBase.DoVirtualWork() ");
            TrueBase.DoVirtualWork();


            Console.WriteLine("\nPlay around with these to get an idea how the inheritance works.");
            Console.WriteLine("-----------------------------------");
            FurtherDerivedClass furtherDerivedClass = new FurtherDerivedClass();
            EvenFurtherDerivedClass evenFurtherDerivedClass = new EvenFurtherDerivedClass();
            BaseClass furtherCastToBase = (BaseClass)furtherDerivedClass;
            BaseClass evenFurtherCastToBase = (BaseClass)evenFurtherDerivedClass;
            FurtherDerivedClass evenFurtherCastToFurther = (FurtherDerivedClass)evenFurtherDerivedClass;

            Console.WriteLine("\n furtherDerivedClass.DoVirtualWork() ");
            furtherDerivedClass.DoVirtualWork();
            Console.WriteLine("\n evenFurtherDerivedClass.DoVirtualWork() ");
            evenFurtherDerivedClass.DoVirtualWork();
            Console.WriteLine("\n furtherCastToBase.DoVirtualWork() ");
            furtherCastToBase.DoVirtualWork();
            Console.WriteLine("\n evenFurtherCastToBase.DoVirtualWork() ");
            evenFurtherCastToBase.DoVirtualWork();
            Console.WriteLine("\n Derived.DoVirtualWork() ");
            Derived.DoVirtualWork();
            Console.WriteLine("\n furtherDerivedClass.BaseVirtualWork() ");
            furtherDerivedClass.BaseVirtualWork();
            Console.WriteLine("\n evenFurtherDerivedClass.BaseVirtualWork() ");
            evenFurtherDerivedClass.BaseVirtualWork();
            Console.WriteLine("\n evenFurtherCastToFurther.BaseVirtualWork() ");
            evenFurtherCastToFurther.BaseVirtualWork();

            Console.ReadKey();
        }
    }
}
