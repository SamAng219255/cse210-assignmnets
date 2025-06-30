using System;

class Program
{
    static void Main(string[] args)
    {
        string grade_percent_str, grade_letter;
        int grade_percent;
        bool did_pass;

        Console.Write("Please enter the grade percentage: %");
        grade_percent_str = Console.ReadLine();
        grade_percent = int.Parse(grade_percent_str);

        if(grade_percent >= 90) {
            grade_letter = "A";
        }
        else if(grade_percent >= 80) {
            grade_letter = "B";
        }
        else if(grade_percent >= 70) {
            grade_letter = "C";
        }
        else if(grade_percent >= 60) {
            grade_letter = "D";
        }
        else {
            grade_letter = "F";
        }

        did_pass = grade_percent >= 70;

        Console.WriteLine($"Grade: {grade_letter}");
        if(did_pass) {
            Console.WriteLine("Congratulations on passing the class!");
        }
        else {
            Console.WriteLine("Better luck next time!");
        }
    }
}