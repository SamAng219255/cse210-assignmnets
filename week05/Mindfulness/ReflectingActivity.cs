using System.Linq;

public class ReflectingActivity : Activity {
	private List<string> _prompts;
	private List<string> _questions;
	private List<int> _randomOrder;
	private int _randomOrderIndex;

	public ReflectingActivity(List<string> prompts, List<string> questions) : base(
		"Reflection Activity",
		"This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
	) {
		_prompts = prompts;
		_questions = questions;
	}

	public override void Run() {
		DisplayPrompt();
		Console.WriteLine("When you have something in mind, press enter to continue.");
		Console.ReadLine();
		Console.Write("You may begin in...");
		ShowCountDown(5);
		Console.Clear();
		DisplayQuestions();
	}

	private string GetRandomPrompt() {
		Random random = new Random();
		return _prompts[random.Next(_prompts.Count())];
	}

	private void SetupRandomQuestions() {
		_randomOrder = Enumerable.Range(0, _questions.Count()).ToList();
		Random random = new Random();
		for(int i=0; i<_questions.Count(); i++) {
			int randomIndex = random.Next(i, _questions.Count());
			int carry = _randomOrder[i];
			_randomOrder[i] = _randomOrder[randomIndex];
			_randomOrder[randomIndex] = carry;
		}
		_randomOrderIndex = 0;
	}
	private string GetNextRandomQuestion() {
		if(_randomOrderIndex >= _randomOrder.Count()) {
			_randomOrderIndex = 0;
			SetupRandomQuestions();
		}
		return _questions[_randomOrder[_randomOrderIndex++]];
	}

	private void DisplayPrompt() {
		Console.WriteLine($"Consider the following prompt:\n\n ——— {GetRandomPrompt()} ———\n");
	}

	private void DisplayQuestions() {
		SetupRandomQuestions();
		DateTime endTime = DateTime.Now.AddSeconds(_duration);
		while(DateTime.Now < endTime) {
			Console.Write($"> {GetNextRandomQuestion()} ");
			ShowSpinner(1);
			Console.Write("\n");
		}
	}
}