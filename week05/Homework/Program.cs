using System;

class Program
{
    static void Main(string[] args)
    {
        var math1 = new MathAssignment(
            studentName: "Alice Johnson",
            topic: "Algebra I",
            textbookSection: "5.2",
            problems: "1-10, 12, 14"
        );
        // These calls will eventually return strings once implemented
        Console.WriteLine(math1.GetSummary());
        Console.WriteLine(math1.GetHomeworkList());

        var math2 = new MathAssignment(
            studentName: "Bob Smith",
            topic: "Geometry",
            textbookSection: "3.4",
            problems: "2, 4, 6-8"
        );
        Console.WriteLine(math2.GetSummary());
        Console.WriteLine(math2.GetHomeworkList());

        var writing1 = new WritingAssignment(
            studentName: "Carol Lee",
            topic: "Environmental Science",
            title: "The Impact of Climate Change"
        );
        Console.WriteLine(writing1.GetSummary());
        Console.WriteLine(writing1.GetWritingInformation());

        var writing2 = new WritingAssignment(
            studentName: "Dave Martinez",
            topic: "Literature",
            title: "Analyzing Shakespeare’s Sonnets"
        );
        Console.WriteLine(writing2.GetSummary());
        Console.WriteLine(writing2.GetWritingInformation());
    }
}