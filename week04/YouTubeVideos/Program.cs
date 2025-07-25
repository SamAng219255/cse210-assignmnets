using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video> {
            new Video("Journey Through the Stars", "Neil Armstrong", 300),
            new Video("Deep Sea Wonders", "Jacques Cousteau", 180),
            new Video("The Secrets of Code", "Ada Lovelace", 240)
        };

        videos[0].AddComment(new Comment("Alice", "Absolutely breathtaking visuals!"));
        videos[0].AddComment(new Comment("Bob", "I learned so much about astronomy."));
        videos[0].AddComment(new Comment("Charlie", "When’s the next installment?"));

        videos[1].AddComment(new Comment("Diana", "The coral reef segment was stunning."));
        videos[1].AddComment(new Comment("Evan", "Great narration and music."));
        videos[1].AddComment(new Comment("Fiona", "Can’t wait to show this to my class."));

        videos[2].AddComment(new Comment("George", "Very clear explanations."));
        videos[2].AddComment(new Comment("Hannah", "Loved the code demos!"));
        videos[2].AddComment(new Comment("Ian", "This inspired me to start learning C#."));

        foreach(Video video in videos) {
            Console.WriteLine(video.GetDisplay());
        }
    }
}