using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers. Type 0 when finished.");

        int input_num;
        List<int> num_list = new List<int>();
        int sum = 0;
        int max = 0;
        float avg;

        Console.Write("Enter number: ");
        while((input_num = int.Parse(Console.ReadLine())) != 0) {
            num_list.Add(input_num);
            Console.Write("Enter number: ");
        }

        foreach(int number in num_list) {
            sum += number;
            if(max < number) {
                max = number;
            }
        }

        avg = (float)sum / num_list.Count;

        Console.WriteLine($"Sum: {sum}\nAverage: {avg}\nMaximum: {max}");
    }
}