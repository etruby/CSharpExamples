using System;

namespace SingletonExample
{
    /// <summary>
    /// This lesson is intended to show an example of the singleton pattern, and 
    /// how it creates a single instance of an object that is globally accessible.
    /// 
    /// Give it a run, see how the data changes, then set a breakpoint, run it
    /// with debugging (F5) and step through the code (F11) to get a handle on
    /// what's happening here.
    /// 
    /// This example is a work in progress and improvements are always welcome.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // This will not compile, as SingletonStatic has no public constructor.
            // SingletonStatic singletonOne = new SingletonStatic();

            Console.Write("Creating local copies...");
            SingletonStatic singletonOne = SingletonStatic.Instance;
            SingletonStatic singletonTwo = SingletonStatic.Instance;
            Console.WriteLine("Done\n");

            Console.WriteLine("Here's a sample.");
            Console.WriteLine("singletonOne and singletonTwo are local copies of SingletoneStatic.Instance.");
            Console.WriteLine("We'll set singletonOne and then show how all three instances have changed.");
            Console.WriteLine("Running code singletonOne._data[0] = \"Thing\";");
            
            singletonOne._data[0] = "Thing";
            
            // this shows the contents of singletonOne, singletonTwo, and SingletonStatic.Instance
            ShowResults(singletonOne, singletonTwo);

            // Now we'll make it interactive. We'll let you pick a single instance to set, then show how it affects all instances...
            DoInteractiveTest(singletonOne, singletonTwo);
        }

        private static void DoInteractiveTest(SingletonStatic singletonOne, SingletonStatic singletonTwo)
        {
            Console.WriteLine("Now we'll make it interactive. We'll let you pick a single instance to set, ");
            Console.WriteLine("then show how it affects all instances...");
            Console.WriteLine("First you'll choose which instance to change.");
            Console.WriteLine("1 = singletonOne");
            Console.WriteLine("2 = singletonTwo");
            Console.WriteLine("3 = SingletonStatic.Instance");
            Console.WriteLine("R = Show Reference Equality");
            Console.WriteLine("Escape = Exit");

            // Variables to get keyboard input.
            ConsoleKeyInfo inputKey = new ConsoleKeyInfo();
            String returnMessage = string.Empty;


            // Continue processing input until the escape key has been pressed.
            while (inputKey.Key != ConsoleKey.Escape)
            {
                Console.Write("\nChoose an instance (1,2,3): ");

                // Read in the input from the keyboard
                inputKey = Console.ReadKey();

                Console.WriteLine();

                // Check which key has been pressed.
                switch (inputKey.Key)
                {
                    // If escape was pressed, do nothing and go back to the top of the loop.
                    case ConsoleKey.Escape:
                        continue;

                    // If R was pressed, show that all of our variables refer to the same object instance and return to choices.
                    case ConsoleKey.R:
                        ShowReferenceEquality(singletonOne, singletonTwo);
                        continue;

                    // If 1 is pressed, set data for singletonOne
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.WriteLine("singletonOne it is.");
                            
                        // Set singletonOne's message
                        returnMessage = SetMessage(singletonOne);

                        // If we didn't recieve a returnMessage, user pressed escape on the previous step. Reset to instance choice.
                        if (string.IsNullOrWhiteSpace(returnMessage)) continue;

                        // else, display what was set...
                        Console.WriteLine("\nSetting singletonOne{0}...", returnMessage);
                        break;

                    // If 2 is pressed, set data for singletonTwo
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.WriteLine("singletonTwo it is.");
                            
                        // Set singletonTwo's message
                        returnMessage = SetMessage(singletonTwo);

                        // If we didn't recieve a returnMessage, user pressed escape on the previous step. Reset to instance choice.
                        if (string.IsNullOrWhiteSpace(returnMessage)) continue;

                        // else, display what was set...
                        Console.WriteLine("\nSetting singletonTwo{0}...", returnMessage);
                        break;

                    // If 3 is pressed, set data for SingletonStatic.Instance
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.WriteLine("SingletonStatic.Instance it is.");

                        // Set SingletonStatic.Instance's message
                        returnMessage = SetMessage(SingletonStatic.Instance);

                        // If we didn't recieve a returnMessage, user pressed escape on the previous step. Reset to instance choice.
                        if (string.IsNullOrWhiteSpace(returnMessage)) continue;

                        // else, display what was set...
                        Console.WriteLine("\nSetting SingletonStatic.Instance{0}...", returnMessage);
                        break;

                    // If anything else was pressed, warn the user that these are the only valid options and reset.
                    default:
                        Console.WriteLine("{0} is not a valid choice. 1, 2, 3, R, or Escape, please.\n", inputKey.KeyChar);
                        continue;
                }

                // Shows the current state of all instances. Should only get here if valid options were chosen.
                ShowResults(singletonOne, singletonTwo);
            }
        }

        /// <summary>
        /// Uses keyboard input to get index and message, then sets instance._data[index] = message;
        /// </summary>
        /// <returns>a string message saying what was set, or string.empty if escape was pressed.</returns>
        private static String SetMessage(SingletonStatic instance)
        {
            Console.WriteLine("Now choose an index between 0 and 9");

            // Variables to receieve keyboard input
            ConsoleKeyInfo inputKey = new ConsoleKeyInfo();
            int index = 0;
            String message = string.Empty;

            // Continue processing input until the escape key has been pressed.
            while (inputKey.Key != ConsoleKey.Escape)
            {
                // Only do stuff if something was pressed.
                if (inputKey.Key != 0)
                {
                    // Tries to parse the pressed key into a int.
                    // If the key pressed is not a valid int, we can't do anything.
                    if (!int.TryParse(inputKey.KeyChar.ToString(), out index))
                        Console.WriteLine("\nThe index needs to be between 0 and 9.");
                    else
                    {
                        // It was a valid int...
                        Console.Write("\nAnd what would you like to put in there? ");

                        // So get the messsage...
                        message = Console.ReadLine();

                        // And set it into the instance.
                        instance._data[index] = message;

                        // Return message to display what got set to where.
                        return string.Format("._data[{0}] to {1}", index, message);
                    }
                }

                // Reads the input key from the keyboard.
                Console.Write("Choose an index: ");
                inputKey = Console.ReadKey();
            }

            // If escape was pressed, return nothing.
            return string.Empty;
        }

        /// <summary>
        /// This simply shows the contents of singletonOne, singletonTwo, and SingletonStatic.Instance
        /// SingletonStatic.Instance is not included in the paramters to show that it is global.
        /// </summary>
        private static void ShowResults(SingletonStatic singletonOne, SingletonStatic singletonTwo)
        {
            Console.WriteLine("\nOK. Here's the results:\n");
            Console.WriteLine("singletonOne: {0}", singletonOne);
            Console.WriteLine("singletonTwo: {0}", singletonTwo);
            Console.WriteLine("SingletonStatic.Instance: {0}", SingletonStatic.Instance);
            Console.WriteLine();
        }

        /// <summary>
        /// This uses the ReferenceEquals to show that singletonOne, singletonTwo, and SingletonStatic.Instance all reference the same object.
        /// SingletonStatic.Instance is not included in the paramters to show that it is global.
        /// </summary>
        private static void ShowReferenceEquality(SingletonStatic singletonOne, SingletonStatic singletonTwo)
        {
            Console.WriteLine("ReferenceEquals(singletonOne, singletonTwo): {0}", ReferenceEquals(singletonOne, singletonTwo));
            Console.WriteLine("ReferenceEquals(singletonOne, SingletonStatic.Instance): {0}", ReferenceEquals(singletonOne, SingletonStatic.Instance));
            Console.WriteLine("ReferenceEquals(singletonTwo, SingletonStatic.Instance): {0} \n", ReferenceEquals(singletonTwo, SingletonStatic.Instance));
        }
    }
}
