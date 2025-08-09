public class ChecklistGoal : Goal {
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points) {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override int RecordEvent() {
        _amountCompleted++;
        if(IsComplete()) {
            return _points + _bonus;
        }
        else {
            return _points;
        }
    }

    public override bool IsComplete() {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString() {
        string completeMark = IsComplete() ? "X" : " ";
        return $"[{completeMark}] {_shortName} ({_points} pts each) — {_description} —— {_amountCompleted}/{_target} Completed ({_bonus} pts completion reward)";
    }

    public override string GetStringRepresentation() {
        string payload = $"2{_shortName.Length:X8}{_shortName}{_description.Length:X8}{_description}{_points:X8}{_amountCompleted:X8}{_target:X8}{_bonus:X8}";
        return $"{payload.Length:X16}{payload}";
    }
}