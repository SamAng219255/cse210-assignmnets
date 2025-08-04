using System;

public abstract class Activity {
	private string _date;
	protected int _duration;
	private string _name;

	public Activity(string date, int duration, string name) {
		_date = date;
		_duration = duration;
		_name = name;
	}

	public string GetSummary() {
		return $"{_date} {_name} ({_duration} min): Distance {GetDistance():F2} mph, Speed {GetSpeed():F2} mph, Pace {GetPace():F2} min per mile";
	}

	protected abstract double GetDistance();
	protected abstract double GetSpeed();
	protected abstract double GetPace();
}