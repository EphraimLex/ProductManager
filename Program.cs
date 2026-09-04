/*
Mini Project for week 36.
Project name: Product List Manager
Author: Ephraim Hakizimana
Submitted Date: 2026-09-04

Note: Level 2 and Level 3 are working even though there are commented out.
*/

using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.RegularExpressions;

/*
Console.WriteLine("------------------------------------");
Console.WriteLine(" PRODUCT LIST MANAGER - LEVEL 2");
Console.WriteLine("------------------------------------\n");

Console.WriteLine("Enter product names.");
Console.WriteLine("Type 'exit' to finish.\n");

List<string> enteredProducts = [];
do
{    
    Console.Write("Product: ");
    string input = Console.ReadLine()!; // the ! is called the null-forgiving operator
    if (input.ToLower().Trim() == "exit")
        break;
    else if (input == "")
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("You forgot to enter a product!");
        Console.ResetColor();
    }
    else
        enteredProducts.Add(input);
} while (true);

// Output the product names
enteredProducts.Sort();
Console.WriteLine("\n Sorted products list: \n");
foreach (string product in enteredProducts)
    Console.WriteLine("- " + product);

Console.ReadLine();
*/

//---------------------------------------------------------------------------------------------

/*

// Level 3 – Product Validation

Console.Clear();
List<string> enteredValidProducts = [];
//enteredProducts.Clear();

Console.WriteLine("------------------------------------");
Console.WriteLine(" PRODUCT LIST MANAGER - LEVEL 3");
Console.WriteLine("------------------------------------\n");

Console.WriteLine("Enter product names.");
Console.WriteLine("Type 'exit' to finish.\n");


string lettersPattern = @"^[A-Z]+";
string hyphenPattern = @"^[A-Z]+-";
//string completePattern = @"^([A-Z]+)(-)([2-4]\d{2}|500)$";

do
{
    Console.Write("Product: ");
    string input = Console.ReadLine()!.Trim();
    if (input.ToLower() == "exit")
        break;
    else if (input == "")
        WriteColor("ERROR: Input cannot be empty.", ConsoleColor.Red);
    else if (!Regex.IsMatch(input, lettersPattern))
        WriteColor("ERROR: The left side must contain letters only.", ConsoleColor.Red);
    else if (!Regex.IsMatch(input, hyphenPattern))
        WriteColor("ERROR: Product must contain a dash (-).", ConsoleColor.Red);
    else
    {
        int hyphenIndex = input.IndexOf('-');
        string rightSide = input[(hyphenIndex + 1)..];

        if (!Regex.IsMatch(rightSide, @"^\d+$"))
        {
            WriteColor("ERROR: The right side must contain numbers only.", ConsoleColor.Red);
        }
        else if (!Regex.IsMatch(rightSide, @"^([2-4]\d{2}|500)$"))
        {
            WriteColor("ERROR: The numeric part must be between 200 and 500.", ConsoleColor.Red);
        }
        else
        {
            WriteColor("SUCCESS: Valid product name.", ConsoleColor.Green);
            enteredValidProducts.Add(input);
        }
    }

} while (true);

// Output the product names
enteredValidProducts.Sort();
Console.WriteLine("\n Sorted valid products: \n");
foreach (string product in enteredValidProducts)
    Console.WriteLine("- " + product);

static void WriteColor(string message, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(message);
    Console.ResetColor();
}

*/

//===========================================================================================


// Level 4 – Advanced Developer Challenge
// Goal: Transform the application into a more realistic inventory management system.

Console.Clear();
List<string> enteredValidProducts = [];
//enteredProducts.Clear();

Console.WriteLine("\n========================================");
Console.WriteLine(" PRODUCT INVENTORY SYSTEM - LEVEL 4");
Console.WriteLine("========================================\n");

// Diplay the various options
Console.WriteLine("1. Add Products");
Console.WriteLine("2. View Products");
Console.WriteLine("3. Search Product");
Console.WriteLine("4. Delete Product");
Console.WriteLine("5. Statistics");
Console.WriteLine("6. Exit");

bool running = true;

while(running)
{

    Console.Write("\nSelect an option: ");
    string option = Console.ReadLine()!;

    switch(option)
    {
        case "1": // Add product
            Console.WriteLine("\nInput 0 to finish adding products\n");
            while (true)
            {
                string lettersPattern = @"^[A-Z]+";
                string hyphenPattern = @"^[A-Z]+-";
                //string completePattern = @"^([A-Z]+)(-)([2-4]\d{2}|500)$";

                Console.Write("\nEnter product: ");
                string input = Console.ReadLine()!.Trim();
                if (input == "0")
                {
                    Console.WriteLine("\n----------------------------------------\n");
                    break;
                }
                else if (input == "")
                    WriteColor("ERROR: Input cannot be empty.", ConsoleColor.Red);
                else if (!Regex.IsMatch(input, lettersPattern))
                    WriteColor("ERROR: The left side must contain letters only.", ConsoleColor.Red);
                else if (!Regex.IsMatch(input, hyphenPattern))
                    WriteColor("ERROR: Product must contain a dash (-).", ConsoleColor.Red);
                else
                {
                    int hyphenIndex = input.IndexOf('-');
                    string rightSide = input[(hyphenIndex + 1)..];

                    if (!Regex.IsMatch(rightSide, @"^\d+$"))
                    {
                        WriteColor("ERROR: The right side must contain numbers only.", ConsoleColor.Red);
                    }
                    else if (!Regex.IsMatch(rightSide, @"^([2-4]\d{2}|500)$"))
                    {
                        WriteColor("ERROR: The numeric part must be between 200 and 500.", ConsoleColor.Red);
                    }
                    else
                    {
                        if (!enteredValidProducts.Contains(input))
                        {
                            WriteColor("Product added successfully.", ConsoleColor.Green);
                            enteredValidProducts.Add(input);
                        }
                        else
                            WriteColor("WARNING: Product already exists.", ConsoleColor.Magenta);
                    }
                }

            }
            break;

        case "2": // View product
            if (enteredValidProducts.Count == 0)
                WriteColor("WARNING: No product has been entered.", ConsoleColor.Magenta);
            else
            {
                Console.WriteLine("Products:");
                foreach (string product in enteredValidProducts)
                {
                    Console.WriteLine(product);
                }
            }
            
            Console.WriteLine("\n----------------------------------------\n");
            break;

        case "3": // Search product
            Console.WriteLine("\nSearch by product name or product code:\n");
            Console.Write("Search product: ");
            string search = Console.ReadLine()!.Trim();
            var results = enteredValidProducts
                .Where(p => p.Contains(search, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (results.Count == 0)
            {
                Console.WriteLine("No products found.");
            }
            else
            {
                Console.WriteLine("\nResults: ");
                foreach (string product in results)
                {
                    Console.WriteLine("- " + product);
                }
                Console.WriteLine("\n----------------------------------------\n");
            }

            break;

        case "4": // Delete product
            Console.Write("\nEnter product to delete: ");
            string productToDelete = Console.ReadLine()!.Trim();

            if (enteredValidProducts.Remove(productToDelete))
            {
                Console.WriteLine($"Deleted: {productToDelete}");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
            Console.WriteLine("\n----------------------------------------\n");

            break;


        case "5": // Statistics
            Console.WriteLine("\nProduct statistics: ");

            int numberOfProducts = enteredValidProducts.Count();
            Console.WriteLine($"- Number of products: {numberOfProducts}");

            int lowestCodeNumber = enteredValidProducts
                .Min(p => int.Parse(p.Split('-')[1]));
            Console.WriteLine($"- Lowest code: {lowestCodeNumber}");

            int highestCodeNumber = enteredValidProducts
                .Max(p => int.Parse(p.Split('-')[1]));
            Console.WriteLine($"- Highest code: {highestCodeNumber}");

            int averageCodeNumber = (int)Math.Round(
                enteredValidProducts.Average(p => int.Parse(p.Split('-')[1]))                
            );
            Console.WriteLine($"- Average code: {averageCodeNumber}");

            Console.WriteLine("\n----------------------------------------\n");
            break;

        case "6": // Exit
            Console.WriteLine("\nSaving products...");
            string json = JsonSerializer.Serialize(enteredValidProducts);
            File.WriteAllText("enteredValidProducts.json", json);

            Console.WriteLine(
                Path.GetFullPath("enteredValidProducts.json")
            );

            Console.WriteLine("Products saved. \n\nApplication closed.");
            return;

        default:
            Console.WriteLine("\n");
            WriteColor(" Please choose a valid option.", ConsoleColor.Magenta);
            break;
    }
}


static void WriteColor(string message, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(message);
    Console.ResetColor();
}

// ==============================================================================


/* ****** ANSWERS TO INTERVIEW QUESTIONS ******

---> Beginner Questions <---
1. The difference between a List and an Array is that an array has a fixed size and cannot be
   dynamically changed while a list can be dynamically changed. To change an array you have to resize 
   every time.

2. int.TryParse() convert an item to integer and return true if the item is convertible and false if
   the item is not convertable. The out value will be the converted integer if convertible or zero(= default
   value for integer) if not convertible.

3. Validation should be separated into methods in order to make the code reusable and cleaner. In this way the 
   tests become easier and the code becomes easier to maintain. 

---> Intermediate Questions <---
1. Encapsulation is an object-oriented programming principle where an object's data (fields) and the operations
   on that data (methods) are combined into a well-defined unit (like a class). [definition from: 
   "The C# Player's Guide", 5th ed]

2. Using classes instead of plain strings facilitates the manipulation of objects: it is well structured.

3. LINQ stands for Language Integrated Query. It is a feature in C# that let one manipulate (query) collection 
   with ease thanks to syntax in LINQ.


*/

