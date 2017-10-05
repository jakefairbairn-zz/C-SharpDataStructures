using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GroupDataStructures
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int user_input = 0;
            int stack_input = 0;
            int queue_input = 0;
            int dictionary_input = 0;
            Stack<string> myStack = new Stack<string>();
            Queue<string> myQueue = new Queue<string>();
            Dictionary<string, string> myDictionary = new Dictionary<string, string>();

            do
            {
                PrintMainMenu();

                try
                {
                    user_input = Int32.Parse(Console.ReadLine());
                    if (user_input < 1 || user_input > 4)
                    {
                    Console.WriteLine("\nPlease enter a valid menu option.\n");
                    }
                }
                catch
                {
                    Console.WriteLine("\nPlease enter a valid menu option.\n");
                }

                switch(user_input)
                {
                    case 1:
                        stack_input = 0;
                        do
                        {
                            PrintStackMenu();

                            //Get Stack menu user input
                            try
                            {
                                stack_input = Int32.Parse(Console.ReadLine());
                                if(stack_input < 1 || stack_input > 7)
                                {
                                    Console.WriteLine("Please enter a valid menu option.");
                                }
                                else
                                {
                                    switch (stack_input)
                                    {
                                        case 1:
                                            //Prompt user for input
                                            Console.WriteLine("\nEnter a string to add to the top of the stack:");

                                            //Get user input
                                            string add_to_stack = Console.ReadLine();

                                            //Push input to myStack
                                            myStack.Push(add_to_stack);
                                            break;
                                        case 2:
                                            //Clear myStack of all entries
                                            myStack.Clear();

                                            //Generate 2000 entries in the format of "New Entry i"
                                            for (int i = 1; i <= 2000; i++)
                                            {
                                                //Push New Entry onto myStack
                                                myStack.Push("New Entry " + i);
                                            }
                                            break;
                                        case 3:
                                            if(myStack.Count == 0)
                                            {
                                                Console.WriteLine("The Stack has no entries to display.");
                                            }
                                            else
                                            {
                                                //Loop through every entry in Stack
                                                Console.WriteLine("\nPrinting Stack entries:\n");
                                                foreach (Object entry in myStack)
                                                {
                                                    //Print entry
                                                    Console.WriteLine(entry);
                                                }
                                            }
                                            break;
                                        case 4:
                                            Console.WriteLine("\nEnter a string to delete from the stack:");
                                            string delete_input = Console.ReadLine();
                                            if (myStack.Contains(delete_input))
                                            {
                                                //Temporary stack to hold entries above the entry to delete
                                                Stack<string> tempStack = new Stack<string>();

                                                //Move values from myStack to tempStack
                                                while (myStack.Peek() != delete_input)
                                                {
                                                    tempStack.Push(myStack.Pop());
                                                }

                                                //Delete the desired entry
                                                myStack.Pop();

                                                //Re-add the strings from tempStack to myStack
                                                foreach (string obj in tempStack)
                                                {
                                                    myStack.Push(obj);
                                                }
                                            }
                                            else
                                            {
                                                //Print if search entry not found in myStack
                                                Console.WriteLine("\n" + delete_input + " does not exist in the Stack.\n");
                                            }
                                            break;
                                        case 5:
                                            if (myStack.Count == 0)
                                            {
                                                Console.WriteLine("\nThe Stack is already empty./n");
                                            }
                                            else
                                            {
                                                myStack.Clear();
                                                Console.WriteLine("\nThe Stack has been cleared.\n");
                                            }
                                            break;
                                        case 6:
                                            //Get input for search from user
                                            Console.WriteLine("\nEnter a string to search for in the Stack:");
                                            string search_input = Console.ReadLine();

                                            //Creat Stopwatch object
                                            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

                                            //Start Stopwatch
                                            sw.Start();
                                            //Search for user input
                                            bool input_found = myStack.Contains(search_input);
                                            //Stop Stopwatch
                                            sw.Stop();
                                            //Get time elapsed during search
                                            TimeSpan ts = sw.Elapsed;

                                            if (input_found)
                                            {
                                                //Print successful search results
                                                Console.WriteLine("\n" + search_input + " was found in the Stack.");
                                                //Format elapsedTime to 00:00:00:000000
                                                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                                    ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
                                                //Print runtime
                                                Console.WriteLine("RunTime: " + ts);
                                            }
                                            else
                                            {
                                                //Print that search was unsuccessful
                                                Console.WriteLine("\n" + search_input + " was not found in the Stack.");
                                            }

                                            break;
                                    }
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Please enter a valid menu option.");
                            }
                        } while (stack_input != 7);
                        break;
                    case 2:
                        queue_input = 0;
                        do
                        {
                            PrintQueueMenu();

                            //Get Queue menu user input
                            try
                            {
                                queue_input = Int32.Parse(Console.ReadLine());

                                if (queue_input < 1 || queue_input > 7)
                                {
                                    Console.WriteLine("Please enter a valid menu option.");
                                }

                                switch(queue_input)
                                {
                                    case 1:
                                        //Prompt user for input
                                        Console.WriteLine("\nEnter a string to add to the top of the Queue:");

                                        //Get user input
                                        string add_to_queue = Console.ReadLine();

                                        //Push input to myQueue
                                        myQueue.Enqueue(add_to_queue);
                                        break;
                                    case 2:
                                        //Clear myQueue of all entries
                                        myQueue.Clear();

                                        //Generate 2000 entries in the format of "New Entry i"
                                        for (int i = 1; i <= 2000; i++)
                                        {
                                            //Push New Entry onto myQueue
                                            myQueue.Enqueue("New Entry " + i);

                                            Console.WriteLine("\nAdded 2,000 entries to the Queue.\n");
                                        }
                                        break;
                                    case 3:
                                        if(myQueue.Count > 0)
                                        {
                                            //Loop through every entry in Queue
                                            Console.WriteLine("\nPrinting Queue entries:\n");
                                            foreach (Object entry in myQueue)
                                            {
                                                //Print entry
                                                Console.WriteLine(entry);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nThere are no entries in the Queue.");
                                        }
                                        break;
                                    case 4:
                                        Console.WriteLine("\nEnter the entry you'd like to delete:");
                                        string queue_delete = Console.ReadLine();
                                        if(myQueue.Contains(queue_delete))
                                        {
                                            myQueue = new Queue<string>(myQueue.Where(DictionaryEntry => DictionaryEntry != queue_delete));
                                            Console.WriteLine("\n" + queue_delete + " has been deleted from the Queue");
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n" + queue_delete + " does not exist in the Queue.");
                                        }
                                        break;
                                    case 5:
                                        if(myQueue.Count == 0)
                                        {
                                            Console.WriteLine("\nThe Queue is already empty.");                                      
                                        }
                                        else
                                        {
                                            myQueue.Clear();
                                            Console.WriteLine("\nThe Queue has been cleared.");
                                        }
                                        break;
                                    case 6:
                                        //Get input for search from user
                                        Console.WriteLine("\nEnter a string to search for in the Queue:");
                                        string search_input = Console.ReadLine();

                                        //Creat Stopwatch object
                                        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

                                        //Start Stopwatch
                                        sw.Start();
                                        //Search for user input
                                        bool input_found = myQueue.Contains(search_input);
                                        //Stop Stopwatch
                                        sw.Stop();
                                        //Get time elapsed during search
                                        TimeSpan ts = sw.Elapsed;

                                        if (input_found)
                                        {
                                            //Print successful search results
                                            Console.WriteLine("\n" + search_input + " was found in the Queue.");
                                        }
                                        else
                                        {
                                            //Print that search was unsuccessful
                                            Console.WriteLine("\n" + search_input + " was not found in the Queue.");
                                        }

                                        //Format elapsedTime to 00:00:00:000000
                                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                            ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
                                        //Print runtime
                                        Console.WriteLine("RunTime: " + ts);
                                        break;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Please enter a valid menu option.");
                            }
                        } while (queue_input != 7);
                        break;
                    case 3:
                        dictionary_input = 0;
                        do
                        {
                            PrintDictionaryMenu();

                            //Get Dictionary menu user input
                            try
                            {
                                dictionary_input = Int32.Parse(Console.ReadLine());

                                if (dictionary_input < 1 || dictionary_input > 7)
                                {
                                    Console.WriteLine("\nPlease enter a valid menu option.\n");
                                }

                                switch(dictionary_input)
                                {
                                    case 1:
                                        //Prompt user for input
                                        Console.WriteLine("\nEnter a string value to add to the Dictionary:");

                                        //Get user input
                                        string add_to_dictionary = Console.ReadLine();

                                        int new_key = myDictionary.Count;
                                        bool duplicate = true;
                                        while (duplicate == true)
                                        {
                                            if (myDictionary.ContainsKey(Convert.ToString(new_key)))
                                            {
                                                new_key++;
                                            }
                                            else
                                            {
                                                duplicate = false;
                                            }
                                        }

                                        //Add user entry to dictionary
                                        myDictionary.Add(Convert.ToString(new_key), add_to_dictionary);

                                        break;
                                    case 2:
                                        //Clear myQueue of all entries
                                        myDictionary.Clear();

                                        //Generate 2000 entries in the format of "New Entry i"
                                        for (int i = 1; i <= 2000; i++)
                                        {
                                            //Push New Entry onto myQueue
                                            myDictionary.Add("New Entry " + i, Convert.ToString(i));
                                        }
                                        break;
                                    case 3:
                                        Console.WriteLine("\nPrinting Dictionary entries:\n");
                                        foreach (KeyValuePair<string, string> entry in myDictionary)
                                        {
                                            Console.WriteLine(entry.Key + " : " + entry.Value);
                                        }
                                        break;
                                    case 4:
                                        //Print the Dictionary for the User
                                        Console.WriteLine("\nPrinting Dictionary entries:\n");
                                        foreach (KeyValuePair<string, string> entry in myDictionary)
                                        {
                                            Console.WriteLine(entry.Key + " : " + entry.Value);
                                        }
                                        Console.WriteLine("\nEnter the key you would like to delete from the Dictionary:");
                                        string delete_key = Console.ReadLine();

                                        if(myDictionary.ContainsKey(delete_key))
                                        {
                                            myDictionary.Remove(delete_key);
                                            Console.WriteLine("\n" + delete_key + " was removed from the Dictionary.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n" + delete_key + " does not exist in the Dictionary.\n");
                                        }
                                        break;
                                    case 5:
                                        if(myDictionary.Count > 0)
                                        {
                                            myDictionary.Clear();
                                            Console.WriteLine("\nThe Dictionary has been cleared.\n");
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nThe Dictionary is alread empty.\n");
                                        }
                                        break;
                                    case 6:
                                        if (myDictionary.Count > 0)
                                        {
                                            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                                            int option = 0;

                                            Console.Write("\nWhat would you like to search by?\n1. Key\n2. Value\nEnter option number: ");

                                            bool valid_option = false;
                                            while (!valid_option)
                                            {
                                                try
                                                {
                                                    option = Int32.Parse(Console.ReadLine());
                                                    if (option == 1 || option == 2)
                                                    {
                                                        valid_option = true;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("\nPlease select a valid menu option.");
                                                    }
                                                }
                                                catch
                                                {
                                                    Console.WriteLine("\nPlease select a valid menu option.");
                                                }
                                            }

                                            if (option == 1)
                                            {
                                                Console.WriteLine("\nEnter the entry's Key:");
                                                string key = Console.ReadLine();
                                                sw.Start();
                                                if (myDictionary.ContainsKey(Convert.ToString(key)))
                                                {
                                                    sw.Stop();
                                                    Console.WriteLine("\nEntry found. RunTime: " + sw.Elapsed + "\n");
                                                }
                                                else
                                                {
                                                    sw.Stop();
                                                    Console.WriteLine("\nEntry not found. RunTime: " + sw.Elapsed + "\n");
                                                }
                                            }
                                            else if (option == 2)
                                            {
                                                Console.WriteLine("\nWhat is the entry's Value?");
                                                string value = Console.ReadLine();
                                                sw.Start();
                                                var key = myDictionary.FirstOrDefault(x => x.Value == "value").Key;
                                                if (myDictionary.ContainsValue(value))
                                                {
                                                    sw.Stop();
                                                    Console.WriteLine("\nValue found. RunTime:" + sw.Elapsed + "\n");
                                                }
                                                else
                                                {
                                                    sw.Stop();
                                                    Console.WriteLine("\nEntry not found.  RunTime:" + sw.Elapsed + "\n");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.Write("\nThere are currently no entries in the Dictionary.\n");
                                        }
                                        break;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Please enter a valid menu option.");
                            }
                        } while (dictionary_input != 7);
                        break;
                }
            } while (user_input != 4);

            Console.WriteLine("\nThank you for using the program.");

            Console.ReadLine();
        }

        private static void PrintQueueMenu()
        {
            //Display Queue menu to user
            Console.WriteLine("\n1. Add one time to Queue");
            Console.WriteLine("2. Add Huge List of Items to Queue");
            Console.WriteLine("3. Display Queue");
            Console.WriteLine("4. Delete from Queue");
            Console.WriteLine("5. Clear Queue");
            Console.WriteLine("6. Search Queue");
            Console.WriteLine("7. Return to Main Menu\n");
        }

        private static void PrintDictionaryMenu()
        {
            //Display Dictionary menu to user
            Console.WriteLine("\n1. Add one time to Dictionary");
            Console.WriteLine("2. Add Huge List of Items to Dictionary");
            Console.WriteLine("3. Display Dictionary");
            Console.WriteLine("4. Delete from Dictionary");
            Console.WriteLine("5. Clear Dictionary");
            Console.WriteLine("6. Search Dictionary");
            Console.WriteLine("7. Return to Main Menu\n");
        }

        private static void PrintStackMenu()
        {
            //Display Stack menu to user
            Console.WriteLine("\n1. Add one time to Stack");
            Console.WriteLine("2. Add Huge List of Items to Stack");
            Console.WriteLine("3. Display Stack");
            Console.WriteLine("4. Delete from Stack");
            Console.WriteLine("5. Clear Stack");
            Console.WriteLine("6. Search Stack");
            Console.WriteLine("7. Return to Main Menu\n");
        }

        private static void PrintMainMenu()
        {
            //Display Main Menu to user
            Console.WriteLine("1. Stack");
            Console.WriteLine("2. Queue");
            Console.WriteLine("3. Dictionary");
            Console.WriteLine("4. Exit\n");
            return;
        }
    }
}
