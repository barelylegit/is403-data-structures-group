using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace is403_data_structures_group
{
    class Program
    {
        // declare global constants
        const int STACK = 1;
        const int QUEUE = 2;
        const int DICTIONARY = 3;
        const int EXIT = 4;
        // function for displaying main menu
        static void mainMenu()
        {
            Console.WriteLine("1. Stack");
            Console.WriteLine("2. Queue");
            Console.WriteLine("3. Dictionary");
            Console.WriteLine("4. Exit");
        }
        // function for displaying second menus
        /*
         * @ param structMenu(name of structure declared in global constants)
         * 
         * Example:
         *  structMenu("Stack") will return the secondary menu with the structure
         *  being Stack since the secondary menu is inheritable
         */
        static void structMenu(string structure)
        {
            Console.WriteLine("1. Add one time to " + structure);
            Console.WriteLine("2. Add Huge List of Items to " + structure);
            Console.WriteLine("3. Display " + structure);
            Console.WriteLine("4. Delete from " + structure);
            Console.WriteLine("5. Clear " + structure);
            Console.WriteLine("6. Search " + structure);
            Console.WriteLine("7. Return to Main Menu");
        }
        static void Main(string[] args)
        {
			Dictionary<string, int> stringDict = new Dictionary<string, int>();
			System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
			TimeSpan ts;

			string stringEntry;
            int dictCount = 1;
            // create errorflag
            bool isValidInput = true;
            // create returnToMainMenu flag
            bool returnToMenu = true;
            // create returnToStructMenu flag
            bool returnToStructMenu = true;

            // queue of strings
            Queue<string> stringQueue = new Queue<string>();

            // creates the stopwatch object for elapsed times
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            // create user input placeholder
            int input = -1;

            while (returnToMenu)
            {
                input = -1; // reset placeholder
                // print main menu
                mainMenu();

                // check for valid inputs from 1-4
                try
                {
                    Console.Write("> ");
                    input = Convert.ToInt32(Console.ReadLine());
                    // if input is not 1-4 throw custom exception
                    if (input < 1 || input > 4)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception e) // this will catch non-ints and ints outside of range
                {
                    Console.WriteLine("Invalid input. Please input a number from 1-4.");
                } 
                /* 
                 * If input is accepted, process drops down to switch.
                 * If input is invalid, returnToMenu is still true and the code continues from
                 * beginning of loop
                 */
                

                switch (input)
                {
                    case STACK:
                        returnToStructMenu = true; // reset returnToStructMenu
                        // output structMenu with Stack
                        while (returnToStructMenu)
                        {
                            structMenu("Stack");
                            try
                            {
                                Console.Write("> ");
                                input = Convert.ToInt32(Console.ReadLine());
                                if (input < 1 || input > 7)
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Invalid input. Input a number from 1-7");
                            }
                            switch (input)
                            {
                                case 1:
                                    Console.WriteLine("Add one time to stack");
                                    break;
                                case 2:
                                    Console.WriteLine("Add list stack");
                                    break;
                                case 3:
                                    Console.WriteLine("display stack");
                                    break;
                                case 4:
                                    Console.WriteLine("delete from stack");
                                    break;
                                case 5:
                                    Console.WriteLine("clear stack");
                                    break;
                                case 6:
                                    Console.WriteLine("search stack");
                                    break;
                                case 7:
                                    Console.WriteLine("return to main menu");
                                    returnToStructMenu = false;
                                    break;
                            }
                        }     
                        break;
                    case QUEUE:
                        returnToStructMenu = true; // reset returnToStructMenu
                        while (returnToStructMenu)
                        {
                            string userInput;

                            structMenu("Queue");
                            try
                            {
                                Console.Write("> ");
                                input = Convert.ToInt32(Console.ReadLine());
                                if (input < 1 || input > 7)
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Invalid input. Input a number from 1-7");
                            }
                            switch (input)
                            {
                                case 1:
                                    // adds a user entered string to the queue
                                    Console.Write("Enter a string to add to the Queue: ");
                                    userInput = Console.ReadLine();
                                    stringQueue.Enqueue(userInput);
                                    break;
                                case 2:
                                    stringQueue.Clear();    // clears the current queue before adding 2000 items
                                    for(int i = 1; i <= 2000; i++)
                                    {
                                        stringQueue.Enqueue("New Entry " + i);
                                    }
                                    Console.WriteLine("Entries added.");
                                    break;
                                case 3:
                                    // displays what is currently in the string
                                    if (stringQueue.Count < 1)
                                    {
                                        Console.WriteLine("The queue is currently empty. Please add to the queue.");
                                    }
                                    else
                                    {
                                        foreach (string element in stringQueue)
                                        {
                                            Console.WriteLine(element);
                                        }
                                    }
                                    break;
                                case 4:
                                    // deletes a value from the queue
                                    if (stringQueue.Count < 1)
                                    {
                                        Console.WriteLine("The queue is currently empty. Please add to the queue.");
                                    }
                                    else
                                    {
                                        Console.Write("Enter the entry to delete: ");
                                        userInput = Console.ReadLine();
                                        if (stringQueue.Contains(userInput))
                                        {
                                            Queue<string> tempQueue = new Queue<string>();

                                            // checks for the string and dequeues
                                            while(stringQueue.Count > 0)
                                            {
                                                if(stringQueue.Peek() == userInput)
                                                {
                                                    // if the string matches, does not dequeue to the temp queue
                                                    stringQueue.Dequeue();
                                                }
                                                else
                                                {
                                                    tempQueue.Enqueue(stringQueue.Dequeue());
                                                }
                                            }

                                            // replaces all of the values back to the string queue minus the "deleted" string
                                            while(tempQueue.Count > 0)
                                            {
                                                stringQueue.Enqueue(tempQueue.Dequeue());
                                            }

                                            Console.WriteLine("The entry was deleted.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("The entry was not found in the queue to be deleted.");
                                        }
                                    }
                                    break;
                                case 5:
                                    stringQueue.Clear(); // clears the queue
                                    break;
                                case 6:
                                    // Search for a string
                                    if (stringQueue.Count < 1)
                                    {
                                        Console.WriteLine("The queue is currently empty. Please add to the queue.");
                                    }
                                    else
                                    {
                                        Console.Write("Enter the entry to search for: ");
                                        userInput = Console.ReadLine();

                                        sw.Start();
                                        bool isFound = stringQueue.Contains(userInput);
                                        sw.Stop();

                                        if (isFound)
                                        {
                                            Console.WriteLine("The entry was found. The total time was " + sw.Elapsed + ".");
                                        }
                                        else
                                        {
                                            Console.WriteLine("The entry was not found. The total time was " + sw.Elapsed + ".");
                                        }

                                        sw.Reset(); // clears current time on the stop watch
                                    }

                                    break;
                                case 7:
                                    // Returns to the main menu
                                    Console.WriteLine("return to main menu");
                                    returnToStructMenu = false;
                                    break;
                            }
                        }
                        break;


                    case DICTIONARY:
                        returnToStructMenu = true; // reset returnToStructMenu
                        while (returnToStructMenu == true)
                        {
                            structMenu("Dictionary");
                            try
                            {
                                Console.Write("> ");
                                input = Convert.ToInt32(Console.ReadLine());
                                if (input < 1 || input > 7)
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Invalid input. Input a number from 1-7");
                            }
                            switch (input)
                            {
								//lets user enter in data to dictionary
                                case 1:
                                    Console.WriteLine("Please enter information to add to the Dictionary:");
									Console.Write("> ");
									stringEntry = Console.ReadLine();
									stringDict.Add(stringEntry, dictCount);
                                    Console.WriteLine("The key \"" + stringEntry + "\" has been successfully added to the Dictionary with the value: " + dictCount);
                                    dictCount++;
                                    break;
								//adds 2000 entries
                                case 2:
                                    Console.WriteLine("Added 2000 \"New Entries\" to the Dictionary\n");
									for (int i = 1; i <= 2000; i++)
									{
										stringDict.Add("New Entry " + i, i);
									}
                                    break;
								//displays all the data in dictionary
                                case 3:
                                    Console.WriteLine("Displaying dictionary...\n");
									foreach (KeyValuePair<string, int> Dictionary in stringDict)
									{
										Console.WriteLine(Dictionary.Key + ": " + Dictionary.Value);
									}
                                    break;

								//Deletes an item that the user wants to delete
                                case 4:
                                    Console.WriteLine("What do you want to delete from the Dictionary?");
									stringEntry = Console.ReadLine();
									if (stringDict.ContainsKey(stringEntry))
									{
										stringDict.Remove(stringEntry);
                                        Console.WriteLine("Success!\n");
									}
									else
									{
										Console.WriteLine("THAT DOESN'T EXIST! D: You need to try something that is actually in your dictionary.\n");
									}
                                    break;
								
								//clears all the data in the dictionary
                                case 5:
                                    Console.WriteLine("Dictionary Cleared.");
									stringDict.Clear();
                                    break;
								
								//Searches for specified item in dictionary
                                case 6:
									Console.WriteLine("What do you want to search for?");
									stringEntry = Console.ReadLine();
                                    Console.WriteLine("Searching dictionary...");
									sw.Start();
									
									if (stringDict.ContainsKey(stringEntry))
									{
										sw.Stop();
										Console.WriteLine(stringEntry + " was found! :D :D");
										Console.WriteLine("Total time was: " + sw.Elapsed);
									}
									else
									{
										sw.Stop();
										Console.WriteLine(stringEntry + " was not found");
										Console.WriteLine("Total time was: "  + sw.Elapsed);

									}
									sw.Reset();
                                    break;
								
								//Returns to the main menu
                                case 7:
                                    Console.WriteLine("Returning to main menu...\n");
                                    returnToStructMenu = false;
                                    break;
                            }
                        }
                        break;
                    case EXIT:
                        returnToMenu = false;
                        break;
                }
            }
            // wait for any key to terminate
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
