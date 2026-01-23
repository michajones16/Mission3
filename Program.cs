// Michael Jones - Section 1

using Mission3;
using System.Collections.Generic;

internal class Program
{
    // Function that handles number input and related error handling
    private static int NumberInput()
    {
        while (true)
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a whole number.");
            }
        }
    }

    // Function that handles date/time input and related error handling
    private static int[] DateInput()
    {
        Console.WriteLine("Enter expiration year:");
        int expYear = NumberInput();

        Console.WriteLine("Enter expiration month (number between 1 and 12):");
        int expMonth = NumberInput();

        // Month scope handling
        while (expMonth < 0 || expMonth > 12)
        {
            Console.WriteLine("Invalid month.");
            expMonth = NumberInput();
        }

        Console.WriteLine("Enter expiration day:");
        int expDay = NumberInput();

        // Day scope handling
        while (expDay < 0 || expDay > 31)
        {
            Console.WriteLine("Invalid day.");
            expDay = NumberInput();
        }

        return [expYear, expMonth, expDay];
    }

    // Prints food item lists (name - category - quantity - expDate)
    private static void printList(List<FoodItem> list)
    {
        list = list.OrderBy(item => item.ExpDate).ToList();
        Console.WriteLine("\n");

        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine((i + 1) + ": " + list[i].Name + " - " + list[i].Category +
                " - " + list[i].Quantity + " - " + list[i].ExpDate.ToString("yyyy-MM-dd"));
        }
    }

    private static void Main(string[] args)
    {
        // Menu
        Console.WriteLine("Welcome to the Food Bank System!");
        Console.WriteLine("\n1: Add Food Items");
        Console.WriteLine("2: Delete Food Items");
        Console.WriteLine("3: Print List of Current Food Items");
        Console.WriteLine("4: Exit the Program");
        Console.WriteLine("\nPick a number to continue:");
        string userChoice = Console.ReadLine();

        // List of all food items entered
        List<FoodItem> allFood = new List<FoodItem>();

        // Checks to see if user has chosen not to exit
        while (userChoice != "4")
        {
            // Add item
            if (userChoice == "1")
            {
                Console.WriteLine("Enter a name for the item: ");
                string itemName = Console.ReadLine();

                Console.WriteLine("Enter a category for the item: ");
                string itemCategory = Console.ReadLine();

                Console.WriteLine("Enter a quantity for the item:");

                int itemQuantity = NumberInput();
                DateTime itemExpDate;

                // Checks to see if date is valid
                while (true)
                {
                    try
                    {
                        int[] dateParts = DateInput();
                        itemExpDate = new DateTime(dateParts[0], dateParts[1], dateParts[2]);
                        break;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Invalid date. Please try again.");
                    }
                }
                
                // Creates new food item once successful
                FoodItem newFood = new FoodItem(itemName, itemCategory, itemQuantity, itemExpDate);
                allFood.Add(newFood);
            }
            // Delete item
            else if (userChoice == "2")
            {
                // Chosen item name
                string itemName = "";

                // List of all food items with that chosen name
                List<FoodItem> matchingFood = new List<FoodItem>();

                // List of all the indexes of the food items in the full item list
                List<int> listIndexes = new List<int>();

                // Checks to see if there are any items with the selected name
                // (will always be 0 to start)
                while (matchingFood.Count == 0)
                {
                    Console.WriteLine("Enter the name of the item you would like to delete:");
                    itemName = Console.ReadLine();

                    // Sorts list by expiration date (ascending)
                    allFood = allFood.OrderBy(item => item.ExpDate).ToList();

                    // Loops through full item list and adds them to food list and index list
                    for (int i = 0; i < allFood.Count; i++)
                    {
                        if (allFood[i].Name == itemName)
                        {
                            matchingFood.Add(allFood[i]);
                            listIndexes.Add(i);
                        }
                    }

                    // Prints list of all food with that name and asks user which one to delete
                    if (matchingFood.Count > 1)
                    {
                        printList(matchingFood);
                        Console.WriteLine(matchingFood.Count + " items have that name. Which one would you like to delete (enter the number)?");
                        int itemIndex = NumberInput();
                        while (itemIndex > matchingFood.Count || itemIndex < 0)
                        {
                            Console.WriteLine("Enter an number on the list.");
                            itemIndex = NumberInput();
                        }

                        // Deletes food from the full item list
                        allFood.RemoveAt(listIndexes[itemIndex - 1]);
                    }

                    // Deletes the item without printing if only one item was found
                    else if (matchingFood.Count == 1)
                    {
                        allFood.RemoveAt(listIndexes[0]);
                    }

                    // Tells user no item was found
                    else
                    {
                        Console.WriteLine("No food item was found with that name.\n");
                    }
                }
            }
            // Print list of all items
            else if (userChoice == "3")
            {
                if (allFood.Count > 0)
                {
                    printList(allFood);
                }
                else
                {
                    Console.WriteLine("\nNo items to display.");
                }
            }

            // Menu (printed again until user presses 4)
            Console.WriteLine("\nWelcome to the Food Bank System!");
            Console.WriteLine("\n1: Add Food Items");
            Console.WriteLine("2: Delete Food Items");
            Console.WriteLine("3: Print List of Current Food Items");
            Console.WriteLine("4: Exit the Program");
            Console.WriteLine("\nPick a number to continue:");
            userChoice = Console.ReadLine();
        }
    }
}