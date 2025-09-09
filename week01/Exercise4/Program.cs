using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> numbers = new List<int>();

        while (true)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int number))
            {
                Console.WriteLine("Please enter a valid integer.");
                continue;
            }

            if (number == 0)
            {
                break;
            }

            numbers.Add(number);
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers entered.");
            return;
        }

        int sum = 0;
        foreach (int n in numbers)
        {
            sum += n;
        }

        double average = (double)sum / numbers.Count;
        int max = int.MinValue;
        foreach (int n in numbers)
        {
            if (n > max) max = n;
        }

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        int smallestPositive = int.MaxValue;
        foreach (int n in numbers)
        {
            if (n > 0 && n < smallestPositive)
            {
                smallestPositive = n;
            }
        }
        if (smallestPositive != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("No positive numbers were entered.");
        }

        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int n in numbers)
        {
            Console.WriteLine(n);
        }
    }
}