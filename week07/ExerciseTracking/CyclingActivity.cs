using System;

public class CyclingActivity : Activity {
	private double _speed;

	public CyclingActivity(string date, int duration, double speed) : base(date, duration, "Cycling") {
		_speed = speed;
	}

	protected override double GetDistance() {
		return _speed * _duration / 60.0;
	}
	protected override double GetSpeed() {
		return _speed;
	}
	protected override double GetPace() {
		return 60 / _speed;
	}
}