public class ListingActivity : Activity {
	private int _count;
	private List<string> _prompts;

	public ListingActivity(List<string> prompts) : base(
		"Listing Activity",
		"This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
	) {
		_prompts = prompts;
	}

	public override void Run() {
		string prompt = GetRandomPrompt();
		Console.Write($"List as many reponses as you can to the following prompt:\n ——— {prompt} ——— \nYou may begin in: ");
		ShowCountDown(10);
		Console.Write("\n");
		List<string> answerList = GetListFromUser();
		_count = answerList.Count();
		Console.WriteLine($"You listed {_count} items!");
	}

	private string GetRandomPrompt() {
		Random random = new Random();
		return _prompts[random.Next(_prompts.Count())];
	}

	private List<string> GetListFromUser() {
		List<string> answerList = new List<string>();
		DateTime endTime = DateTime.Now.AddSeconds(_duration);
		while(DateTime.Now < endTime) {
			Console.Write("> ");
			answerList.Add(Console.ReadLine());
		}
		return answerList;
	}
}