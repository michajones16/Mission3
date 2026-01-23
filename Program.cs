using Mission3;
using System.Collections.Generic;

internal class Program
{
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

    private static void printList(List<FoodItem> list)
    {
        list = list.OrderBy(item => item.ExpDate).ToList();
        Console.WriteLine("\n");

        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine((i + 1) + ": " + list[i].Name + " - " + list[i].Category + " - " + list[i].Quantity + " - " + list[i].ExpDate.ToString("yyyy-MM-dd"));
        }
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Food Bank System!");
        Console.WriteLine("Pick a number to continue:");
        Console.WriteLine("1: Add Food Items");
        Console.WriteLine("2: Delete Food Items");
        Console.WriteLine("3: Print List of Current Food Items");
        Console.WriteLine("4: Exit the Program");
        string userChoice = Console.ReadLine();

        List<FoodItem> allFood = new List<FoodItem>();

        while (userChoice != "4")
        {
            if (userChoice == "1")
            {
                Console.WriteLine("\n");

                Console.WriteLine("Enter a name for the item: ");
                string itemName = Console.ReadLine();

                Console.WriteLine("Enter a category for the item: ");
                string itemCategory = Console.ReadLine();

                Console.WriteLine("Enter a quantity for the item:");

                int itemQuantity = NumberInput();
                DateTime itemExpDate;

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
                FoodItem newFood = new FoodItem(itemName, itemCategory, itemQuantity, itemExpDate);
                allFood.Add(newFood);
            }
            else if (userChoice == "2")
            {
                Console.WriteLine("\n");

                string itemName = "";
                List<FoodItem> matchingFood = new List<FoodItem>();
                List<int> listIndexes = new List<int>();

                while (matchingFood.Count == 0)
                {
                    Console.WriteLine("Enter the name of the item you would like to delete:");
                    itemName = Console.ReadLine();

                    allFood = allFood.OrderBy(item => item.ExpDate).ToList();

                    for (int i = 0; i < allFood.Count; i++)
                    {
                        if (allFood[i].Name == itemName)
                        {
                            matchingFood.Add(allFood[i]);
                            listIndexes.Add(i);
                        }
                    }

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
                        allFood.RemoveAt(listIndexes[itemIndex - 1]);
                    }
                    else if (matchingFood.Count == 1)
                    {
                        allFood.RemoveAt(listIndexes[0]);
                    }
                    else
                    {
                        Console.WriteLine("No food item was found with that name.\n");
                    }
                }
            }
            else if (userChoice == "3")
            {
                if (allFood.Count > 0)
                {
                    printList(allFood);
                }
                else
                {
                    Console.WriteLine("No items to display.");
                }
            }

            Console.WriteLine("\nWelcome to the Food Bank System!");
            Console.WriteLine("Pick a number to continue:");
            Console.WriteLine("1: Add Food Items");
            Console.WriteLine("2: Delete Food Items");
            Console.WriteLine("3: Print List of Current Food Items");
            Console.WriteLine("4: Exit the Program");
            userChoice = Console.ReadLine();
        }
    }
}