using System;

public class SwimmingActivity : Activity {
	private double _laps;

	public SwimmingActivity(string date, int duration, int laps) : base(date, duration, "Swimming") {
		_laps = laps;
	}

	protected override double GetDistance() {
		return (0.031 * _laps);
	}
	protected override double GetSpeed() {
		return (GetDistance() / _duration) * 60;
	}
	protected override double GetPace() {
		return _duration / GetDistance();
	}
}