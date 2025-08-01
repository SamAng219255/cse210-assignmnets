public abstract class Activity {
	private string _name;
	private string _description;
	protected int _duration;

	public Activity(string name, string description) {
		_name = name;
		_description = description;
	}

	public void DisplayStartingMessage() {
		Console.Write($"Welcome to the {_name}.\n\n{_description}\n\nHow long, in seconds, would you like for your session? ");
		while(!int.TryParse(Console.ReadLine(), out _duration)) {
			Console.Write("Invalid time. Please use only the digit keys to express your number.\nHow long, in seconds, would you like for your session? ");
		}
		Console.Clear();
		Console.Write("Get ready...");
		ShowCountDown(5);
		Console.Write("\n");
	}

	public void DisplayEndingMessage() {
		Console.WriteLine("\n\nWell done!");
		ShowSpinner(10);
		Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}.");
		ShowSpinner(10);
		Console.Clear();
	}

	public abstract void Run();

	public void ShowSpinner(int seconds) {
		List<string> spinnerChars = new List<string>{"|", "/", "—", "\\"};
		for(int i=0; i<seconds*4; i++) {
			if(i > 0) {
				Console.Write("\b");
			}
			Console.Write(spinnerChars[i % spinnerChars.Count()]);
			Thread.Sleep(250);
		}
		Console.Write("\b ");
	}

	public void ShowCountDown(int seconds) {
		int characterCount = 0;
		for(int i=seconds; i>0; i--) {
			if(i < seconds) {
				Console.Write(new string('\b', characterCount) + new string(' ', characterCount) + new string('\b', characterCount));
			}
			string show = $"{i}";
			characterCount = show.Length;
			Console.Write(show);
			Thread.Sleep(1000);
		}
		Console.Write("\b ");
	}
}