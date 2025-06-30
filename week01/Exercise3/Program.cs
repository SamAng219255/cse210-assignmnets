using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();

        int magic_number = randomGenerator.Next(1, 101);
        bool guessing = true;
        int guess_count = 1;
        int guess;

        Console.WriteLine("Welcome to my guessing game! Guess the number from 1 to 100 to win!");
        Console.Write("What is your first guess? ");
        guess = int.Parse(Console.ReadLine());

        if(guess == magic_number) {
            guessing = false;
            Console.WriteLine("You win!\n First try! Are you psychic or something?");
        }

        while(guessing) {
            if(guess < magic_number) {
                Console.WriteLine("Wrong... guess higher!");
            }
            else {
                Console.WriteLine("Wrong... guess lower!");
            }
            Console.Write("What is your next guess? ");
            guess = int.Parse(Console.ReadLine());
            guess_count += 1;
            if(guess == magic_number) {
                guessing = false;
                Console.WriteLine($"You Win!\nYou took {guess_count} tries to guess the number!");
                if(guess_count <= 7) {
                    Console.WriteLine("That's pretty good! Play again to beat your high score!");
                }
                else {
                    Console.WriteLine("I know you can do better! Play again to improve your score!");
                }
            }
        }
    }
}