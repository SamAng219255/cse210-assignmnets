public class ProgressGoal : Goal {
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ProgressGoal(string name, string description, int points, int target, int bonus) : base(name, description, points) {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override int RecordEvent() {
        Console.Write("How much progress did you make? ");
        int progress;
        if(!int.TryParse(Console.ReadLine(), out progress)) {
            Console.WriteLine("Invalid response. Not a number.");
            return 0;
        }
        _amountCompleted+=progress;
        if(IsComplete()) {
            return _points * progress + _bonus;
        }
        else {
            return _points * progress;
        }
    }

    public void MarkComplete(int progress) {
        _amountCompleted+=progress;
    }

    public override bool IsComplete() {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString() {
        string completeMark = IsComplete() ? "X" : " ";
        return $"[{completeMark}] {_shortName} ({_points} pts each) — {_description} —— {_amountCompleted}/{_target} Completed ({_bonus} pts completion reward)";
    }

    public override string GetStringRepresentation() {
        string payload = $"5{_shortName.Length:X8}{_shortName}{_description.Length:X8}{_description}{_points:X8}{_amountCompleted:X8}{_target:X8}{_bonus:X8}";
        return $"{payload.Length:X16}{payload}";
    }
}