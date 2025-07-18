using System;

/*
Addition: The program never reselects already hidden words when hiding new words.
*/

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("1 Nephi", 3, 7);
        Scripture scripture = new Scripture(reference, "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.");

        bool running = true;
        while(running) {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            if(scripture.hiddenAll() || Console.ReadLine() == "quit") {
                running = false;
                break;
            }
            else {
                scripture.HideRandom(6);
            }
        }
    }
}