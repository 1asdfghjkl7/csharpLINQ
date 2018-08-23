using System;
using System.Linq;
using System.Collections.Generic;


// Build a collection of customers who are millionaires
public class Customer
{
    public string Name { get; set; }
    public double Balance { get; set; }
    public string Bank { get; set; }
}

// Define a bank
public class Bank
{
    public string Symbol { get; set; }
    public string Name { get; set; }
}

public class GroupedMillionaires
{
    public string Bank { get; set; }
    public IEnumerable<string> Millionaires { get; set; }
}

public class Program
{
    public static void Main()
    {
        // Find the words in the collection that start with the letter 'L'
        List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

        List<string> LFruits = fruits.Where((fruit) => fruit.StartsWith("L")).ToList();
        // foreach (string item in LFruits)
        // {
        //     Console.WriteLine(item);
        // }

        // Which of the following numbers are multiples of 4 or 6
        List<int> numbers = new List<int>()
{
    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
};

        List<int> fourSixMultiples = numbers.Where((number => number % 4 == 0 || number % 6 == 0)).ToList();

        // foreach (int item in fourSixMultiples)
        // {
        //     Console.WriteLine(item);
        // }

        // Order these student names alphabetically, in descending order (Z to A)
        List<string> names = new List<string>()
{
    "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
    "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
    "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
    "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
    "Francisco", "Tre"
};

        List<string> descend = names.OrderByDescending(a => a).ToList();

        // foreach (string item in descend)
        // {
        //     Console.WriteLine(item);
        // }

        // Build a collection of these numbers sorted in ascending order
        List<int> numbers2 = new List<int>()
        {
            15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
        };

        List<int> sortedNum = numbers2.OrderBy(a => a).ToList();

        // foreach (int item in sortedNum)
        // {
        //     Console.WriteLine(item);
        // }

        // Output how many numbers are in this list
        List<int> numbers3 = new List<int>()
        {
            15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
        };

        int bigCount = numbers3.Count();

        // Console.WriteLine(bigCount);

        // How much money have we made?
        List<double> purchases = new List<double>()
        {
            2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
        };

        double sumPurchase = purchases.Sum();

        // Console.WriteLine(sumPurchase);

        // What is our most expensive product?
        List<double> prices = new List<double>()
        {
            879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
        };

        double maxPrice = prices.Max();

        // Console.WriteLine(maxPrice);

        /*
    Store each number in the following List until a perfect square
    is detected.

    Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
        */
        List<int> wheresSquaredo = new List<int>()
        {
            66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
        };

        List<int> takeWhileS = wheresSquaredo.TakeWhile(n => Math.Sqrt(n) % 1 != 0).ToList();

        foreach (int item in takeWhileS)
        {
            Console.WriteLine(item);
        }

        List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        };



        var groupedByBank = customers.Where(c => c.Balance >= 1000000).GroupBy(
            p => p.Bank,
            p => p.Name,
            (bank, millionaires) => new GroupedMillionaires() { Bank = bank, Millionaires = millionaires }
        ).ToList();

        foreach (var item in groupedByBank)
        {
            Console.WriteLine($"{item.Bank}: {string.Join(" and ", item.Millionaires)}");
        }

        // Create some banks and store in a List
        List<Bank> banks = new List<Bank>() {
                new Bank(){ Name="First Tennessee", Symbol="FTB"},
                new Bank(){ Name="Wells Fargo", Symbol="WF"},
                new Bank(){ Name="Bank of America", Symbol="BOA"},
                new Bank(){ Name="Citibank", Symbol="CITI"},
            };

        List<Customer> millionaireReport = customers.Where(c => c.Balance >= 1000000)
            .Select(c => new Customer()
            {
                Name = c.Name,
                Bank = banks.Find(b => b.Symbol == c.Bank).Name,
                Balance = c.Balance
            })
            .ToList();

        foreach (Customer customer in millionaireReport)
        {
            Console.WriteLine($"{customer.Name} at {customer.Bank}");
        }




    }
}