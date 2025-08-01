using System;

/*
To show creativity and exceed the core requirements, I implemented an algorithm to give
the questions in a series of random orders without repeating until every question has been
asked each time in the Reflection Activity.
*/

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>{
            new BreathingActivity(),
            new ReflectingActivity(
                new List<string> {
                    "Think of a time when you stood up for someone else.",
                    "Think of a time when you did something really difficult.",
                    "Think of a time when you helped someone in need.",
                    "Think of a time when you did something truly selfless."
                },
                new List<string> {
                    "Why was this experience meaningful to you?",
                    "Have you ever done anything like this before?",
                    "How did you get started?",
                    "How did you feel when it was complete?",
                    "What made this time different than other times when you were not as successful?",
                    "What is your favorite thing about this experience?",
                    "What could you learn from this experience that applies to other situations?",
                    "What did you learn about yourself through this experience?",
                    "How can you keep this experience in mind in the future?"
                }
            ),
            new ListingActivity(
                new List<string>{
                    "Who are people that you appreciate?",
                    "What are personal strengths of yours?",
                    "Who are people that you have helped this week?",
                    "When have you felt the Holy Ghost this month?",
                    "Who are some of your personal heroes?"
                }
            )
        };

        bool running = true;
        while(running) {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string response = Console.ReadLine();
            int option;
            if(int.TryParse(response, out option) && option > 0 && option < 4) {
                int activityIndex = option - 1;
                activities[activityIndex].DisplayStartingMessage();
                activities[activityIndex].Run();
                activities[activityIndex].DisplayEndingMessage();
            }
            else if(option == 4) {
                Console.WriteLine("Goodbye!");
                running = false;
            }
            else {
                Console.WriteLine("Invalid option.\nPlease respond with the number of one of the listed menu options.\n");
                activities[0].ShowSpinner(10);
            }
        }
    }
}