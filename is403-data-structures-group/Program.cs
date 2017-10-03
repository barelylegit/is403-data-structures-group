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
            // create errorflag
            bool isValidInput = true;
            // create returnToMainMenu flag
            bool returnToMenu = true;
            // create returnToStructMenu flag
            bool returnToStructMenu = true;

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
