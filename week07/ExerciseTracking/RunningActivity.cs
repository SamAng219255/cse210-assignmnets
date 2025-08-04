using System;

public class RunningActivity : Activity {
	private double _distance;

	public RunningActivity(string date, int duration, double distance) : base(date, duration, "Running") {
		_distance = distance;
	}

	protected override double GetDistance() {
		return _distance;
	}
	protected override double GetSpeed() {
		return (_distance / _duration) * 60;
	}
	protected override double GetPace() {
		return _duration / _distance;
	}
}