using System;
using StructureMap;

namespace Avensia.Storefront.Developertest
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container(new DefaultRegistry());

            var productListVisualizer = container.GetInstance<ProductListVisualizer>();

            var shouldRun = true;
            DisplayOptions();

            while (shouldRun)
            {
                Console.Write("Enter an option: ");
                var input = Console.ReadKey();
                Console.WriteLine("\n");
                switch (input.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Console.WriteLine("Printing all products");
                        productListVisualizer.OutputAllProducts();
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Console.WriteLine("Printing paginated products");
                        // It can also be taken from the user
                        productListVisualizer.OutputPaginatedProducts(0, 5);
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        Console.WriteLine("Printing products grouped by price");
                        productListVisualizer.OutputProductGroupedByPriceSegment();
                        break;
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        var code = Console.ReadLine();
                        // Todo: Validation goes here !!!
                        int currencyCode = Convert.ToInt32(code);
                        productListVisualizer.SetCurrencyCode(currencyCode);
                        break;
                    case ConsoleKey.Q:
                        shouldRun = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }

                Console.WriteLine();
                DisplayOptions();
            }

            Console.Write("\n\rPress any key to exit!");
            Console.ReadKey();
        }

        private static void DisplayOptions()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - Print all products");
            Console.WriteLine("2 - Print paginated products");
            Console.WriteLine("3 - Print products grouped by price");
            Console.WriteLine("4 - Please select your currency, USD-1, 2-GBP, 3-SEK, 4-DKK");
            Console.WriteLine("q - Quit");
        }
    }
}
