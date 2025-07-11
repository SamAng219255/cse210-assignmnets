class PromptGenerator {
    private const List<string> prompts = new List<string>{
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is one thing I learned today, and how might I apply it going forward?",
        "Who did I help today, and how did it make me feel?",
        "What moment today brought me the most peace?",
        "What challenge did I face today, and how did I respond to it?",
        "What is something I’m grateful for today that I might usually overlook?"
    };
    private Random randomGenerator = new Random();

    public string GetPrompt() {
        return prompts[randomGenerator.Next(prompts.Count())];
    }
}