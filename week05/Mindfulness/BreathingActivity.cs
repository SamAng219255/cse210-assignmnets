public class BreathingActivity : Activity {
	public BreathingActivity() : base(
		"Breathing Activity",
		"This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing."
	) {}

	public override void Run() {
		DateTime endTime = DateTime.Now.AddSeconds(_duration);
		while(DateTime.Now < endTime) {
			Console.Write("\n\nBreathe in...");
			ShowCountDown(4);
			Console.Write("\nHold it...");
			ShowCountDown(7);
			Console.Write("\nNow breathe out...");
			ShowCountDown(8);
		}
	}
}