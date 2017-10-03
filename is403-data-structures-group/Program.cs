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
            Stack<string> stringStack = new Stack<string>();
            // create errorflag
            bool isValidInput = true;
            // create returnToMainMenu flag
            bool returnToMenu = true;
            // create returnToStructMenu flag
            bool returnToStructMenu = true;

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch(); //creates a stopwatch object

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
                                case 1: //enter string
                                    Console.WriteLine("Enter a string:"); //prompts user to enter a string
                                    stringStack.Push(Console.ReadLine()); //puts the string on the stack
                                    break;
                                case 2: //add huge list
                                    stringStack.Clear(); //empties the stack 
                                    for (int i = 1; i <= 2000; i++) //adds 2000 entries
                                    {
                                        stringStack.Push("New Entry " + i);
                                    }
                                    break;
                                case 3: //display
                                    if (stringStack.Count() == 0) //catches when the user hasn't added any items yet
                                    {
                                        Console.WriteLine("No items to display, please add items");
                                    }
                                    else
                                    {
                                        Stack<string> tempStringStack = new Stack<string>();

                                        while (stringStack.Count() != 0)//saves all of the imtes that are being popped
                                        {
                                            string tempValue;
                                            tempValue = stringStack.Pop();
                                            tempStringStack.Push(tempValue);
                                        }
                                        while (tempStringStack.Count() != 0) //displays all the items
                                        {
                                            string tempValue;
                                            tempValue = tempStringStack.Pop();
                                            Console.WriteLine(tempValue);
                                            stringStack.Push(tempValue);
                                        }

                                    }
                                    break;
                                case 4: //delete from stack
                                    string valueToDelete;
                                    bool errorFlag = false;
                                    if (stringStack.Count() == 0)
                                    {
                                        Console.WriteLine("Your stack is empty, please add to the stack");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Enter the value you wish to delete: ");//prompt the user for the string they want to delete
                                        valueToDelete = Console.ReadLine();
                                        Stack<string> tempStringStack = new Stack<string>();
                                        while (errorFlag == false)
                                        {
                                            if (stringStack.Count() == 0) //in thise case, the item did not exist
                                            {
                                                Console.WriteLine("The item you searched did not exist in the Stack.");
                                                errorFlag = true;
                                            }
                                            else if (stringStack.Peek() == valueToDelete)
                                            {
                                                stringStack.Pop(); //removes desired item from stack
                                                errorFlag = true;
                                            } 
                                            else
                                            {
                                                tempStringStack.Push(stringStack.Pop()); //places the value into another temporary stack
                                            }

                                        }
                                        while (tempStringStack.Count() != 0)//replaces the items on the stack
                                        {
                                            stringStack.Push(tempStringStack.Pop());
                                        }
                                    }

                                    break;
                                case 5: //empties the stack
                                    stringStack.Clear();
                                    Console.WriteLine("Stack has been cleared");
                                    break;
                                case 6: //searches the stack
                                    if (stringStack.Count() == 0)
                                    {
                                        Console.WriteLine("Your stack is empty, please add to the stack");
                                    }
                                    else
                                    {
                                        string valueToFind;
                                        bool errorFlag1 = false;
                                        Stack<string> tempStringStack = new Stack<string>();
                                        Console.WriteLine("Enter the entry to search:");//prompts the user to enter the string they want to search
                                        valueToFind = Console.ReadLine();

                                        sw.Start(); //begins stopwatch
                                        
                                        while (errorFlag1 == false)
                                        {
                                            
                                            if (stringStack.Count() == 0) //in this case, the item did not exist
                                            {
                                                Console.WriteLine("Not Found");
                                                errorFlag1 = true;
                                               
                                            }
                                            else if (stringStack.Peek() == valueToFind)
                                            {
                                                Console.WriteLine("Found"); //removes desired item from stack
                                                errorFlag1 = true;
                                               
                                            }
                                            else
                                            {
                                                tempStringStack.Push(stringStack.Pop()); //places the value into another temporary stack
                                            }

                                        }
                                        while (tempStringStack.Count() != 0)
                                        {
                                            stringStack.Push(tempStringStack.Pop()); //replaces all of the stack's original values
                                        }
                                        sw.Stop();//stop stopwatch
                                        Console.WriteLine("Search took: " + sw.Elapsed); //display the elapsed time
                                    }
                                    
                                    break;
                                case 7:
                                    Console.WriteLine("return to main menu"); //returns the user to the main menu
                                    returnToStructMenu = false;
                                    break;
                            }
                        }     
                        break;
                    case QUEUE:
                        returnToStructMenu = true; // reset returnToStructMenu
                        while (returnToStructMenu)
                        {
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
                                    Console.WriteLine("Add one time to queue");
                                    break;
                                case 2:
                                    Console.WriteLine("Add list queue");
                                    break;
                                case 3:
                                    Console.WriteLine("display queue");
                                    break;
                                case 4:
                                    Console.WriteLine("delete from queue");
                                    break;
                                case 5:
                                    Console.WriteLine("clear queue");
                                    break;
                                case 6:
                                    Console.WriteLine("search queue");
                                    break;
                                case 7:
                                    Console.WriteLine("return to main menu");
                                    returnToStructMenu = false;
                                    break;
                            }
                        }
                        break;
                    case DICTIONARY:
                        returnToStructMenu = true; // reset returnToStructMenu
                        while (returnToStructMenu)
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
                                case 1:
                                    Console.WriteLine("Add one time to dictionary");
                                    break;
                                case 2:
                                    Console.WriteLine("Add list dictionary");
                                    break;
                                case 3:
                                    Console.WriteLine("display dictionary");
                                    break;
                                case 4:
                                    Console.WriteLine("delete from dictionary");
                                    break;
                                case 5:
                                    Console.WriteLine("clear dictionary");
                                    break;
                                case 6:
                                    Console.WriteLine("search dictionary");
                                    break;
                                case 7:
                                    Console.WriteLine("return to main menu");
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
