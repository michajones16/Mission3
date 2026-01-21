internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Food Bank System!");
        Console.WriteLine("Pick a number to continue:");
        Console.WriteLine("1: Add Food Items");
        Console.WriteLine("2: Delete Food Items");
        Console.WriteLine("3: Print List of Current Food Items");
        Console.WriteLine("4: Exit the Program");
        string userChoice = Console.ReadLine();

        while (userChoice == "1" || userChoice == "2" || userChoice == "3")
        {
            if (userChoice == "1")
            {
                Console.WriteLine("Enter a name for the item: ");
                string itemName = Console.ReadLine();

                Console.WriteLine("Enter a category for the item: ");
                string itemCategory = Console.ReadLine();

                Console.WriteLine("Enter a quantity for the item:");

                int itemQuantity;

                try
                {
                    itemQuantity = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a whole number.");
                }
            }

            Console.WriteLine("Welcome to the Food Bank System!");
            Console.WriteLine("Pick a number to continue:");
            Console.WriteLine("1: Add Food Items");
            Console.WriteLine("2: Delete Food Items");
            Console.WriteLine("3: Print List of Current Food Items");
            Console.WriteLine("4: Exit the Program");
            userChoice = Console.ReadLine();
        }
    }
}