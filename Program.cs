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

    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Food Bank System!");
        Console.WriteLine("Pick a number to continue:");
        Console.WriteLine("1: Add Food Items");
        Console.WriteLine("2: Delete Food Items");
        Console.WriteLine("3: Print List of Current Food Items");
        Console.WriteLine("4: Exit the Program");
        string userChoice = Console.ReadLine();

        while (userChoice != "4")
        {
            if (userChoice == "1")
            {
                Console.WriteLine("Enter a name for the item: ");
                string itemName = Console.ReadLine();

                Console.WriteLine("Enter a category for the item: ");
                string itemCategory = Console.ReadLine();

                Console.WriteLine("Enter a quantity for the item:");

                int itemQuantity = NumberInput();

                while (true)
                {
                    try
                    {
                        int[] dateParts = DateInput();
                        DateTime itemExpDate = new DateTime(dateParts[0], dateParts[1], dateParts[2]);
                        break;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Invalid date. Please try again.");
                    }
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