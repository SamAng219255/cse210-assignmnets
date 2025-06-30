using System;

class Program
{
    static void DisplayWelcome() {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName() {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }
    static int PromptUserNumber() {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }
    static int SquareNumber(int num) {
        return num*num;
    }
    static void DisplayResult(string name, int sqr_number) {
        Console.WriteLine($"{name}, the square of your number is {sqr_number}");
    }

    static void Main(string[] args)
    {
        string user_name;
        int num, sqr_num;

        Program.DisplayWelcome();
        user_name = Program.PromptUserName();
        num = Program.PromptUserNumber();
        sqr_num = Program.SquareNumber(num);
        Program.DisplayResult(user_name, sqr_num);
    }
}